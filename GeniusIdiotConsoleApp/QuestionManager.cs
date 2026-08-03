using System;
using System.Collections.Generic;
using System.Linq;

namespace GeniusIdiotConsoleApp;

public class QuestionManager
{
    private readonly FileDataManager<Question> dataManager = new();
    private readonly string path = "questions.json";

    public List<Question> GetQuestions() => dataManager.Load(path);

    public List<Question> ShuffleQuestions(List<Question> questions) => questions.OrderBy(x => Guid.NewGuid()).ToList();

    public void AddNewQuestion()
    {
        Console.WriteLine("Введите, пожалуйста, новый вопрос:");
        string questionText = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(questionText) || questionText.Trim() == "0")
        {
            Console.WriteLine("Введите, пожалуйста, вопрос корректно (не пустая строка и не '0'):");
            questionText = Console.ReadLine();
        }
        int answer;
        bool isValid;
        do
        {
            Console.Write("Введите правильный ответ (только число): ");
            isValid = int.TryParse(Console.ReadLine(), out answer);
            if (!isValid)
            {
                Console.WriteLine("Ответ должен быть целым числом. Попробуйте ещё раз.");
            }
        } while (!isValid);
        var newQuestion = new Question(questionText, answer);
        var updatedList = dataManager.Add(path, newQuestion);
        Console.WriteLine($"Вопрос успешно добавлен! Теперь в базе {updatedList.Count} вопросов.");
    }
    
    public void DeleteQuestion()
    {
        var questions = GetQuestions(); // Загружаем актуальные данные
        if (questions.Count == 0)
        {
            Console.WriteLine("Список вопросов пуст. Нечего удалять.");
            return;
        }
        Console.WriteLine("\n=== Список вопросов ===");
        for (int i = 0; i < questions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {questions[i].QuizQuestion}");
        }
        Console.WriteLine("========================\n");
        int questionNumber;
        while (true)
        {
            Console.Write("Введите номер вопроса для удаления (0 для отмены): ");
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Ошибка: ввод не может быть пустым. Попробуйте снова.\n");
                continue;
            }
            if (!int.TryParse(input, out questionNumber))
            {
                Console.WriteLine("Ошибка: введите корректное целое число.\n");
                continue;
            }
            if (questionNumber == 0)
            {
                Console.WriteLine("Удаление отменено.");
                return;
            }
            if (questionNumber < 1 || questionNumber > questions.Count)
            {
                Console.WriteLine($"Ошибка: введите число от 1 до {questions.Count} или 0 для отмены.\n");
                continue;
            }
            break;
        }
        Question targetQuestion = questions[questionNumber - 1];
        Console.Write($"Вы действительно хотите удалить вопрос \"{targetQuestion.QuizQuestion}\"? (да/нет): ");
        string confirmation = Console.ReadLine()?.Trim().ToLower();
        if (confirmation == "да" || confirmation == "yes" || confirmation == "y")
        {
            questions.RemoveAt(questionNumber - 1);
            dataManager.Save(path, questions);
            Console.WriteLine("Список вопросов обновлён.");
        }
        else
        {
            Console.WriteLine("Удаление отменено пользователем.");
        }
    }
}