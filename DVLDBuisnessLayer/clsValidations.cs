using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBuisnessLayer
{
    public class clsValidations
    {
        public static bool IsNumberOnly(string Input)
        {
            return Input.All(char.IsDigit);
        }
    }
}
