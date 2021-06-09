using Core.UnitTest.Model;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Core.UnitTest.Test.DataLogicTest
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    class DataHandlerTests
    {
        [Test]
        public void JsonProcess_JsonProcess_Successfully()
        {
            Student student = new Student();
            student.Name = "John";
            student.Age = 31;
            student.City = "New York";

            string studentJson = "{ \"Name\":\"John\", \"Age\":31, \"City\":\"New York\"}";
            var actualStudent = studentJson.ToObject<Student>();

            student.Should().Equals(actualStudent);

            var actualStudentJson = student.ToJson<Student>();

            JToken.Parse(studentJson).Should().BeEquivalentTo(JToken.Parse(actualStudentJson));

        }

        [Test]
        public void JsonProcess_JsonArrayProcess_Successfully()
        {
            List<Student> students = new List<Student>();

            Student student2 = new Student();
            student2.Name = "John";
            student2.Age = 31;
            student2.City = "New York";
            

            Student student = new Student();
            student.Age = 20;
            student.Name = "W33";
            student.City = "Ha Noi";

            students.Add(student);
            students.Add(student2);



            string studentJson = "[{ \"Name\":\"W33\", \"Age\":20, \"City\":\"Ha Noi\"}, { \"Name\":\"John\", \"Age\":31, \"City\":\"New York\"}]";
            var actualStudent = studentJson.ToListObject<Student>();

            students.Should().BeEquivalentTo(actualStudent);

            var actualStudentJson = students.ToJson<Student>();

            JToken.Parse(studentJson).Should().BeEquivalentTo(JToken.Parse(actualStudentJson));

        }

        [Test]
        public void GetJsonValue_JsonObjectGetValue_Successfully()
        {
            string studentJson = "{ \"Name\":\"W33\", \"Age\":20, \"City\":\"Ha Noi\"}";
            var data = studentJson.GetJsonValue("$..Name").ToString();

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void GetJsonValue_JsonArrayGetValue_Successfully()
        {
            string studentJson = "[{ \"Name\":\"W33\", \"Age\":20, \"City\":\"Ha Noi\"},{ \"Name\":\"W33Haa\", \"Age\":30, \"City\":\"Ha Noi 2\"}]";
            var data = studentJson.GetJsonValue("$..[0].Name").ToString();

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void UpdateJsonValue_JsonUpdateValue_Successfully()
        {
            string studentJson = "{ \"SessionId\" : \"<sessionId>\", \"PaymentMethodType\": \"payinfull\", \"OptionalExtras\": [ \"RO\", \"RS\" ], \"TotalAmountTopay\": \"<TotalPremium in quote response> +<premium of opexs>\" }";
            var data = studentJson.UpdateJsonValue("$..OptionalExtras", "[\"123\"]").ToString();

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void IsValidJson_ValidateInvalidJson_ReturnFalse()
        {
            string studentJson = "{ \"SessionId : \"<sessionId>\", \"PaymentMethodType\": \"payinfull\", \"OptionalExtras\": [ \"RO\", \"RS\" ], \"TotalAmountTopay\": \"<TotalPremium in quote response> +<premium of opexs>\" }";

            Assert.IsFalse(studentJson.IsValidJson());
        }

        [Test]
        public void IsValidJson_ValidateInvalidJson_ReturnTrue()
        {
            string studentJson = "{ \"SessionId\" : \"<sessionId>\", \"PaymentMethodType\": \"payinfull\", \"OptionalExtras\": [ \"RO\", \"RS\" ], \"TotalAmountTopay\": \"<TotalPremium in quote response> +<premium of opexs>\" }";

            Assert.IsTrue(studentJson.IsValidJson());
        }

        [Test]
        public void ReadOnlyCollection_ToList_Successfully()
        {
            List<string> listString = new List<string>();
            listString.Add("1");
            listString.Add("2");
            listString.Add("3");
            ReadOnlyCollection<string> collections = new ReadOnlyCollection<string>(listString);

            var convertedList = collections.ToList<string>();

            Assert.AreEqual(listString, convertedList);

        }

    }
}
