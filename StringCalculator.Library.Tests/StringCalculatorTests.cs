using NUnit.Framework;

namespace StringCalculator.Library.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        StringCalculator _calculator = new StringCalculator();

        [Test]
        public void ReturnsZeroOnEmptyString()
        {
            var result = _calculator.Add("");

            Assert.AreEqual(0, result);
        }

        [Test]
        public void ReturnsOneWithStringNumberOne()
        {
            var result = _calculator.Add("1");

            Assert.AreEqual(1, result);
        }

        [Test]
        public void ReturnsTwoWithStringNumberTwo()
        {
            var result = _calculator.Add("2");

            Assert.AreEqual(2, result);
        }

        [Test]
        public void ReturnsSumWithCommaSeparatedNumbers()
        {
            var result = _calculator.Add("2,1");

            Assert.AreEqual(3, result);
        }

        [Test]
        public void ReturnsSumWithCommaSeparatedUnknownAmountOfNumbers()
        {
            var result = _calculator.Add("2,1,2");

            Assert.AreEqual(5, result);
        }

        [Test]
        public void ReturnsSumWithCommaSeparatedUnknownAmountOfNumbersAndNewLine()
        {
            var result = _calculator.Add("2\n1,2");

            Assert.AreEqual(5, result);
        }

        [Test]
        public void ReturnsSumWithDifferentDelimeterAndUnknownAmountOfNumbers()
        {
            var result = _calculator.Add("//;\n1;2");

            Assert.AreEqual(3, result);
        }

        [Test]
        public void ReturnsSumWithDifferentDelimeterAndUnknownAmountOfNumbersFive()
        {
            var result = _calculator.Add("//;\n1;2;3;12;4");

            Assert.AreEqual(22, result);
        }

        [Test]
        public void ThrowsNegativesErrorMessage()
        {
            Action action = () => _calculator.Add("-1");

            var ex = Assert.Throws<Exception>(() => action());

            Assert.AreEqual("negatives not allowed: -1", ex.Message);
        }

        [Test]
        public void ThrowsMultipleNegativesErrorMessage()
        {
            Action action = () => _calculator.Add("-1,-2,-4");

            var ex = Assert.Throws<Exception>(() => action());

            Assert.AreEqual("negatives not allowed: -1,-2,-4", ex.Message);
        }

        [Test]
        public void ReturnsSumIgnoringValuesOverOneThousand()
        {
            var result = _calculator.Add("1001,1,2");

            Assert.AreEqual(3, result);
        }
    }
}