using System;
using System.Text;


namespace usoDelYield
{
    internal class Program
    {
        public class NumerosImpares
        {
            public static IEnumerable<int> GetNumerosImparesYield(int limite)
            {int io = 0;
                if (io > limite)
                    throw new ArgumentException("mal!");

                for (int i = 0; i <= limite; i += 2)
                {
                    yield return i;
                }
            }

            public static void Main(string[] args)
            {
                int limite = 1000;
                Console.WriteLine($"Lista de números impares hasta {limite}:");
                foreach (int numero in GetNumerosImparesYield(limite))
                {
                    Console.WriteLine(numero);
                }
                Console.WriteLine("\n");

                foreach (int numero in GetNumerosImpares(limite))
                {
                    Console.WriteLine(numero);
                }
                string conectionDB = "Server=(localdb)\\mssqllocaldb;Database=Products;Trusted_Connection=True;";

            }

            

            public static List<int> GetNumerosImpares(int limite) 
            {
                List<int> list = new List<int>();
                for (int i = 0; i <= limite; i += 2)
                {
                    list.Add(i);
                }
                return list;
            }
        }
    }
}
