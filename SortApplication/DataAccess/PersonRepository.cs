using System.Collections.Generic;
using SortApplication.DataAccess.Helpers;
using SortApplication.DataAccess.Interfaces;

namespace SortApplication.DataAccess
{
    /// <summary>
    /// The repository that manages the list of people.
    /// </summary>
    internal class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(IList<Person> context) : base(context)
        {
        }

        /// <inheritdoc />
        public IList<Person> GetPeopleByNamesAscending()
        {
            return base.GetAll().ByNamesAscending();
        }

        /// <inheritdoc />
        public IList<Person> GetPeopleByNamesDescending()
        {
            return base.GetAll().ByNamesDescending();
        }
    }
}