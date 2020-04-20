using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Polish_Notation
{
    class IdentifyChars
    {
        //Метод возвращает true, если проверяемый символ - пробел
        public static bool IsDelimeter(char c)
        {
            if (" ".IndexOf(c) != -1)
                return true;
            return false;
        }

        //Метод возвращает true, если проверяемый символ - оператор
        public static bool IsOperator(char с)
        {
            if ("+-/*^()".IndexOf(с) != -1)
                return true;
            return false;
        }

        //Метод возвращает true, если проверяемый символ отвечает за унарный оператор(тригонометрическую функцию)
        public static bool IsUnarOperator(char a)
        {
            if ("sctg~".IndexOf(a) != -1)
                return true;
            return false;
        }

    }
}
