using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using League.Data;

namespace League
{
  public class Program
  {
    public static void Main(string[] args)
    {
    var host = CreateHostBuilder(args).Build();
    CreateDbIfNotExists(host);
    host.Run();
    }

    // call the initializer to populate the database
    private static void CreateDbIfNotExists(IHost host)
    {
      using (var scope = host.Services.CreateScope())
      {
      var services = scope.ServiceProvider;
      var context = services.GetRequiredService<LeagueContext>();
      // context.Database.EnsureCreated();
      DbInitializer.Initialize(context);
      }
    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
          webBuilder.UseStartup<Startup>();
        });
  }
}
