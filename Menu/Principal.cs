using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sopa;
using Tabla;



namespace Inicio
{
    class Principal
    {
        static void Main(string[] args)
        {
            Inicio();
        }
        public static void Inicio()
        {
            Console.Clear();
            string[] opciones = new string[3] { "Sopa de Letras", "Pizarra", "Salir" };
            int l = opciones.Length;
            string titulo = "TP 1";
            Herramientas.DibujoMenu(titulo, opciones);
            Console.Write("Elija una opcion: ");
            int op = Herramientas.LeerEntero(1, l);
            switch (op)
            {
                case 1:
                    SopaLetras.Sopa(); break;
                case 2: Pizarron.Pizarra(); break;
                case 3: Console.Clear(); break;
            }
        }
    }
}
