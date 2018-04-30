using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework_Sample.Models {
    class HullCode {    //艦種別
        [Key]
        public int HullCodeId { get; set; } //艦種記号ID
        public string HullCodeSymbol { get; set; }  //艦種記号 ex.DD,DDG,DDH
        public virtual ICollection<SelfDefenseShip> SelfDefenseShips { get; set; }   //種別護衛艦
    }
}
