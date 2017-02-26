using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Moq;
using NUnit.Framework;
using SortApplication.BussinessLogic;
using SortApplication.BussinessLogic.Enums;
using SortApplication.BussinessLogic.Interfaces;
using SortApplication.DataAccess;
using SortApplication.DataAccess.Interfaces;

namespace SortApplicationTest.BussinessLogic
{
    [TestFixture]
    public class FileHandlingTest
    {
        private const string OutputFile = "outputFileTest.txt";
        private const string DataPath = "..\\..\\..\\Data\\";
        private string _fileLocation = AppDomain.CurrentDomain.BaseDirectory + DataPath;
        private const string InputFile = "RandomPeopleList.txt";
        private const string ExpectedSortedByAscending = "sortedByAscendingNames.txt";
        private const string ExpectedSortedByDescending = "sortedByDescendingNames.txt";
        
        private IFileHandling _fileHandling;
        private Mock<ILogger> _mockLogger;
        private Mock<IPersonRepository> _mockPersonRepository;

        [SetUp]
        public void SetUp()
        {
            _mockLogger = new Mock<ILogger>();
            _mockPersonRepository = new Mock<IPersonRepository>();
            _fileHandling = new FileHandling(_mockPersonRepository.Object, _mockLogger.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockLogger = null;
            _mockPersonRepository = null;
            _fileHandling = null;
        }

        [Test]
        public void GivenAValidFileInput_WhenCallingFileReader_ThenDataIsAddedToRepositoryForEachPersonReturned()
        {
            // Arrange
            var expectedPeopleList = GetListOfPeopleFromFile(_fileLocation + InputFile);

            // Act
            _fileHandling.FileReader(_fileLocation + InputFile);

            // Assert
            foreach (var person in expectedPeopleList)
            {
                _mockPersonRepository.Verify(x => 
                    x.Add(It.Is<Person>(p => p.FirstName == person.FirstName && p.LastName == person.LastName)), Times.Once);
            }
        }

        [Test]
        public void GivenAValidFileInput_WhenCallingFileReaderAndPersonRepositoryThrowsAnException_ThenLoggerIsCalled()
        {
            // Arrange
            _mockPersonRepository.Setup(m => m.Add(It.IsAny<Person>())).Throws<Exception>();

            // Act
            Assert.Throws<Exception>(() => _fileHandling.FileReader(_fileLocation + InputFile));

            // Assert
            _mockLogger.Verify(x => x.WriteLog(It.IsAny<string>(), It.IsAny<Exception>()));
        }

        [Test]
        public void GivenDataInTheRepositoryAndSortingOptionIsAscending_WhenCallingFileWriter_ThenDataIsWrittenToAFile()
        {
            // Arrange
            var expectedPeopleList = GetListOfPeopleFromFile(_fileLocation + ExpectedSortedByAscending);
            _mockPersonRepository.Setup(m => m.GetPeopleByNamesAscending()).Returns(expectedPeopleList);

            // Act
            _fileHandling.FileWriter(_fileLocation + OutputFile, SortingOptions.Asc);

            // Assert
            _mockPersonRepository.Verify(m => m.GetPeopleByNamesAscending());
            var actualPeopleList = GetListOfPeopleFromFile(_fileLocation + OutputFile);
            CollectionAssert.AreEqual(expectedPeopleList.ToList(), actualPeopleList.ToList(), Comparer());
        }

        [Test]
        public void GivenDataInTheRepositoryAndSortingOptionIsDescending_WhenCallingFileWriter_ThenDataIsWrittenToAFile()
        {
            // Arrange
            var expectedPeopleList = GetListOfPeopleFromFile(_fileLocation + ExpectedSortedByDescending);
            _mockPersonRepository.Setup(m => m.GetPeopleByNamesDescending()).Returns(expectedPeopleList);

            // Act
            _fileHandling.FileWriter(_fileLocation + OutputFile, SortingOptions.Desc);

            // Assert
            _mockPersonRepository.Verify(m => m.GetPeopleByNamesDescending());
            var actualPeopleList = GetListOfPeopleFromFile(_fileLocation + OutputFile);
            CollectionAssert.AreEqual(expectedPeopleList.ToList(), actualPeopleList.ToList(), Comparer());
        }

        [Test]
        public void GivenDataInTheRepository_WhenCallingFileWriterAndPersonRepositoryThrowsAnException_ThenLoggerIsCalled()
        {
            // Arrange
            _mockPersonRepository.Setup(m => m.GetPeopleByNamesAscending()).Throws<Exception>();

            // Act
            Assert.Throws<Exception>(() => _fileHandling.FileWriter(_fileLocation + OutputFile, SortingOptions.Asc));

            // Assert
            _mockLogger.Verify(x => x.WriteLog(It.IsAny<string>(), It.IsAny<Exception>()));
        }
        
        private static Comparer<Person> Comparer()
        {
            return Comparer<Person>.Create((x, y) => x.LastName == y.LastName && x.FirstName == y.FirstName ? 0 : -1);
        }

        private IList<Person> GetListOfPeopleFromFile(string file)
        {
            IList<Person> result = new List<Person>();
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(file);
                string strline;

                while ((strline = reader.ReadLine()) != null)
                {
                    var values = strline.Split(',').Select(p => p.Trim()).ToList();
                    Person person = new PersonBuilder().WithFirstName(values[1]).WithLastName(values[0]).Build();
                    result.Add(person);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return result;
        }
    }
}