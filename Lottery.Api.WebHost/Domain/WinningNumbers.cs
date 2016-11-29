using System.Collections.Generic;

namespace Lottery.Api.Domain
{
    public class WinningNumbers
    {
        public IList<int> Primary { get; set; }
        public IList<int> Secondary { get; set; }
    }
}
