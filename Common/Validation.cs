using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Validation
    {

        private static int[,] _multiplicationTable = {
                { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                { 1, 2, 3, 4, 0, 6, 7, 8, 9, 5 },
                { 2, 3, 4, 0, 1, 7, 8, 9, 5, 6 },
                { 3, 4, 0, 1, 2, 8, 9, 5, 6, 7 },
                { 4, 0, 1, 2, 3, 9, 5, 6, 7, 8 },
                { 5, 9, 8, 7, 6, 0, 4, 3, 2, 1 },
                { 6, 5, 9, 8, 7, 1, 0, 4, 3, 2 },
                { 7, 6, 5, 9, 8, 2, 1, 0, 4, 3 },
                { 8, 7, 6, 5, 9, 3, 2, 1, 0, 4 },
                { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }
            };

        private static int[,] _permutationTable = {
                { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                { 1, 5, 7, 6, 2, 8, 3, 0, 9, 4 },
                { 5, 8, 0, 3, 7, 9, 6, 1, 4, 2 },
                { 8, 9, 1, 6, 0, 4, 3, 5, 2, 7 },
                { 9, 4, 5, 3, 1, 2, 6, 8, 7, 0 },
                { 4, 2, 8, 6, 5, 7, 3, 9, 0, 1 },
                { 2, 7, 9, 3, 8, 0, 6, 4, 1, 5 },
                { 7, 0, 4, 6, 9, 1, 3, 2, 5, 8 }
            };

        private static int[] _inverseTable = { 0, 4, 3, 2, 1, 5, 6, 7, 8, 9 };

        public static int CheckSum(string number)
        {
            int c = 0;
            int len = number.Length;

            for (int i = 0; i < len; ++i)
                c = _multiplicationTable[c, _permutationTable[((i + 1) % 8), number[len - i - 1] - '0']];

            return _inverseTable[c];
        }

        public static bool Validate(string number)
        {
            int c = 0;
            int len = number.Length;

            for (int i = 0; i < len; ++i)
                c = _multiplicationTable[c, _permutationTable[(i % 8), number[len - i - 1] - '0']];

            return c == 0;
        }

        public static bool CheckValidationMelliCode(string NCode)
        {
            const int n = 10;
            if (NCode.Length != n)
                return false;

            if ((NCode == "0000000000") || (NCode == "1111111111") || (NCode == "2222222222") ||
  (NCode == "3333333333") || (NCode == "4444444444") || (NCode == "5555555555") ||
(NCode == "6666666666") || (NCode == "7777777777") || (NCode == "8888888888") ||
(NCode == "9999999999") || (NCode == "1000000001") || (NCode == "1234567891") ||
(NCode == "0123456789")) return false;



            else
            {
                int l = 0, k;
                for (int i = 0; i < n - 1; i++)
                {
                    try { k = Convert.ToInt16(NCode[i].ToString()); }
                    catch { return false; }
                    l += k * (n - i);
                }
                l %= 11;

                return (l > 1) ? (11 - l) == Convert.ToInt16(NCode[n - 1].ToString()) : l == Convert.ToInt16(NCode[n - 1].ToString());
            }
        }

        public static bool CheckLegalNationalCode(String nationalCode)
        {
            try
            {
                const int n = 11;
                if (nationalCode.Length != n)
                    return false;


                if (nationalCode.Length < 11 || int.Parse(nationalCode) == 0)
                    return false;
                if (nationalCode == "12345678910" || nationalCode == "15151515151" || nationalCode == "12111111111" || nationalCode == "10600000000" ||
     nationalCode == "10330003469" || nationalCode == "10860214050" || nationalCode == "10100336120" || nationalCode == "10109999113" ||
     nationalCode == "98765432112" || nationalCode == "20301100200" || nationalCode == "11000000000" || nationalCode == "10444444444" ||
     nationalCode == "10100189668" || nationalCode == "10100698167" || nationalCode == "41141889939" || nationalCode == "41115736386" ||
     nationalCode == "10390400372" || nationalCode == "12345678925" || nationalCode == "10101353350" || nationalCode == "10487309547" ||
     nationalCode == "33333333333")
                    return false;

                if (int.Parse(nationalCode.Substring(3, 9)) == 0)
                    return false;

                int c = int.Parse(nationalCode.Substring(10, 1));
                int d = int.Parse(nationalCode.Substring(9, 1)) + 2;
                int[] z = new int[] { 29, 27, 23, 19, 17 };
                int s = 0;

                for (byte i = 0; i < 10; i++)
                    s += (d + int.Parse(nationalCode.Substring(i, 1))) * z[i % 5];

                s = s % 11;

                if (s == 10)
                    s = 0;

                return (c == s);
            }
            catch { return false; }
        }
    }
}
