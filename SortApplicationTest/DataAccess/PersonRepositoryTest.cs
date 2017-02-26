using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SortApplication.DataAccess;
using SortApplication.DataAccess.Interfaces;

namespace SortApplicationTest.DataAccess
{
    [TestFixture]
    public class PersonRepositoryTest
    {
        private IPersonRepository _personRepository;
        private IList<Person> _context;

        [SetUp]
        public void SetUp()
        {
            _context = new List<Person>();
            _context = BuildListOfPeople();
            _personRepository = new PersonRepository(_context);
        }
        
        [TearDown]
        public void Cleanup()
        {
            _personRepository = null;
            _context = null;
        }

        [Test]
        public void GivenRandomListOfPeople_WhenCallingGetPeopleByNamesDescending_ThenSortedListOfPeopleIsReturned()
        {
            // Arrange
            IList<Person> expectedList = _context.OrderByDescending(x => x.LastName).ThenByDescending(x => x.FirstName).ToList();

            // Act
            var result = _personRepository.GetPeopleByNamesDescending();

            // Assert
            CollectionAssert.AreEqual(expectedList.ToList(), result.ToList(), Comparer());
        }

        [Test]
        public void GivenRandomListOfPeople_WhenCallingGetPeopleByNamesAscending_ThenSortedListOfPeopleIsReturned()
        {
            // Arrange
            IList<Person> expectedList = _context.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();

            // Act
            var result = _personRepository.GetPeopleByNamesAscending();

            // Assert
            CollectionAssert.AreEqual(expectedList.ToList(), result.ToList(), Comparer());
        }

        private static Comparer<Person> Comparer()
        {
            return Comparer<Person>.Create((x, y) => x.LastName == y.LastName && x.FirstName == y.FirstName ? 0 : -1);
        }

        private IList<Person> BuildListOfPeople()
        {
            Person p0 = new PersonBuilder().WithFirstName("WILL").WithLastName("BAKER").Build();
            Person p1 = new PersonBuilder().WithFirstName("LIAM").WithLastName("KENT").Build();
            Person p2 = new PersonBuilder().WithFirstName("DANIEL").WithLastName("SMITH").Build();
            Person p3 = new PersonBuilder().WithFirstName("OSCAR").WithLastName("SMITH").Build();
            Person p4 = new PersonBuilder().WithFirstName("GEORGE").WithLastName("JOHNSON").Build();
            Person p5 = new PersonBuilder().WithFirstName("NOAH").WithLastName("ROBINSON").Build();
            Person p6 = new PersonBuilder().WithFirstName("JAMES").WithLastName("LEE").Build();
            Person p7 = new PersonBuilder().WithFirstName("RALPH").WithLastName("HARRIS").Build();
            Person p8 = new PersonBuilder().WithFirstName("ANDREW").WithLastName("TAYLOR").Build();
            Person p9 = new PersonBuilder().WithFirstName("MADISON").WithLastName("MARTIN").Build();

            return new List<Person> { p0, p1, p2, p3, p4, p5, p6, p7, p8, p9 };
        }
    }
}