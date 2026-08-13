using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSoft.DatabaseServer.Models
{
  public class BaseCRUDEntity
  {
    [Key]
    public Guid Id { get; set; }

    public Guid? CreatedBy { get; set; }


    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss.fffZ}")]
    public DateTime? CreatedAt { get; set; }


    public Guid? UpdatedBy { get; set; }


    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss.fffZ}")]
    public DateTime? UpdatedAt { get; set; }

    public bool? DeletedFlag { get; set; }

    public long? Order { get; set; }

    public bool? EnableFlag { get; set; } = true;
  }
}
