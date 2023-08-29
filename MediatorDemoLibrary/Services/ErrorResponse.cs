using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDemoLibrary.Services
{
    public record ErrorResponse(string Message, List<string> Errors);
}
