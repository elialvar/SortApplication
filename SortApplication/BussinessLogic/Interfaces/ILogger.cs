using System;

namespace SortApplication.BussinessLogic.Interfaces
{
    /// <summary>
    /// Interface that specifies methods to log events to a file.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Writes the trace string to a file.
        /// </summary>
        /// <param name="trace">String to be written in a file.</param>
        void WriteLog(string trace);

        /// <summary>
        /// Writes the trace string and an exception to a file.
        /// </summary>
        /// <param name="trace">String to be written in a file.</param>
        /// <param name="ex">Exception to be written in a file.</param>
        void WriteLog(string trace, Exception ex);
    }
}
