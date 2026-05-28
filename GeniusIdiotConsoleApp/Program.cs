namespace GeniusIdiotConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //вопросы
            string[] questions = new string[5];
            questions[0] = "Сколько будет 2 плюс 2, умноженное на 2?";
            questions[1] = "Бревно нужно распилить на 10 частей. Сколько надо сделать распилов?";
            questions[2] = "На двух руках 10 пальцев. Сколько пальцев на 5 руках?";
            questions[3] = "Укол делают каждые полчаса. Сколько нужно минут для трех уколов?";
            questions[4] = "5 свечей горело, 2 потухли. Сколько свечей осталось?";

            //ответы
            int[] answers = new int[5];
            answers[0] = 6;   // Для первого вопроса
            answers[1] = 9;   // Для второго
            answers[2] = 25;  // Для третьего
            answers[3] = 60;  // Для четвертого
            answers[4] = 2;   // Для пятого

            int correctAnswersCount = 0;

            for (int i = 0; i < questions.Length - 1; i++)
            {
                Console.WriteLine(questions[i]);
                Console.Write("Ваш ответ: ");
                int userAnswer = int.Parse(Console.ReadLine());
                if (userAnswer == answers[i]) correctAnswersCount++;
            }

            Console.WriteLine($"Количество правильных ответов: {correctAnswersCount}");
        }
    }
}
