using Microsoft.AspNetCore.Identity;

namespace Clean.Domain.Entities.Identity;

public class User : IdentityUser<Guid>
{
    public DateTime InsertOn { get; set; }
    public DateTime? UpdateOn { get; set; }
    public bool IsActive { get; set; } = true;
    public byte[] RowVersion { get; set; } = null!;
}