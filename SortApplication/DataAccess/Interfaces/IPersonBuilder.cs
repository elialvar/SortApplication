namespace SortApplication.DataAccess.Interfaces
{
    /// <summary>
    /// Consruct a Domain Object 'Person'.
    /// </summary>
    internal interface IPersonBuilder
    {
        PersonBuilder WithFirstName(string firstName);

        PersonBuilder WithLastName(string lastName);

        PersonBuilder WithAge(int age);

        PersonBuilder WithPhoneNumber(int phoneNumber);

        Person Build();
    }
}
