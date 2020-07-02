using NUnit.Framework;

namespace Domain.Tests
{
    public class FizzBuzzTests
    {
        private FizzBuzz fizzBuzz;

        private static readonly int valueMultipleOf3 = 3;
        private static readonly int valueMultipleOf5 = 5;
        private static readonly int valueMultipleOf3And5 = 15;
        private static readonly int valueNotMultipleOf3Or5 = 7;

        [SetUp]
        public void Setup()
        {
            fizzBuzz = new FizzBuzz();
        }

        [Test]
        public void Value_WhenIsMultipleOf3_ShouldReturnFizz()
        {
            int value = valueMultipleOf3;

            var result = fizzBuzz.GetResult(value);

            Assert.That(result, Is.EqualTo(FizzBuzz.FizzResult));
        }

        [Test]
        public void Value_WhenIsMultipleOf5_ShouldReturnBuzz()
        {
            int value = valueMultipleOf5;

            var result = fizzBuzz.GetResult(value);

            Assert.That(result, Is.EqualTo(FizzBuzz.BuzzResult));
        }

        [Test]
        public void Value_WhenIsMultipleOf3And5_ShouldReturnFizzBuzz()
        {
            int value = valueMultipleOf3And5;

            var result = fizzBuzz.GetResult(value);

            Assert.That(result, Is.EqualTo(FizzBuzz.FizzBuzzResult));
        }

        [Test]
        public void Value_WhenIsNotMultipleOf3Or5_ShouldReturnValue()
        {
            int value = valueNotMultipleOf3Or5;

            var result = fizzBuzz.GetResult(value);

            Assert.That(result, Is.EqualTo(value.ToString()));
        }

    }
}
