using System;
using Lottery.Api.Contracts;
using System.Collections.Generic;

namespace Lottery.Api.Application
{
    public interface ILotteryService
    {
        void CreateDraw(CreateLotteryDrawCommand command);
        LotteryResultByDrawDateResult FindByDrawDate(DateTime drawDate);
        void SpecifyWinningNumbers(string name, SpecifyWinningNumbersCommand command);
    }
}
