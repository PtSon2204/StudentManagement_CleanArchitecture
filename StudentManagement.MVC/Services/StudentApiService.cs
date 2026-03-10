using System.Text.Json;
using StudentManagement.MVC.Interfaces;
using StudentManagement.MVC.Models;

namespace StudentManagement.MVC.Services
{
    public class StudentApiService : IStudentApiService
    {
        private readonly HttpClient _httpClient;

        public StudentApiService(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("API");
        }

        public async Task Create(StudentVm student)
        {
            await _httpClient.PostAsJsonAsync("api/Student", student);
        }

        public async Task DeleteStudent(int id)
        {
            await _httpClient.DeleteAsync($"api/Student/{id}");
        }

        public Task<List<StudentVm>> FilterStudents(string? name, bool? gender, DateTime? dob, double? gpa, string? dept)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StudentVm>> GetAllStudentsAsync()
        {
            var response = await _httpClient.GetAsync("api/Student");

            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();

            var students = JsonSerializer.Deserialize<List<StudentVm>>(data,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return students;
        }

        public async Task<StudentVm> GetStudentById(int id)
        {
            var response = await _httpClient.GetAsync($"api/Student/{id}");

            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<StudentVm>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task Update(int id, StudentVm student)
        {
            await _httpClient.PutAsJsonAsync($"api/Student/{id}", student);
        }
    }
}
