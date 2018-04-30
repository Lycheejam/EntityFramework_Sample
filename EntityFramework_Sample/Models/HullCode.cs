using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Sample.Models {
    class HullCode {    //艦種別
        public int HullCodeId { get; set; } //艦種記号ID
        public string HullCodeSymbol { get; set; }  //艦種記号 ex.DD,DDG,DDH
        public virtual ICollection<SelfDefenseShip> SelfDefenseShips { get; set; }   //種別護衛艦
    }
}
