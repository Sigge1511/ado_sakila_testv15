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
                    Console.WriteLine("Felaktigt val.");
                    ReturnToMenu();
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
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("Inga skådespelare hittades med det namnet.");
                        connection.Close(); //Stänger min koppling till db
                        ReturnToMenu();
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["Actor_Id"]}, Förnamn: {reader["FirstName"]}, Efternamn: {reader["LastName"]}");
                        }
                        connection.Close(); //Stänger min koppling till db
                        SearchFilmsByActorId();
                    }
                }
                
            }
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
                //skicka med parameter till min SP
                command2.Parameters.AddWithValue("@LastName", lastname);

                //Sätter igång min reader för att hämta data
                using (SqlDataReader reader = command2.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("Inga skådespelare hittades med det namnet.");
                        connection.Close(); //Stänger min koppling till db
                        ReturnToMenu();
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["Actor_Id"]}, Förnamn: {reader["FirstName"]}, Efternamn: {reader["LastName"]}");
                        }
                        connection.Close(); //Stänger min koppling till db
                        SearchFilmsByActorId();
                    }
                }
                
            }
        }
        internal void SearchFilmsByActorId() 
        { 
            Console.WriteLine("Skriv id på den skådespelare du vill söka på:");
            int idchoice = int.Parse(Console.ReadLine());


            var connection = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Sakila; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
            connection.Open(); //öppnar koppling till db
                               //använd kommando
            using (var command3 = new SqlCommand("uspSearchFilmsByActorId", connection)) //här står namn på min SP
            {
                //Säg att det är en SP
                command3.CommandType = CommandType.StoredProcedure;
                //skicka med parameter till min SP
                command3.Parameters.AddWithValue("@ActorId", idchoice);

                //Sätter igång min reader för att hämta data
                using (SqlDataReader reader = command3.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("Inga skådespelare hittades.");
                        connection.Close(); //Stänger min koppling till db
                        ReturnToMenu();
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Filmtitel: {reader["Title"]},\t" 
                                + $"Betyg: {reader["Rating"]},\tSläpptes: {reader["Released"]}");
                        }
                        connection.Close(); //Stänger min koppling till db
                    }
                }

            }

        }
        public void ReturnToMenu()
        {
            Console.WriteLine("Tryck enter för att återgå till menyn.");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
    }
}
