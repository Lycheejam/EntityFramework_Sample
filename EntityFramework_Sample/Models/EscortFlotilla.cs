using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Sample.Models {
    class EscortFlotilla {  //護衛隊群
        public int EscortFlotillaId { get; set; }   //護衛隊群ID
        public string EscortFlotillaName { get; set; }  //護衛隊群名 ex.第1護衛隊群
        public virtual ICollection<EscortDivision> EscortDivision { get; set; }
    }
}
