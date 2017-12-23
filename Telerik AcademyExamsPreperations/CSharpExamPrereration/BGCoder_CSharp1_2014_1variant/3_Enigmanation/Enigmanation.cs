using System;

class Enigmanation
{
    static void Main()
    {
        string expression = Console.ReadLine();

        char operators = '+';
        char operatotInBreckets = '+';
        decimal sum = 0;
        decimal charSum = 0;
        decimal sumInBrackets = 0;
        decimal charSumInBreckets = 0;
        bool inBreckets = false;

        foreach (char character in expression)
        {
            if (character == '=')
            {
                break;
            }

            // Expression in breckets

            if (character == '(')
            {
                inBreckets = true;
                continue;
            }
            if (character == ')')
            {
                inBreckets = false;
                if (operators == '+')
                {
                    sum += sumInBrackets;
                }
                if (operators == '-')
                {
                    sum -= sumInBrackets;
                }
                if (operators == '*')
                {
                    sum *= sumInBrackets;
                }
                if (operators == '%')
                {
                    sum %= sumInBrackets;
                }

                sumInBrackets = 0;
                charSumInBreckets = 0;
                operatotInBreckets = '+';
            }


            // Digits

            if (char.IsDigit(character))
            {
                if (inBreckets == true)
                {
                    charSumInBreckets = character - '0';
                }
                else
                {
                    charSum = character - '0';
                }

                if (inBreckets == true)
                {
                    if (operatotInBreckets == '+')
                    {
                        sumInBrackets += charSumInBreckets;
                    }
                    if (operatotInBreckets == '-')
                    {
                        sumInBrackets -= charSumInBreckets;
                    }
                    if (operatotInBreckets == '*')
                    {
                        sumInBrackets *= charSumInBreckets;
                    }
                    if (operatotInBreckets == '%')
                    {
                        sumInBrackets %= charSumInBreckets;
                    }
                }
                else
                {
                    if (operators == '+')
                    {
                        sum += charSum;
                    }
                    if (operators == '-')
                    {
                        sum -= charSum;
                    }
                    if (operators == '*')
                    {
                        sum *= charSum;
                    }
                    if (operators == '%')
                    {
                        sum %= charSum;
                    }
                }
            }


            // Operator

            if (character == '+' || character == '-' || character == '*' || character == '%')
            {
                if (inBreckets == true)
                {
                    switch (character)
                    {
                        case '+': operatotInBreckets = '+'; break;
                        case '-': operatotInBreckets = '-'; break;
                        case '*': operatotInBreckets = '*'; break;
                        case '%': operatotInBreckets = '%'; break;
                    }
                }
                else
                {
                    switch (character)
                    {
                        case '+': operators = '+'; break;
                        case '-': operators = '-'; break;
                        case '*': operators = '*'; break;
                        case '%': operators = '%'; break;
                    }
                }
            }
        }
        Console.WriteLine("{0:F3}", sum);
    }
}
