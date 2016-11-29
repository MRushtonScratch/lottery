using System;
using System.Linq;
using System.Collections.Generic;

namespace Lottery.Api.Domain
{
    public class LotteryDraw
    {
        public LotteryDraw(string name, string description, DateTime date, LotteryNumbers primaryNumbers, LotteryNumbers secondaryNumbers)
        {
            Name = name;
            Description = description;
            DrawDate = date;
            PrimaryNumbers = primaryNumbers;
            SecondaryNumbers = secondaryNumbers;
        }        

        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime DrawDate { get; private set; }
        public LotteryNumbers PrimaryNumbers { get; private set; }
        public LotteryNumbers SecondaryNumbers { get; private set; }
        public WinningNumbers WinningNumbers { get; private set; }

        public void SpecifyWinningNumbers(WinningNumbers winningNumbers)
        {
            if (Validate(PrimaryNumbers, winningNumbers.Primary) &&
                Validate(SecondaryNumbers, winningNumbers.Secondary))
            {
                WinningNumbers = winningNumbers;
            }
            else
            {
                throw new ArgumentException($"Winning numbers must be within range as defined by the draw Primary 1-{PrimaryNumbers.TotalAmountOfNumbers}, Secondary 1-{SecondaryNumbers.TotalAmountOfNumbers}");
            }
        }

        private bool Validate(LotteryNumbers lotteryNumbers, IList<int> winningNumbers)
        {
            return winningNumbers.All(winningNo => lotteryNumbers.Numbers.Any(lotteryNum => winningNo == lotteryNum));
        }
    }
}
