using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAD_1.Helper
{
    class InputManager
    {
        public static string CheckType(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                if (input == "0")
                {
                    return "0";
                }

                if (int.TryParse(input, out var result))
                {               
                    return  "int";
                }
            }
            
            return "null";
        }
    }
}
