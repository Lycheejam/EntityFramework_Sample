using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Sample.Models {
    class EscortDivision {  //護衛隊
        public int EscortDivisionId { get; set; }   //護衛隊ID
        public string EscortDivisionName { get; set; }  //護衛隊名 ex.第1護衛隊
        public virtual EscortFlotilla EscortFlotilla { get; set; }  //所属護衛隊群
        public virtual ICollection<SelfDefenseShip> SelfDefenseShips { get; set; }   //所属艦艇
    }
}
