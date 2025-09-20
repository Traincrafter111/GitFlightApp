using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitFlightApp.Helpers
{
    public static class FileAccessHelper
    {
        /// <summary>
        /// Combines the application's local data directory path with the specified file name.
        /// </summary>
        /// <param name="filename">The name of the file to be combined with the application's local data directory. Cannot be null or empty.</param>
        /// <returns>The full file path as a string, combining the application's local data directory and the specified file
        /// name.</returns>
        public static string GetLocalFilePath(string filename)
        {
            return Path.Combine(FileSystem.AppDataDirectory, filename);
        }
    }
}
