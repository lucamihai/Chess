using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Application.Classes
{
    class Utilities
    {
        public static string GetReversedString(string stringToBeReversed)
        {
            char[] stringCharacters = stringToBeReversed.ToCharArray();
            Array.Reverse(stringCharacters);
            return new string(stringCharacters);
        }
    }
}
