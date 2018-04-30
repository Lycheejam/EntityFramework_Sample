using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Sample.Models {
    class MaritimeSelfDefenseForce {
        //護衛艦
        public class SelfDefenseShip {
            public virtual EscortDivision EscortDivision { get; set; }  //所属
            public virtual HullCode HullCode { get; set; }  //艦種記号
            public int ShipNumber { get; set; }     //艦識別番号
            public string ShipName { get; set; }    //艦名
            public virtual ShipClass ShipClass { get; set; }    //艦種型
            public int StandardDisplacement { get; set; }   //基準排水量（トン）
            public int FullLoadDisplacement { get; set; }   //満載排水量（トン）
            public double FullLength { get; set; }  //全長（メートル）
            public double FullWidth { get; set; }   //全幅（メートル）
            public DateTime CommissionYear { get; set; } //就役（年）
        }
        //護衛隊群
        public class EscortFlotilla {
            public int EscortFlotillaId { get; set; }   //護衛隊群ID
            public string EscortFlotillaName { get; set; }  //護衛隊群名 ex.第1護衛隊群
            public virtual ICollection<EscortDivision> EscortDivision { get; set; }
        }
        //護衛隊
        public class EscortDivision {
            public int EscortDivisionId { get; set; }   //護衛隊ID
            public string EscortDivisionName { get; set; }  //護衛隊名 ex.第1護衛隊
            public virtual EscortFlotilla EscortFlotilla { get; set; }  //所属護衛隊群
            public virtual ICollection<SelfDefenseShip> SelfDefenseShip { get; set; }   //所属艦艇
        }
        //艦種記号
        public class HullCode {
            public int HullCodeId { get; set; } //艦種記号ID
            public string HullCodeSymbol { get; set; }  //艦種記号 ex.DD,DDG,DDH
            public virtual ICollection<SelfDefenseShip> SelfDefenseShip { get; set; }   //種別護衛艦
        }
        //艦種型
        public class ShipClass {
            public int ShipClassId { get; set; }    //艦種型ID
            public string ShipClassName { get; set; }   //艦種型名 ex.こんごう型,ひゅうが型
            public virtual ICollection<SelfDefenseShip> SelfDefenseShip { get; set; }   //型別護衛艦
        }
    }
}
