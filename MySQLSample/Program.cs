using MySql.Data.MySqlClient;
using System;

namespace MySQLSample
{
  class Program
  {
    static void Main(string[] args)
    {
      var con = new MySqlConnection("server=127.0.0.1;user=root;database=mydbname;port=3306;password=mysecret;sslmode=none");
      try
      {
        Console.WriteLine("Connecting to MySQL...");
        con.Open();

        var sql = "SELECT id, name FROM user";
        var cmd = new MySqlCommand(sql, con);
        var rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
          Console.WriteLine(string.Concat(rdr[0], " - ", rdr[1]));
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
      finally
      {
        con.Close();
        Console.WriteLine("Desconnecting from MySQL...");
      }
    }
  }
}
