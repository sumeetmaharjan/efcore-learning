using System.Linq;

namespace EFCoreMovies.Utilities
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> source, int page, int records)
        {
            return source
                .Skip((page - 1) * records)
                .Take(records);
        }
    }
}
