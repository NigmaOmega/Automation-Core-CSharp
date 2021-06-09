using Core.UnitTest.Model;
using NUnit.Framework;
using System.IO;
using System.Reflection;

namespace Core.UnitTest.Test.Data.DataAccess
{
    [TestFixture]
    public class FileTests : BaseFixture
    {
        [Test]
        public void ReadCsv_ValidPath_Successfully()
        {
            string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\UnitTest\DataTest\User.csv";
            var data = FileAccess.ReadCsv(filePath).ToList<User>();

            Assert.AreEqual(2, data.Count);
        }

        [Test]
        public void ReadCsv_ValidPathAndFileDoNotHaveHeaders_Successfully()
        {
            string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\UnitTest\DataTest\User.csv";
            var data = FileAccess.ReadCsv(filePath, false);

            Assert.AreEqual(3, data.Rows.Count);
        }

        [Test]
        public void ReadJson_ValidPath_Successfully()
        {
            string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var data = FileAccess.ReadJson(currentDirectory + @"\UnitTest\DataTest\student.json");

            Assert.IsNotNull(data);
        }

        [Test]
        public void ReadExcel_ValidPath_Successfully()
        {
            string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var data = FileAccess.ReadExcel(currentDirectory + @"\UnitTest\DataTest\User.xlsx").ToList<User>();

            Assert.AreEqual(2, data.Count);
        }


        [Test]
        public void ReadExcel_ValidPathWIthWorksheetIndexAndHaveHeaders_Successfully()
        {
            string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var data = FileAccess.ReadExcel(currentDirectory + @"\UnitTest\DataTest\User.xlsx", 0).ToList<User>();

            Assert.AreEqual(2, data.Count);
        }

        [Test]
        public void ReadExcel_ValidPathWIthWorksheetIndexAndDonotHaveHeaders_Successfully()
        {
            string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var data = FileAccess.ReadExcel(currentDirectory + @"\UnitTest\DataTest\User.xlsx", 0, false);


            Assert.AreEqual(3, data.Rows.Count);
        }

        [Test]
        public void ReadExcel_ValidPathWIthWorksheetName_Successfully()
        {
            string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var data = FileAccess.ReadExcel(currentDirectory + @"\UnitTest\DataTest\User.xlsx", "User").ToList<User>();

            Assert.AreEqual(2, data.Count);
        }

        [Test]
        public void ReadExcel_ValidPathWIthWorksheetNameAndDonotHaveHeaders_Successfully()
        {
            string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var data = FileAccess.ReadExcel(currentDirectory + @"\UnitTest\DataTest\User.xlsx", "User", false);


            Assert.AreEqual(3, data.Rows.Count);
        }

    }
}
