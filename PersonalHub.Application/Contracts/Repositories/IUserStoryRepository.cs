using PersonalHub.Domain.Entities;
using PersonalHub.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalHub.Application.Contracts.Repositories
{
    public interface IUserStoryRepository : IGenericRepository<UserStory, UserStoryId>
    {
    }
}
