using iSoft.Database.DbContexts;
using iSoft.Database.Models;
using iSoft.Database.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.Service
{
  public class TypeGoodsService
  {
    public async Task<List<TypeGoods>> GetAllAsync(bool IsContainDelete = false)
    {
      // Mỗi lần gọi dùng context riêng và giải phóng sau khi đọc xong.
      await using var context = new MySqlDbContext();
      var repository = new TypeGoodsRepository(context);
      return await repository.GetAllAsync(IsContainDelete).ConfigureAwait(false);
    }
  }
}
