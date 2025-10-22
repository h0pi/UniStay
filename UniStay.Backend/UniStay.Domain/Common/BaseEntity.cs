using System.ComponentModel.DataAnnotations;

namespace UniStay.Domain.Common;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public DateTime? ModifiedAtUtc { get; set; }
}