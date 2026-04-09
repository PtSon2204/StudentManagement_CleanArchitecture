using System.Text.Json;
using StudentManagement.MVC.Interfaces;
using StudentManagement.MVC.Models.Departments;

namespace StudentManagement.MVC.Services
{
    public class DepartmentApiService : IDepartmentApiService
    {
        private readonly HttpClient _httpClient;
        public DepartmentApiService(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("API");
        }

        public async Task Create(CreateDepartmentVm department)
        {
            await _httpClient.PostAsJsonAsync($"api/Department", department);
        }

        public async Task Delete(string id)
        {
            await _httpClient.DeleteAsync($"api/Department/{id}");
        }

        public async Task<IEnumerable<DepartmentVm>> GetAll()
        {
            var response = await _httpClient.GetAsync("api/Department");

            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<DepartmentVm>>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task<DepartmentVm> GetById(string id)
        {
            var response = await _httpClient.GetAsync($"api/Department/{id}");

            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<DepartmentVm>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task Update(string id, UpdateDepartmentVm department)
        {
            await _httpClient.PutAsJsonAsync($"api/Department/{id}", department);
        }
    }
}
