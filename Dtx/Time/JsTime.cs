using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtx.Time
{
    public static class JsTime
    {
        public static long ToMilliseconds(this DateTime dt)
        {
            return (dt.ToUniversalTime().Ticks - (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).Ticks) / 10000;
        }
    }
}
