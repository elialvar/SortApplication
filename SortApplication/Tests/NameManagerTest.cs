using System.IO;
using NUnit.Framework;

namespace SortApplication.Tests
{
    /*[TestFixture]
    class NameManagerTest
    {
        private const string DataPath = "..\\..\\Tests\\Data\\";

        private INameManager _nameManager;
        private ILogger _logger;
        
        [SetUp]
        public void SetUp()
        {
            _nameManager = new NameManager();
        }

        [TearDown]
        public void TearDown()
        {
            _nameManager = null;
            _logger = null;
        }

        [Test]
        public void GivenAValidFileInput_WhenCallingGetNamesFromFileAndThenSortNames_ThenAListOfSortedNamesIsReturned()
        {
            // Arrange
            Logger.Initialize("LogFileTest1");
            _logger = Logger.Instance;

            var expectedNameList = _nameManager.GetNamesFromFile(DataPath + "ExpectedNameList.txt", _logger);

            // Act
            var actualNameList = _nameManager.GetNamesFromFile(DataPath + "NameList.txt", _logger);
            var actualSortedNameList = _nameManager.SortNames(actualNameList, _logger);

            // Assert
            Assert.IsNotNull(actualSortedNameList);
            Assert.AreEqual(expectedNameList.Count, actualSortedNameList.Count);

            for (int i = 0; i <= actualSortedNameList.Count -1; i++)
            {
                Assert.AreEqual(expectedNameList[i].FirstName, actualSortedNameList[i].FirstName);
                Assert.AreEqual(expectedNameList[i].LastName, actualSortedNameList[i].LastName);
            }
        }

        [Test]
        public void GivenAListOfNames_WhenCallingSetNamesToFile_ThenAFileContainingTheNamesIsCreated()
        {
            // Arrange
            Logger.Initialize("LogFileTest2");
            _logger = Logger.Instance;

            const string outputFile = "outputFileTest.txt";
            var expectedNameList = _nameManager.GetNamesFromFile(DataPath + "NameList.txt", _logger);
            
            // Act
            _nameManager.SetNamesToFile(expectedNameList, DataPath + outputFile, _logger);
            var actualNameList = _nameManager.GetNamesFromFile(DataPath + outputFile, _logger);
            
            // Assert
            Assert.True(File.Exists(DataPath + outputFile));
            Assert.AreEqual(expectedNameList.Count, actualNameList.Count);

            for (int i = 0; i <= actualNameList.Count - 1; i++)
            {
                Assert.AreEqual(expectedNameList[i].FirstName, actualNameList[i].FirstName);
                Assert.AreEqual(expectedNameList[i].LastName, actualNameList[i].LastName);
            }
        }
    }*/
}
