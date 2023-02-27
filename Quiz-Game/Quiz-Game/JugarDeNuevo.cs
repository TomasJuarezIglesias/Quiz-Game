using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Game
{
    public class JugarDeNuevo
    {
        // Metodo para realizar pregunta al jugador de si quiere seguir jugando
        public static bool SeguirJugando()
        {
            Console.WriteLine("Desea jugar otra vez?");
            Console.Write("Indique SI en el caso de querer seguir jugando o NO en el caso de no querer seguir jugando: ");
            string respuesta = Console.ReadLine();
            if (respuesta.ToLower() != "si" && respuesta.ToLower() != "no")
            {
                Console.WriteLine("Ingrese una respuesta valida!");
                return SeguirJugando();
            }

            if (respuesta.ToLower() == "si")
            {
                return true;
            }

            return false;
        }

    }
}
