using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualTest.Models {
    class EscortDivision {  //護衛隊
        public int EscortDivisionId { get; set; }   //護衛隊ID
        public string EscortDivisionName { get; set; }  //護衛隊名 ex.第1護衛隊
        public EscortFlotilla EscortFlotilla { get; set; }  //所属護衛隊群
        public ICollection<SelfDefenseShip> SelfDefenseShips { get; set; }   //所属艦艇
    }
}
