namespace GeniusIdiotConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Инициализируем хранилище (файл будет в папке с программой)
            var storage = new ResultStorage("results.json");
            // 2. Загружаем существующую историю (или получаем пустой список)
            List<GameResult> allResults = storage.Load();
            var userName = GetUserName();
            do
            {
                var quizData = GetRandomizedQuizData();
                int correctAnswersCount = RunQuiz(quizData, userName);
                // 3. Получаем ТОЛЬКО короткий диагноз для сохранения в историю
                string shortDiagnosis = GetShortDiagnosis(quizData, correctAnswersCount);
                // 4. Показываем результат (метод сам сформирует красивую фразу с именем)
                ShowQuizResults(shortDiagnosis, userName);
                // 5. Создаем новую запись и добавляем в общий список
                var newResult = new GameResult(userName, correctAnswersCount, shortDiagnosis, DateTime.Now);
                allResults.Add(newResult);
                // 6. Сохраняем обновленный список в файл
                storage.Save(allResults);
            } while (AskToPlayAgain());
            Console.WriteLine($"\n{userName}, спасибо за игру!");
            // Спрашиваем про историю после выхода из цикла
            HistoryAsk(allResults);
        }

        private static void HistoryAsk(List<GameResult> allResults)
        {
            Console.Write("Хотите посмотреть историю всех игр? (да/нет): ");
            var answer = Console.ReadLine()?.ToLower().Trim();
            if (answer == "да" || answer == "yes" || answer == "д")
            {
                DisplayHistoryTable(allResults);
            }
        }

        private static string GetShortDiagnosis((string Question, int Answer)[] quizData, int correctAnswersCount)
        {
            // Вычисление короткого диагноза для сохранения в БД/файл
            var diagnosisCount = 5;
            var result = (correctAnswersCount * diagnosisCount) / quizData.Length;
            return result switch
            {
                0 => "Идиот",
                1 => "Кретин",
                2 => "Дурак",
                3 => "Крепкий середняк",
                4 => "Талант",
                5 => "Гений"
            };
        }

        private static void ShowQuizResults(string shortDiagnosis, string userName)
        {
            // Формирование полной фразы для вывода в консоль на основе короткого диагноза
            string fullMessage = shortDiagnosis switch
            {
                "Идиот" => $"Простите, {userName}, но по результатам викторины, Вы - {shortDiagnosis}, очень жаль!",
                "Кретин" => $"{userName}, Ваш результат - {shortDiagnosis}. В этот раз хотя бы один верный ответ.",
                "Дурак" => $"{userName}, у Вас половина правильных ответов. Ваш результат - {shortDiagnosis}.",
                "Крепкий середняк" => $"Нормальный результат, {userName} - {shortDiagnosis}.",
                "Талант" => $"Вы - {shortDiagnosis}, {userName}! Ещё шаг до идеала.",
                "Гений" => $"{userName}, все ответы верны! Вы - {shortDiagnosis}! Поздравляю!",
                _ => $"Неизвестный результат"
            };
            Console.WriteLine($"\nРезультат викторины:\n{fullMessage}");
        }

        private static bool AskToPlayAgain()
        {
            // Вопрос о новой игре
            while (true)
            {
                Console.WriteLine("\nВы желаете сыграть ещё раз?");
                Console.WriteLine("Введите 'да' или 'нет'");
                Console.Write("Ваш ответ: ");
                var answer = Console.ReadLine().ToLower().Trim();
                if (answer == "да") return true;
                if (answer == "нет") return false;
                Console.WriteLine("Я не понял ваш ответ. Пожалуйста, введите 'да' или 'нет'.");
            }
        }

        private static string GetUserName()
        {
            // Запрос имени пользователя
            Console.WriteLine("Приветствую! Введите, пожалуйста, Ваше имя");
            Console.Write("Меня зовут: ");
            var userName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userName))
            {
                userName = "Хитрюга";
            }
            Console.WriteLine($"\nСпасибо, {userName}, теперь мы можем начать викторину");
            return userName;
        }

        private static (string Question, int Answer)[] GetRandomizedQuizData()
        {
            // Создаём и перемешиваем вопросы
            Console.WriteLine("\nПоехали! Отвечайте на вопросы ТОЛЬКО цифрами:");
            var quizData = new (string Question, int Answer)[]
            {
                ("Сколько будет 2 + 2 * 2?", 6),
                ("Бревно нужно распилить на 10 частей. Сколько надо сделать распилов?", 9),
                ("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25),
                ("Укол делают каждые полчаса. Сколько нужно минут для трех уколов?", 60),
                ("5 свечей горело, 2 потухли. Сколько свечей осталось?", 2),
                ("Сколько будет 2 + 2 * 2?", 6),
                ("Бревно нужно распилить на 10 частей. Сколько надо сделать распилов?", 9),
                ("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25),
                ("Укол делают каждые полчаса. Сколько нужно минут для трех уколов?", 60),
                ("5 свечей горело, 2 потухли. Сколько свечей осталось?", 2)
            };
            return quizData.OrderBy(x => Guid.NewGuid()).ToArray();
        }

        private static int RunQuiz((string Question, int Answer)[] quizData, string userName)
        {
            // Запуск викторины
            int correctAnswersCount = 0;
            foreach (var quiz in quizData)
            {
                Console.WriteLine(quiz.Question);
                Console.Write("Ваш ответ: ");
                int userAnswer;
                while (!int.TryParse(Console.ReadLine(), out userAnswer))
                {
                    Console.Write($"{userName}, введите, пожалуйста, только число: ");
                }
                if (userAnswer == quiz.Answer) correctAnswersCount++;
            }
            return correctAnswersCount;
        }

        private static void DisplayHistoryTable(List<GameResult> results)
        {
            Console.WriteLine("\n=== История результатов ===");
            // 1. Проверка на пустоту
            if (results == null || results.Count == 0)
            {
                Console.WriteLine("История пуста. Сыграйте хотя бы одну игру, чтобы увидеть результаты здесь!");
                return;
            }
            // 2. Вывод заголовков таблицы (ширины: 25 + 18 + 30 + 20 = 93 + разделители = ~105)
            Console.WriteLine($"{"Имя игрока",-25} | {"Правильных ответов",-18} | {"Диагноз",-30} | {"Дата",-20}");
            // 3. Вывод разделительной линии
            Console.WriteLine(new string('-', 105));
            // 4. Вывод каждой записи (дата форматируется в короткий вид, чтобы не ломать столбец)
            foreach (var result in results)
            {
                Console.WriteLine($"{result.UserName,-25} | {result.CorrectAnswers,-18} | {result.Diagnosis,-30} | {result.Date:dd.MM.yyyy HH:mm, -20}");
            }
            // 5. Нижняя разделительная линия
            Console.WriteLine(new string('-', 105));
            Console.WriteLine();
        }
    }
}