using Clean.Domain.Common.Primitives;

namespace Clean.Domain.Entities.Customers.Primitives;

public record CustomerFirstName(string Value) : BaseRecordValueObject
{
    protected override void Validate()
    {
        if (string.IsNullOrWhiteSpace(Value))
            throw new ArgumentException(@"نام مشترک الزامی می باشد", nameof(Value));
        if (Value.Length > 50)
            throw new ArgumentOutOfRangeException(nameof(Value), @"نام مشترک نباید بیش از 50 کارکتر باشد");
    }

    public static implicit operator string(CustomerFirstName objectVal)
    {
        return objectVal.Value;
    }
}
