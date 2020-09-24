using System;
using System.IO;
using System.Linq;
using Laboratorio1GeneradorArchivos.Clases;
namespace Laboratorio1GeneradorArchivos
{
    class MainClass
    {
        public static void Main(string[] args)
        {
   
            int opcion;
            AdmArchivos Archivo = new AdmArchivos("../../Archivos txt");
            do
            {
                Console.WriteLine("---------Generador de archivos txt---------");
                Console.WriteLine("1. Crear txt");
                Console.WriteLine("2. Ver txt");
                Console.WriteLine("3. Editar txt");
                Console.WriteLine("4. Eliminar txt");
                Console.WriteLine("0. Salir");
                Console.Write("Escoja una opcion:");
                opcion = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                try
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("Ingrese el nombre del archivo");
                            Archivo.crearArchivo(Console.ReadLine());
                        break;

                        case 2:
                            Archivo.verArchivos();
                        break;

                        case 3:
                            Console.WriteLine("Ingrese el nombre del archivo para editar");
                            Archivo.editarTexto(Console.ReadLine());
                        break;

                        case 4:
                            Console.WriteLine("Ingrese el nombre del archivo para eliminar");
                            Archivo.eliminarArchivo(Console.ReadLine());
                        break;

                        default:
                            Console.WriteLine("OPCION INVALIDA");
                        break;
                    }

                
                }
                catch (Exception e)
                {
                    Console.WriteLine("Excepcion: " + e.Message);
                }
                finally
                {
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (opcion != 0);
        }
    }
}
