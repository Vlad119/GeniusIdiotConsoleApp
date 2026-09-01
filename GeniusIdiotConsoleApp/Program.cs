using GeniusIdiot.Core.Managers;
using GeniusIdiot.Core.Models;

namespace GeniusIdiotConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        var resultManager = new ResultManager("results.json");
        var allResults = resultManager.Load();
        var questionManager = new QuestionManager();
        GetApplicationMode(questionManager);
        var userName = GetUserName();
        do
        {
            Console.WriteLine("\nПоехали! Отвечайте на вопросы ТОЛЬКО цифрами:");
            var quizData = questionManager.ShuffleQuestions(questionManager.GetQuestions());
            if (quizData.Count == 0)
            {
                Console.WriteLine("Вопросы закончились! Добавьте новые вопросы в главном меню.");
                break;
            }
            int correctAnswersCount = RunQuiz(quizData, userName);
            string shortDiagnosis = GetShortDiagnosis(quizData, correctAnswersCount);
            ShowQuizResults(shortDiagnosis, userName);
            var newResult = new GameResult(userName, correctAnswersCount, shortDiagnosis, DateTime.Now);
            resultManager.Add(newResult);
        } while (AskToPlayAgain());
        Console.WriteLine($"\n{userName}, спасибо за игру!");
        HistoryAsk(allResults);
    }

    private static void GetApplicationMode(QuestionManager questionManager)
    {
        while (true)
        {
            Console.WriteLine("\n=== Главное меню ===");
            Console.WriteLine("1. Начать игру");
            Console.WriteLine("2. Добавить новый вопрос");
            Console.WriteLine("3. Удалить вопрос");
            Console.Write("Ваш выбор: ");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2 && choice != 3))
            {
                Console.WriteLine("Пожалуйста, введите 1, 2 или 3.");
                Console.Write("Ваш выбор: ");
            }
            if (choice == 1)
            {
                break; // Выходим из меню и идём играть!
            }
            if (choice == 2)
            {
                string addMore;
                do
                {
                    questionManager.AddNewQuestion();
                    Console.WriteLine("Хотите добавить ещё один вопрос? (да/нет)");
                    addMore = Console.ReadLine()?.ToLower().Trim();
                } while (addMore == "да" || addMore == "д" || addMore == "yes" || addMore == "y");
            }
            if (choice == 3)
            {
                questionManager.DeleteQuestion();
            }
        }
    }

    private static void HistoryAsk(List<GameResult> allResults)
    {
        Console.Write("Хотите посмотреть историю всех игр? (да/нет) (yes/no): ");
        while (true)
        {
            var answer = Console.ReadLine()?.ToLower().Trim();
            if (answer == "да" || answer == "д" || answer == "yes" || answer == "y")
            {
                DisplayHistoryTable(allResults);
                return;
            }
            if (answer == "нет" || answer == "н" || answer == "no" || answer == "n") return;
            Console.WriteLine("Я не понял ваш ответ. Пожалуйста, введите (да/нет) (yes/no).");
        }
    }

    private static string GetShortDiagnosis(List<Question> quizData, int correctAnswersCount)
    {
        const int MaxScore = 5;
        var result = (correctAnswersCount * MaxScore) / quizData.Count;
        return result switch
        {
            0 => "Идиот",
            1 => "Кретин",
            2 => "Дурак",
            3 => "Крепкий середняк",
            4 => "Талант",
            5 => "Гений",
            _ => "Неизвестный результат"
        };
    }

    private static void ShowQuizResults(string shortDiagnosis, string userName)
    {
        string fullMessage = shortDiagnosis switch
        {
            "Идиот" => $"Простите, {userName}, но по результатам викторины, Вы - {shortDiagnosis}, очень жаль!",
            "Кретин" => $"{userName}, Ваш результат - {shortDiagnosis}. В этот раз хотя бы один верный ответ.",
            "Дурак" => $"{userName}, у Вас половина правильных ответов. Ваш результат - {shortDiagnosis}.",
            "Крепкий середняк" => $"Нормальный результат, {userName} - {shortDiagnosis}.",
            "Талант" => $"Вы - {shortDiagnosis}, {userName}! Ещё шаг до идеала.",
            "Гений" => $"{userName}, все ответы верны! Вы - {shortDiagnosis}! Поздравляю!",
            _ => "Неизвестный результат"
        };
        Console.WriteLine($"\nРезультат викторины:\n{fullMessage}");
    }

    private static bool AskToPlayAgain()
    {
        while (true)
        {
            Console.WriteLine("\nВы желаете сыграть ещё раз? (да/нет) (yes/no)");
            Console.Write("Ваш ответ: ");
            var answer = Console.ReadLine()?.ToLower().Trim();
            if (answer == "да" || answer == "д" || answer == "yes" || answer == "y") return true;
            if (answer == "нет" || answer == "н" || answer == "no" || answer == "n") return false;
            Console.WriteLine("Я не понял ваш ответ. Пожалуйста, введите (да/нет) (yes/no).");
        }
    }

    private static string GetUserName()
    {
        Console.WriteLine("Приветствую! Введите, пожалуйста, Ваше имя");
        Console.Write("Меня зовут: ");
        var userName = Console.ReadLine();
        var user = new User(userName);
        Console.WriteLine($"\nСпасибо, {user.Name}, теперь мы можем начать викторину");
        return user.Name;
    }

    private static int RunQuiz(List<Question> quizData, string userName)
    {
        int correctAnswersCount = 0;
        foreach (var question in quizData)
        {
            Console.WriteLine(question.QuizQuestion);
            Console.Write("Ваш ответ: ");
            int userAnswer;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out userAnswer))
                {
                    break;
                }
                Console.Write($"{userName}, введите, пожалуйста, только число: ");
            }
            if (question.CheckCorrectAnswer(userAnswer))
            {
                correctAnswersCount++;
            }
        }
        return correctAnswersCount;
    }

    private static void DisplayHistoryTable(List<GameResult> results)
    {
        Console.WriteLine("\n=== История результатов ===");
        if (results == null || results.Count == 0)
        {
            Console.WriteLine("История пуста. Сыграйте хотя бы одну игру, чтобы увидеть результаты здесь!");
            return;
        }
        Console.WriteLine($"{"Имя игрока",-25} | {"Правильных ответов",-18} | {"Диагноз",-30} | {"Дата",-20}");
        Console.WriteLine(new string('-', 105));
        foreach (var result in results)
        {
            Console.WriteLine(
                $"{result.UserName,-25} | {result.CorrectAnswers,-18} | {result.Diagnosis,-30} | {result.Date,-20:dd.MM.yyyy HH:mm}");
        }
        Console.WriteLine(new string('-', 105));
        Console.WriteLine();
    }
}