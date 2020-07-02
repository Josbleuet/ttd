using System;
using System.IO;

namespace Domain
{
    public class FizzBuzz
    {
        public static readonly string FizzResult = "Fizz";
        public static readonly string BuzzResult = "Buzz";
        public static readonly string FizzBuzzResult = "FizzBuzz";


        public string GetResult(int value)
        {
            if (valueIsMultipleOf(value, 3) && valueIsMultipleOf(value, 5))
            {
                return FizzBuzzResult;
            }
            if (valueIsMultipleOf(value, 3))
            {
                return FizzResult;
            }
            if (valueIsMultipleOf(value, 5))
            {
                return BuzzResult;
            }

            return value.ToString();
        }

        private bool valueIsMultipleOf(int value, int multiple)
        {
            return value % multiple == 0;
        }

        public void PrintResults(TextWriter writer, int times)
        {
            for (int i = 0; i < times; i++)
            {
                writer.WriteLine(GetResult(i));
            }
        }
    }
}
