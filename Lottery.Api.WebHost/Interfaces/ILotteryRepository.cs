using Lottery.Api.Domain;
using System;
using System.Collections.Generic;

namespace Lottery.Api.Application
{
    public interface ILotteryRepository
    {
        void Create(LotteryDraw lotteryDraw);
        void Update(LotteryDraw lotteryDraw);
        LotteryDraw FindByName(string name);
        IEnumerable<LotteryDraw> FindByDate(DateTime drawDate);
    }
}
