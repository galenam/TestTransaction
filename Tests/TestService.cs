using System;
using NUnit.Framework;
using TestTransaction;

namespace Tests
{
    [TestFixture]

    public class TestService
    {
        Service _service = new Service();

        [SetUp]
        public void Init()
        {
            _service.Add(1, new DateTime(2022, 8, 17), (decimal)123.45);
        }

        [Test]
        public void TestAdd()
        {
            Assert.IsTrue(_service.Add(2, new DateTime(2022, 8, 17), (decimal)123.45));
        }

        [Test]
        public void TestDuplicateAddFail()
        {
            Assert.IsFalse(_service.Add(1, new DateTime(2022, 8, 17, 0, 0, 0, 0), (decimal)123.45));
        }

        [Test]
        public void TestGet()
        {
            string json;
            Assert.IsTrue(_service.Get(1, out json));
            var correct = "{\"id\":1,\"transactionDate\":\"2022-08-17T00:00:00.0000000+03:00\",\"amount\":123.45}";
            Assert.AreEqual(correct, json);
        }
    }
}