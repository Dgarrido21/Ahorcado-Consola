using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colgado
{
    class Palabra
    {
        //Atributos
        private string palabra = "";
        private char[] letra = new char[7];
        private bool[] verif = new bool[7];
        private int intentos = 7;
        //Constructor
        public Palabra(string palabra)
        {
            this.palabra = palabra;
            for (int i = 0; i < palabra.Length; i++)
            {
                letra[i] = palabra[i];
                verif[i] = false;
            }
        }
        //Funciones
        public void VerificarLetra(char letra)
        {
            if (palabra.Contains(letra))
            {
                for (int i = 0; i < palabra.Length; i++)
                {
                    if (this.letra[i] == letra)
                    {
                        verif[i] = true;
                    }
                }
            }
            else
            {
                intentos--;
            }
        }
        public bool VerificarGanador()
        {
            bool ganador = true;
            for (int i = 0; i < palabra.Length; i++)
            {
                if (verif[i] == false)
                {
                    ganador = false;
                }
            }
            return ganador;
        }
        public bool VerificarPerdedor()
        {
            return (intentos <= 0);
        }
        public string RecibirPalabra()
        {
            string enviar = "";
            for (int i = 0; i < palabra.Length; i++)
            {
                if (verif[i])
                {
                    enviar += letra[i];
                }
                else
                {
                    enviar += '_';
                }
                enviar += ' ';
            }
            return enviar;
        }
        public int GetIntentos()
        {
            return intentos;
        }
    }
}
