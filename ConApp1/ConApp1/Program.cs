using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp1
{
    internal class Program
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataReader reader;
        public static string constr = " Server=tcp:sivaboyillaserver.database.windows.net,1433;Initial Catalog=sivareddy3116Db;Persist Security Info=False;User ID=sivareddy3116;Password=sivareddy@3116;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        static void Main(string[] args)
        {
            try 
            {
                con = new SqlConnection(constr);
                cmd = new SqlCommand("select * from player", con);
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read()) 
                {
                    Console.WriteLine("Player ID: \t \t" + reader["PId"]);
                    Console.WriteLine("Player Name: \t" + reader["Pname"]);
                    Console.WriteLine("player Role: \t"+ reader["prole"]);
                    Console.WriteLine("Player Team: \t" + reader["pteam"]);
                    Console.WriteLine("\n");
                }
            }
            catch(SqlException ex){ Console.WriteLine("server Error" + ex.Message); }
            catch(Exception ex) { Console.WriteLine("Error" + ex.Message); }
            finally 
            { 
                con.Close();
                Console.ReadKey(); 
            }
        }
    }
}
