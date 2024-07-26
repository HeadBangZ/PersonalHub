using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalHub.Domain.ValueObjects
{
    public interface IUserStoryItemId
    {
        Guid Value { get; }
    }

    public readonly record struct StoryTaskId(Guid Value) : IUserStoryItemId
    {
        public static StoryTaskId NewStoryTaskId => new(Guid.NewGuid());
    }

}
