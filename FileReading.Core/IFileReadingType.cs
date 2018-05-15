using System.Collections.Generic;
using System.Linq;

namespace FileReading.Core
{
    public interface IFileReadingType
    {
        bool IsMatch(bool encrypted);
        string ReadMatchType(string role, string filePath);
    }

    public class SimpleFileReading : IFileReadingType
    {
        readonly IEnumerable<IFileReading> _fileReadings;

        public SimpleFileReading(IEnumerable<IFileReading> fileReadings)
        {
            _fileReadings = fileReadings;
        }

        public bool IsMatch(bool encrypted) => !encrypted;

        public string ReadMatchType(string role, string filePath) =>
            _fileReadings.FirstOrDefault(m => m.IsInRole(role) && m.IsMatch(filePath))?.Read(filePath);

    }

    public class EncryptedFileReading : IFileReadingType
    {
        readonly IEnumerable<IFileReading> _fileReadings;

        public EncryptedFileReading(IEnumerable<IFileReading> fileReadings)
        {
            _fileReadings = fileReadings;
        }

        public bool IsMatch(bool encrypted) => encrypted;

        public string ReadMatchType(string role, string filePath) =>
            _fileReadings.FirstOrDefault(m => m.IsInRole(role) && m.IsMatch(filePath))?.ReadEncrypted(filePath);

    }

}

