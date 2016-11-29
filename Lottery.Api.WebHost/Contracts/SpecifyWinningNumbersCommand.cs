using System.Collections.Generic;

namespace Lottery.Api.Contracts
{
    public class SpecifyWinningNumbersCommand
    {
        public IList<int> Primary { get; set; }
        public IList<int> Secondary { get; set; }
    }
}
