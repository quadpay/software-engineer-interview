using System;
using System.Collections.Generic;
using System.Text;

namespace Zip.InstallmentsService.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public static class DateTimeHelper
    {
        public static DateTime GetNextDateAfterDays(DateTime date, int days)
        {
            return date.AddDays(days).Date;
        }

    }
}
