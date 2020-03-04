using CalcCheck.Core.Driver;
using NUnit.Framework;

namespace CalcCheck.Tests
{
    [SetUpFixture]
    public class BaseFixture
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            DriverManager.SetupDriver();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            DriverManager.TearDown();
        }
    }
}
