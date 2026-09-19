using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSoft.Database.Models
{
  [Table("m_users")]
  public class User
  {
    [Key]
    [Column(TypeName = "char(36)")]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string FullName { get; set; } = string.Empty;

    [MaxLength(255)]
    public string? EmployeeCode { get; set; }

    [MaxLength(255)]
    public string? IdCardCode { get; set; }

    [Column(TypeName = "tinyint(1)")]
    public bool? SyncFlag { get; set; }

    [Required]
    [MaxLength(50)]
    public string Username { get; set; } = string.Empty;

    [MaxLength(255)]
    public string? Password { get; set; }

    [MaxLength(50)]
    public string? DisplayName { get; set; }

    [MaxLength(50)]
    public string? FirstName { get; set; }

    [MaxLength(50)]
    public string? MiddleName { get; set; }

    [MaxLength(50)]
    public string? LastName { get; set; }

    [MaxLength(255)]
    public string? Email { get; set; }

    [Required]
    [MaxLength(10)]
    public string Role { get; set; } = string.Empty;

    public int? Gender { get; set; }

    [MaxLength(25)]
    public string? PhoneNumber { get; set; }

    [Column(TypeName = "datetime(6)")]
    public DateTime? Birthday { get; set; }

    [MaxLength(255)]
    public string? Address { get; set; }

    [MaxLength(20)]
    public string? CitizenId { get; set; }

    [MaxLength(255)]
    public string? Avatar { get; set; }

    [Column(TypeName = "datetime(6)")]
    public DateTime? LastLogin { get; set; }

    public int? LoginFailCount { get; set; }

    [MaxLength(255)]
    public string? UserSstp { get; set; }

    [Column(TypeName = "datetime(6)")]
    public DateTime? BlockedTo { get; set; }

    [Column(TypeName = "tinyint(1)")]
    public bool? IsAllowOverWeight { get; set; }

    [Column(TypeName = "char(36)")]
    public Guid? LocationId { get; set; }

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

    public ICollection<Permission> Permissions { get; set; } =
      new List<Permission>();

    public ICollection<RecordTruck>? RecordTrucks { get; set; }
    public ICollection<RecordWeight>? RecordWeights { get; set; }
  }
}
