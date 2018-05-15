using System;
using FileReading.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static FileReading.Test.DependencyResolver;

namespace FileReading.Test
{
    [TestClass]
    public class FileReadingTests
    {
        FileReadingLogic fileReadingLogic;

        [TestInitialize]
        public void Initialize()
        {
            fileReadingLogic = Resolve<FileReadingLogic>();
        }

        [TestMethod]
        public void Simple_TextFile_Reader()
        {
            // Arrange
            var encrypted = false;
            var filePath = "test.txt";
            var role = Roles.RolesEnum.Admin.ToString();
            // Act
            var simpleTxtFileReaderResult = fileReadingLogic.ReadFile(filePath, role, encrypted);
            // Assert
            Assert.AreEqual("TxtReader", simpleTxtFileReaderResult);
        }

        [TestMethod]
        public void Encrypted_TextFile_Reader()
        {
            // Arrange
            var encrypted = true;
            var filePath = "test.txt";
            var role = Roles.RolesEnum.Admin.ToString();
            // Act
            var encryptedTxtFileReaderResult = fileReadingLogic.ReadFile(filePath, role, encrypted);
            // Assert
            Assert.AreEqual("EncryptedTxtReader", encryptedTxtFileReaderResult);
        }

        [TestMethod]
        public void SimpleUser_Role_Can_Not_Acces_To_Encrypted_TextFile_Reader()
        {
            // Arrange
            var encrypted = true;
            var filePath = "test.txt";
            var role = Roles.RolesEnum.SimpleUser.ToString();
            // Act
            var encryptedTxtFileReaderResult = fileReadingLogic.ReadFile(filePath, role, encrypted);
            // Assert
            Assert.IsNull(encryptedTxtFileReaderResult);
        }

        [TestMethod]
        public void Simple_XmlFile_Reader()
        {
            // Arrange
            var encrypted = false;
            var filePath = "test.xml";
            var role = Roles.RolesEnum.Admin.ToString();
            // Act
            var simpleXmlFileReaderResult = fileReadingLogic.ReadFile(filePath, role, encrypted);
            // Assert
            Assert.AreEqual("XmlReader", simpleXmlFileReaderResult);
        }

        [TestMethod]
        public void Encrypted_XmlFile_Reader()
        {
            // Arrange
            var encrypted = true;
            var filePath = "test.xml";
            var role = Roles.RolesEnum.Admin.ToString();
            // Act
            var encryptedXmlFileReaderResult = fileReadingLogic.ReadFile(filePath, role, encrypted);
            // Assert
            Assert.AreEqual("EncryptedXmlReader", encryptedXmlFileReaderResult);
        }

        [TestMethod]
        public void Can_Read_Encrypted_XmlFile_Without_Role()
        {
            // Arrange
            var encrypted = true;
            var filePath = "test.xml";
            var role = "";
            // Act
            var encryptedXmlFileReaderWithoutResult = fileReadingLogic.ReadFile(filePath, role, encrypted);
            // Assert
            Assert.AreEqual("EncryptedXmlReader", encryptedXmlFileReaderWithoutResult);
        }

        [TestMethod]
        public void Simple_JsonFile_Reader()
        {
            // Arrange
            var encrypted = false;
            var filePath = "test.json";
            var role = Roles.RolesEnum.Admin.ToString();
            // Act
            var simpleJsonFileReaderResult = fileReadingLogic.ReadFile(filePath, role, encrypted);
            // Assert
            Assert.AreEqual("JsonReader", simpleJsonFileReaderResult);
        }

        [TestMethod]
        public void Encrypted_JsonFile_Reader()
        {
            // Arrange
            var encrypted = true;
            var filePath = "test.json";
            var role = Roles.RolesEnum.Admin.ToString();
            // Act
            var encryptedJsonFileReaderResult = fileReadingLogic.ReadFile(filePath, role, encrypted);
            // Assert
            Assert.AreEqual("EncryptedJsonReader", encryptedJsonFileReaderResult);
        }



    }
}
