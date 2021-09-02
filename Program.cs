using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ejercicio2Unidad4
{
    
        namespace Agenda
        {
            class Program
            {
                static void Main(string[] args)
                {
                    Console.WriteLine("Elige una opcion:");
                    Console.WriteLine("1 - Crear");
                    Console.WriteLine("2 - Ingresar contacto");
                    Console.WriteLine("3 - Buscar contacto");
                    Console.WriteLine("4 - Eliminar Contacto");
                    Console.WriteLine("5 - Salir");
                    string R = Console.ReadLine();
                    switch (R)
                    {
                        case ("1"):
                            Console.Clear();
                            Crear(); break;
                        case ("2"):
                            Console.Clear();
                            Ingresar(); break;
                        case ("3"):
                            Console.Clear();
                            Buscar(); break;
                        case ("4"):
                            Console.Clear();
                            Eliminar(); break;
                        case ("5"):
                            Console.Clear();
                            Salir(); break;
                        default: break;
                    }
                    Console.ReadKey();
                }
                static void Crear()
                {
                    StreamWriter archivo = File.AppendText("agenda.txt");
                    Console.WriteLine("Creado");
                }
                static void Ingresar()
                {
                    StreamWriter archivo;
                    archivo = File.AppendText("agenda.txt");
                    string nombre, apellido, direccion, numero;
                    string linea;
                    Console.WriteLine("Ingrese el nombre");
                    nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese el apellido");
                    apellido = Console.ReadLine();
                    Console.WriteLine("Ingrese la dirección");
                    direccion = Console.ReadLine();
                    Console.WriteLine("Ingrese el numero de telefono");
                    numero = Console.ReadLine();
                    linea = nombre + "; " + apellido + "; " + direccion + "; " + numero;
                    archivo.WriteLine(linea);
                    archivo.Close();
                }
                static void Buscar()
                {
                    StreamReader lectura;
                    string[] datos = new string[4];
                    char delimitador = ';';
                    string cadena, dato;
                    lectura = File.OpenText("agenda.txt");
                    Console.WriteLine("Ingresa el dato para buscar:");
                    dato = Console.ReadLine();
                    cadena = lectura.ReadLine();
                    bool encontrado = false;
                    while (cadena != null && encontrado == false)
                    {
                        datos = cadena.Split(delimitador);
                        if (datos[0] == dato)
                        {
                            Console.WriteLine("Nombre: " + datos[0]);
                            Console.WriteLine("Apellido: " + datos[1]);
                            Console.WriteLine("Direccion: " + datos[2]);
                            Console.WriteLine("Numero: " + datos[3]);
                            encontrado = true;
                        }
                        else
                        {
                            cadena = lectura.ReadLine();
                        }
                    }
                    if (encontrado == false)
                    {
                        Console.WriteLine("No encontrado.");
                    }
                    lectura.Close();
                }
                static void Eliminar()
                {
                    StreamReader lectura;
                    StreamWriter cambio;
                    string[] datos = new string[3];
                    char delimitador = ';';
                    /*agenda*//*at*/
                    string cadena, proxdelte;
                    lectura = File.OpenText("agenda.txt");
                    cambio = File.CreateText("agendat.txt");
                    Console.WriteLine("Ingresa el contacto a eliminar:");
                    proxdelte = Console.ReadLine();
                    cadena = lectura.ReadLine();
                    bool encontrado = false;
                    while (cadena != null)
                    {
                        datos = cadena.Split(delimitador);
                        if (datos[0] == proxdelte)
                        {
                            encontrado = true;
                        }
                        else
                        {
                            cambio.WriteLine(cadena);
                        }
                        cadena = lectura.ReadLine();
                    }
                    if (encontrado == false)
                    {
                        Console.WriteLine("No encontrado.");
                    }
                    else
                    {
                        Console.WriteLine("Eliminado");
                    }
                    lectura.Close();
                    cambio.Close();
                    File.Delete("agenda.txt");
                    File.Move("agendat.txt", "agenda.txt");
                }
                static void Salir() { return; }
            }
        }
    
}   