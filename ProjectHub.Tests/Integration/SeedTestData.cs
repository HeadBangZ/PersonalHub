using ProjectHub.Domain.Workspace.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHub.Tests.Integration
{
    public class SeedTestData
    {
        public static List<Space> CreateMultipleSpaceData(int count)
        {
            var spaces = new List<Space>();

            for (int i = 0; i < count; i++)
            {
                var name = $"Space {i}";
                var description = $"Description for Space {i}";
                var space = CreateData(name, description);
                spaces.Add(space);
            }

            return spaces;
        }

        public static Space CreateData(string name, string description)
        {
            var space = new Space(name, description);

            return space;
        }
    }
}
