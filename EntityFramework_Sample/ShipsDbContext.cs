using EntityFramework_Sample.Models;
using System.Data.Entity;

namespace EntityFramework_Sample {
    class ShipsDbContext : DbContext {
        public ShipsDbContext()
            : base("name=ShipsDbContext") {
        }
        public DbSet<SelfDefenseShip> SelfDefenseShips { get; set; }
        public DbSet<EscortFlotilla> EscortFlotillas { get; set; }
        public DbSet<EscortDivision> EscortDivisions { get; set; }
        public DbSet<HullCode> HullCodes { get; set; }
        public DbSet<ShipClass> ShopClasses { get; set; }
    }
}