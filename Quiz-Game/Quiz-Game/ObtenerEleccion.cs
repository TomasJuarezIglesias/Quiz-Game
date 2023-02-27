using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Game
{
    public class ObtenerEleccion : Jugador
    {
        // Metodo para obtener respuesta de la pregunta
        public int ObtenerRespuesta()
        {
            Console.Write("Ingrese el numero de su respuesta: ");
            string respuesta = Console.ReadLine();
            bool canParse = int.TryParse(respuesta, out int number);

            // validacion respuesta
            if (respuesta == "" || !canParse ||int.Parse(respuesta) != 1 && int.Parse(respuesta) != 2 && int.Parse(respuesta) != 3 && int.Parse(respuesta) != 4 )
            {
                Console.WriteLine("Ingrese un numero valido");
                return ObtenerRespuesta();
            }

            Eleccion = int.Parse(respuesta);
            return Eleccion;
        }

        


    }
}
