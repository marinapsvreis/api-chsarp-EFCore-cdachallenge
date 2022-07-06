using API_DOTNET.Data;
using API_DOTNET.Model;
using API_DOTNET.Repository;
using API_DOTNET.View;
using Microsoft.AspNetCore.Mvc;

namespace API_DOTNET.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CriminalCodeController : ControllerBase
  {

    private readonly ICriminalCodeRepository _repository;

    public CriminalCodeController(ICriminalCodeRepository repository)
    {
      _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var criminalCodes = await _repository.GetCriminalCodes();
      List<CriminalCodeViewOutput> listCriminalCodes = new List<CriminalCodeViewOutput>();
      foreach (CriminalCode criminalCode in criminalCodes)
      {
        CriminalCodeViewOutput criminalCodeViewOutput = new CriminalCodeViewOutput()
        {
          CriminalCodeId = criminalCode.Id,
          Name = criminalCode.Name,
          Description = criminalCode.Description,
          Penalty = criminalCode.Penalty,
          PrisionTime = criminalCode.PrisionTime,
          StatusId = criminalCode.StatusId,
          CreateDate = criminalCode.CreateDate,
          UpdateDate = criminalCode.UpdateDate,
          CreateUserId = criminalCode.CreateUserId,
          UpdateUserId = criminalCode.UpdateUserId
        };

        listCriminalCodes.Add(criminalCodeViewOutput);
      }
      return criminalCodes.Any() ? Ok(listCriminalCodes) : NoContent();
    }

    // Implementação da Paginação Pendente
    // [HttpGet]
    // public async Task<IActionResult> Get()
    // {
    //   var criminalCodes = await _repository.GetCriminalCodes();
    //   List<CriminalCodeViewOutput> listCriminalCodes = new List<CriminalCodeViewOutput>();
    //   foreach (CriminalCode criminalCode in criminalCodes)
    //   {
    //     CriminalCodeViewOutput criminalCodeViewOutput = new CriminalCodeViewOutput()
    //     {
    //       CriminalCodeId = criminalCode.CriminalCodeId,
    //       Name = criminalCode.Name,
    //       Description = criminalCode.Description,
    //       Penalty = criminalCode.Penalty,
    //       PrisionTime = criminalCode.PrisionTime,
    //       StatusId = criminalCode.StatusId,
    //       CreateDate = criminalCode.CreateDate,
    //       UpdateDate = criminalCode.UpdateDate,
    //       CreateUserId = criminalCode.CreateUserId,
    //       UpdateUserId = criminalCode.UpdateUserId
    //     };

    //     listCriminalCodes.Add(criminalCodeViewOutput);
    //   }
    //   return criminalCodes.Any() ? Ok(listCriminalCodes) : NoContent();
    // }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      var criminalCode = await _repository.GetCriminalCode(id);

      CriminalCodeViewOutput criminalCodeViewOutput = new CriminalCodeViewOutput()
      {
        CriminalCodeId = criminalCode.Id,
        Name = criminalCode.Name,
        Description = criminalCode.Description,
        Penalty = criminalCode.Penalty,
        PrisionTime = criminalCode.PrisionTime,
        StatusId = criminalCode.StatusId,
        CreateDate = criminalCode.CreateDate,
        UpdateDate = criminalCode.UpdateDate,
        CreateUserId = criminalCode.CreateUserId,
        UpdateUserId = criminalCode.UpdateUserId
      };

      return criminalCode != null ? Ok(criminalCodeViewOutput) : NotFound("CriminalCode não encontrado");
    }

    [HttpPost]
    public async Task<IActionResult> Post(CriminalCodeViewInput criminalCodeViewInput, int userId)
    {
      CriminalCode criminalCode = new CriminalCode()
      {
        Name = criminalCodeViewInput.Name,
        Description = criminalCodeViewInput.Description,
        Penalty = criminalCodeViewInput.Penalty,
        PrisionTime = criminalCodeViewInput.PrisionTime,
        CreateDate = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now),
        UpdateDate = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now)
      };

      criminalCode.CreateUserId = userId;
      criminalCode.UpdateUserId = userId;
      criminalCode.StatusId = 1;

      _repository.AddCriminalCode(criminalCode);
      return await _repository.SaveChangesAsync() ? Ok("CriminalCode adicionado com sucesso") : BadRequest("Erro ao salvar CriminalCode");
    }

    [HttpPut("{idCriminalCode}")]
    public async Task<IActionResult> Put(int idCriminalCode, CriminalCodeViewInput criminalCodeViewInput, int userId)
    {
      var criminalCodeBanco = await _repository.GetCriminalCode(idCriminalCode);
      if (criminalCodeBanco == null) return NotFound("CriminalCode não encontrado");

      criminalCodeBanco.Name = criminalCodeViewInput.Name;
      criminalCodeBanco.Description = criminalCodeViewInput.Description;
      criminalCodeBanco.Penalty = criminalCodeViewInput.Penalty;
      criminalCodeBanco.PrisionTime = criminalCodeViewInput.PrisionTime;
      criminalCodeBanco.UpdateDate = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
      criminalCodeBanco.UpdateUserId = userId;

      _repository.UpdateCriminalCode(criminalCodeBanco);

      return await _repository.SaveChangesAsync() ? Ok("CriminalCode atualizado com sucesso") : BadRequest("Erro ao atualizar CriminalCode");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var criminalCodeBanco = await _repository.GetCriminalCode(id);
      if (criminalCodeBanco == null) return NotFound("CriminalCode não encontrado");

      _repository.DeleteCriminalCode(criminalCodeBanco);

      return await _repository.SaveChangesAsync() ? Ok("CriminalCode deletado com sucesso") : BadRequest("Erro ao deletar CriminalCode");
    }
  }
}