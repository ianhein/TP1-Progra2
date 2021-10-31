using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Inicio

{ 
    class Herramientas
    {
        public static int LeerEntero(int min, int max)
        {
            int valor = -1;
            bool exito = false;
            do
            {
                try
                {
                    valor = int.Parse(Console.ReadLine());
                    if (valor <= max && valor >= min)
                    {
                        exito = true;
                    }
                    else
                    {
                        Console.WriteLine("\nLa opción no está dentro de los límites, intente nuevamente");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nDebe ingresar un número entero, intente nuevamente");
                    exito = false;
                }
                catch
                {
                    Console.WriteLine("\nOpción incorrecta, intente nuevamente");
                    exito = false;
                }
            } while (!exito);
            return valor;
        }
        public static void DibujoMenu(string titulo, string[] opciones)
        {
            //Busco cual es la palabra mas larga del menu
            //para definir el ancho del mismo
            int largo = titulo.Length;
            for (int i = 0; i < opciones.Length; i++)
            {
                if (largo < opciones[i].Length)
                {
                    largo = opciones[i].Length;
                }
            }
            //a la palabra mas larga del menu le sumo 8 para los espacios y el marco
            largo = largo + 8;

            //Posicion donde comienza a dibujar el menu
            //esta posicion la repito en todos los lugares que comienzo o ubico el cursor 
            //en una linea
            Console.CursorLeft = 10;

            //Dibujo la linea superior del menu
            for (int i = 0; i < largo; i++)
            {
                if (i == 0)
                    Console.Write("╔");
                else
                    if (i == largo - 1)
                    Console.Write("╗\n");
                else
                    Console.Write("═");


            }

            //Coloco el tiulo del menu centrado.
            Console.CursorLeft = 10;
            Console.Write("║");
            Console.CursorLeft = ((largo - titulo.Length) / 2) + 10;
            Console.Write(titulo);
            Console.CursorLeft = (largo - 1) + 10;
            Console.Write("║\n");

            //Cierro el cuadro del titulo
            Console.CursorLeft = 10;
            for (int i = 0; i < largo; i++)
            {
                if (i == 0)
                    Console.Write("╠");
                else
                    if (i == largo - 1)
                    Console.Write("╣\n");
                else
                        if (i == 4)
                    Console.Write("╦");
                else
                    Console.Write("═");


            }

            //recorro el array de las opciones y las imprimo
            // con el marco correspondiente
            Console.CursorLeft = 10;
            for (int i = 0; i < opciones.Length; i++)
            {
                Console.CursorLeft = 10;

                Console.Write("║ ");
                if (i < 9)
                {
                    Console.Write("0{0}║ {1}", i + 1, opciones[i]);
                }
                else
                {
                    Console.Write("{0}║ {1}", i + 1, opciones[i]);
                }
                Console.CursorLeft = (largo - 1) + 10;
                Console.Write("║\n");
            }
            Console.CursorLeft = 10;

            //cierro el cuadro del menu
            for (int i = 0; i < largo; i++)
            {
                if (i == 0)
                    Console.Write("╚");
                else
                    if (i == largo - 1)
                    Console.Write("╝\n");
                else
                        if (i == 4)
                    Console.Write("╩");
                else
                    Console.Write("═");


            }

        }
    }

}