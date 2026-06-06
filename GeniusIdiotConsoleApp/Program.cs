namespace GeniusIdiotConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userName = GetUserName();
            var quizData = GetRandomizedQuizData();
            int correctAnswersCount = RunQuiz(quizData, userName);
            Console.WriteLine($"{userName}, результат викторины: Вы {GetQuizResult(correctAnswersCount, userName)}");
        }

        private static string GetUserName()//Запрос имени пользователя
        {
            Console.WriteLine("Приветствую! Введите, пожалуйста, Ваше имя");
            var userName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userName))
            {
                userName = "Хитрюга";
            }
            Console.WriteLine($"Спасибо, {userName}, теперь мы можем начать викторину\n");
            return userName;
        }

        private static (string Question, int Answer)[] GetRandomizedQuizData()//Создаём и перемешиваем вопросы
        {
            var quizData = new (string Question, int Answer)[]
            {
                ("Сколько будет 2 плюс 2, умноженное на 2?", 6),
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
                if (userAnswer == quiz.Answer)
                {
                    correctAnswersCount++;
                }
            }
            return correctAnswersCount;
        }

        private static string GetQuizResult(int count, string userName)//Проверка результата викторины
        {
            return count switch
            {
                0 => $"Простите, {userName}, но по результатам викторины, Вы - идиот, очень жаль!",
                1 => $"{userName}, Ваш результат - кретин. В этот раз хотя бы один верный ответ.",
                2 => $"{userName}, половина правильных ответов. Ваш результат - дурак.",
                3 => $"Нормальный результат, {userName}, Вы - крепкий середняк.",
                4 => $"{userName}, отличный результат! Ещё шаг до идеала. Вы - талант!",
                5 => $"{userName}, все ответы верны! Ты - Гений! Поздравляю!"
            };
        }
    }
}
