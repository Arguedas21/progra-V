using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HttpClientExtensionMethods.Pages
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
    }

    public class UserModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public UserModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
        }

        public new User? User { get; private set; }  // Use 'new' to hide inherited member
        public string ResponseMessage { get; private set; } = string.Empty;

        public async Task OnGetAsync()
        {
            // Get the user information.
            User = await _httpClient.GetFromJsonAsync<User>("users/1");
            if (User != null)
            {
                Console.WriteLine($"Id: {User.Id}");
                Console.WriteLine($"Name: {User.Name}");
                Console.WriteLine($"Username: {User.Username}");
                Console.WriteLine($"Email: {User.Email}");
            }
        }

        public async Task OnPostAsync()
        {
            // Get the user information again (or this could be different in a real scenario).
            User = await _httpClient.GetFromJsonAsync<User>("users/1");
            if (User != null)
            {
                // Post a new user.
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("users", User);
                ResponseMessage = response.IsSuccessStatusCode ? "Success" : "Error";
                Console.WriteLine($"{ResponseMessage} - {response.StatusCode}");
            }
        }
    }
}
