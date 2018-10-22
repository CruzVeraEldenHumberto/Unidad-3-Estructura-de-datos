using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_3_Cruz_Vera_Elden_Humberto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; //Codigo para poder imprimir los tipos de carta
            Blackjack partida = new Blackjack(); // Manda a llamar el objeto partida de la clase Blackjack
            partida.Jugar(); // Se invoca el metodo Jugar para que comience el juego
            Console.ReadKey(); // Pausar la pantalla

        }
    }
}
