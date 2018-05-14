using LayzyLoadingTest.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace LayzyLoadingTest {
    public class ShipsDbContext : DbContext {
        public ShipsDbContext()
            : base("name=ShipsDbContext") {
        }
    }
    public DbSet<SelfDefenseShip> SelfDefenseShips { get; set; }
    //public DbSet<EscortFlotilla> EscortFlotillas { get; set; }
    //public DbSet<EscortDivision> EscortDivisions { get; set; }
    //public DbSet<HullCode> HullCodes { get; set; }
    //public DbSet<ShipClass> ShipClasses { get; set; }
}