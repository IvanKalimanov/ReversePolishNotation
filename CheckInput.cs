using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Reverse_Polish_Notation.IdentifyChars;

namespace Reverse_Polish_Notation
{
    class CheckInput
    {
        /*
        *функция проверяет правильную расстановку скобок и верный набор входных данных
        */
        public static bool IsCorrectBracketsAndOperators(string s)
        {
            var stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {

                if (s[i] == '(') stack.Push(s[i]);
                else if (s[i] == ')')
                {
                    if (stack.Count == 0) return false;

                    if (stack.Pop() != '(') return false;
                }

                else if (IsOperator(s[i]) || IsDelimeter(s[i])) continue;

                else if (Char.IsDigit(s[i]) || s[i] == ',' || s[i] == '.') continue;

                else if (i + 3 < s.Length)
                    switch (s.Substring(i, 3))
                    {
                        case "sin": i += 2; break;

                        case "cos": i += 2; break;

                        case "tan": i += 2; break;

                        case "ctg": i += 2; break;

                        default:
                            return false;

                    }
                else
                    return false;
            }
            return stack.Count == 0;
        }
    }
}
