using CoinQualify.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinQualify.Controllers
{
    public class CoinController : Controller
    {
        private readonly ILogger<CoinController> _logger;
        private readonly CqContext _context;

        public CoinController(ILogger<CoinController> logger, CqContext context)
        {
            _logger = logger;
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CoinDetails(int Id)
        {
            var coin = _context.Coins.FirstOrDefault(o => o.Coin_id == Id);
            coin.Coin_id = Id;
            
            return Json(coin);
        }
        
        public async Task<IActionResult> CoinUpdate(Coin coin)
        {
            if (coin.Coin_id == 0)
            {
                await _context.AddAsync(coin);
            }
            else
            {               
                _context.Update(coin);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Dashboard", "Home");

        }

        public async Task<IActionResult> CalculateProfit(int Coin_id)
        {
            var coin =  _context.Coins.FirstOrDefault(o => o.Coin_id == Coin_id);
            if (coin.Usercoin_sellprice > coin.Usercoin_buyprice)
            {
                if (coin.Usercoin_buyprice > 0 || coin.Usercoin_sellprice > 0)
                {
                    //percengate
                    decimal per = (coin.Usercoin_sellprice * 100) / coin.Usercoin_buyprice;
                    decimal newper = per - 100;
                    coin.Usercoin_profit = newper;
                    _context.Update(coin);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    await _context.SaveChangesAsync();
                }
                
            }
            else
            {
                if (coin.Usercoin_buyprice> 0 || coin.Usercoin_sellprice>0 )
                {
                    decimal per_ = (coin.Usercoin_sellprice * 100) / coin.Usercoin_buyprice;
                    decimal newper_ = per_ - 100;
                    coin.Usercoin_profit = newper_;
                    _context.Update(coin);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    await _context.SaveChangesAsync();
                }
                
            }
            return RedirectToAction("Wallet", "User");
        }
    }
}
