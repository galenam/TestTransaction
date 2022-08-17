using System;
using NUnit.Framework;
using TestTransaction;

namespace Tests
{
    [TestFixture]
    public class TestHelper
    {
        private static object[] TestCasesSuccess =
        {
            new object[] {"123", new Func<string, int>((string s) => Convert.ToInt32(s)), 123},
            new object[] {"17.08.2022", new Func<string, DateTime>((string s) => Convert.ToDateTime(s)), new DateTime(2022,8,17)},
            new object[] {"123,45", new Func<string, decimal>((string s) => Convert.ToDecimal(s)), (decimal)123.45},
        };

        private static object[] TestCasesUnSuccess =
        {
            new object[] {"", new Func<string, int>((string s) => Convert.ToInt32(s))},
            new object[] {"12.03.2020234", new Func<string, DateTime>((string s) => Convert.ToDateTime(s))},
            new object[] {"123,ddd45", new Func<string, decimal>((string s) => Convert.ToDecimal(s))},
        };

        [TestCaseSource(nameof(TestCasesSuccess))]
        public void TestCheckGetParsedValueIsSuccess<T>(string value, Func<string, T> parse, T correctResult)
        where T : struct
        {
            T result;
            var isConverted = Helper.GetParsedValue<T>(value, parse, out result);
            Assert.IsTrue(isConverted);
            Assert.AreEqual(correctResult, result);
        }

        [TestCaseSource(nameof(TestCasesUnSuccess))]
        public void TestCheckGetParsedValueIsUnSuccess<T>(string value, Func<string, T> parse)
        where T : struct
        {
            T result;
            var isConverted = Helper.GetParsedValue<T>(value, parse, out result);
            Assert.IsFalse(isConverted);
        }
    }
}
