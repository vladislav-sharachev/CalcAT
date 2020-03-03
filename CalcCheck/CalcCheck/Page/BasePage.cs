using CalcCheck.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Winium;

namespace CalcCheck.Page
{
    public class BasePage
    {
        protected WiniumDriver _driver = DriverManager.SetupDriver();

        protected IWebElement CloseButton => _driver.FindElementById("Close");

        protected IWebElement Header => _driver.FindElementById("Header");

        protected IWebElement NavigationToggle => _driver.FindElementById("TogglePaneButton");

        protected IWebElement StandartPage => _driver.FindElementById("Standard");

        public bool HasStandardCalculatorMode()
        {
            return Header.GetAttribute("Name").Equals("Standard Calculator mode");
        }

        public void ClickOnOpenNavigation()
        {
            NavigationToggle.Click();
        }

        public void OpenStandardCalculatorPage()
        {
            StandartPage.Click();
        }
    }
}
