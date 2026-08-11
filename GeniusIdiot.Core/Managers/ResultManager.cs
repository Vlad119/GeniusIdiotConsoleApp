using GeniusIdiot.Core.Models;

namespace GeniusIdiot.Core.Managers;

public class ResultManager
{
    private readonly FileDataManager<GameResult> dataManager = new();
    private readonly string path;

    public ResultManager(string path) => this.path = path;
    
    public List<GameResult> Load() => dataManager.Load(path);
    
    public void Save(List<GameResult> results) => dataManager.Save(path, results);
    
    public void Add(GameResult result) => dataManager.Add(path, result);
    
}