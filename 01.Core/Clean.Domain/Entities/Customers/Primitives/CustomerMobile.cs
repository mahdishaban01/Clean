using Clean.Domain.Common.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Clean.Domain.Entities.Customers.Primitives
{
    public record CustomerMobile(string Value) : BaseRecordValueObject
    {
        protected override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Value))
                throw new ArgumentException(@"شماره موبایل نمیتواند خالی باشد", nameof(Value));
            if (int.TryParse(Value, out int intCode) && intCode == 0)
                throw new ArgumentOutOfRangeException(nameof(Value), @"تلفن نمیتواند صفر باشد");
            if (!Regex.IsMatch(Value, @"^[0-9]*$"))
                throw new ArgumentOutOfRangeException(nameof(Value), "شماره تلفن باید عدد باشد باشد");
            if (Value.Length !=11)
                throw new ArgumentOutOfRangeException(nameof(Value), @"شماره موبایل باید دقیقا 11 کارکتر باشد");
        }

    }

}
