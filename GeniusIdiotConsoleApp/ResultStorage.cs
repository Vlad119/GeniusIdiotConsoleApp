namespace GeniusIdiotConsoleApp;

public class ResultStorage
{
    private readonly FileRepository<GameResult> repository = new();
    private readonly string path;

    public ResultStorage(string path) => this.path = path;
    
    public List<GameResult> Load() => repository.Load(path);
    
    public void Save(List<GameResult> results) => repository.Save(path, results);
    
    public void Add(GameResult result) => repository.Add(path, result);
    
}