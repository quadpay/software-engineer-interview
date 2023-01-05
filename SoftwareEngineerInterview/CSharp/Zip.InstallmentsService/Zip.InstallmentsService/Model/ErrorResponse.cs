using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zip.InstallmentsService.Model
{
    /// <summary>
    /// Class contains error response properties
    /// </summary>
    public class ErrorResponse
    {
     public bool Success { get; set; }
     public string Message { get; set; }
     public int StatusCode { get; set; }

    }
}
