using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Prova7
{
    static class DbManager
    {
        const string connectionString= @"Data Source= (localdb)\mssqllocaldb;" +
                                          "Initial Catalog = RegistrazioneUtenti;" +
                                          "Integrated Security=true;";

        public static void TrovaUtente(string username)
        {
           using(SqlConnection connection=new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select * from dbo.Utenti where Username=@Username";
                    command.Parameters.AddWithValue("@Username", username);
                    SqlDataReader reader = command.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        throw new CustomException("Utente non trovato");  //Se non trovo l'utente selezionato nel database sollevo l'eccezione personalizzata
                    }
                    else
                    {
                        Console.WriteLine("Utente già presente");
                    }
                }
                catch(SqlException ex)
                {
                    Console.WriteLine(ex.Message);   //Questa eccezione viene gestita nel momento in cui vengono rilevati problemi nel database (es. stringa di connessione errata, query scritta male ecc..)
                }
                catch(CustomException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

    }
}
