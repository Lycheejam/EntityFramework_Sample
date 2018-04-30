using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework_Sample.Models {
    class EscortDivision {  //護衛隊
        [Key]
        public int EscortDivisionId { get; set; }   //護衛隊ID
        public string EscortDivisionName { get; set; }  //護衛隊名 ex.第1護衛隊
        public virtual EscortFlotilla EscortFlotilla { get; set; }  //所属護衛隊群
        public virtual ICollection<SelfDefenseShip> SelfDefenseShips { get; set; }   //所属艦艇
    }
}
