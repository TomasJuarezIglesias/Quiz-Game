using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Game
{
    public class QuestionDB : Questions
    {
        // Informacion necesaria para conexion a base de datos
        private string ConnectionDB = "Data Source=TOMASJUAREZ; Initial Catalog=Questions; User=soporte; Password=123"; 
       
        // Metodo para obtener lista de preguntas, junto con sus respuestas para el juego
        public List<Questions> Get()
        {
            List<Questions> list = new List<Questions>();
            string query = "select Question, Answer1, Answer2, Answer3, Answer4, Correct from Question";

            using (SqlConnection connection = new SqlConnection(ConnectionDB))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Questions questions = new Questions();

                    questions.Question = reader.GetString(0);
                    questions.Answer1 = reader.GetString(1);
                    questions.Answer2 = reader.GetString(2);
                    questions.Answer3 = reader.GetString(3);
                    questions.Answer4 = reader.GetString(4);
                    questions.Correct = reader.GetString(5);
           
                    list.Add(questions);

                }

                reader.Close();
                connection.Close();
            }

            return list;
        }


    }
}
