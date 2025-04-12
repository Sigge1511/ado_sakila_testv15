using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;


namespace ado_sakila_testv15
{
    internal class HelperClass
    {
        internal void Menu() 
        {
            Console.WriteLine("Meny");
            Console.WriteLine("1. Sök efter förnamn");
            Console.WriteLine("2. Sök efter efternamn");
            Console.WriteLine("Välj genom att skriva en siffra");
            int choice = int.Parse(Console.ReadLine());
            MenuSelection(choice);
        }
        internal void MenuSelection(int choice) 
        {
            switch (choice) 
            {
                case 1:
                    Console.Clear();
                    SearchByFirstName();
                    break;
                case 2:
                    Console.Clear();
                    SearchByLastName();
                    break;
                default:

                    break;
            
            }
        }
        internal void SearchByFirstName()
        {
            var connection = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Sakila; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");

            Console.WriteLine("Ange ett förnamn:");
            string firstname = Console.ReadLine();
            //öppna
            connection.Open(); //öppnar koppling till db
                               //använd kommando
            using (var command1 = new SqlCommand("uspSearchForActors_FirstName", connection)) //här står namn på min SP
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
                        Console.WriteLine($"ID: {reader["Actor_Id"]}, Förnamn: {reader["FirstName"]}, Efternamn: {reader["LastName"]}");
                    }
                }
                SearchFilmsByActorId();
            }
            connection.Close(); //Stänger min koppling till db
        }
        internal void SearchByLastName()
        {
            var connection = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Sakila; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");

            Console.WriteLine("Ange ett efternamn:");
            string lastname = Console.ReadLine();
            //öppna
            connection.Open(); //öppnar koppling till db
                               //använd kommando
            using (var command2 = new SqlCommand("uspSearchForActors_LastName", connection)) //här står namn på min SP
            {
                //Säg att det är en SP
                command2.CommandType = CommandType.StoredProcedure;
                //skicka med parameter
                command2.Parameters.AddWithValue("@LastName", lastname);

                //Sätter igång min reader för att hämta data
                using (SqlDataReader reader = command2.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["Actor_Id"]}, Förnamn: {reader["FirstName"]}, Efternamn: {reader["LastName"]}");
                    }
                }
                SearchFilmsByActorId();
            }
        }
        internal void SearchFilmsByActorId() 
        { 
        
        
        }
        
    }
}
