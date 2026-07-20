using System.Text.Encodings.Web;
using System.Text.Json;

namespace GeniusIdiotConsoleApp
{
    internal class ResultStorage
    {
        public string Path { get; init; }

        public ResultStorage(string path)
        {
            Path = path;
        }

        public List<GameResult> Load()
        {
            if (!File.Exists(Path))
            {
                // Если файла нет, то возвращаем пустой список
                return new List<GameResult>();
            }
            try
            {
                //читаем в строку
                string json = File.ReadAllText(Path);
                // Десериализуем JSON в список GameResult
                List<GameResult> results = JsonSerializer.Deserialize<List<GameResult>>(json);
                // Если файл пустой, то возвращаем пустой список
                return results ?? new List<GameResult>();
            }
            catch (Exception ex)
            {
                // Если файл повреждён или произошла другая ошибка — логируем и возвращаем пустой список
                Console.WriteLine($"Ошибка при загрузке результатов: {ex.Message}");
                return new List<GameResult>();
            }
        }

        public void Save(List<GameResult> results)
        {
            try
            {
                // Настраиваем параметры для красивого форматирования
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };
                // Сериализуем список в JSON строку
                string json = JsonSerializer.Serialize(results, options);
                // Записываем JSON в файл (перезаписываем весь файл)
                File.WriteAllText(Path, json);
            }
            catch (Exception ex)
            {
                // Если произошла ошибка записи — логируем
                Console.WriteLine($"Ошибка при сохранении результатов: {ex.Message}");
            }
        }
    }
}
