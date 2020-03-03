using CalcCheck.Step;
using NUnit.Framework;
using System;

namespace CalcCheck.Test
{

    [TestFixture]
    public class BaseTest
    {
        [SetUp]
        public void BeforeTest()
        {
            CalcSteps.CheckThatStandardCalculatorPageIsShown();
            CalcSteps.ClickOnClearButton();
        }

        [TestCase]
        public void CalculatorTest()
        {
            var theInputedNumber = CalcSteps.InputRandomNumber();
            CalcSteps.ClickOnSqureRootButton();
            CalcSteps.CheckThatInTheFieldTheCorrectOperationIsShown(theInputedNumber);

            var expectedResult = Math.Round(Math.Sqrt(theInputedNumber), 12);

            CalcSteps.CheckThatTheResultIsCorrect(expectedResult);
            CalcSteps.ClickOnMultiplyButton();
            CalcSteps.ClickOnEqualButton();
            CalcSteps.CheckThatResultIsTheInputedNumber(theInputedNumber);
        }

        [TearDown]
        public void AfterTest()
        {
            CalcSteps.CloseCalculator();
        }
    }
}