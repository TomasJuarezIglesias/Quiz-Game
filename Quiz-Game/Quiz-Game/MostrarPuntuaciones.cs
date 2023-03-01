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
            List<Jugador> Jugadores = JugadorDB.Get();
            var jugadoresOrdenados = Jugadores.OrderByDescending(x => x.Puntuacion).ToList();

            Console.WriteLine("Los Mayores puntuaciones son: ");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($" {i + 1}- {jugadoresOrdenados[i].Nombre}, {jugadoresOrdenados[i].Puntuacion}");

            }
            
        }

    }
}
