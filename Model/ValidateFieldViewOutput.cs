using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_DOTNET.Model
{
  public class ValidateFieldViewOutput
  {
    public IEnumerable<string> Erros { get; private set; }
    public ValidateFieldViewOutput(IEnumerable<string> erros)
    {
      Erros = erros;
    }
  }
}