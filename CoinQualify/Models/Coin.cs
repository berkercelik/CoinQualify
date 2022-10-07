using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoinQualify.Models
{
    public class Coin
    {
        [Key]
        public int Coin_id { get; set; }
        public string Coin_symbol { get; set; }
        public string Coin_name { get; set; }
        public User User { get; set; }
        public int Usercoin_id { get; set; }
        public decimal Usercoin_amount { get; set; }
        public decimal Usercoin_buyprice { get; set; }
        public decimal Usercoin_sellprice { get; set; }
        public decimal Usercoin_profit { get; set; }


    }
}
