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
    }
}
