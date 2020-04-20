using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Reverse_Polish_Notation.IdentifyChars;

namespace Reverse_Polish_Notation
{
    class RpnAlgorithm
    {
        


        //метод, преобразующий унарные тригонометрические операторы в односимвольный вид
        //сделано, чтобы не менять основный алгоритм
        static private string TransformTrigonometricFunction(string s)
        {
            s = s.Replace("sin", "s");
            s = s.Replace("cos", "c");
            s = s.Replace("tan", "t");
            s = s.Replace("ctg", "g");
            return s;
        }


        //метод, нормализующий вид строки(тригонометрические операторы становятся нормальными)
        static private string RetransformTrigonometricFunction(string s)
        {

            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case 's': s = s.Insert(i + 1, "in"); i += 2; break;
                    case 'c': s = s.Insert(i + 1, "os"); i += 2; break;
                    case 't': s = s.Insert(i + 1, "an"); i += 2; break;
                    case 'g': s = s.Insert(i, "ct"); i += 3; break;
                    default: break;
                }

            }
            return s;

        }




        //Метод возвращает приоритет оператора
        static private byte GetPriority(char s)
        {
            switch (s)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 3;
                case '*': case '/': return 4;
                case '~': return 5;
                case '^': return 6;
                case 's': case 'c':case 't':case 'g': return 7;
               
                default: return 8;
            }

        }

        /*
        * вычисления с элементами стека, если встречен бинарный оператор
        */
        static private double CalculationsIfBinaryOperator(char input, double a, double b)
        {
            double result = 0;

            switch (input)
            {
                case '+': result = b + a; break;
                case '-': result = b - a; break;
                case '*': result = b * a; break;
                case '/':
                    try
                    {
                        result = b / a;
                        if (a == 0)
                            throw new DivideByZeroException();
                    }
                    catch (DivideByZeroException)
                    {
                        MessageBox.Show("Attempted divide by zero.");
                        result = b / a;
                    }
                    break;

                case '^': result = Math.Pow(b, a); break;
            }
            return result;
        }


        /*
        * вычисления с элементами стека, если встречен бинарный оператор
        */
        static private double CalculationIfUnarOperator(char input, double a)
        {
            double result = 0;

            switch (input)
            {
                case '~': result = -a; break;
                case 's': result = Math.Sin(a); break;
                case 'c': result = Math.Cos(a); break;
                case 't': result = Math.Tan(a); break;
                case 'g':
                    try
                    {
                        result = 1 / Math.Tan(a);
                    }
                    catch (DivideByZeroException)
                    {
                        MessageBox.Show("Attempted divide by zero.");
                        result = 1 / Math.Tan(a);
                    }
                    break;
            }
            return result;
        }
        

        //"Входной" метод класса
        static public ResultOfCounting Calculate(string input)
        {
            input = input.Replace('.', ',');
     
            //Преобразовываем выражение в постфиксную запись
            string output = GetExpression(input);
            
            //Решаем полученное выражение
            ResultOfCounting result = Counting(output); 
            return result; 

        }

        static public string GetExpression(string input)
        {

            input = TransformTrigonometricFunction(input);
            string output = string.Empty; 
            Stack<char> operStack = new Stack<char>();
            
            for (int i = 0; i < input.Length; i++)
            {

                if (IsDelimeter(input[i]))
                    continue;

                //обработка унарного минуса
                if (input[i] == '-')
                    if (i == 0 || (i > 0 && "+-*^/(".IndexOf(input[i - 1]) != -1))
                    {
                        operStack.Push('~');
                        continue;
                    }

                if (Char.IsDigit(input[i]))
                {

                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]) && !IsUnarOperator(input[i]))
                    {
                        output += input[i];
                        i++;
                        //чтобы не выйти за длину строки
                        if (i == input.Length) break;
                    }

                    output += " ";
                    //Возвращаемся на один символ назад, к символу перед разделителем
                    i--; 
                }
                else if (IsOperator(input[i]) || IsUnarOperator(input[i]))
                {
                    if (operStack.Count > 0 && input[i] != '(')
                    {
                        if (input[i] == ')')
                        {
                            char c = operStack.Pop();
                            while (c != '(')
                            {
                                output += c + " ";
                                c = operStack.Pop();
                            }
                        }
                        else if (GetPriority(input[i]) > GetPriority(operStack.Peek()))
                            operStack.Push(char.Parse(input[i].ToString()));
                        else
                        {
                            while (operStack.Count > 0 && GetPriority(input[i]) <= GetPriority(operStack.Peek()))
                                output += operStack.Pop().ToString() + " ";
                            operStack.Push(char.Parse(input[i].ToString()));
                        }
                    }
                    else
                        operStack.Push(char.Parse(input[i].ToString()));
                }
                 

            }
            while (operStack.Count > 0)
                output += operStack.Pop() + " ";

            return RetransformTrigonometricFunction(output);
        }

        /*
        * вычисление выражения в ОПЗ
        */
        static private ResultOfCounting Counting(string input)
        {
            double result = 0; 
            Stack<double> temp = new Stack<double>(); 
            string number;
            for (int i = 0; i < input.Length; i++) 
            {
                number = string.Empty;
                //Если символ - цифра, то читаем все число и записываем на вершину стека
                if (char.IsDigit(input[i]))
                {
                    
                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]) && !IsUnarOperator(input[i]))
                    {
                        number += input[i];
                        i++;
                        if (i == input.Length) break;
                    }
                    temp.Push(double.Parse(number)); 
                    i--;
                }
                else if (IsOperator(input[i]) )
                {
                    //Берем два последних значения из стека
                    double a, b;

                    try
                    {
                        a = temp.Pop();
                        b = temp.Pop();
                        result = CalculationsIfBinaryOperator(input[i], a, b);
                        temp.Push(result);
                    }

                    catch (InvalidOperationException)
                    {
                        //если поймали исключение (стек пуст), вёрнем резултат с флагом, что есть ошибка
                        return new ResultOfCounting(0, false, string.Empty);
                    }
                }


                else if (IsUnarOperator(input[i])) 
                {
                    
                    double a;
                    try
                    {
                        a = temp.Pop();
                        result = CalculationIfUnarOperator(input[i], a);
                        temp.Push(result);
                        
                    }
                    catch (InvalidOperationException)
                    {
                        //если поймали исключение (стек пуст), вёрнем резултат с флагом, что есть ошибка
                        return new ResultOfCounting(0, false, string.Empty);
                    }
                }

            }
            return new ResultOfCounting(temp.Peek(), true, input); 
        }
    }

    //структура, содержащая вычисленное значение и информацию о наличии исключений
    public struct ResultOfCounting
    {
        public readonly double Value;
        public readonly bool IsCorrectInput;
        public readonly string Expression;
        public ResultOfCounting(double val, bool flag, string exp)
        {
            Value = val;
            IsCorrectInput = flag;
            Expression = exp;
        }
    }
}


