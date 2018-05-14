namespace VirtualTest {
    using System.Data.Entity;
    using VirtualTest.Models;

    class VirtualDbContext : DbContext {
        public VirtualDbContext()
            : base("name=VirtualDbContext") {
        }

        public DbSet<SelfDefenseShip> SelfDefenseShips { get; set; }
        public DbSet<EscortFlotilla> EscortFlotillas { get; set; }
        public DbSet<EscortDivision> EscortDivisions { get; set; }
        public DbSet<HullCode> HullCodes { get; set; }
        public DbSet<ShipClass> ShipClasses { get; set; }
    }
}