using BibliotecaDeClasesTest;
using System.Diagnostics;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            string txt = "asd";
            Console.WriteLine(a + " " + txt);

            Class1 c1 = new Class1();
            c1.IOmprimir();
            int b = 0; ;
            dividir(a, b);
            dividirIf(a,b);
            dividirAssert(a,b);
        }

        public static void dividir(int a, int b)
        {   
            int c = a / b;

            Console.WriteLine(c.ToString());
        }

        public static void dividirIf(int a, int b)
        {
            int c = 0;
            if (b!= 0 && b<0) {
                c =  a/b;
            }
            Console.WriteLine(c.ToString());
        }

        public static void dividirAssert(int a, int b)
        {
            Debug.Assert(b != 0);
            int c = a / b;
            
            Console.WriteLine(c.ToString());
        }

        public static void dividirTryCatch(int a, int b)
        {
            try { 
                int c = a / b;
                Console.WriteLine(c.ToString());
            }
            catch(DivideByZeroException e) {
                Debug.WriteLine(e.Message);
            }
        }
    }
}
