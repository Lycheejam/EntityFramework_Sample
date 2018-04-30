using System.Data.Entity.Migrations;

namespace EntityFramework_Sample.Models {
    internal sealed class Configuration : DbMigrationsConfiguration<ShipsDbContext>{
        public Configuration() {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "EntityFramework_Sample.ShipsDbContext";
        }
    }
}
