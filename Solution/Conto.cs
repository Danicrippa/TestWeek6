using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek6.Solution
{
    public class Conto
    {
        public string NomeCliente { get; set; }
        public int NumeroConto { get; set; }
        public string NomeBanca { get; set; }
        public decimal Saldo { get; set; }
        public DateTime DataUltimaOperazione { get; set; }
        public decimal Valore { get; set; }
        public static Conto AddAccount(string NomeCliente);
        public override bool Equals(object obj)
        {

            try
            {
                
                if (NomeCliente == null)
                {
                    return false;
                }
                return true;
            }

            catch (Exception exG)
            {
                Console.WriteLine($"Si è verificato un errore generico");
                return false;
            }
        }

        internal static Conto GetByNumber(int number)
        {
            throw new NotImplementedException();
        }
        internal static void WithDrawFrom(Conto account, decimal amount)
        {
            throw new NotImplementedException();
        }
        
        }
    
        internal static void PayInto(Conto account, decimal amount)
        {
            throw new NotImplementedException();
        }
    }


