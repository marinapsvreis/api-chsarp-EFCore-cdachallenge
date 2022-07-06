using System.ComponentModel.DataAnnotations;

namespace API_DOTNET.View
{
  public class LoginViewInput
  {
    [Required(ErrorMessage = "O username é obrigatório")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória")]
    public string Password { get; set; }

  }
}