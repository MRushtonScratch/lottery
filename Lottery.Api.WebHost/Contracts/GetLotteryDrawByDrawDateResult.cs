using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Api.Contracts
{
    public class LotteryResultByDrawDateResult
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DrawDate { get; set; }
        public int TotalAmountOfPrimaryNumbers { get; set; }
        public IEnumerable<int> PrimaryNumbers { get; set; }
        public int TotalAmountOfSecondaryNumbers { get; set; }
        public IEnumerable<int> SecondaryNumbers { get; set; }
        public IEnumerable<int> WinningPrimaryNumbers { get; set; }
        public IEnumerable<int> WinningSecondaryNumbers { get; set; }
    }
}
