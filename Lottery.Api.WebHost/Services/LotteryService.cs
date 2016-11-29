using Lottery.Api.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Lottery.Api.Application
{
    public class LotteryService : ILotteryService
    { 
        private ILotteryRepository _repository;

        // Could derive these values using a settings provider from .config or .json 
        private int _primaryNumberCount = 49;
        private int _totalAmountOfPrimaryNumbers = 5;
        private int _secondaryNumberCount = 10;
        private int _totalAmountOfSecondaryNumbers = 2;

        public LotteryService(ILotteryRepository repository)
        {
            _repository = repository;
        }

        public void CreateDraw(CreateLotteryDrawCommand lotteryDrawCommand)
        {
            var existingDraw = _repository.FindByName(lotteryDrawCommand.Name);
            if (existingDraw != null)
            {
                throw new ArgumentException($"Lottery draw {lotteryDrawCommand.Name} already exists");
            }

            Domain.LotteryDraw draw = new Domain.LotteryDraw(lotteryDrawCommand.Name,
                                            lotteryDrawCommand.Description,
                                            lotteryDrawCommand.DrawDate.Date,
                                            new Domain.LotteryNumbers(_primaryNumberCount, _totalAmountOfPrimaryNumbers),
                                            new Domain.LotteryNumbers(_secondaryNumberCount, _totalAmountOfSecondaryNumbers));
            _repository.Create(draw);
        }
        
        public void SpecifyWinningNumbers(string name, SpecifyWinningNumbersCommand winningNumbersCommand)
        {
            var existingDraw = _repository.FindByName(name);

            if (existingDraw == null)
            {
                throw new ArgumentException($"Unable to find lottery draw {name}");
            }

            existingDraw.SpecifyWinningNumbers(new Domain.WinningNumbers
            {
                Primary = winningNumbersCommand.Primary,
                Secondary = winningNumbersCommand.Secondary
            });
            _repository.Update(existingDraw);
        }

        public LotteryResultByDrawDateResult FindByDrawDate(DateTime drawDate)
        {
            var result = _repository.FindByDate(drawDate).FirstOrDefault();

            if (result != null) {

                return new LotteryResultByDrawDateResult {
                    Name = result.Name,
                    Description = result.Description,
                    DrawDate = result.DrawDate,
                    PrimaryNumbers = result.PrimaryNumbers.Numbers,
                    TotalAmountOfPrimaryNumbers = result.PrimaryNumbers.TotalAmountOfNumbers,
                    SecondaryNumbers = result.SecondaryNumbers.Numbers,
                    TotalAmountOfSecondaryNumbers = result.SecondaryNumbers.TotalAmountOfNumbers,
                    WinningPrimaryNumbers = result.WinningNumbers?.Primary ?? new List<int>(),
                    WinningSecondaryNumbers = result.WinningNumbers?.Secondary ?? new List<int>()
                };
            }

            return null;
        }
    }
}
