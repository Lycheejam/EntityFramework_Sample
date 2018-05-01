using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework_Sample.Models {
    class HullCode {    //艦種別
        [Key]
        [Column(Order = 0)]
        [Required]
        public int HullCodeId { get; set; } //艦種記号ID
        [Column(Order = 1)]
        [Required]
        public string HullCodeSymbol { get; set; }  //艦種記号 ex.DD,DDG,DDH
        public virtual ICollection<SelfDefenseShip> SelfDefenseShips { get; set; }   //種別護衛艦
    }
}
