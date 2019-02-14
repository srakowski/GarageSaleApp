using GarageSaleApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace GarageSaleApp.DataAccess
{
    public class GarageSaleAppDbContext : DbContext
    {
        public DbSet<GarageSaleEvent> GarageSaleEvents { get; set; }

        public DbSet<GarageSaleEventParty> GarageSaleEventParties { get; set; }

        public DbSet<Party> Parties { get; set; }

        public DbSet<Payout> Payouts { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<SaleLineItem> SaleLineItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=garagesales.db");
        }
    }
}
