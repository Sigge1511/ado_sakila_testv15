﻿using Microsoft.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
namespace ado_sakila_testv15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connection= new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Sakila; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");

            Console.WriteLine("Välj om du vill söka på \n  1. Förnamn \n  2. Efternamn");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                //förnamn
                //var command1 = new SqlCommand("förnamn", connection); //här ska sql uttryck läggas in
                //connection.Open(); //öppnar koppling till db

                //var returninfo = command1.ExecuteReader();

                //connection.Close(); //Stänger min koppling till db
            }
            else if (choice == 2)
            {
                //efternamn
                //var command2 = new SqlCommand("efternamn", connection); //här ska sql uttryck läggas in
                //connection.Open(); //öppnar koppling till db

                //var returninfo = command2.ExecuteReader();

                //connection.Close(); //Stänger min koppling till db
            }
            else 
            {
                Console.WriteLine("Ogiltigt val. Programmet avslutas");
            }


        }
    }
}
