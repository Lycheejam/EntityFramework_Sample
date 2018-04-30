using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework_Sample.Models {
    class EscortFlotilla {  //護衛隊群
        [Key]
        public int EscortFlotillaId { get; set; }   //護衛隊群ID
        public string EscortFlotillaName { get; set; }  //護衛隊群名 ex.第1護衛隊群
        public virtual ICollection<EscortDivision> EscortDivision { get; set; }
    }
}
