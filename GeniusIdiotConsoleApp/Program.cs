namespace GeniusIdiotConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] questions = GetQuestions();
            int[] answers = GetAnswers();
            int correctAnswersCount = RunQuiz(questions, answers);
            Console.WriteLine($"Количество правильных ответов: {correctAnswersCount}");
        }

        private static int RunQuiz(string[] questions, int[] answers)
        {
            int correctAnswersCount = 0;
            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine(questions[i]);
                Console.Write("Ваш ответ: ");
                int userAnswer = int.Parse(Console.ReadLine());
                if (userAnswer == answers[i]) correctAnswersCount++;
            }
            return correctAnswersCount;
        }

        private static int[] GetAnswers()
        {
            int[] answers = [6, 9, 25, 60, 2];
            return answers;
        }

        private static string[] GetQuestions()
        {
            string[] questions =
            [
                "Сколько будет 2 плюс 2, умноженное на 2?",
                "Бревно нужно распилить на 10 частей. Сколько надо сделать распилов?",
                "На двух руках 10 пальцев. Сколько пальцев на 5 руках?",
                "Укол делают каждые полчаса. Сколько нужно минут для трех уколов?",
                "5 свечей горело, 2 потухли. Сколько свечей осталось?",
            ];
            return questions;
        }
    }
}
