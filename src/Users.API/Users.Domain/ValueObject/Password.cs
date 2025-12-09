using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Domain.ValueObject
{
    public record Password
    {
        public string Value { get; }
        public Password(string value) => Value = value;
    }
}
