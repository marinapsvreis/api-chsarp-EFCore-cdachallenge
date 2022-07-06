
using API_DOTNET.Configurations;
using API_DOTNET.Filters;
using API_DOTNET.Model;
using API_DOTNET.Repository;
using API_DOTNET.View;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API_DOTNET.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UserController : ControllerBase
  {

    private readonly IUserRepository _userRepository;
    private readonly IAuthenticationService _authenticationService;

    public UserController(IUserRepository userRepository,
                             IAuthenticationService authenticationService)
    {
      _userRepository = userRepository;
      _authenticationService = authenticationService;
    }

    [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewInput))]
    [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidateFieldViewOutput))]
    [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(GenericErrorView))]
    [HttpPost]
    [Route("login")]
    [CustomValidationModelState]
    public async Task<IActionResult> Logar(LoginViewInput loginViewInput)
    {
      var user = await _userRepository.ObterAsync(loginViewInput.UserName);

      if (user == null)
      {
        return BadRequest("Houve um erro ao tentar acessar");
      }

      var userViewOutput = new UserViewOutput()
      {
        UserId = user.Id,
        UserName = loginViewInput.UserName
      };

      userViewOutput.Token = _authenticationService.GerarToken(userViewOutput);


      return Ok(userViewOutput);
    }

    [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewInput))]
    [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidateFieldViewOutput))]
    [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(GenericErrorView))]
    [HttpPost("register")]
    [CustomValidationModelState]
    public async Task<IActionResult> Registrar(RegisterViewInput registerViewInput)
    {
      var user = await _userRepository.ObterAsync(registerViewInput.UserName);

      if (user != null)
      {
        return BadRequest("Usuário já cadastrado");
      }

      user = new User();
      user.UserName = registerViewInput.UserName;
      user.Password = registerViewInput.Password;

      _userRepository.Adicionar(user);
      _userRepository.Commit();

      return Created("", registerViewInput);
    }
  }
}