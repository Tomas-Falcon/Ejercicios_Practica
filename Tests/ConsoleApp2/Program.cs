using System.Diagnostics.Metrics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using static System.Net.WebRequestMethods;

namespace ConsoleApp2
{
    internal class Program
    {

        static string name;
        static void Main(string[] args)
        {
            for (int i = 0; i < 12; i++)
            {
                Thread t = new Thread(WriteToSharedResource);
                t.Name = $"Thread{i + 1}";
                t.Start();
            }
        }

        static void WriteToSharedResource()
        {
            string urlApi = "http://Tarea_Curso_Jorge:8080";
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(urlApi);
                for (int i = 0; i < 200; i++)
                {
                    httpClient.GetFromJsonAsync<object>("AllGames");
                    Console.WriteLine(Thread.CurrentThread.Name + " - " + i);
                }
            }
        }
    }
    
}
