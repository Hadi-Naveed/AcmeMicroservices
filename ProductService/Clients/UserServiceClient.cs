/*using ProductService.DTOs;
using System.Text.Json;

namespace ProductService.Clients
{
    public class UserServiceClient
    {
        private readonly HttpClient _http;

        public UserServiceClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<UserDto?> GetUserById(string id)
        {
            var response = await _http.GetAsync($"https://localhost:7239/api/users/{id}");

            if (!response.IsSuccessStatusCode)
                return null;
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<UserDto>(json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });


        }
    }
}
*/