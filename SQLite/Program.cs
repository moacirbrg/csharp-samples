using Microsoft.Data.Sqlite;
using System;

namespace SQLite
{
  class Program
  {
    static void Main(string[] args)
    {
      var connString = new SqliteConnectionStringBuilder() { DataSource = "test.db" };
      using (var conn = new SqliteConnection(connString.ToString()))
      {
        conn.Open();

        using (var transaction = conn.BeginTransaction())
        {
          var cmd1 = conn.CreateCommand();
          cmd1.Transaction = transaction;
          cmd1.CommandText = "CREATE TABLE IF NOT EXISTS user ([id] INTEGER PRIMARY KEY AUTOINCREMENT, [name] VARCHAR(50))";
          cmd1.ExecuteNonQuery();

          var cmd2 = conn.CreateCommand();
          cmd2.Transaction = transaction;
          cmd2.CommandText = "INSERT INTO user (name) VALUES ($name)";
          cmd2.Parameters.AddWithValue("$name", "Moacir");
          cmd2.ExecuteNonQuery();

          var cmd3 = conn.CreateCommand();
          cmd3.Transaction = transaction;
          cmd3.CommandText = "SELECT id, name FROM user";
          using (var reader = cmd3.ExecuteReader())
          {
            while (reader.Read())
            {
              var id = reader.GetInt32(0);
              var name = reader.GetString(1);
              Console.WriteLine(string.Format("O id do usuário {0} é {1}", name, id));
            }
          }

          transaction.Commit();
        }
      }
    }
  }
}
