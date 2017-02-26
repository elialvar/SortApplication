using System;
using System.IO;
using System.Linq;
using SortApplication.BussinessLogic.Enums;
using SortApplication.BussinessLogic.Interfaces;

namespace SortApplication.BussinessLogic
{
    internal class AppLogic : IAppLogic
    {
        /// <summary>
        /// File name where the sorted name list will be stored.
        /// </summary>
        private const string OutputFileName = "sortedName.txt";

        private readonly ILogger _logger;
        private readonly IFileHandling _fileHandling;
        private readonly IConsole _consoleWrapper;

        public AppLogic(IFileHandling fileHandling, IConsole consoleWrapper, ILogger logger)
        {
            if (fileHandling == null || consoleWrapper == null || logger == null)
            {
                throw new ArgumentNullException("Argument null in the call to AppLogic.");
            }

            _fileHandling = fileHandling;
            _logger = logger;
            _consoleWrapper = consoleWrapper;
        }

        public void Run()
        {
            _consoleWrapper.WriteLine("**********************************************************************");
            _consoleWrapper.WriteLine("");
            _consoleWrapper.WriteLine("    Welcome to SortApplication. ");
            _consoleWrapper.WriteLine("");
            _consoleWrapper.WriteLine("    Please type the word 'exit' when you want to stop the application.");
            _consoleWrapper.WriteLine("");
            _consoleWrapper.WriteLine("    * For sorting a file specify a file name and sorting option, 'asc'.");
            _consoleWrapper.WriteLine("     -asc for ascending sorting");
            _consoleWrapper.WriteLine("     -desc for descending sorting");
            _consoleWrapper.WriteLine("     Example: fileName.txt -asc");
            _consoleWrapper.WriteLine("");

            while (true) // Loop indefinitely
            {
                _consoleWrapper.WriteLine("**********************************************************************");
                _consoleWrapper.WriteLine("");
                _consoleWrapper.WriteLine("Enter file name: ");
                _consoleWrapper.WriteLine("");

                string userInput = _consoleWrapper.ReadLine();
                if (userInput == "exit")
                {
                    return;
                }

                var values = userInput.Split('-').Select(p => p.Trim()).ToList();
                string fileName = values[0];
                SortingOptions option = SortingOptions.Asc;

                if (values.Count > 1 && values[1].ToLowerInvariant() == SortingOptions.Desc.ToString().ToLowerInvariant())
                {
                    option = SortingOptions.Desc;
                }

                _consoleWrapper.WriteLine("");

                if (!File.Exists(values[0]))
                {
                    _consoleWrapper.WriteLine("The file '" + fileName + "' does not exist.");
                }
                else
                {
                    try
                    {
                        _fileHandling.FileReader(fileName);
                        _fileHandling.FileWriter(OutputFileName, option);

                        _consoleWrapper.WriteLine("Finished: created '" + OutputFileName + "' that contains the sorted list.");
                    }
                    catch(Exception ex)
                    {
                        _consoleWrapper.WriteLine("An error occurred while processing the name list. Please, check the log file for more information.");
                        _logger.WriteLog("An exception occurred in method 'Run' from 'AppLogic'", ex);
                    }
                }

                _consoleWrapper.WriteLine("");
                _consoleWrapper.WriteLine("");
            }
        }
    }
}