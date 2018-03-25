using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAD_1.Helper
{
    public class Valid
    {
        public static bool IsValid(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                return true;
            }

            return false;
        }
    }
}
