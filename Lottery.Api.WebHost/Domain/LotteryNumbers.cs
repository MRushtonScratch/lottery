using System.Collections.Generic;
using System.Linq;

namespace Lottery.Api.Domain
{
    public class LotteryNumbers
    {
        public LotteryNumbers(int numberRange, int totalAmountOfNumbers)
        {
            Numbers = Enumerable.Range(1, numberRange);
            TotalAmountOfNumbers = totalAmountOfNumbers;
        }

        public int TotalAmountOfNumbers { get; private set; }
        public IEnumerable<int> Numbers { get; private set; }
    }
}
