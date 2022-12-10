using System;
using System.Collections.Generic;
using System.Text;

namespace Zip.InstallmentsService.Entity.Response
{
    /// <summary>
    /// /// <summary>
    /// Data structure which defines all the properties for a validating a request.
    /// </summary>
    /// </summary>
    public class ValidateResponseModel
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
    }
}
