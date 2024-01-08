using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class Program
{
    static void Main(string[] args)
    {
        string track = "-";
        string[] DemiParsedExpression = new string[100];
        string expression = "3500+10/2";
        int index = 0;
        for (int j = 0; j < expression.Length; j++)
        {
            if (char.IsNumber(expression[j]))
            {
                DemiParsedExpression[index] = DemiParsedExpression[index] + expression[j];
            }
            if (!char.IsNumber(expression[j]))
            {
                index++;
                DemiParsedExpression[index] = DemiParsedExpression[index] + expression[j];
                index++;
            }
        }
        List <string> list = new List <string>();
        for (int j = 0; j < DemiParsedExpression.Length; j++)
        {
           Console.Write($"{ DemiParsedExpression[j]}\n");
        }
    }
    public static void Execute(string[] s)
    {
        int[] orderOfPriority = new int[s.Length];
        float[] numberBlock = new float[s.Length];
        for (int i = 0; i < orderOfPriority.Length; i++)
        {
            switch (s[i])
            {
                case "+":
                    orderOfPriority[i] = 1;
                    break;
                case "-":
                    orderOfPriority[i] = 1;
                    break;
                case "*":
                    orderOfPriority[i] = 2;
                    break;
                case "/":
                    orderOfPriority[i] = 2;
                    break;
                default:
                    numberBlock[i] = float.Parse(s[i]);
                break;
            }
        }
        int max = 0;
        for (int i = 0;i < orderOfPriority.Length; i++)
        {
            if (orderOfPriority[i] > max)
                max = orderOfPriority[i];
        }
        for (int i = 0; i < s.Length; i++) 
        {
            if (orderOfPriority[i] == max)
                switch(s[i])
                {
                    case "*":
                        numberBlock[i - 1] = numberBlock[i - 1] * numberBlock[i + 1];
                        break;
                    case "/":
                        numberBlock[i - 1] = numberBlock[i - 1] / numberBlock[i + 1];
                        break;
                }
        }
    }
}


