using L1_1.DataObject;
using System.Text.Json;

namespace L1_1.Client
{
    internal class Client <T> where T : ContentDTO
    {
        readonly HttpClient client = new HttpClient();

        // Функция для получения контента по URL
        public async Task<T> GetContentAsync(string url)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }
        }

        // Функция для получения контента по URL + id
        public async Task<T> GetContentByIdAsync(string url, int id) => await GetContentAsync(url + $"{id}");

        // Функция для получения контента по URL в промежутке id
        public List<T> GetContentByAnyIdAsync(string url, int id1, int id2)
        {
            List<Task<T>> tasklist = new List<Task<T>>();
            List<T> result = new List<T>();
            for (int i = id1; i <= id2; i++)
            {
                tasklist.Add(GetContentByIdAsync(url, i));
            }
            Task.WaitAll(tasklist.ToArray());
            tasklist.ForEach(t => result.Add(t.Result));
            return result;
        }
    }
}
