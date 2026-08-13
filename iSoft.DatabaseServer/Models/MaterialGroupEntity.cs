using HSF.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.DatabaseServer.Models
{
  [Table("I_MaterialGroups")]
  public class MaterialGroupEntity : BaseConnectivityCRUDEntity
  {
    #region Properties
    public string? Name { get; set; }
    public int? MaterialType { get; set; }
    public string? TypeName { get; set; }
    public Guid? MaterialGroupParentId { get; set; }

    #endregion

    #region Relations
    public List<MaterialEntity> Materials { get; set; } = new List<MaterialEntity>();
    #endregion
  }
}
