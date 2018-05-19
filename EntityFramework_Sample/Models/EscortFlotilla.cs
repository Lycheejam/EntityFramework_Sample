using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework_Sample.Models {
    public class EscortFlotilla {  //護衛隊群
        [Key]
        [Column(Order = 0)]
        [Required]
        public int EscortFlotillaId { get; set; }   //護衛隊群ID
        [Column(Order = 1)]
        [Required]
        public string EscortFlotillaName { get; set; }  //護衛隊群名 ex.第1護衛隊群
        public virtual ICollection<EscortDivision> EscortDivision { get; set; }
    }
}
