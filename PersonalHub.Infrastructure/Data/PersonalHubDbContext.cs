using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalHub.Infrastructure.Data
{
    public class PersonalHubDbContext : DbContext
    {
        public PersonalHubDbContext(DbContextOptions<PersonalHubDbContext> options) : base(options) { }
    }
}
