using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Game
{
    public class JugadorDB
    {
        // Metodo que realiza una lista de la puntuacion de los jugadores
        public static List<Jugador> Get()
        {
            string ConnectionDB = "Data Source=TOMASJUAREZ; Initial Catalog=Jugadores; User=soporte; Password=123";
            string query = "select Nombre, Puntuacion from Jugador";

            List<Jugador> list = new List<Jugador>();

            using (SqlConnection conection = new SqlConnection(ConnectionDB))
            {
                SqlCommand command = new SqlCommand(query, conection);
                conection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Jugador unJugador = new Jugador();
                    unJugador.Nombre = reader.GetString(0);
                    unJugador.Puntuacion = reader.GetInt32(1);

                    list.Add(unJugador);
                }

                reader.Close();
                conection.Close();
            }

            return list;
        }

        // Metodo para agregar un nuevo jugador a la tabla de la base de datos
        public static void Insert(Jugador unJugador)
        {
            string ConnectionDB = "Data Source=TOMASJUAREZ; Initial Catalog=Jugadores; User=soporte; Password=123";
            string query = "Insert Into Jugador (Nombre, Puntuacion) values (@Nombre, @Puntuacion)";
            using (SqlConnection conection = new SqlConnection(ConnectionDB))
            {
                SqlCommand command = new SqlCommand(query, conection);
                command.Parameters.AddWithValue("@Nombre", unJugador.Nombre);
                command.Parameters.AddWithValue("@Puntuacion", unJugador.Puntuacion);
                conection.Open();
                command.ExecuteNonQuery();
                conection.Close();
            }

        }

    }
}
