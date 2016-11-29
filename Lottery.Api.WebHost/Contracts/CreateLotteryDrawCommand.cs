using System;

namespace Lottery.Api.Contracts
{
    public class CreateLotteryDrawCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DrawDate { get; set; }
    }
}
