using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_List
{
    class Clase_Principal
    {
        static void Main(string[] args)
        {
            var miListaDinamica = new Dynamic_List_Class<string>();
            miListaDinamica.Add("Uno");
            miListaDinamica.Add("Dos");


            Console.WriteLine(miListaDinamica.Cotains("Uno"));


            Console.ReadKey();


        }
    }
}
