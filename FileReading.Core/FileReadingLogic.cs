using System.Collections.Generic;
using System.Linq;

namespace FileReading.Core  
{
    public class FileReadingLogic
    {
        readonly IEnumerable<IFileReadingType> _fileReadingTypes;

        public FileReadingLogic(IEnumerable<IFileReadingType> fileReadingTypes)
        {
            _fileReadingTypes = fileReadingTypes;
        }

        public string ReadFile(string filePath, string role, bool encrypted) =>
            _fileReadingTypes.FirstOrDefault(f => f.IsMatch(encrypted)).ReadMatchType(role, filePath);
    }
}


