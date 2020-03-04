using CalcCheck.Core;
using CalcCheck.Pages;
using NUnit.Framework;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CalcCheck.Steps
{
    public class CalcSteps
    {
        public static int InputRandomNumber()
        {
            Console.WriteLine("Ввести случайное число");
            var number = GenerateRandomNumber();
            new StandardCalcPage().InputNumbers(number);
            return number;
        }

        public static void CheckThatStandardCalculatorPageIsShown()
        {
            Console.WriteLine("Проверить что открыта страница со стандартным калькулятором");
            BasePage basePage = new BasePage();
            if (!basePage.HasStandardCalculatorMode())
            {
                basePage.ClickOnOpenNavigation();
                basePage.OpenStandardCalculatorPage();
            }
        }

        public static void ClickOnClearButton()
        {
            new StandardCalcPage().ClickOnClearButton();
        }

        public static void CheckThatInTheFieldTheCorrectOperationIsShown(int expectedNumber)
        {
            Console.WriteLine("Проверить что в поле отображается корректная операция");
            var actualNumber = Regex.Replace(
                new StandardCalcPage().GetCalculatorExpression(), @"[\sа-яa-z— ]", "", RegexOptions.IgnoreCase);

            Assert.That(actualNumber, Is.EqualTo(string.Format("√({0})", expectedNumber)),
                "Calculator expression result is not equal to the expected");
        }

        public static void CheckThatResultIsTheInputedNumber(int expectedNumber)
        {
            Console.WriteLine("Проверить что результат равен введенному числу");
            int actualNumber;
            int.TryParse(string.Join("", new StandardCalcPage().GetCalcResult()
                .Where(r => char.IsDigit(r))), out actualNumber);

            Assert.That(actualNumber, Is.EqualTo(expectedNumber), "Calculator result is not equal to the expected");
        }

        public static void CloseCalculator()
        {
            new StandardCalcPage().CloseCalculator();
        }

        public static void ClickOnEqualButton()
        {
            Console.WriteLine("Кликнуть на кнопку Равно");
            new StandardCalcPage().ClickOnEqualButton();
        }

        public static void ClickOnMultiplyButton()
        {
            Console.WriteLine("Кликнуть на кнопку умножения");
            new StandardCalcPage().ClickOnMultiplyButton();
        }


        public static void CheckThatTheResultIsCorrect(double expectedResult)
        {
            Console.WriteLine("Проверить что результат корректный");
            var actualResult = Math.Round(Convert.ToDouble(
                Regex.Replace(new StandardCalcPage().CheckThatTheResultIsCorrect(),
                "[а-яa-z ]", "", RegexOptions.IgnoreCase)), 12);

            Assert.That(actualResult, Is.EqualTo(expectedResult), "Actual result is not equal to the expected");
        }

        public static void ClickOnSqureRootButton()
        {
            Console.WriteLine("Кликнуть на кнопку Извлечь корень");
            new StandardCalcPage().ClickOnSquareRootButton();
        }

        private static int GenerateRandomNumber()
        {
            int number = new Random().Next(1, 100);
            return number;
        }
    }
}