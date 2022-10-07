using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinQualify.Models
{
    public class CqContext : DbContext
    {
        public CqContext(DbContextOptions<CqContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Coin> Coins { get; set; }
    }
}
