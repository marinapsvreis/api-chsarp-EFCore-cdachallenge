using API_DOTNET.Model;
using API_DOTNET.Repository;
using API_DOTNET.View;
using Microsoft.AspNetCore.Mvc;

namespace API_DOTNET.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class DisableCriminalCodeController : ControllerBase
  {

    private readonly ICriminalCodeRepository _repository;

    public DisableCriminalCodeController(ICriminalCodeRepository repository)
    {
      _repository = repository;
    }

    /// <summary>
    /// Alterando o status do Criminal Code para Ativo
    /// </summary>

    [HttpPut("{idCriminalCode}")]
    public async Task<IActionResult> PutDisable(int idCriminalCode, int userId)
    {
      var criminalCodeBanco = await _repository.GetCriminalCode(idCriminalCode);
      if (criminalCodeBanco == null) return NotFound("CriminalCode não encontrado");

      criminalCodeBanco.StatusId = 2;
      criminalCodeBanco.UpdateUserId = userId;

      _repository.UpdateCriminalCode(criminalCodeBanco);

      return await _repository.SaveChangesAsync() ? Ok("CriminalCode desabilitado com sucesso") : BadRequest("Erro ao desabilitar CriminalCode");
    }
  }
}