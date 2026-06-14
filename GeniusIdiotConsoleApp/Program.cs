namespace GeniusIdiotConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userName = GetUserName();
            do
            {
                var quizData = GetRandomizedQuizData();
                int correctAnswersCount = RunQuiz(quizData, userName);
                ShowQuizResults(quizData, correctAnswersCount, userName);
            } while (AskToPlayAgain());
            Console.WriteLine($"\n{userName}, cпасибо за игру!");
        }


        private static void ShowQuizResults((string Question, int Answer)[] quizData, int correctAnswersCount, string userName)
        {
            Console.WriteLine($"\nРезультат викторины:\n{GetQuizResult(quizData, correctAnswersCount, userName)}");
        }

        private static bool AskToPlayAgain()//Вопрос о новой игре
        {
            while (true)
            {
                Console.WriteLine($"Вы желаете сыграть ещё раз?");
                Console.WriteLine("Введите 'да' или 'нет'");
                Console.Write("Ваш ответ: ");
                var answer = Console.ReadLine().ToLower().Trim();
                if (answer == "да") return true;
                if (answer == "нет") return false;
                Console.WriteLine("\nЯ не понял ваш ответ. Пожалуйста, введите 'да' или 'нет'.");
            }
        }

        private static string GetUserName()//Запрос имени пользователя
        {
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

        private static (string Question, int Answer)[] GetRandomizedQuizData()//Создаём и перемешиваем вопросы
        {
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

        private static int RunQuiz((string Question, int Answer)[] quizData, string userName)//Запуск викторины
        {
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

        private static string GetQuizResult((string Question, int Answer)[] quizData, int correctAnswersCount, string userName)//Проверка результата викторины
        {
            var diagnosisCount = 5;
            var result = (correctAnswersCount * diagnosisCount) / quizData.Length;
            return result switch
            {
                0 => $"Простите, {userName}, но по результатам викторины, Вы - идиот, очень жаль!\n",
                1 => $"{userName}, Ваш результат - кретин. В этот раз хотя бы один верный ответ.\n",
                2 => $"{userName}, у Вас половина правильных ответов. Ваш результат - дурак.\n",
                3 => $"Нормальный результат, {userName} - крепкий середняк.\n",
                4 => $"Вы - талант, {userName}! Ещё шаг до идеала.\n",
                5 => $"{userName}, все ответы верны! Вы - Гений! Поздравляю!\n"
            };
        }
    }
}
