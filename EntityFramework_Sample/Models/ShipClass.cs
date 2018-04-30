using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Sample.Models {
    class ShipClass {   //艦型
        public int ShipClassId { get; set; }    //艦種型ID
        public string ShipClassName { get; set; }   //艦種型名 ex.こんごう型,ひゅうが型
        public virtual ICollection<SelfDefenseShip> SelfDefenseShips { get; set; }   //型別護衛艦
    }
}
