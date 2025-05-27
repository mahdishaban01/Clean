using Clean.Domain.Entities.Identity;

namespace Clean.Domain.Common.Entities;

public abstract class BaseEntity<TId> : IValidatableEntity where TId : IEquatable<TId>
{
    public TId Id { get; protected set; } = default!;
    public DateTime InsertOn { get; set; }
    public DateTime? UpdateOn { get; set; }
    public Guid InsertUserId { get; set; }
    public Guid? UpdateUserId { get; set; }
    public bool IsActive { get; set; } = true;
    public byte[] RowVersion { get; set; } = null!;

    public User InsertUser { get; set; } = null!;
    public User? UpdateUser { get; set; }

    public abstract void ValidateInvariants();
}
