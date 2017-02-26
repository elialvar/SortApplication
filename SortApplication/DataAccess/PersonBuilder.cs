using System;
using SortApplication.DataAccess.Interfaces;

namespace SortApplication.DataAccess
{
    internal class PersonBuilder : IPersonBuilder
    {
        private readonly Person _person;

        public PersonBuilder()
        {
            _person = new Person { Id = Guid.NewGuid() };
        }

        public PersonBuilder WithFirstName(string firstName)
        {
            _person.FirstName = firstName;
            return this;
        }

        public PersonBuilder WithLastName(string lastName)
        {
            _person.LastName = lastName;
            return this;
        }

        public PersonBuilder WithAge(int age)
        {
            _person.Age = age;
            return this;
        }

        public PersonBuilder WithPhoneNumber(int phoneNumber)
        {
            _person.PhoneNumber = phoneNumber;
            return this;
        }

        public Person Build()
        {
            return _person;
        }
    }
}