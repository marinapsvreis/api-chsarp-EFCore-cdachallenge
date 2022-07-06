using System.ComponentModel.DataAnnotations;

namespace API_DOTNET.View
{
  public class StatusViewInput
  {
    [Required(ErrorMessage = "Nome do Status é obrigatório!")]
    public string Name { get; set; }
  }
}