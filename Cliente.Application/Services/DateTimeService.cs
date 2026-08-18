using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Application.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Agora()
        {
            return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
                DateTime.UtcNow,
                "E. South America Standart Time");
        }
    }
}
