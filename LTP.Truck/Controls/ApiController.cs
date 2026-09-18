using ApiSyncData;
using ApiSyncData.Req;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTP.Truck.Controls
{
  public partial class AppCore
  {
    public async Task<string> Warehouse(WarehouseUpsertRequest warehouseUpsertRequest)
    {
      try
      {
        var api = new ApiService();
        return await api.UpsertWarehouseAsync(warehouseUpsertRequest);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<string> CategoryTare(CategoryTareUpsertRequest categoryTareUpsertRequest)
    {
      try
      {
        var api = new ApiService();
        return await api.UpsertCategoryTareAsync(categoryTareUpsertRequest);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<string> TypeGoods(TypeGoodsUpsertRequest typeGoodsUpsertRequest)
    {
      try
      {
        var api = new ApiService();
        return await api.UpsertTypeGoodsAsync(typeGoodsUpsertRequest);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<string> ProductGroup(ProductGroupUpsertRequest productGroupUpsertRequest)
    {
      try
      {
        var api = new ApiService();
        return await api.UpsertProductGroupAsync(productGroupUpsertRequest);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<string> Client(ClientUpsertRequest clientUpsertRequest)
    {
      try
      {
        var api = new ApiService();
        return await api.UpsertClientAsync(clientUpsertRequest);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<string> LicensePlate(LicensePlateUpsertRequest licensePlateUpsertRequest)
    {
      try
      {
        var api = new ApiService();
        return await api.UpsertLicensePlateAsync(licensePlateUpsertRequest);
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
