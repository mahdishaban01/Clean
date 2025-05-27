using Microsoft.AspNetCore.Identity;

namespace Clean.Domain.Entities.Identity;

public class Role : IdentityRole<Guid> 
{
    public DateTime InsertOn { get; set; }
    public DateTime? UpdateOn { get; set; }
    public Guid InsertUserId { get; set; }
    public Guid? UpdateUserId { get; set; }
    public bool IsActive { get; set; } = true;
    public byte[] RowVersion { get; set; } = null!;

    public User InsertUser { get; set; } = null!;
    public User? UpdateUser { get; set; }
}