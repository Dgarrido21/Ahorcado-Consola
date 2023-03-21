using System;
using System.Collections.Generic;

namespace Colgado
{
    class Program
    {
        static void Main(string[] args)
        {
            Palabra palabra = new Palabra(EscogerPalabra());
            do
            {
                Dibujar(palabra);
                Turno(palabra);
            } while (palabra.VerificarGanador() == false && palabra.VerificarPerdedor() == false);
            if (palabra.VerificarPerdedor())
            {
                Console.WriteLine("Has perdido");
            }
            if (palabra.VerificarGanador())
            {
                Console.WriteLine("Has ganado");
            }
        }
        static string EscogerPalabra()
        {
            Random rand = new Random();
            List<string> palabras = new List<string> { "CERVEZA", "DIEZMAR", "MARACAS", "LEYENDO", "MUTILAR" };
            return palabras[rand.Next(palabras.Count)];
        }
        static char PedirLetra()
        {
            char character = 'a';
            bool errores = true;
            do
            {
                try
                {
                    Console.WriteLine("Por favor ingrese una letra valida (sin tilde).");
                    string characters = Console.ReadLine();
                    character = Convert.ToChar(characters);
                    character = char.ToUpper(character);
                    if (character < 65 || character > 90)
                    {
                        throw new Exception("Letra ivalida");
                    }
                    errores = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Letra ivalida");
                }
            } while (errores);
            return character;
        }
        static void Turno(Palabra palabra)
        {
            palabra.VerificarLetra(PedirLetra());
            Dibujar(palabra);
        }
        static void Dibujar(Palabra palabra)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("╔═══════════════╗");
            Console.WriteLine("║               |");
            if (palabra.GetIntentos() >= 1)
            {
                Console.WriteLine("║               O");
            }
            else
            {
                Console.WriteLine("║");
            }
            if(palabra.GetIntentos() >= 4)
            {
                Console.WriteLine("║              /|\\");
            }
            else if (palabra.GetIntentos() >= 3)
            {
                Console.WriteLine("║              /|");
            }
            else if (palabra.GetIntentos() >= 2)
            {
                Console.WriteLine("║              /");
            }
            else
            {
                Console.WriteLine("║");
            }
            if (palabra.GetIntentos() >= 5)
            {
                Console.WriteLine("║               |");
            }
            else
            {
                Console.WriteLine("║");
            }
            if (palabra.GetIntentos() >= 7)
            {
                Console.WriteLine("║              / \\");
            }
            else if (palabra.GetIntentos() >= 6)
            {
                Console.WriteLine("║              / ");
            }
            else
            {
                Console.WriteLine("║");
            }
            Console.WriteLine("║");
            Console.WriteLine("║");
            Console.WriteLine(palabra.RecibirPalabra());
            Console.WriteLine();
        }
    }
}