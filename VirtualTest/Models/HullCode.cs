using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualTest.Models {
    class HullCode {    //艦種別
        public int HullCodeId { get; set; } //艦種記号ID
        public string HullCodeSymbol { get; set; }  //艦種記号 ex.DD,DDG,DDH
        public ICollection<SelfDefenseShip> SelfDefenseShips { get; set; }   //種別護衛艦
    }
}
