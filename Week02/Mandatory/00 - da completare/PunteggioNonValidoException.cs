using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class MiaEccezione : Exception
    {
        public MiaEccezione() 
        {
            Console.ForegroundColor = ConsoleColor.Red; Console.Write("\nIl valore che hai inserito non è valido. Inserisci un numero compreso fra 1 e 10 \n"); Console.ResetColor();

        }
        public MiaEccezione(string message) : base(message) { }
    }
}
