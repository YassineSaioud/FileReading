using System;
using static FileReading.Core.Roles;

namespace FileReading.Core
{
    public interface IFileReading
    {
        bool IsMatch(string filePath);
        bool IsInRole(string role);
        string Read(string filePath);
        string ReadEncrypted(string filePath);
    }

    public class TextFileReading : IFileReading
    {
        public bool IsInRole(string role) => role == RolesEnum.Admin.ToString() || string.IsNullOrEmpty(role);

        public bool IsMatch(string filePath) => filePath.Split('.')[1].Equals("txt", StringComparison.CurrentCultureIgnoreCase);

        public string Read(string filePath) => "TxtReader";

        public string ReadEncrypted(string filePath) => "EncryptedTxtReader";
    }

    public class XmlFileReading : IFileReading
    {
        public bool IsInRole(string role) => role == RolesEnum.Admin.ToString() || role == RolesEnum.SimpleUser.ToString() || string.IsNullOrEmpty(role);

        public bool IsMatch(string filePath) => filePath.Split('.')[1].Equals("xml", StringComparison.CurrentCultureIgnoreCase);

        public string Read(string filePath) => "XmlReader";

        public string ReadEncrypted(string filePath) => "EncryptedXmlReader";
    }

    public class JsonFileReading : IFileReading
    {
        public bool IsInRole(string role) => role == RolesEnum.Admin.ToString() || role == RolesEnum.SimpleUser.ToString() || string.IsNullOrEmpty(role);

        public bool IsMatch(string filePath) => filePath.Split('.')[1].Equals("json", StringComparison.CurrentCultureIgnoreCase);

        public string Read(string filePath) => "JsonReader";

        public string ReadEncrypted(string filePath) => "EncryptedJsonReader";
    }



}
