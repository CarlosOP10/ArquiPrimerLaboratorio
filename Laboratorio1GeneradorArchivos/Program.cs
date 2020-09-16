using System;
using System.IO;
using System.Linq;

namespace Laboratorio1GeneradorArchivos
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            int ex=1;
            do
            {
                Console.WriteLine("---------Generador de archivos txt---------");
                Console.WriteLine("1. Crear txt");
                Console.WriteLine("2. Ver txt");
                Console.WriteLine("3. Eliminar txt");
                Console.WriteLine("0. Salir");
                Console.Write("Escoja una opcion:");
                ex = Convert.ToInt16(Console.ReadLine());

                try
                {
                    if (ex == 1)
                    {
                        Console.Clear();
                        Console.Write("Escribir el nombre del txt:");
                        string nombre = Console.ReadLine();
                        StreamWriter sw = new StreamWriter($"../../{nombre}.txt");
                        Console.Write("Cuantas lineas desea tener en la su archivo txt?:");
                        int lineas = Convert.ToInt16(Console.ReadLine());
                        Console.Clear();
                        string[] escrito = new string[lineas];
                        Console.WriteLine($"NOMBRE DEL ARCHIVO: {nombre}.txt");
                        for (int i = 0; i < lineas; i++)
                        { 
                            Console.WriteLine($"NUMERO DE LINEAS RESTANTES: {(lineas - i)}  EN CASO QUE DESEE FINALIZAR ESCRIBA EXIT y PRESIONE ENTER");
                            escrito[i] = Console.ReadLine();
                            if (escrito[i] == "exit" || escrito[i] == "Exit" || escrito[i] == "EXTI")
                                break;
                            else
                                sw.WriteLine($"{i+1}. {escrito[i]}");
                            Console.Clear();
                        }
                        sw.Close();
                        StreamWriter lista = File.Exists("../../archivos.txt") ? File.AppendText("../../archivos.txt") : new StreamWriter("../../archivos.txt");
                        lista.WriteLine(nombre);
                        lista.Close();
                    }
                    if (ex == 2)
                    {
                        Console.Clear();
                        if (File.Exists("../../archivos.txt"))
                        {
                            Console.WriteLine("Lista de Archivos");
                            string[] lineas = File.ReadAllLines("../../archivos.txt");
                            for (int i = 0; i < lineas.Length; i++)
                            {
                                Console.WriteLine(i + 1 + ". " + lineas[i]);
                            }
                            Console.Write("Seleccione una archivo:");
                            int op = Convert.ToInt16(Console.ReadLine());
                            if (op > lineas.Length || op < 1)
                            {
                                Console.WriteLine("Opcion invalida!");
                            }
                            else
                            {
                                StreamReader archivo = File.OpenText($"../../{lineas[op - 1]}.txt");
                                string contenido = archivo.ReadToEnd();
                                Console.WriteLine("\n" + contenido);
                                archivo.Close();
                                Console.WriteLine("Desea anadir lineas al archivo txt?  1:si  2:no");
                                int op2 = Convert.ToInt16(Console.ReadLine());
                                if(op2==1)
                                {
                                    StreamWriter aumentar = File.AppendText("../../"+lineas[op - 1]+".txt");
                                    Console.Write("¿Cuantas lineas desea anadir al archivo?");
                                    int n = Convert.ToInt16(Console.ReadLine());
                                    string[] escribir = new string[n];
                                    for (int i = 0; i < n; i++)
                                    {
                                        Console.WriteLine($"NUMERO DE LINEAS RESTANTES: {(n - i)}");
                                        escribir[i] = Console.ReadLine();
                                        aumentar.WriteLine($"{lineas.Length+i}. {escribir[i]}");
                                        Console.Clear();
                                    }
                                    aumentar.Close();
                                    Console.WriteLine("Lineas anadidas!!");
                                }
                                else
                                {
                                    Console.WriteLine("Hasta pronto!!");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("No existe ningun archivo txt generado");
                            Console.ReadKey();
                        }
                    }
                    if(ex==3)
                    {
                        Console.Clear();
                        if (File.Exists("../../archivos.txt"))
                        {
                            Console.WriteLine("Lista de Archivos");
                            string[] lineas = File.ReadAllLines("../../archivos.txt");
                            for (int i = 0; i < lineas.Length; i++)
                            {
                                Console.WriteLine(i + 1 + ". " + lineas[i]);
                            }
                            Console.Write("Seleccione una archivo para borrar:");
                            int op = Convert.ToInt16(Console.ReadLine());
                            if (op > lineas.Length || op < 1)
                            {
                                Console.WriteLine("Opcion invalida!");
                            }
                            else
                            {
                                File.Delete(lineas[op - 1] + ".txt");
                                File.WriteAllLines("../../archivos.txt", File.ReadLines("../../archivos.txt").Where(linea => linea != lineas[op - 1]).ToList());
                                Console.WriteLine("Lista Eliminada");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("No existe archivos txt aun");
                            Console.ReadKey();
                        }
                        
                    }
                    if (ex < 0 || ex > 3)
                    {
                        Console.Clear();
                        Console.WriteLine("OPCION INVALIDA");
                        Console.ReadKey();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Excepcion: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Se finalizo la ejecucion del programa.");
                }
            } while (ex != 0);
        }
    }
}
