using System;
using System.Collections; // Uso de la libreria System.Collections para poder utilizar la pila y la lista
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_3_Cruz_Vera_Elden_Humberto
{
    class Blackjack
    {
        private List<Carta> Baraja = new List<Carta>(); // Creación de una lista que contiene objetos Carta
        private Stack<Carta> DeckChido = new Stack<Carta>(); // Creación de una pila que contiene Cartas barajeadas

        int value;   // Parametros que son enviados al constructor de Carta() para asignar los atributos del objeto
        string type;

        char Simbolo; // Simbolo de la carta
        
        int CCC = 0; // Contador de cuantas cartas se han repartido
        int SumaValor = 0; // Variable que contiene el puntaje del juego

        int PartidasGanadas; // Partidas ganadas y perdidas
        int PartidasPerdidas;

        char JugarOtraVez; // Variable para volver a jugar

        Carta cartita; // Creacion del objeto cartita de la clase Carta

        // Creación de una variable aleatoria para poder barajear las cartas
        private readonly Random randCard = new Random(DateTime.Now.Millisecond);

        private void CrearDeck() //Metodo que crea una lista de 52 objetos tipo carta
        {
            for (int ContSimbolo = 1; ContSimbolo < 5; ContSimbolo++) // Ciclo que permite que se le asigne un simbolo
                // a cada carta
            {
                switch (ContSimbolo) //Switch para poder asignar un tipo de carta diferente en cada recorrida
                {
                    case 1:
                        Simbolo = '♥';
                        break;

                    case 2:
                        Simbolo = '♠';
                        break;
                    case 3:
                        Simbolo = '♣';
                        break;
                    case 4:
                        Simbolo = '♦';
                        break;

                }

                for (int ContValor = 1; ContValor < 14; ContValor++) // Ciclo para asignar valores y tipo de cartas
                {
                    if (ContValor == 1) // Si el contador vale 1 se le asigna la letra A al tipo de dato y valor 11
                    {
                        type = "A" + Simbolo;
                        value = 11;
                    }

                    // Si el contador vale entre 2 y 10 se le asigna el valor del contador y el tipo seria el valor
                    // del contador convertido en un string 
                    if (ContValor > 1 && ContValor < 11)
                    {
                        value = ContValor;
                        type = value.ToString() + Simbolo;
                    }
                        
                    // Si el contador vale 11 se le asigna el valor de 10 y el tipo seria J
                    if (ContValor == 11)
                    {
                        type = "J" + Simbolo;
                        value = 10;
                    }

                    // Si el contador vale 12 se le asigna el valor de 10 y el tipo seria Q
                    if (ContValor == 12)
                    {
                        type = "Q" + Simbolo;
                        value = 10;
                    }

                    // Si el contador vale 13 se le asigna el valor de 10 y el tipo seria K
                    if (ContValor == 13)
                    {
                        type = "K" + Simbolo;
                        value = 10;
                    }

                    cartita = new Carta(value, type); // Aqui se termina de crear el objeto cartita
                    Baraja.Add(cartita); // Al crear el objeto se le agrega un objeto a la lista Baraja
                }
            }
        }


        private void Barajear() // Metodo para barajear las cartas de la lista y asignarlas a una pila
        {
            CrearDeck(); // Manda a llamar a CrearDeck()
            
            int TamCartas = Baraja.Count; // Se establece el tamaño del ciclo for (52)
            int now; 
            for (int i = 0; i < TamCartas; i++) // Ciclo para barajear
            {
                now = randCard.Next(0, Baraja.Count); // Se establece cuantos valores seran aleatorios (52)
                DeckChido.Push(Baraja[now]); // Se agrega la carta a una pila DeckChido
                Baraja.RemoveAt(now); // Se remueve un elemento de Baraja para que no se repitan las cartas
            }
        }

        private object TiradaInicial() // Primer parte de la partida, se sacan dos cartas de la pila
        {
            Barajear(); // Manda a llamar a Barajear()
            
            Console.Write("Inicia el juego, presione una tecla para darle dos cartas: ");
            Console.ReadKey();
            Console.WriteLine();

            foreach (var carta in DeckChido) // Se crear un ciclo para tomar las cartas de la pila DeckChido
            {
                Console.Write(carta.Tipo); // Se despliega el tipo de carta
                Console.WriteLine();
                SumaValor = carta.Valor+SumaValor; // Se agrega el valor de la carta a este contador

                if (carta.Valor == 11 && SumaValor > 21) // Condicion para que si saca un A y pasa de 21 el valor de A sea 1
                {
                    SumaValor = SumaValor - 10;
                }

                Console.WriteLine("Su puntuación es de: {0}",SumaValor); // Imprime la puntuación
                if (SumaValor == 21) // Si se cumple la condicion se rompe el ciclo
                {
                    Console.WriteLine("\nFelicidades, usted ha ganado!");
                    PartidasGanadas++;
                    break;
                }
               
                CCC = CCC + 1; // Contador de cartas utilizadas
                
                if (CCC == 2) // Si el jugador saca dos cartas termina el ciclo
                    break;
                Console.WriteLine();
            }
            return DeckChido.Pop(); // Regresa el metodo Pop de DeckChido, con esto expulsa las cartas de la pila

        }

        private object TomarCartas() // Parte 2 del juego, el usuario tiene que tomar maximo 5 cartas
        {
            TiradaInicial(); // Manda a llamar tirada inicial

            DeckChido.Pop(); // Expulsa un elemento de la pila para que no se repita (batalle con esto como por 15 min)

            foreach (var carta in DeckChido) // Ciclo para tomar las cartas que falten
            {
                if (SumaValor == 21) // Si el usuario antes de entrar a este ciclo tuvo la suerte de tener 21 se rompe
                {
                    break;
                }

                Console.Write("\nPresione una tecla para tomar una carta: ");
                Console.ReadKey();
                Console.WriteLine();
                Console.Write(carta.Tipo); // Muestra el tipo de carta
                Console.WriteLine();
                SumaValor = carta.Valor + SumaValor; // El contador sigue sumando el puntaje del juego

                if (carta.Valor == 11 && SumaValor > 21) // Condicion para que si saca un A y pasa de 21 el valor de A sea 1
                {
                    SumaValor = SumaValor - 10;
                }

                Console.WriteLine("Su puntuación es de: {0}", SumaValor); // Imprime la puntuacion
              
                
                if (SumaValor == 21) // Si SumaValor == 21 se termina el juego, rompe el ciclo y despliega un mensaje
                {
                    Console.WriteLine("\nFelicidades, usted ha ganado!");
                    PartidasGanadas++;
                    break;
                }

                if (SumaValor>21) // Si SumaValor > 21 se termina el juego, rompe el ciclo y despliega un mensaje
                {
                    Console.WriteLine("\nUsted ha perdido la partida :(");
                    PartidasPerdidas++;
                    break;
                }

                CCC = CCC + 1; // Contador de cartas utilizas

                if (CCC == 5 & SumaValor<21) // Si se sacan 5 cartas y el usuario no tiene 21 se despliega un mensaje
                    // de derrota y se rompe el ciclo
                {
                    Console.WriteLine("\nUsted ha perdido la partida :(");
                    PartidasPerdidas++;
                    break;
                }

            }
            return DeckChido.Pop(); // Se regresa el metodo Poo de DeckChido para expulsar la carta del deck

        }

        public void Jugar() // Se le llama metodo jugar porque este invoca a los demas y tiene una opcion para volve a juagr
        {
            CCC = 0; // Cartas utilizadas por el usuario = 0 para que se pueda volver a jugar
            SumaValor = 0; // Puntaje = 0 para que se pueda volver a jugar

            TomarCartas(); // Se invoca al metodo TomarCartas()

            Console.WriteLine("\nPartidas ganadas: {0}", PartidasGanadas); // despliega partidas ganadas y perdidas
            Console.WriteLine("Partidas perdidas: {0}", PartidasPerdidas);
            
            Console.Write("\nDesea jugar otra vez? Presione s para jugar  ");
            JugarOtraVez = Console.ReadKey().KeyChar; // Opcion para poder volver a jugar
            Console.WriteLine();

            // Si se cumple la condición, se limpia la pantalla y el metodo se manda a llamar a si mismo
            if (JugarOtraVez == 's') 
            {
                Console.Clear();
                Jugar();
            }

            else // Si la condición anterior no se cumple se acaba el programa
            {
                Console.WriteLine("\nMuchas gracias por haber jugado");
                Console.WriteLine("Sus partidas ganadas fueron: {0}", PartidasGanadas); // Partidas ganadas
                Console.WriteLine("Sus partidas perdidas fueron: {0}", PartidasPerdidas); // Partidas perdidas
                Console.Write("\nPresione una tecla para salir: ");
            }
        }

    }
}
