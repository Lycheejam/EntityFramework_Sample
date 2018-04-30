using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework_Sample.Models {
    class ShipClass {   //艦型
        [Key]
        public int ShipClassId { get; set; }    //艦種型ID
        public string ShipClassName { get; set; }   //艦種型名 ex.こんごう型,ひゅうが型
        public virtual ICollection<SelfDefenseShip> SelfDefenseShips { get; set; }   //型別護衛艦
    }
}
