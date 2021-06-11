using System;

namespace Prova7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inserisci username: ");
            string user = Console.ReadLine();

            DbManager.TrovaUtente(user);
        }
    }
}
