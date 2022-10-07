using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoinQualify.Models;
using CoinQualify.Filter;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoinQualify.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly CqContext _context;
        public UserController(ILogger<UserController> logger, CqContext context)
        {
            _logger = logger;
            _context = context;

        }

        [UserFilter]
        public async Task<IActionResult> Wallet()
        {
            var coin = _context.Coins.FirstOrDefault(u => u.Usercoin_id == HttpContext.Session.GetInt32("id"));
            HttpContext.Session.GetInt32("id");
            List<Coin> list = _context.Coins.ToList();
            return View(list);
        }
        public async Task<IActionResult> AddCoin(Coin coin)
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
                       

            return RedirectToAction(nameof(Wallet));
        }
        public async Task<IActionResult> CoinDetails(int Coin_id)
        {
            var coin = await _context.Coins.FindAsync(Coin_id);
            return Json(coin);
        }

        public async Task<IActionResult> DeleteCoin(int? Id)
        {
            Coin coin = await _context.Coins.FindAsync(Id);
            _context.Remove(coin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Wallet));
        }


        #region api
        public User Walletapi()
        {
            var user = _context.Users.FirstOrDefault(u => u.User_id == HttpContext.Session.GetInt32("id"));
            HttpContext.Session.GetInt32("id");
            user.User_pw = "";
            return user;
        }
        

        public Coin Walletcoin3api()
        {           
            var coin = _context.Coins.FirstOrDefault(u => u.Coin_id == HttpContext.Session.GetInt32("cid"));
            HttpContext.Session.GetInt32("cid");
            return coin;            
        }
        #endregion
        public IActionResult Login()
        {
            return View();
        }

        [UserFilter]
        public IActionResult Index()
        {
            return RedirectToAction("Dashboard", "Home");
        }

        #region signin out
        public async Task<IActionResult> Signin(string Usermail, string Pass)
        {
            var user = _context.Users.FirstOrDefault(u => u.User_mail == Usermail && u.User_pw == Pass);
            if (user == null)
            {
                return RedirectToAction(nameof(Login));
            }

            
          
            HttpContext.Session.SetInt32("id", user.User_id);
            
            return RedirectToAction(nameof(Wallet));
        }
        public IActionResult Signout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region add user
        public async Task<IActionResult> UserDetails(int User_id)
        {
            var user = await _context.Users.FindAsync(User_id);
            return Json(user);
        }
        public async Task<IActionResult> AddUser(User user)
        {

            if (user.User_id == 0)
            {
                await _context.AddAsync(user);
            }
            else
            {
                _context.Update(user);
            }
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Login));
        }
        #endregion
        
        public User PrintName()
        {           
            var user = _context.Users.FirstOrDefault(u => u.User_id == HttpContext.Session.GetInt32("id"));
            HttpContext.Session.GetInt32("id");
            user.User_pw = "";
            return user;

        }
    }
}
