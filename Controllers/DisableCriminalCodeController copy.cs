using API_DOTNET.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API_DOTNET.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class EnableCriminalCodeController : ControllerBase
  {

    private readonly ICriminalCodeRepository _repository;

    public EnableCriminalCodeController(ICriminalCodeRepository repository)
    {
      _repository = repository;
    }

    /// <summary>
    /// Alterando o Status do Criminal Code para Inativo
    /// </summary>

    [HttpPut("{idCriminalCode}")]
    public async Task<IActionResult> PutDisable(int idCriminalCode, int userId)
    {
      var criminalCodeBanco = await _repository.GetCriminalCode(idCriminalCode);
      if (criminalCodeBanco == null) return NotFound("CriminalCode não encontrado");

      criminalCodeBanco.StatusId = 1;
      criminalCodeBanco.UpdateUserId = userId;

      _repository.UpdateCriminalCode(criminalCodeBanco);

      return await _repository.SaveChangesAsync() ? Ok("CriminalCode desabilitado com sucesso") : BadRequest("Erro ao desabilitar CriminalCode");
    }
  }
}