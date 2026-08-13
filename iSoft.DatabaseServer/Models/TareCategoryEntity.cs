using HSF.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.DatabaseServer.Models
{
  [Table("I_TareCategorys")]
  public class TareCategoryEntity : BaseConnectivityCRUDEntity
  {
    #region Properties
    public string? Name { get; set; }
    public float? Weight { get; set; } //Kg
    public int? TareGroup { get; set; }
    public string? Description { get; set; }
    public string? TareCode { get; set; }

    #endregion

    #region Relations
    public List<LaborProductivityRecognitionEntity>? Recognitions { get; set; }
    public List<MaterialEntity>? Materials { get; set; }
    #endregion
  }
}
