using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LayzyLoadingTest.Models {
    class ShipClass {   //艦型
        public int ShipClassId { get; set; }    //艦種型ID
        public string ShipClassName { get; set; }   //艦種型名 ex.こんごう型,ひゅうが型
        public ICollection<SelfDefenseShip> SelfDefenseShips { get; set; }   //型別護衛艦
    }
}
