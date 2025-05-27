using Clean.Domain.Common.Entities;
using Clean.Domain.Entities.Customers.Primitives;

namespace Clean.Domain.Entities.Customers;

public class Customer : BaseEntity<int>
{
    public override void ValidateInvariants() { }

    #region Fields

    public CustomerFirstName FirstName { get; set; } = null!;
    public CustomerLastName LastName { get; set; } = null!;
    public CustomerMobile Mobile { get; set; } = null!;
    public CustomerNationalCode NationalCode { get; set; } = null!;

    #endregion
}
