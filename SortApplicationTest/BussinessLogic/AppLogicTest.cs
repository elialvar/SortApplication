using System;
using Moq;
using NUnit.Framework;
using SortApplication.BussinessLogic;
using SortApplication.BussinessLogic.Enums;
using SortApplication.BussinessLogic.Interfaces;

namespace SortApplicationTest.BussinessLogic
{
    [TestFixture]
    public class AppLogicTest
    {
        private const string OutputFileName = "sortedName.txt";
        private const string DataPath = "..\\..\\..\\Data\\";
        private readonly string _fileLocation = AppDomain.CurrentDomain.BaseDirectory + DataPath;

        private IAppLogic _appLogic;
        private Mock<ILogger> _mockLogger;
        private Mock<IFileHandling> _mockFileHandling;
        private Mock<IConsole> _mockConsole;

        [SetUp]
        public void SetUp()
        {
            _mockLogger = new Mock<ILogger>();
            _mockFileHandling = new Mock<IFileHandling>();
            _mockConsole = new Mock<IConsole>();
            _appLogic = new AppLogic(_mockFileHandling.Object, _mockConsole.Object, _mockLogger.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockLogger = null;
            _appLogic = null;
            _mockFileHandling = null;
            _mockConsole = null;
        }

        [Test]
        public void GivenASystemRunning_WhenCallingRunWithAscendingSortingOption_ThenFileHandlingIsCalled()
        {
            // Arrange
            string inputFileLocation = _fileLocation + "RandomPeopleList.txt";
            const string exit = "exit";
            const string sortingOption = "-asc";
            _mockConsole.SetupSequence(m => m.ReadLine()).Returns(inputFileLocation + sortingOption).Returns(exit);

            // Act
            _appLogic.Run();

            // Assert
            _mockFileHandling.Verify(m => m.FileReader(inputFileLocation));
            _mockFileHandling.Verify(m => m.FileWriter(OutputFileName, SortingOptions.Asc));
        }

        [Test]
        public void GivenASystemRunning_WhenCallingRunWithDescendingSortingOption_ThenFileHandlingIsCalled()
        {
            // Arrange
            string inputFileLocation = _fileLocation + "RandomPeopleList.txt";
            const string exit = "exit";
            const string sortingOption = "-desc";
            _mockConsole.SetupSequence(m => m.ReadLine()).Returns(inputFileLocation + sortingOption).Returns(exit);

            // Act
            _appLogic.Run();

            // Assert
            _mockFileHandling.Verify(m => m.FileReader(inputFileLocation));
            _mockFileHandling.Verify(m => m.FileWriter(OutputFileName, SortingOptions.Desc));
        }

        [Test]
        public void GivenASystemRunning_WhenCallingRunAndFileHandlingThrowAnException_ThenLoggerIsCalled()
        {
            // Arrange
            string inputFileLocation = _fileLocation + "RandomPeopleList.txt";
            const string exit = "exit";
            const string sortingOption = "-desc";

            _mockConsole.SetupSequence(m => m.ReadLine()).Returns(inputFileLocation + sortingOption).Returns(exit);
            _mockFileHandling.Setup(m => m.FileReader(It.IsAny<string>())).Throws<Exception>();

            // Act
            _appLogic.Run();

            // Assert
            _mockLogger.Verify(x => x.WriteLog(It.IsAny<string>(), It.IsAny<Exception>()));
        }
    }
}