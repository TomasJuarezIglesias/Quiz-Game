using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Game
{
    public class Juego
    {
        // Metodo donde se realiza las llamadas a metodos para el funcionamiento del juego
        public static async Task<Task> InicioJuego()
        {
            // Metodo asincronico para obtener preguntas de la DB para el juego
            var task = QuestionDB.Get();
            // Se muestra los mayores puntuajes
            MostrarPuntuaciones.MostrarPuntuacion();
            // Se obtiene el nombre del nuevo jugador
            Jugador unJugador = ObtenerDatosJugador.ObtenerDatos();
            
            Console.WriteLine("El juego se esta iniciando...");
            Thread.Sleep(1000);
            Console.Clear();

            List<Questions> list = await task;
            foreach (var question in list)
            {
                Console.Clear();
                bool correcto = false; // Se utiliza para saber si la eleccion del jugador es correcta

                Console.WriteLine($"La pregunta es... \n{question.Question}");
                Console.WriteLine($"Las opciones son:\n 1-{question.Answer1} \n 2-{question.Answer2} \n 3-{question.Answer3}\n 4-{question.Answer4}");
                ObtenerEleccion obtenerEleccion = new ObtenerEleccion();

                int respuesta = obtenerEleccion.ObtenerRespuesta();

                // switch para validacion de si la respuesta fue correcta
                switch (respuesta) 
                {
                    case 1:
                        if (question.Answer1 == question.Correct)
                        {
                            correcto = true;
                            unJugador.Puntuacion++;
                        }
                        break;
                    case 2:
                        if (question.Answer2 == question.Correct)
                        {
                            correcto = true;
                            unJugador.Puntuacion++;
                        }
                        break;
                    case 3:
                        if (question.Answer3 == question.Correct)
                        {
                            correcto = true;
                            unJugador.Puntuacion++;
                        }
                        break;
                    case 4:
                        if (question.Answer4 == question.Correct)
                        {
                            correcto = true;
                            unJugador.Puntuacion++;
                        }
                        break;
                }
                
                // validador para decirle al jugador si su respuesta fue correcta
                if (correcto)
                {
                    Console.Clear();
                    Console.WriteLine("Tu respuesta ha sido correcta!!!");
                    Thread.Sleep(1000);
                    correcto = false; // Se lo vuelve a valor original para proxima pregunta
                    Console.Clear();
                    Console.WriteLine("Pasando a la siguiente pregunta.....");
                    Thread.Sleep(500);

                    continue;
                }

                Console.Clear();
                Console.WriteLine("Respuesta erronea");
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine("Pasando a la siguiente pregunta.....");
                Thread.Sleep(500);
            }
            // Muestra de puntuacion realizada
            Console.Clear();
            Console.WriteLine("Fin de las preguntas");
            Console.WriteLine($"Su puntuacion fue: {unJugador.Puntuacion}");
            Thread.Sleep(1000);
            Console.Clear();
            
            // Guarda datos jugador en la DB 
            JugadorDB.Insert(unJugador);

            // se obtiene un bool conrespecto a la respuesta del jugador
            bool seguirJugando = JugarDeNuevo.SeguirJugando();

            if (seguirJugando)
            {
                Console.WriteLine("Escogio seguir jugando");
                Thread.Sleep(1000);
                Console.Clear();
                return InicioJuego();
            }

            

            // cualquier task 
            // Tan solo se utiliza para lograr hacer un metodo recursivo
            Console.WriteLine("Decidio no seguir jugando");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Fin del Juego");
            return task;    
        }


    }
}
