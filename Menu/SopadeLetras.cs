using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inicio;



namespace Sopa
{
    public class SopaLetras
    {
        public static void Principal(string[] args)
        {
            Sopa();
        }
        public static void Sopa()
        {
            Console.Clear();
            Console.WriteLine("Seleccionar nivel: ");
            Console.WriteLine("1- Nivel 1.");
            Console.WriteLine("2- Nivel 2.");
            Console.WriteLine("3- Nivel 3.");
            Console.WriteLine("4- Volver al Menú");
            int op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1: Principal(15); Sopa(); break;  //recursividad, en vez de loopearlo.
                case 2: Principal(20); Sopa(); break;
                case 3: Principal(30); Sopa(); break;
                case 4: Inicio.Principal.Inicio(); break;
                default:
                    Console.WriteLine("Por favor, seleccione una opción");
                    Sopa();
                    break;
            }
        }
        static void Principal(int tam)
        {


            //Pedir palabras al Usuario
            Random random = new Random();
            List<string> palabras = new List<string> { };

            int count = 0;
            do
            {

                Console.WriteLine("Escribe una palabra:  {0}/3 ", count);
                string p = Console.ReadLine();
                if (p.Length <= tam)
                {
                    palabras.Add(p);
                    count++;
                }
                else

                { Console.WriteLine("Error: La palabra no debe superar los {0} caracteres", tam / 2); }

            } while (count < 3);

            //Determinar si cada palabra es Horizontal o Vertical
            List<int> orientaciones = new List<int> { };
            for (int i = 0; i < 3; i++)
            {
                int orientacion = random.Next(0, 2); //0 horizontal, 1 vertical
                orientaciones.Add(orientacion);
            }

            //Determinar posicion de las palabras en la matriz (lo complicado)
            List<Tuple<int, int>> posPal = new List<Tuple<int, int>> { };
            for (int i = 0; i < 3; i++)
            {
                if (orientaciones[i] == 0)
                {
                    int posicionX = random.Next(0, tam);
                    int posicionY = random.Next(0, tam - palabras[i].Length);
                    posPal.Add(Tuple.Create(posicionX, posicionY));
                }
                if (orientaciones[i] == 1)
                {
                    int posicionX = random.Next(0, tam - palabras[i].Length);
                    int posicionY = random.Next(0, tam);
                    posPal.Add(Tuple.Create(posicionX, posicionY));
                }
            }


            //creando la matriz
            char[,] matriz = new char[tam, tam];

            for (int i = 0; i < tam; i++)
            {
                for (int c = 0; c < tam; c++)
                {

                    int letra = random.Next(65, 91);

                    //codigos ascii de las letras a randomizar

                    char caracter = Convert.ToChar(letra);
                    matriz[i, c] = caracter;
                }

            }

            //cargando las palabras en la matriz

            for (int i = 0; i < palabras.Count(); i++)
            {
                string palabra = palabras[i];

                int posX = posPal[i].Item2;
                int posY = posPal[i].Item1;
                var chars = palabra.ToCharArray();
                foreach (char c in palabra)
                {
                    if (orientaciones[i] == 0)
                    {
                        matriz[posX, posY] = char.ToUpper(c);
                        posX++;
                    }
                    if (orientaciones[i] == 1)
                    {
                        matriz[posX, posY] = char.ToUpper(c);
                        posY++;
                    }
                }

            }
            jugar(matriz, palabras, orientaciones, posPal, tam);
            Console.ReadKey(true);




        }
        static void dibujarMatriz(char[,] mat, int t)
        {
            Console.WriteLine();
            for (int i = 0; i < t; i++)
            {
                for (int c = 0; c < t; c++)
                {
                    Console.Write(mat[i, c] + " ");
                }
                Console.CursorTop++;
                Console.CursorLeft = 0;
            }
            Console.WriteLine();
        }


        public static void jugar(char[,] m, List<string> palabras, List<int> orientaciones,
                                    List<Tuple<int, int>> posiciones1, int dim)
        {
            Console.Clear();
            Console.WriteLine("Juguemos!!");
            Console.Write("Tenés que encontrar las siguientes palabras:");
            Console.Write("'{0}', '{1}' y '{2}'.", palabras[0], palabras[1], palabras[2]);
            Console.WriteLine();

            int count = 0;
            bool continuar = false;
            List<Tuple<int, int>> posicionesSolucion = new List<Tuple<int, int>> { };
            try //bloque de código para la excepción
            {

                while (count != 3)
                {
                    Console.Clear();
                    Console.Write("Tenes que encontrar las siguientes palabras:");
                    Console.WriteLine("'{0}', '{1}' y '{2}'.", palabras[0], palabras[1], palabras[2]);
                    Console.WriteLine("{0}/3 Encontradas", count);
                    dibujarMatriz(m, dim);
                    Console.Write("Ingrese una columna: ");
                    int posX = int.Parse(Console.ReadLine()) - 1;
                    Console.WriteLine();
                    Console.Write("Ingrese una fila: ");
                    int posY = int.Parse(Console.ReadLine()) - 1;
                    Console.WriteLine();
                    int posicion = 0;

                    for (int i = 0; i < posiciones1.Count; i++)
                    {
                        if (posX == (posiciones1[i].Item1) && posY == (posiciones1[i].Item2))
                        {

                            continuar = true;
                            posicion = i;
                        }
                    }
                    if (continuar == true)
                    {
                        int sig = 0;
                        Console.Write("Ingrese orientacion (Vertical = 0, Horizontal = 1): ");
                        int or;
                        do
                        {
                            or = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            if (or == 0 || or == 1)
                            {
                                sig = 1;
                            }
                            if (or > 1) //Si la orientación ingresada está fuera de 
                                        // las orientaciones 0 e 1, te vuelve a pedir la 
                                        //orientacion
                            {
                                Console.WriteLine("Esa orientación no existe!");
                                Console.WriteLine("Intentelo nuevamente!");
                            }

                        } while (sig == 0);



                        if (continuar == true)
                        {
                            string palabra;
                            Console.Write("Ingrese la palabra: ");
                            palabra = Console.ReadLine();
                            if (palabra == palabras[posicion])
                            {
                                System.Threading.Thread.Sleep(500);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(palabras[posicion], Console.ForegroundColor);
                                Console.WriteLine();
                                Console.ResetColor();
                                count++;

                            }
                            else
                            {
                                Console.WriteLine("La palabra es incorrecta! Intenta nuevamente");
                                Sopa();
                            }
                        }
                    }

                    else if (continuar == false)
                    {
                        Console.WriteLine("Has perdido, apriete una tecla para continuar.");
                        Console.ReadKey();
                        Sopa();
                    }
                }

                if (count == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Ganaste el juego!!!");
                    Console.Write("Pulsa cualquier tecla para volver al Sopa..");
                    Console.ReadKey();
                    Sopa();
                }
            }
            catch (FormatException) //Agarra el error del error de formato por si se escribió un string en vez de un int y devolver un mensaje
            {
                Console.WriteLine("Ocurrió un error.");
                System.Threading.Thread.Sleep(500);

            }
            finally //
            {
                Console.WriteLine("Sólo números. Reiniciando.");
                System.Threading.Thread.Sleep(500);
                Console.WriteLine(".");
                System.Threading.Thread.Sleep(250);
                Console.WriteLine(".");
                System.Threading.Thread.Sleep(150);
                Console.WriteLine(".");
                System.Threading.Thread.Sleep(50);
                Sopa();

            }
        }
    }
}