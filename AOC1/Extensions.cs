using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2021
{
    public static class Extensions
    {
        public static bool Contains(this string val, char x, int number)
        {
            if (val == null)
                return false;

            var stringSeq = "";
            for (int i = 0; i < number; i++)
            {
                stringSeq += x;
            }

            return val.Contains(stringSeq);
        }

    }
}
