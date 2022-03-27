using L1_1.DataObject;
using System.Text.Json;

namespace L1_1.Client
{
    internal class Client <T> where T : ContentDTO
    {
        // Функция для получения контента по URL
        public async Task<T> GetContentAsync(string url, CancellationToken token)
        {
            try
            {
                using HttpClient client = new HttpClient();
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
        public async Task<T> GetContentByIdAsync(string url, int id, CancellationToken token) => await GetContentAsync(url + $"{id}", token);

        // Функция для получения контента по URL в промежутке id
        public List<T> GetContentByAnyIdAsync(string url, int id1, int id2, CancellationToken token)
        {
            List<Task<T>> tasklist = new List<Task<T>>();
            List<T> result = new List<T>();
            for (int i = id1; i <= id2; i++)
            {
                tasklist.Add(GetContentByIdAsync(url, i, token));
            }
            Task.WaitAll(tasklist.ToArray());
            tasklist.ForEach(t => result.Add(t.Result));
            return result;
        }
    }
}
