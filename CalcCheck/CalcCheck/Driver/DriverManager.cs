using OpenQA.Selenium.Winium;
using System;

namespace CalcCheck.Driver
{
    public static class DriverManager
    {
        private const string calculatorAppPath = @"C:/windows/system32/calc.exe";
        private static WiniumDriver driver;

        public static WiniumDriver SetupDriver()
        {
            if (driver == null)
            {
                Setup();
            }
            return driver;
        }

        private static void Setup()
        {
            var options = new DesktopOptions();
            options.ApplicationPath = calculatorAppPath;
            string winiumDriverPath = AppDomain.CurrentDomain.BaseDirectory + "/Resources";
            var service = WiniumDriverService.CreateDesktopService(winiumDriverPath);
            driver = new WiniumDriver(service, options);
        }

        public static void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}