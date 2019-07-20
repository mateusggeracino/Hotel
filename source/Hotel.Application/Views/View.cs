using System;
using System.Collections.Generic;

namespace Hotel.Application.Views
{
    public abstract class View
    {
        public void CleanScreen()
        {
            Console.Clear();
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public string GetInput()
        {
            return Console.ReadLine();
        }

        public void PressToContinue()
        {
            Message("Press any key to continue");
            Console.ReadKey();
        }

        public void PrintErrors(List<string> errors)
        {
            foreach (var erro in errors)
            {
                Message(erro);
            }
        }
    }
}