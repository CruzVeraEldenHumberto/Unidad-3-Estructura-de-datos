using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_1.Cruz_Vera_Elden_Humberto
{
    class Program  // Aqui me faltó orientarlo a objetos
    {
        static void Main(string[] args)
        {   // Variables de captura para el usuario
            int NumMaterias = 0;
            string NombreMateria;
            string NombreAlumno;
            int CantAlum = 0;
            int Calificacion = 0;
            int TotalAlum = 0;

            // Variables utilizadas como contadores en unos ciclos
            int ContAux = 0;
            int ContAux2 = 0;
            int ContAux3 = 0;
            int ContAux4 = 0;

            // Declaración de listas, cada una contiene distintos datos ingresados por el usuario
            List<object> materias = new List<object>(); // Lista que contiene las materias y sus nombres
            List<int> cantidadalumnos = new List<int>(); // Lista que contiene los alumnos de cada clase
            List<object> nombres = new List<object>(); // Lista de nombres de los alumnos
            List<int> calificaciones = new List<int>(); // Lista de calificaciones de cada alumno 

            try // bloque try para el manejo de excepciones
            {
                Console.Write("Capture el número de materias existentes: ");
                NumMaterias = Int16.Parse(Console.ReadLine());  // Captura de la cantidad de numero de materias

                Console.WriteLine();

                for (int Cont = 0; Cont < NumMaterias; Cont++) // Ciclo for para capturar el nombre de la materia y la cantidad
                    // de alumnos
                {
                    Console.Write("Capture el nombre de la materia: ");
                    NombreMateria = Console.ReadLine(); // Captura del nombre de la materia
                    materias.Add(NombreMateria); // Se agrega el valor de NombreMateria a la lista materias

                    Console.Write("Capture la cantidad de alumnos: ");
                    CantAlum = Int16.Parse(Console.ReadLine()); // Captura de la cantidad de alumnos por clase
                    cantidadalumnos.Add(CantAlum); // Se agrega el valor de CantAlum a la lista cantidadalumnos
                    TotalAlum = cantidadalumnos[Cont] + TotalAlum; // Se obtiene el total de alumnos para ser utilizado despues

                    Console.WriteLine();
                }

                Console.Clear(); // Limpia la pantalla de la consola

                do // Ciclos anidados
                {
                    for (int Contador = 0; Contador < cantidadalumnos[ContAux2]; Contador++) // Ciclo para capturar
                        // Captura nombre y calificacion del alumno de la clase
                    {
                        Console.Write("Nombre del alumno #{0} de la materia de {1}: ", Contador + 1, materias[ContAux2]);
                        NombreAlumno = Console.ReadLine(); // captura el nombre del alumno
                        nombres.Add(NombreAlumno); // Se agrega el valor de NombreAlumno a nombres

                        Console.Write("Ingrese la calificación del alumno: ");
                        Calificacion = Int16.Parse(Console.ReadLine()); // Captura la calificación del alumno

                        while (Calificacion < 0 || Calificacion > 100) // Ciclo que evita que el usuario ingrese una cantidad 
                            // indebida
                        {
                            Console.WriteLine("Por favor ingrese una calificación valida");
                            Console.Write("Nombre del alumno #{0} de la materia de {1}: ", Contador + 1, materias[ContAux2]);
                            Calificacion = Int16.Parse(Console.ReadLine()); // Captura de calificacion del alumno
                        }

                        calificaciones.Add(Calificacion); // Añade el valor de Calificacion a calificaciones
                        Console.WriteLine();
                        ContAux++; // Contador utilizado en el ciclo do while, para que se pidan alumnos de todas
                        // las clases
                    }
                    ContAux2++; // Contador que delemita la cantidad de alumnos por clase
                    
                } while (ContAux < TotalAlum); // mientras este contador sea menor al total de alumnos, se seguira ejecutando

                Console.Clear();

                foreach (object datos in materias) // Ciclo que al pasar por el recorrido despliega una clase distinta
                {
                    Console.WriteLine("Clase: {0}", datos); // Imprime nombre de la clase
                    
                    Console.WriteLine("Alumnos en clase {0} y su calificacion:", datos);
                    Console.WriteLine();
                    for (int Contador = 0; Contador < cantidadalumnos[ContAux3]; Contador++) 
                        // Ciclo que por cada recorrido va mostrando un alumno a la vez de la clase actual
                    {
                        Console.WriteLine(nombres[ContAux4] + ", Calificacion: " + calificaciones[ContAux4] + "\n");
                        ContAux4++;
                    }
                    ContAux3++;
                }
            }

            catch(Exception x) // Al atrapar una excepcion, despliega un mensaje
            {
                Console.WriteLine(x.Message);
            }


            finally // Si el programa encuentra una excepcion o no, muestra el siguiente mensaje
            {
                Console.Write("\nGracias por ejecutar este programa, presione cualquier tecla para salir: ");
                Console.ReadKey();
            }

        }
    }
}
