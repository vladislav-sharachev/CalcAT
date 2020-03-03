using CalcCheck.Driver;
using NUnit.Framework;

namespace CalcCheck.Test
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
