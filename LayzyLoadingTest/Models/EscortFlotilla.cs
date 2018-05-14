using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LayzyLoadingTest.Models {
    class EscortFlotilla {  //護衛隊群
        public int EscortFlotillaId { get; set; }   //護衛隊群ID
        public string EscortFlotillaName { get; set; }  //護衛隊群名 ex.第1護衛隊群
        public ICollection<EscortDivision> EscortDivision { get; set; }
    }
}
