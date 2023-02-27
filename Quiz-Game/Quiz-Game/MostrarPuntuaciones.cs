using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Game
{
    public class MostrarPuntuaciones
    {
        // Metodo para mostrar la puntuacion de los primeros 3 jugadores
        public static void MostrarPuntuacion()
        {
            int contador = 0;
            List<Jugador> list = JugadorDB.Get();
            foreach (Jugador unJugador in list)
            {
                Console.WriteLine("Los Mayores puntuaciones son: ");
                contador++;
                Console.WriteLine($" {contador}- {unJugador.Nombre}, {unJugador.Puntuacion}");

                if (contador == 3)
                {
                    return;
                }
            }

        }

    }
}
