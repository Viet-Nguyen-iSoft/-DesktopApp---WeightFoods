using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iSoft.Database.DbContexts;
using iSoft.Database.Models;
using iSoft.Database.Repositorys;

namespace iSoft.Database.Service
{
  public class ClientService
  {
    public async Task<List<Client>> GetAllAsync(bool IsContainDelete = false)
    {
      // Mỗi lần gọi dùng context riêng và giải phóng sau khi đọc xong.
      await using var context = new MySqlDbContext();
      var repository = new ClientRepository(context);
      return await repository.GetAllAsync(IsContainDelete).ConfigureAwait(false);
    }
  }
}
