using System.Linq.Expressions;

namespace System.Linq
{
    public static class LinqExtensions
    {
        public static IQueryable<T> ToPage<T>(this IQueryable<T> items, int page, int pageSize) where T : class
        {
            if (page <= 0)
                page = 1;

            if (pageSize > 0)
            {
                items = items.Skip((page - 1) * pageSize).Take(pageSize);
            }
            return items;
        }

        public static T FindBy<T>(this IQueryable<T> items, Expression<Func<T, bool>> expression) where T : class
        {
            return items.Where(expression).FirstOrDefault();
        }

        public static IQueryable<T> FilterBy<T>(this IQueryable<T> items, Expression<Func<T, bool>> expression) where T : class
        {
            return items.Where(expression);
        }
    }
}
