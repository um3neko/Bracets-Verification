using System;
using System.Collections.Generic;
using System.Text;

namespace Bracets_Verification 
{
     public class BracketsVerification
     {  
        private static string _allowableValues = "{}()[]";
        

        /// <summary>
        /// приложение реализует класс BracketsVerification одним публичным методом
        /// </summary>
        /// <param name="stringToCheck"></param>
        /// <returns></returns>
        public List<int> checkInputValidation(string stringToCheck)
        {
            Console.WriteLine(stringToCheck);
            checkInputNotEmpty(stringToCheck);
            checkInputContainsNonBracketsValue(stringToCheck);
            
            return checkBalance(stringToCheck);


        }
        /// <summary>
        /// метод для проверки строки на пустоту, если она пустая - метод генерирует исключение.
        /// </summary>
        /// <param name="stringToCheck"></param>
        private void checkInputNotEmpty(string stringToCheck)
        {
            if (String.IsNullOrEmpty(stringToCheck))
            {
                Console.WriteLine("String is empty");
                throw new ArgumentException($"String is empty");
            }  
        }

        /// <summary>
        /// метод для проверки строки на недопустимые символы, если она есть -
        /// метод генерирует исключение и уведомляет о недопустимых символах.
        /// </summary>
        /// <param name="stringToCheck"></param>
        private void checkInputContainsNonBracketsValue(string stringToCheck)
        {
            string unexpectedCharacters = ""; //строка которая будет содержать недопустимые символы, чтоб вывести их в консоль
            for (int i = 0; i < stringToCheck.Length; i++)
            {
                if (!_allowableValues.Contains(stringToCheck[i]))
                {
                    unexpectedCharacters += "'" + stringToCheck[i] + "'" + " ";
                }
            }
            if (unexpectedCharacters != "")
            {
                Console.WriteLine($"A characters {unexpectedCharacters} doesn’t belong to any known brackets type ");
                throw new ArgumentException($"A characters doesn’t belong to any known brackets type ");
            }
                
        }
        
        /// <summary>
        /// метод для проверки строки на то, что все открытые скобки имеют закрывающие скобки, если такие скобки присутствуют,
        /// метод возвращает список индексов всех несбалансированных скобок начиная с нуля, если все скобки имеют закрывающую скобку, метод возвращает список с индексом -1.
        /// В тестовом задание есть неточность, так как в части Functional Description сказано " Output: integer value returns  -1 - when balanced and number of bracket when not balanced "
        /// но в части "Acceptance Criteria: " otherwise print - NOT BALANCED and return a number of not balanced brackets in the line. " а именно return number of brackets 
        ///  и мною было принято решение лучше возвращать list of integer.
        /// </summary>
        /// <param name="stringToCheck"></param>
        /// <returns></returns>
        private List<int> checkBalance(string stringToCheck)
        {
            Stack<char> unmatchedBracketsIndexes = new Stack<char>(); // стэк нужен для того, чтоб проследить все ли открывающие скобки имеют закрывающую скобку.
                                                                    // если стэк оказывается в конце пустой, проверка на то, что строка не содержит непарных скобок выполнена

            List<int> listForReturningByApplication = new List<int>(); // по заданию, нужно вернуть number of brackets
                                                                       // " otherwise print - NOT BALANCED and return a number of not balanced brackets in the line. "
                                                                       // таким образом, мое приложение будет возвращать индексы всех целочисленных непарных скобок 

            for (int i = 0; i < stringToCheck.Length; i++)
            {
                    switch (stringToCheck[i])
                {
                    case '{':

                        unmatchedBracketsIndexes.Push('{'); // добавляю в стэк индекс открывающей скобки, если он не покинет очередь, значит скобка незакрывающаяся
                        break;

                    case '}':
                        try
                        {
                            string test = "";                                   //создаем пустую строку 
                            test += unmatchedBracketsIndexes.Pop();             //снимаем его с верхушки и добавляем к нему
                            test += stringToCheck[i];                           //добавляем к нему текущий элемент
                                                                                //идея в том, что если у нас идет строка ([)] то следующий if проверил содержит ли 
                                                                                //наша переменная _allowedValues подстроку [), если она ее не содержит
                            if (!_allowableValues.Contains(test))               //тогда скобки не получаются не сбалансированны и в список индексов мы заносим индекс текущего элемента 
                            {
                                listForReturningByApplication.Add(i+1);
                            }
                            
                        }
                        catch 
                        {
                            listForReturningByApplication.Add(i + 1);
                            // если стэк пустой, при попытке удаления оттуда закрывающей скобки
                            // она автоматически попадает в список несбалансированых скобок.
                            // Тоесть если строка начнется с закрывающейся скобки } то, она будет несбалансированой. 
                            // или ()} 
                            //       ↑ сейчас  стэк пустой , поэтому она попадет в список несбалансированных скобок.
                        }
                        break;

                    case '(':

                        unmatchedBracketsIndexes.Push('(');
                        break;
                    case ')':
                        
                        try
                        {
                            string test = "";
                            test += unmatchedBracketsIndexes.Pop();
                            test += stringToCheck[i];
                            if (!_allowableValues.Contains(test))
                            {
                                listForReturningByApplication.Add(i + 1);
                            }
                        }
                        catch 
                        {
                            listForReturningByApplication.Add(i + 1);
                        }
                        break;

                    case '[':

                        unmatchedBracketsIndexes.Push('[');
                        break;
                    case ']':
                        try
                        {
                            string test = "";
                            test += unmatchedBracketsIndexes.Pop();
                            test += stringToCheck[i];
                            if (!_allowableValues.Contains(test))
                            {
                                listForReturningByApplication.Add(i + 1);
                            }
                        }
                        catch 
                        {
                            listForReturningByApplication.Add(i + 1);
                        }
                        break; 
                }
            }
            
            if (listForReturningByApplication.Count != 0)
            {
                                                                    
                Console.Write($"NOT BALANCED (");
                foreach (var e in listForReturningByApplication)
                {
                    Console.Write(e + " ");
                }
                Console.Write(")");
                
                return listForReturningByApplication;

            }
            else
            {
                Console.WriteLine("BALANCED");
                listForReturningByApplication.Add(-1);
                
                return listForReturningByApplication;
            }
              
        }
       
        
     }
}

