using System.ComponentModel.DataAnnotations;

namespace FakeStore.Validations
{
  public class LoginValidation
  {
    [Required, MinLength(6), MaxLength(30)]
    public string Username { get; set; } = null!;

    [Required, MinLength(6), MaxLength(40)]
    public string Password { get; set; } = null!; 
  }
}
