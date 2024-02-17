using System.Net.Http.Json;
using FakeStore.Validations;

namespace FakeStore.Service
{
  class TokenResponse
  {
    public string Token { get; set; } = null!;
  }
  public interface IAuthService
  {
    public Task<string?> Login(LoginValidation model);
  }

  public class AuthService(HttpClient http) : IAuthService
  {
    public async Task<string?> Login(LoginValidation model)
    {
      try
      {
        var response = await http.PostAsJsonAsync("https://fakestoreapi.com/auth/login", model, default);
        var data = await response.Content.ReadFromJsonAsync<TokenResponse>();
        return data?.Token;
      } catch {
        return null;
      }
    }
  }
}