namespace SortApplication.DataAccess
{
    /// <summary>
    /// Domain object that represents the data of a person.
    /// </summary>
    public class Person : EntityBase
    {
        internal string FirstName { get; set; }
        
        internal string LastName { get; set; }

        internal int? Age { get; set; }

        internal int? PhoneNumber { get; set; }
    }
}