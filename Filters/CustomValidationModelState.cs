using API_DOTNET.Model;
using API_DOTNET.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace API_DOTNET.Filters
{
  public class CustomValidationModelState : ActionFilterAttribute
  {

    public override void OnActionExecuting(ActionExecutingContext context)
    {
      if (!context.ModelState.IsValid)
      {
        var validateFieldViewOutput = new ValidateFieldViewOutput(context.ModelState.SelectMany(sm => sm.Value.Errors)
                                                                                    .Select(s => s.ErrorMessage));
        context.Result = new BadRequestObjectResult(validateFieldViewOutput);
      }
    }

  }
}
