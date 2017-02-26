using System.Collections.Generic;

namespace SortApplication.DataAccess.Interfaces
{
    /// <summary>
    /// The repository that manages the list of people.
    /// </summary>
    public interface IPersonRepository : IRepository<Person>
    {
        /// <summary>
        /// Sort the list of people ascendingly by last name followed by the first name. 
        /// </summary>
        /// <returns>Sorted list of people.</returns>
        IList<Person> GetPeopleByNamesAscending();

        /// <summary>
        /// Sort the list of people descendantly by last name followed by the first name. 
        /// </summary>
        /// <returns>Sorted list of people.</returns>
        IList<Person> GetPeopleByNamesDescending();
    }
}