using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Zip.InstallmentsService.Helpers
{
    public static class ObjectResponse
    {
        public static ObjectResult GetResults(
            HttpStatusCode StatusCode,
            string message = "",
            bool isGeneralException = false)
        {
            if (!isGeneralException)
            {
                return new ObjectResult(null)
                {
                    StatusCode = (int)StatusCode,
                    Value = message
                };
            }
            else
            {
                return new ObjectResult(null)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Value = "Unkown exception occured. Please contact administrator"
                };
            }

        }

    }
