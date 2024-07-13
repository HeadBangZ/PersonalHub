using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalHub.Domain.ValueObjects
{
    public readonly record struct UserId(Guid Value)
    {
        public static UserId NewUserId => new(Guid.NewGuid());
        public override string ToString() => this.Value.ToString();
    }
}
