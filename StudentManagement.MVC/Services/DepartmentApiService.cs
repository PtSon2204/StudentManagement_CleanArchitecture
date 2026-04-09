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

        public async Task<IEnumerable<DepartmentVm>> GetAll()
        {
            var response = await _httpClient.GetAsync("api/Department");

            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsByteArrayAsync();

            return JsonSerializer.Deserialize<IEnumerable<DepartmentVm>>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
