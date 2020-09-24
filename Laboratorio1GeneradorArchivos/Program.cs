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
            //Metodo largo Absolutamente toda la logica esta un un solo archivo
            //Codigo duplicado Algunas partes como la edicion del texto (esto esta implementado de manera implicita) se repiten tambien 
            //como algunas funciones para limpiar la pantalla o la funcion de ver archivos 
            //Excesivo uso de literales El path para ver los archivos esta hardcodeado
            //Shotgun operation: El path de los archivos esta hardcodeado y si lo cambias tendrias que cambiar de TODOS las funciones que 
            //hacen uso de esto
            //Identificadores cortos: Algunos identificadores como ex op y mas son muy ambiguos
            //Envidia de caracteristicas: Crear, Ver archivos utilizan el metodo editar
            //demasiados ifs: Existen muchos ifs anidados y esto se puede ver mas elegante con un switch
            //Codigo muerto: Como el File.exists crea un archivo cuando no existe, asi que nunca llegara al else
            //statement
            int ex;
            AdmArchivos Archivo = new AdmArchivos("../../archivos.txt");
            do
            {
                Console.WriteLine("---------Generador de archivos txt---------");
                Console.WriteLine("1. Crear txt");
                Console.WriteLine("2. Ver txt");
                Console.WriteLine("3. Eliminar txt");
                Console.WriteLine("0. Salir");
                Console.Write("Escoja una opcion:");
                ex = Convert.ToInt16(Console.ReadLine());
                Console.Clear();
                try
                {
                    if (ex == 1)
                    {
                        Archivo.crearArchivo();

                    }
                    if (ex == 2)
                    {
                        Archivo.verArchivos();

                    }
                    if(ex==3)
                    {
                        Archivo.eliminarArchivo();                        
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
