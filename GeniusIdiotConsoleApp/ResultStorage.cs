using System.Text.Encodings.Web;
using System.Text.Json;

namespace GeniusIdiotConsoleApp
{
    internal class ResultStorage
    {
        public string Path { get; init; }
        public ResultStorage(string path) => Path = path;

        public List<GameResult> Load()
        {
            if (!File.Exists(Path)) return new List<GameResult>();
            try
            {
                string json = File.ReadAllText(Path);
                List<GameResult> results = JsonSerializer.Deserialize<List<GameResult>>(json);
                return results ?? new List<GameResult>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке результатов: {ex.Message}");
                return new List<GameResult>();
            }
        }

        public void Save(List<GameResult> results)
        {
            try
            {
                // параметры для красивого форматирования
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };
                string json = JsonSerializer.Serialize(results, options);
                File.WriteAllText(Path, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении результатов: {ex.Message}");
            }
        }
    }
}
