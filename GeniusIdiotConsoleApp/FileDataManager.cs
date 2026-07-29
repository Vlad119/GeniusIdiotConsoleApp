using System.Text.Json;

namespace GeniusIdiotConsoleApp;

public class  FileDataManager<T>
{
   public void Save(string path, List<T> data)
   {
      var options = new JsonSerializerOptions
      {
         WriteIndented = true,
         Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
      };
      string json = JsonSerializer.Serialize(data, options);
      File.WriteAllText(path, json);
   }
   
   public List<T> Load(string path)
   {
      if (!File.Exists(path))
      {
         return new List<T>();
      }
      string json = File.ReadAllText(path);
      List<T> results = JsonSerializer.Deserialize<List<T>>(json);
      return results ?? new List<T>();
   }

   public List<T> Add(string path, T data)
   {
      List<T> items = Load(path);
      items.Add(data);
      Save(path, items);
      return items;
   }
}