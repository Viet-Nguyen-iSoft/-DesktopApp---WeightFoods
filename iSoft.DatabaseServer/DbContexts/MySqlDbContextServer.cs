using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.DatabaseServer.DbContexts
{
  public class MySqlDbContextServer : CommonDbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      DotNetEnv.Env.Load();
      string? server = Environment.GetEnvironmentVariable("DB_CONFIG_ADDRESS_SERVER");
      string? port = Environment.GetEnvironmentVariable("DB_CONFIG_PORT_SERVER");
      string? user = Environment.GetEnvironmentVariable("DB_CONFIG_USERNAME_SERVER");
      string? password = Environment.GetEnvironmentVariable("DB_CONFIG_PASSWORD_SERVER");
      string? databaseName = Environment.GetEnvironmentVariable("DB_CONFIG_DATABASE_NAME_SERVER");

      if (!optionsBuilder.IsConfigured)
      {
        var connectionString =
          $"Server={server};" +
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
