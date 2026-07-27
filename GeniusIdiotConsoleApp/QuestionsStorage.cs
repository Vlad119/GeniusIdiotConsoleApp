namespace GeniusIdiotConsoleApp;

public class QuestionsStorage
{
    private readonly FileRepository<Question> _repository = new();
    private readonly string path = "questions.json"; 
    
    public List<Question> GetQuestions() => this._repository.Load(path);
    
    public List<Question> ShuffleQuestions(List<Question> questions) => questions.OrderBy(x => Guid.NewGuid()).ToList();
   
}