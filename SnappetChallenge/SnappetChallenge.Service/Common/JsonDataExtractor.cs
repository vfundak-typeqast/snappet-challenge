using Newtonsoft.Json;
using System.Reflection;

namespace SnappetChallenge.Service.Common
{
    public class JsonDataExtractor
    {
        public static async Task<IEnumerable<T>> LoadJsonData<T>(string filePath)
        {
            using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(filePath);
            using StreamReader sr = new(stream);
            string result = await sr.ReadToEndAsync();
            IEnumerable<T> items = JsonConvert.DeserializeObject<List<T>>(result);

            return items;
        }
    }
}