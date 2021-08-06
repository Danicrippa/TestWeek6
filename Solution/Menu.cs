using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;

namespace TestWeek6.Solution
{
    internal class Menu
    {
        internal static void Start()
        {
            Console.WriteLine("Benvenuto nella banca");

            char scelta;

            do
            {
                Console.WriteLine("Premi 1 per creare un nuovo conto");
                Console.WriteLine("Premi 2 per versare su un conto");
                Console.WriteLine("Premi 3 per prelevare da un conto");
                Console.WriteLine("Premi 4 per visualizzare il saldo di un conto");
                Console.WriteLine("Premi q per uscire");

                scelta = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (scelta)
                {
                    case '1':
                        //Aggiungi conto
                        AddNewAccount();
                        Console.WriteLine();
                        break;
                    case '2':
                        //Versa nel conto
                        PayIntoAccount();
                        Console.WriteLine();
                        break;
                    case '3':
                        //Preleva dal conto
                        WithdrawFromAccount();
                        Console.WriteLine();
                        break;
                    case '4':
                        //Visualizza saldo 
                        GetAccountBalance();
                        Console.WriteLine();
                        break;
                    case 'q':
                        //Esci
                        Console.WriteLine("\nCiao!");
                        return;
                    default:
                        Console.WriteLine("Scelta non disponibile. Riprova!");
                        break;
                }

            } while (!(scelta == 'q'));
        }
        private static void PayIntoAccount()
        {
            int number;

            do
                Console.Write("Inserisci il numero di conto su cui versare: ");
            while (!int.TryParse(Console.ReadLine(), out number));

            Conto account = Conto.GetByNumber(number);

            if (account != null)
            {
                decimal amount;
                Console.Write("Importo : ");
                while (!decimal.TryParse(Console.ReadLine(), out amount) ||
                        amount <= 0)
                {
                    Console.Write("Inserisci un importo valido:");
                }
                Conto.PayInto(account, amount);

            }
            else
                Console.WriteLine($"Conto n. {number} non esistente");
        }
        private static void WithdrawFromAccount()
        {
            int number;

            do
                Console.Write("Inserisci il numero di conto : ");
            while (!int.TryParse(Console.ReadLine(), out number));

            Conto account = Conto.GetByNumber(number);

            if (account != null)
            {
                decimal amount;

                Console.Write("Importo da prelevare: ");
                while (!decimal.TryParse(Console.ReadLine(), out amount) ||
                        amount <= 0 || account.Saldo < amount)
                {
                    Console.WriteLine($"Il tuo saldo è {account.Saldo}. " +
                        $"Inserisci un importo valido!");
                }

                Conto.WithDrawFrom(account, amount);

            }
            else
                Console.WriteLine($"Conto n. {number} non esistente");
        }

        private static void GetAccountBalance()
        {
            int n;
            do
                Console.Write(" vedere il saldo: ");
            while (!int.TryParse(Console.ReadLine(), out n));

            Conto account = Conto.GetByNumber(n);

            if (account != null)
            {
                Console.WriteLine($"Il saldo del conto {account.NumeroConto} è: {account.Saldo}");
            }
            else
            {
                Console.WriteLine("Non ci sono conti con questo numero ");
            }
        }

        private static void AddNewAccount()
        {
            
            string NomeCliente;
            do
            {
                Console.Write("Inserisci il tuo nome:");
                NomeCliente = Console.ReadLine();
            }
            while (NomeCliente.Length == 0);
            Conto account = Conto.AddAccount(NomeCliente);

            Console.WriteLine($"Conto numero {account.NumeroConto} creato per cliente {account.NomeCliente}");
        }

    }
}




