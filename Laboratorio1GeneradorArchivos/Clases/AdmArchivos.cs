using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio1GeneradorArchivos.Clases
{
    class AdmArchivos
    {
        private string direccionArch;

        public AdmArchivos(string filePath)
        {
            direccionArch = filePath;
        }

        public void editarTexto(string nombreArchivo)
        {
            if (File.Exists($"{direccionArch}/{nombreArchivo}.txt"))
            {
                string linea;
                Console.WriteLine("Aniade el texto que quieras, presiona enter para nueva linea");
                Console.WriteLine("Escribe: 'save' para dejar de editar");
                do
                {
                    linea = Console.ReadLine();
                    if (linea != "save")
                    {
                        File.AppendAllText($"{direccionArch}/{nombreArchivo}.txt", linea + Environment.NewLine);
                    }
                } while (linea != "save");
                Console.WriteLine("El archivo se edito exitosamente");
            }
            else
            {
                Console.WriteLine("El archivo a editar no existe");
            }
        }

    

        public void crearArchivo(string nombreArchivo)
        {
            if (File.Exists($"{direccionArch}/{nombreArchivo}.txt"))
            {
                Console.WriteLine("El archivo con este nombre existe");
            }
            else
            {
                StreamWriter sw = new StreamWriter($"{direccionArch}/{nombreArchivo}.txt");
                Console.WriteLine($"El archivo {nombreArchivo} se creo exitosamente");
            }
        }

        public void verArchivos()
        { 
            Console.WriteLine("Lista de los Archivos");
            foreach (string archivo in Directory.GetFiles(direccionArch, "*.txt").Select(Path.GetFileName))
                Console.WriteLine($"-: {archivo}");
        }


        public void eliminarArchivo(string nombreArchivo)
        {
            if (File.Exists($"{direccionArch}/{nombreArchivo}.txt"))
            {
                File.Delete($"{direccionArch}/{nombreArchivo}.txt");
                Console.WriteLine("Archivo eliminado");
            }
            else
            {
                Console.WriteLine("El archivo a eliminar no existe");
            }
        }
    }
}
