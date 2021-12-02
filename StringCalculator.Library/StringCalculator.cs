namespace StringCalculator.Library
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (String.IsNullOrEmpty(numbers))  
            {
                return 0;
            }

            var delimiters = new[] { ',', '\n' };

            //Support different delimiters
            if (numbers.StartsWith("//"))
            {
                delimiters = new[] { ';', '\n' };
                var DifferentNumbersSum = numbers.Split(delimiters);

                int sumNumber = 0;
                foreach (var number in DifferentNumbersSum)
                {
                    bool isNumber = number.Any(c => char.IsDigit(c));
                    
                    if (isNumber)
                    {
                        sumNumber += int.Parse(number);
                    }
                }

                return sumNumber;
            }

            var numberList = numbers.Split(delimiters).Select(number => int.Parse(number));

            var negativeNumbers = numberList.Where(number => number < 0);

            if (negativeNumbers.Any())
            {
                var negativesString = string.Join(',', negativeNumbers.Select(negativeNumber => negativeNumber.ToString()));

                throw new Exception($"negatives not allowed: {negativesString}");
            }

            var numbersSum = numberList.Where(number => number <= 1000).Sum();

            return numbersSum;
        }
    }
}