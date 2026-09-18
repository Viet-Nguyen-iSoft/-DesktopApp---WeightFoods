using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSoft.Database.Models
{
  [Table("m_permissions")]
  public class Permission
  {
    [Key]
    [Column(TypeName = "char(36)")]
    public Guid Id { get; set; }

    [MaxLength(255)]
    public string? Name { get; set; }

    [MaxLength(255)]
    public string? PermissionCode { get; set; }

    public int? ViewFlag { get; set; }
    public int? EditFlag { get; set; }
    public int? DeleteFlag { get; set; }

    [Column(TypeName = "tinyint(1)")]
    public bool? IsUsedViewFlag { get; set; }

    [Column(TypeName = "tinyint(1)")]
    public bool? IsUsedCreateNewFlag { get; set; }

    [Column(TypeName = "tinyint(1)")]
    public bool? IsUsedEditFlag { get; set; }

    [Column(TypeName = "tinyint(1)")]
    public bool? IsUsedDeleteFlag { get; set; }

    [Column(TypeName = "tinyint(1)")]
    public bool? IsUsedCopyFlag { get; set; }

    [Column(TypeName = "tinyint(1)")]
    public bool? IsUsedRenewFlag { get; set; }

    [Column(TypeName = "tinyint(1)")]
    public bool? IsUsedApproveFlag { get; set; }

    [Column(TypeName = "tinyint(1)")]
    public bool? IsUsedImportFlag { get; set; }

    [Column(TypeName = "tinyint(1)")]
    public bool? IsUsedExportFlag { get; set; }

    [MaxLength(255)]
    public string? Description { get; set; }

    [Column(TypeName = "tinyint(1)")]
    public bool? DeletedFlag { get; set; }

    [Column(TypeName = "char(36)")]
    public Guid? CreatedBy { get; set; }

    [Column(TypeName = "datetime(6)")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "char(36)")]
    public Guid? UpdatedBy { get; set; }

    [Column(TypeName = "datetime(6)")]
    public DateTime? UpdatedAt { get; set; }

    public long? Order { get; set; }

    [Column(TypeName = "tinyint(1)")]
    public bool? EnableFlag { get; set; }

    [MaxLength(100)]
    public string? SerialCode { get; set; }

    public ICollection<User> Users { get; set; } = new List<User>();
  }
}
