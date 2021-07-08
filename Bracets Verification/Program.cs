using System;
using System.Collections.Generic;

namespace Bracets_Verification
{
    class Program
    {
        static void Main(string[] args)
        {
            BracketsVerification bracketsVerification = new BracketsVerification();
            string b = "([)]";
            
            bracketsVerification.checkInputValidation(b);
            Console.ReadKey();
        }
    }
}
