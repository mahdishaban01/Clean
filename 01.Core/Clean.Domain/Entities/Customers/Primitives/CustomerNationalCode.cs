using Clean.Domain.Common.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Clean.Domain.Entities.Customers.Primitives;

public record CustomerNationalCode(string Value) : BaseRecordValueObject
{
    protected override void Validate()
    {
        if (string.IsNullOrWhiteSpace(Value))
            throw new ArgumentException("کد ملی نمی‌تواند خالی باشد", nameof(Value));

        if (!Regex.IsMatch(Value, @"^[0-9]*$"))
            throw new ArgumentOutOfRangeException(nameof(Value), "کد ملی باید دقیقا 10 رقم عددی باشد");
    }
}
