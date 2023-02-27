using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Game
{
    public class ObtenerDatosJugador
    {
        // Metodo para obtener nombre del nuevo jugador
        public static Jugador ObtenerDatos()
        {
            Thread.Sleep(3000);
            Console.Clear();
            Jugador nuevoJugador = new Jugador();
            Console.Write("Ingrese nombre para empezar juego: ");
            string nombre = Console.ReadLine();
            if (nombre == "")
            {
                Console.WriteLine("Ingrese un valor valido");
                return ObtenerDatos();
            }
            nuevoJugador.Nombre = nombre;
            Console.Clear();
            return nuevoJugador;
        }
    }
}
