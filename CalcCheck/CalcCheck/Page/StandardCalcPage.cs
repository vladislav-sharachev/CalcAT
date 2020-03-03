using OpenQA.Selenium;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CalcCheck.Page
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
            var expression = Regex.Replace(expressionText, @"[\sа-яa-z— ]", "", RegexOptions.IgnoreCase);
            return expression;
        }

        public double CheckThatTheResultIsCorrect()
        {
            var getCalcResult = CalculatorResultsField.GetAttribute("Name");
            var actualResult = Math.Round(Convert.ToDouble(
                Regex.Replace(getCalcResult, "[а-яa-z ]", "", RegexOptions.IgnoreCase)), 12);
            return actualResult;
        }

        public void ClickOnMultiplyButton()
        {
            MultiplyButton.Click();
        }

        public void ClickOnEqualButton()
        {
            EqualButton.Click();
        }

        public int GetCalcResult()
        {
            var calcResultText = CalculatorResultsField.GetAttribute("Name").ToString();
            int calcResult;
            int.TryParse(string.Join("", calcResultText.Where(r => char.IsDigit(r))), out calcResult);
            return calcResult;
        }

        public void CloseCalculator()
        {
            CloseButton.Click();
        }
    }
}