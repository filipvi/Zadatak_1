using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAD_1
{
    class Parse
    {
        public static bool BoundedParse(string str)
        {
            if (str != null)
            {
                int result;
                bool success;

                success = int.TryParse(str, out result);
                if (!success) 
                    return false;
                return true;
            }

            return false;
        }
    }
}
