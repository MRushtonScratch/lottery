using Lottery.Api.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using Lottery.Api.Domain;

namespace Lottery.Api.Application
{
    public class LotteryRepository : ILotteryRepository
    {
        private IList<LotteryDraw> _inMemoryDb;

        public LotteryRepository()
        {
            _inMemoryDb = new List<LotteryDraw>();
        }

        public void Create(LotteryDraw lotteryDraw)
        {
            _inMemoryDb.Add(lotteryDraw);
        }

        public IEnumerable<LotteryDraw> FindByDate(DateTime drawDate)
        {
            return _inMemoryDb.Where(x => x.DrawDate == drawDate);
        }

        public LotteryDraw FindByName(string name)
        {
            return _inMemoryDb.FirstOrDefault(x => string.CompareOrdinal(x.Name, name) == 0);
        }

        public void Update(LotteryDraw lotteryDraw)
        {
            var draw = FindByName(lotteryDraw.Name);

            if (draw == null)
            {
                throw new ArgumentException("Lottery Draw could not be found");
            }

            draw = lotteryDraw;
        }
    }
}
