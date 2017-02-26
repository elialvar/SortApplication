using System;
using System.IO;
using System.Linq;
using SortApplication.BussinessLogic.Enums;
using SortApplication.BussinessLogic.Interfaces;
using SortApplication.DataAccess;
using SortApplication.DataAccess.Interfaces;

namespace SortApplication.BussinessLogic
{
    internal class FileHandling : IFileHandling
    {
        private readonly ILogger _logger;
        private readonly IPersonRepository _personRepository;

        public FileHandling(IPersonRepository personRepository, ILogger logger)
        {
            if (personRepository == null || logger == null)
            {
                throw new ArgumentNullException("Argument null in the call to FileHandling.");
            }

            _personRepository = personRepository;
            _logger = logger;
        }

        /// <inheritdoc />
        public void FileReader(string file)
        {
            StreamReader reader = null;
            try
            {
                // Clear the repository.
                _personRepository.RemoveAll();

                reader = new StreamReader(file);
                string strline;
                
                while ((strline = reader.ReadLine()) != null)
                {
                    var values = strline.Split(',').Select(p => p.Trim()).ToList();
                    Person person = new PersonBuilder().WithFirstName(values[1]).WithLastName(values[0]).Build();
                    _personRepository.Add(person);

                    _logger.WriteLog("Person: " + person.LastName + ", " + person.FirstName + " successfully read from file.");
                }
            }
            catch (Exception exception)
            {
                _logger.WriteLog("An exception occurred in method 'FileReader' from 'FileHandling'. ", exception);
                throw;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        /// <inheritdoc />
        public void FileWriter(string file, SortingOptions option)
        {
            StreamWriter writer = null;
            try
            {
                if (File.Exists(file))
                {
                    File.Delete(file);
                    _logger.WriteLog("A previous file named '" + file + "' already existed and it was deleted.");
                }

                writer = File.CreateText(file);

                var people = option == SortingOptions.Asc ? 
                            _personRepository.GetPeopleByNamesAscending() :
                            _personRepository.GetPeopleByNamesDescending();

                foreach (var person in people)
                {
                    writer.WriteLine(person.LastName + ", " + person.FirstName);
                    _logger.WriteLog("Person: " + person.LastName + ", " + person.FirstName + " successfully written to file.");
                }

                writer.Close();
            }
            catch (Exception exception)
            {
                _logger.WriteLog("An exception occurred in method 'FileWriter' from 'FileHandling'. ", exception);
                throw;
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }
    }
}