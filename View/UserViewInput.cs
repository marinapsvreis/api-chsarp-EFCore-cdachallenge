using System.ComponentModel.DataAnnotations;

namespace API_DOTNET.View
{
  public class UserViewInput
  {
    [Required(ErrorMessage = "Username é obrigatório!")]
    public string UserName { get; set; }
    [Required(ErrorMessage = "Password é obrigatório!")]
    public string Password { get; set; }
  }
}