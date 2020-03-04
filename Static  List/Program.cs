using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dynamic_List;

namespace Static__List
{
    class Program
    {
        static void Main(string[] args)
        {
            var miListaEstatica = new Dynamic_List_Class<string>();

            miListaEstatica.Add("Dos");

            Console.WriteLine(miListaEstatica[0]);

            Console.ReadKey();



        }
    }
}
