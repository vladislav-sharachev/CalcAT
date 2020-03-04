using CalcCheck.Core;
using OpenQA.Selenium;

namespace CalcCheck.Pages
{
    public class StandardCalcPage : BasePage
    {

        private IWebElement ClearButton => _driver.FindElementById("clearButton");

        private IWebElement SquareRootButton => _driver.FindElementById("squareRootButton");

        private IWebElement CalculatorExpressionField => _driver.FindElementById("CalculatorExpression");

        private IWebElement CalculatorResultsField => _driver.FindElementById("CalculatorResults");

        private IWebElement MultiplyButton => _driver.FindElementById("multiplyButton");

        private IWebElement EqualButton => _driver.FindElementById("equalButton");

        private IWebElement NumButton(char numberOfTheButton)
        {
            return _driver.FindElementById(string.Format("num{0}Button", numberOfTheButton));
        }

        public void ClickOnClearButton()
        {
            ClearButton.Click();
        }

        public int InputNumbers(int randomNumber)
        {
            var numByString = randomNumber.ToString();

            foreach (char numByStr in numByString)
            {
                NumButton(numByStr).Click();
            }
            return randomNumber;
        }

        public void ClickOnSquareRootButton()
        {
            SquareRootButton.Click();
        }

        public string GetCalculatorExpression()
        {
            var expressionText = CalculatorExpressionField.GetAttribute("Name");
            return expressionText;
        }

        public string CheckThatTheResultIsCorrect()
        {
            var getCalcResult = CalculatorResultsField.GetAttribute("Name");
            return getCalcResult;
        }

        public void ClickOnMultiplyButton()
        {
            MultiplyButton.Click();
        }

        public void ClickOnEqualButton()
        {
            EqualButton.Click();
        }

        public string GetCalcResult()
        {
            var calcResultText = CalculatorResultsField.GetAttribute("Name");
            return calcResultText;
        }

        public void CloseCalculator()
        {
            CloseButton.Click();
        }
    }
}