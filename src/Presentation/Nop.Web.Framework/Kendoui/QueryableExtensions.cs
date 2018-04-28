using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace Nop.Web.Framework.Kendoui
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// Sort a collection
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="queryable">Collection</param>
        /// <param name="sort">Sort parameters</param>
        /// <returns>Result</returns>
        public static IQueryable<T> Sort<T>(this IQueryable<T> queryable, IEnumerable<Sort> sort)
        {
            if (sort != null && sort.Any())
            {
                // Create ordering expression e.g. Field1 asc, Field2 desc
                var ordering = string.Join(",", sort.Select(s => s.ToExpression()));

                // Use the OrderBy method of Dynamic Linq to sort the data
                return queryable.OrderBy(ordering);
            }

            return queryable;
        }
    }
}
