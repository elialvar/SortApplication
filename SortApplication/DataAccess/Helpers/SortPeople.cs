using System.Collections.Generic;
using System.Linq;

namespace SortApplication.DataAccess.Helpers
{
    /// <summary>
    /// Extension methods that implement different sortings for a list of people.
    /// </summary>
    internal static class SortPeople
    {
        public static IList<Person> ByNamesAscending(this IList<Person> people)
        {
            return people.OrderBy(x => x.LastName).ThenBy(y => y.FirstName).ToList();
        }

        public static IList<Person> ByNamesDescending(this IList<Person> people)
        {
            return people.OrderByDescending(x => x.LastName).ThenByDescending(y => y.FirstName).ToList();
        }
    }
}