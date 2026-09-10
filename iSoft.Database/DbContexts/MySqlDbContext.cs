using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.DbContexts
{
  public class MySqlDbContext : CommonDbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      DotNetEnv.Env.Load();
      string? host = Environment.GetEnvironmentVariable("DB_CONFIG_ADDRESS");
      string? port = Environment.GetEnvironmentVariable("DB_CONFIG_PORT");
      string? user = Environment.GetEnvironmentVariable("DB_CONFIG_USERNAME");
      string? password = Environment.GetEnvironmentVariable("DB_CONFIG_PASSWORD");
      string? databaseName = Environment.GetEnvironmentVariable("DB_CONFIG_DATABASE_NAME");

      if (!optionsBuilder.IsConfigured)
      {
        var connectionString =
          $"Server={host};" +
          $"Port={port};" +
          $"Database={databaseName};" +
          $"User ID={user};" +
          $"Password={password};" +
          "DateTimeKind=Utc;";

        optionsBuilder.UseMySql(
          connectionString,
          ServerVersion.AutoDetect(connectionString));
      }
    }
  }
}
