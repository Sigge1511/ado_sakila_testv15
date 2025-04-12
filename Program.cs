using Microsoft.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using System.Data;
using MySql.Data.MySqlClient;
namespace ado_sakila_testv15
{
    internal class Program
    {
        //uspSearchFilmsByActorId
        //uspSearchForActors_LastName
        //uspSearchForActors_FirstName
        static void Main(string[] args)
        {
            var connection= new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Sakila; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");

            Console.WriteLine("Välj om du vill söka på \n  1. Förnamn \n  2. Efternamn\n\n");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("Ange ett förnamn:");
                string firstname = Console.ReadLine();
                //öppna
                connection.Open(); //öppnar koppling till db
                //använd kommando
                using (var command1 = new SqlCommand("uspSearchForActors_FirstName", connection)) //här ska sql uttryck läggas in
                {
                    //Säg att det är en SP
                    command1.CommandType = CommandType.StoredProcedure;
                    //skicka med parameter
                    command1.Parameters.AddWithValue("@FirstName", firstname);

                    //Sätter igång min reader för att hämta data
                    using (SqlDataReader reader = command1.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["actor_id"]}, Förnamn: {reader["first_name"]}, Efternamn: {reader["last_name"]}");
                        }
                    }
                }
                connection.Close(); //Stänger min koppling till db
            }
            else if (choice == 2)
            {
                Console.WriteLine("Ange ett efternamn:");
                string lastname = Console.ReadLine();
                var command2 = new SqlCommand("efternamn", connection); //här ska sql uttryck läggas in
                connection.Open(); //öppnar koppling till db

                var returninfo = command2.ExecuteReader();

                connection.Close(); //Stänger min koppling till db
            }
            else
            {
                Console.WriteLine("Ogiltigt val. Programmet avslutas");
            }


        }
    }
}
