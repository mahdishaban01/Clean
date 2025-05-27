using Clean.Domain.Common.Primitives;

namespace Clean.Domain.Entities.Customers.Primitives;

public record CustomerLastName(string Value) : BaseRecordValueObject
{
    protected override void Validate()
    {
        if (string.IsNullOrWhiteSpace(Value))
            throw new ArgumentException(@"نام خانوادگی مشترک الزامی می باشد", nameof(Value));
        if (Value.Length > 50)
            throw new ArgumentOutOfRangeException(nameof(Value), @"نام خانوادگی مشترک نباید بیش از 50 کارکتر باشد");
    }

    public static implicit operator string(CustomerLastName objectVal)
    {
        return objectVal.Value;
    }
}

