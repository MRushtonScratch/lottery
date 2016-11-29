using Lottery.Api.Application;
using Lottery.Api.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Lottery.Api.WebHost.Controllers
{
    [Route("api/[controller]")]
    public class LotteryController : Controller
    {
        private ILotteryService _lotteryService;
        public LotteryController(ILotteryService lotteryService)
        {
            _lotteryService = lotteryService;
        }
        
        [HttpPost("draw")]
        public IActionResult Create([FromBody]CreateLotteryDrawCommand lotteryDrawCommand)
        {
            try
            {
                _lotteryService.CreateDraw(lotteryDrawCommand);
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
                
        [HttpGet("draw/{drawDate}")]
        public IActionResult SearchByDate(DateTime drawDate)
        {
            var result = _lotteryService.FindByDrawDate(drawDate);
            if (result != null)
            {
                return Json(result);
            }

            return new NotFoundObjectResult("No results found");
        }

        [HttpPut("draw/{name}/winningNumbers")]
        public IActionResult Put(string name, [FromBody]SpecifyWinningNumbersCommand winningNumbersCommand)
        {
            try
            {
                _lotteryService.SpecifyWinningNumbers(name, winningNumbersCommand);
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
