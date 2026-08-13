using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.DatabaseServer.Models
{
  [Table("I_MaterialTares")]
  public class MaterialTareEntity : BaseConnectivityCRUDEntity
  {
    #region Properties
    public Guid? MaterialId { get; set; }
    public Guid? MaterialSubId { get; set; }
    public string? SerialCode { get; set; }
    #endregion


    #region Relations

    #endregion
  }
}
