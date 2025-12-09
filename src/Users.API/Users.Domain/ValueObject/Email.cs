using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Domain.ValueObject
{
    /// <summary>
    /// record - сравнивает по значениям полей
    /// record - не изменяемый тип (immutable)
    /// </summary>
    public record Email
    {
        public string Value { get; }
        public Email(string value) => Value = value;
        
    }
}
