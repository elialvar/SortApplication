using SortApplication.BussinessLogic.Enums;

namespace SortApplication.BussinessLogic.Interfaces
{
    public interface IFileHandling
    {
        /// <summary>
        /// Read data from the file and store it in the PersonRepository.
        /// </summary>
        /// <param name="file">File to be read.</param>
        void FileReader(string file);

        /// <summary>
        /// Sort the list of people according to the 'option'
        /// and write the list into 'file'.
        /// </summary>
        /// <param name="file">File where data will be stored.</param>
        /// <param name="option">Sorting option to be applied.</param>
        void FileWriter(string file, SortingOptions option);
    }
}