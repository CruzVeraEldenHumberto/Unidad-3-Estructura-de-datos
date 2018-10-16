using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_2.Cruz_Vera_Elden_Humberto_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue myQueue = new Queue(); //Crear una nueva cola
            

            myQueue.Enqueue("Hola"); // Agregar un elemento nuevo a la cola
            myQueue.Enqueue("Mundo");
            myQueue.Enqueue("xd");
            Queue myQueue2 = new Queue(); // Creacion de otra cola para verificar la sincronizacion despues

            myQueue.Clone(); // Clona los datos superficiales de la cola, no encontre manera de implementarlo

            Console.WriteLine("Tamaño de la cola: {0}", myQueue.Count); // Muestra el tamaño de la cola

            Queue miCola = Queue.Synchronized(myQueue); // Crea una cola sincronizada con la cola myQueue

            Console.WriteLine("\nmyQueue: {0}.", myQueue.IsSynchronized ? "esta sincronizada" : "no esta sincronizada"); // Determina si esta sicronzianda la cola
            Console.WriteLine("miCola: {0}.", miCola.IsSynchronized ? "esta sincronizada" : "no esta sincronizada");

            Console.WriteLine();
            for (int Cont = 0; Cont < 3; Cont++) // ciclo para ver los datos
            {
                
                Console.WriteLine(myQueue.Peek()); // ve el elemento actual de la cola
                myQueue.Dequeue(); // saca el elemento de la cola

            }

            myQueue.TrimToSize(); // Reduce o reestablece el tamaño de la cola despues de sacar elementos de una cola
            Console.WriteLine("\nTamaño de la cola: {0}", myQueue.Count); // checa el tamaño de la cola


           
            Console.ReadKey();
        }
    }
}
