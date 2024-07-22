using PersonalHub.Application.Contracts.Repositories;
using PersonalHub.Domain.Entities;
using PersonalHub.Domain.ValueObjects;
using PersonalHub.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalHub.Infrastructure.Repositories
{
    public class ToDoListRepository : GenericRepository<ToDoList, ToDoListId>, IToDoListRepository
    {
        private readonly PersonalHubDbContext _context;

        public ToDoListRepository(PersonalHubDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
