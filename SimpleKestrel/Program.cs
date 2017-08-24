using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace SimpleKestrel
{
  class Program
  {
    static void Main(string[] args)
    {
      new WebHostBuilder()
        .UseKestrel(options => {
          options.Listen(IPAddress.Any, 8080);
        })
        .UseLibuv()
        .UseStartup<Startup>()
        .Build()
        .Run();
    }

    class Startup
    {
      public void Configure(IApplicationBuilder app)
      {
        app.Run(ctx => {
          var con = ctx.Connection;
          var res = "Hello World!";
          ctx.Response.ContentLength = res.Length;
          ctx.Response.ContentType = "text/plain";
          return ctx.Response.WriteAsync(res);
        });
      }
    }
  }
}
