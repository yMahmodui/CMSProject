using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtx.Security
{
    public class Hashing
    {
        public static string GetSha1(string value)
        {
            if (value == null)
                return string.Empty;

            value = value.Trim();
            if (value == string.Empty)
                return string.Empty;

            try
            {
                var bytInputs = Encoding.ASCII.GetBytes(value);
                var oHash = System.Security.Cryptography.SHA1.Create();
                var bytHashes = oHash.ComputeHash(bytInputs);

                var oStringBuilder = new StringBuilder();

                foreach (var t in bytHashes)
                    oStringBuilder.Append(t.ToString("X2"));

                return (oStringBuilder.ToString());
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
