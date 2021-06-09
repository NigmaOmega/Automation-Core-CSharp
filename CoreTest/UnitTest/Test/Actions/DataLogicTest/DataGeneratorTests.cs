using NUnit.Framework;

namespace Core.UnitTest.Test.Data
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    class DataGeneratorTests : BaseFixture
    {
        [Test]
        public void GenerateString_Successful()
        {
            string result = DataGenerator.GenerateString(10);
            Assert.AreEqual(10, result.Length);
        }

        [Test]
        public void GenerateInt_Successful()
        {
            string result = DataGenerator.GenerateString(10, true);
            Assert.AreEqual(10, result.Length);
        }

    }
}
