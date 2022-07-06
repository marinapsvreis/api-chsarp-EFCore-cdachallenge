using System.ComponentModel.DataAnnotations;

namespace API_DOTNET.View
{
  public class CriminalCodeViewInput
  {
    [Required(ErrorMessage = "Nome do Criminal Code é obrigatório!")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Descrição do Criminal Code é obrigatório!")]
    public string Description { get; set; }
    [Required(ErrorMessage = "Penalty do Criminal Code é obrigatório!")]
    public Decimal Penalty { get; set; }
    [Required(ErrorMessage = "Prision Time do Criminal Code é obrigatório!")]
    public int PrisionTime { get; set; }
  }
}