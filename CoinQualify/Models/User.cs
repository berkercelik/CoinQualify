using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoinQualify.Models
{
    public class User
    {
        [Key]
        public int User_id { get; set; }
        public string User_name { get; set; }
        public string User_mail { get; set; }
        public string User_pw { get; set; }

    }
}
