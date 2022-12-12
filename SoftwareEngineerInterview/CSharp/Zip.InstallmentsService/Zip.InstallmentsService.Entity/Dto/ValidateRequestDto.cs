using System;
using System.Collections.Generic;
using System.Text;

namespace Zip.InstallmentsService.Entity.Dto
{
    public class ValidateRequestDto
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
    }
}
