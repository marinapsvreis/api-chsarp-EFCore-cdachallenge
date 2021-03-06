using API_DOTNET.Model;
using API_DOTNET.Repository;
using API_DOTNET.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_DOTNET.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  [Authorize]
  public class StatusController : ControllerBase
  {

    private readonly IStatusRepository _repository;

    public StatusController(IStatusRepository repository)
    {
      _repository = repository;
    }

    /// <summary>
    /// Encontrando todos os Status
    /// </summary>

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var statuss = await _repository.GetStatuss();
      return statuss.Any() ? Ok(statuss) : NoContent();
    }

    /// <summary>
    /// Encontrando Status por Id
    /// </summary>

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      var status = await _repository.GetStatus(id);
      return status != null ? Ok(status) : NotFound("Status não encontrado");
    }

    /// <summary>
    /// Criando um Status
    /// </summary>

    [HttpPost]
    public async Task<IActionResult> Post(StatusViewInput statusViewInput)
    {
      Status status = new Status()
      {
        Name = statusViewInput.Name,
      };

      _repository.AddStatus(status);
      return await _repository.SaveChangesAsync() ? Ok("Status adicionado com sucesso") : BadRequest("Erro ao salvar status");
    }

    /// <summary>
    /// Alterando um Status
    /// </summary>

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Status status)
    {
      var statusBanco = await _repository.GetStatus(id);
      if (statusBanco == null) return NotFound("Status não encontrado");

      statusBanco.Name = status.Name ?? statusBanco.Name;

      _repository.UpdateStatus(statusBanco);

      return await _repository.SaveChangesAsync() ? Ok("Status atualizado com sucesso") : BadRequest("Erro ao atualizar Status");

    }

    /// <summary>
    /// Deletando um Status
    /// </summary>

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var statusBanco = await _repository.GetStatus(id);
      if (statusBanco == null) return NotFound("Status não encontrado");

      _repository.DeleteStatus(statusBanco);

      return await _repository.SaveChangesAsync() ? Ok("Status deletado com sucesso") : BadRequest("Erro ao deletar status");
    }
  }
}