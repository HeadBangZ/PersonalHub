using ProjectHub.Domain.Workspace.Entities;
using ProjectHub.Infrastructure.Data.Contexts;

namespace ProjectHub.Tests.Integration
{
    public class SeedTestData
    {
        public static List<T> CreateMultipleEntityData<T>(ProjectHubDbContext context, int count, Func<int, T> createEntity) where T : class
        {
            var entities = new List<T>();

            for (int i = 0; i < count; i++)
            {
                var space = createEntity(i);
                entities.Add(space);
            }

            context.Set<T>().AddRange(entities);
            context.SaveChanges();

            return entities;
        }

        public static Space CreateSpaceData(int i)
        {
            var name = $"Space {i}";
            var description = $"Description for Space {i}";
            var space = new Space(name, description);
            return space;
        }
    }
}
