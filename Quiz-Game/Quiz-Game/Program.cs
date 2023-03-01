using System;

namespace Quiz_Game
{ 
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Metodo para que se ejecute el juego
            await Juego.InicioJuego();

        }
    }
}
