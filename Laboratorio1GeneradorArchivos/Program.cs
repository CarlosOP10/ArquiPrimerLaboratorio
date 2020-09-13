using System;
using System.IO;
namespace Laboratorio1GeneradorArchivos
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            try
            {
                string[] escrito=new string[10];
                StreamWriter sw = new StreamWriter("../../ArchivoGenerado.txt");
                Console.WriteLine("escribe exit para finalizar ");
                for (int i = 0; i < 10; i++)
                {
                    escrito[i] =Console.ReadLine();
                    sw.WriteLine(escrito[i]);
                    if (escrito[i]=="exit" || escrito[i]=="Exit")
                        break;
                }
                sw.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Excepcion: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Se finalizo la ejecucion del programa.");
            }
        }
    }
}
