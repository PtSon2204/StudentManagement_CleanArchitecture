using StudentManagement.MVC.Interfaces;
using StudentManagement.MVC.Models;
using System.Text.Json;

namespace StudentManagement.MVC.Services
{
    public class RoleApiService : IRoleApiService
    {
        private readonly HttpClient _httpClient;

        public RoleApiService(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("API");
        }

        public async Task<List<RoleVm>> GetAll()
        {
            var response = await _httpClient.GetAsync("api/Role");

            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<RoleVm>>(data,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<RoleVm> GetById(int id)
        {
            var response = await _httpClient.GetAsync($"api/Role/{id}");

            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<RoleVm>(data,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task Create(RoleVm role)
        {
            await _httpClient.PostAsJsonAsync("api/Role", role);
        }

        public async Task Update(int id, RoleVm role)
        {
            await _httpClient.PutAsJsonAsync($"api/Role/{id}", role);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/Role/{id}");
        }
    }
}
