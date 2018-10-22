using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_3_Cruz_Vera_Elden_Humberto
{
    public class Carta // Se crea una clase Carta para poder instanciar un objeto de ella
    {
        // Atributos que formaran parte de un objeto carta
        public int Valor { get; set; }
        public string Tipo { get; set; }

        public Carta(int value, string type) // El constructor recibe dos parametros para crear el objeto
        { // Se asignan los valores del constructor a los atributos
            Valor = value;
            Tipo = type;
        }
    }
}
