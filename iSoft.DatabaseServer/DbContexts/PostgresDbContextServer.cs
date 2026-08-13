using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.DatabaseServer.DbContexts
{
  public class PostgresDbContextServer: CommonDbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      DotNetEnv.Env.Load();
      string server = Environment.GetEnvironmentVariable("DB_CONFIG_ADDRESS_SERVER");
      string port = Environment.GetEnvironmentVariable("DB_CONFIG_PORT_SERVER");
      string user = Environment.GetEnvironmentVariable("DB_CONFIG_USERNAME_SERVER");
      string passwords = Environment.GetEnvironmentVariable("DB_CONFIG_PASSWORD_SERVER");
      string name_db = Environment.GetEnvironmentVariable("DB_CONFIG_DATABASE_NAME_SERVER");

      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseNpgsql(
                                      $"Server={server};" +
                                      $"Port={port};" +
                                      $"Database={name_db};" +
                                      $"User Id={user};" +
                                      $"Password={passwords};"
                                      );
      }
    }
  }
}
