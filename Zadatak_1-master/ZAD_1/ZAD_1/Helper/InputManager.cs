using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAD_1.Helper
{
    class InputManager
    {
        public static bool ParseToInt(string input)
        {
            if (int.TryParse(input, out var result))
            {
                return true;
            }
            return false;
        }

        public static string CheckType(string input)
        {
            int n;
            if (!string.IsNullOrWhiteSpace(input))
            {
                bool inputResult = IsQuit(input);
                if (inputResult)
                {
                    return "Quit";                    
                }

                inputResult = IsValidInt(input);
                if (inputResult)
                {
                    return "Int";
                }

                inputResult = IsValidString(input);
                if (inputResult)
                {
                    return "String";
                }
            }

            return "Null";

        }

    public static bool IsQuit(string input)
    {
        if (input == "0")
        {
            return true;
        }
        return false;
    }

    public static bool IsValidString(string input)
    {
        return true;
    }

    public static bool IsValidInt(string input)
    {
        if (int.TryParse(input, out var result))
        {
            return true;
        }

        return false;
    }
}
}
