using System;
using System.Net;

namespace HttpListenerSample
{
  class Program
  {
    static void Main(string[] args)
    {
      var listener = new HttpListener();
      listener.Prefixes.Add("http://localhost:8080/");

      listener.Start();
      Console.WriteLine("Server started!");

      Console.CancelKeyPress += delegate {
        Console.WriteLine("Server stoped!");
        listener.Stop();
      };

      while (true)
      {
        var ctx = listener.GetContext();
        var req = ctx.Request;
        var res = ctx.Response;
        Console.WriteLine("Connected...");

        var msg = "<html><body><h1>Hello World!</h1>This is my HTTP Server!</body></html>";

        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(msg);
        res.ContentLength64 = buffer.Length;
        var output = res.OutputStream;
        output.Write(buffer, 0, buffer.Length);
        output.Close();
      }
    }
  }
}
