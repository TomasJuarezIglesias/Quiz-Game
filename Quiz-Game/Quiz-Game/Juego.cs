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
        public static void InicioJuego()
        {
            QuestionDB questionDB = new QuestionDB();
            List<Questions> list = questionDB.Get();
            Console.WriteLine("El juego se esta iniciando...");
            Thread.Sleep(1000);
            Console.Clear();
            foreach (var question in list)
            {
                bool correcto = false; // Se utiliza para saber si la eleccion del jugador es correcta

                Console.WriteLine($"La pregunta es... \n {question.Question}");
                Console.WriteLine($"Las opciones son:\n 1-{question.Answer1} \n 2-{question.Answer2} \n 3-{question.Answer3}\n 4-{question.Answer4}");
                ObtenerEleccion obtenerEleccion = new ObtenerEleccion();

                int respuesta = obtenerEleccion.ObtenerRespuesta();
                switch (respuesta) 
                {
                    case 1:
                        if (question.Answer1 == question.Correct)
                        {
                            correcto = true;
                        }
                        break;
                    case 2:
                        if (question.Answer2 == question.Correct)
                        {
                            correcto = true;
                        }
                        break;
                    case 3:
                        if (question.Answer3 == question.Correct)
                        {
                            correcto = true;
                        }
                        break;
                    case 4:
                        if (question.Answer4 == question.Correct)
                        {
                            correcto = true;
                        }
                        break;
                }

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
        }


    }
}
