using Microsoft.Data.SqlClient;
using System;
using System.Data;
namespace ado_sakila_testv15
{
    internal class Program
    {
        //uspSearchFilmsByActorId
        //uspSearchForActors_LastName
        //uspSearchForActors_FirstName
        static void Main(string[] args)
        {
            var helper = new HelperClass();
            helper.Menu();



            
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
