namespace GeniusIdiotConsoleApp;

public class QuestionManager
{
    private readonly FileDataManager<Question> dataManager = new();
    private readonly string path = "questions.json";

    public List<Question> GetQuestions() => dataManager.Load(path);

    public List<Question> ShuffleQuestions(List<Question> questions) => questions.OrderBy(x => Guid.NewGuid()).ToList();

    public void AddNewQuestion()
    {
        Console.WriteLine("Введите, пожалуйста, новый вопрос");
        string question = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(question))
        {
            Console.WriteLine("Введите, пожалуйста, вопрос корректно");
            question = Console.ReadLine();
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
        var newQuestion = new Question(question, answer);
        var updatedList = dataManager.Add(path, newQuestion);
        Console.WriteLine($"Вопрос успешно добавлен! Теперь в базе {updatedList.Count} вопросов.");
    }
}