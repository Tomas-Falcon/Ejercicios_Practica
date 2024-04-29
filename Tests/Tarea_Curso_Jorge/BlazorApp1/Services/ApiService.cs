namespace BlazorApp1
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
            
            var urlApi = Environment.GetEnvironmentVariable("URLAPI");
            _httpClient.BaseAddress = new Uri(urlApi);
        }

        ~ApiService() { _httpClient.Dispose(); }

        public async Task<List<Games>> GetDataAsync(string endpoint)
        {
            return await _httpClient.GetFromJsonAsync<List<Games>>($"{endpoint}");
        }

        public async Task<List<Games>> GetDataAsync(string endpoint, string nombre)
        {
            return await _httpClient.GetFromJsonAsync<List<Games>>($"{endpoint}?name={nombre}");
        }

        public async Task<HttpResponseMessage> Delete(string endpoint, string id)
        {
            return await _httpClient.DeleteAsync($"{endpoint}?id={id}");
        }

        public async Task<HttpResponseMessage> InsertGameAsync(string titulo, int puntuacion, float precio)
        {
            return await _httpClient.PostAsJsonAsync($"InsertGame?titulo={titulo}&puntuacion={puntuacion}&precio={precio}", new { });
        }

        public async Task<HttpResponseMessage> EditGameAsync(int id, string titulo, int puntuacion, float precio)
        {
            return await _httpClient.PutAsJsonAsync($"Edit?id={id}&titulo={titulo}&puntuacion={puntuacion}&precio={precio}", new { });
        }
    }

}
