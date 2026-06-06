namespace GeniusIdiotConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var quizData = InitQuizData();
            var randomQuizData = quizData.OrderBy(x => Guid.NewGuid()).ToArray();
            int correctAnswersCount = RunQuiz(randomQuizData);
            Console.WriteLine($"Количество правильных ответов: {correctAnswersCount}");
        }

        private static (string Question, int Answer)[] InitQuizData()
        {
            var quizData = new (string Question, int Answer)[]
            {
                ("Сколько будет 2 плюс 2, умноженное на 2?", 6),
                ("Бревно нужно распилить на 10 частей. Сколько надо сделать распилов?", 9),
                ("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25),
                ("Укол делают каждые полчаса. Сколько нужно минут для трех уколов?", 60),
                ("5 свечей горело, 2 потухли. Сколько свечей осталось?", 2)
            };
            return quizData;
        }

        private static int RunQuiz((string Question, int Answer)[] quizData)
        {
            int correctAnswersCount = 0;
            foreach (var quiz in quizData)
            {
                Console.WriteLine(quiz.Question);
                Console.Write("Ваш ответ: ");
                int userAnswer = int.Parse(Console.ReadLine());
                if (userAnswer == quiz.Answer) correctAnswersCount++;
            }
            return correctAnswersCount;
        }
    }
}
