using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework_Sample.Models {
    public class SelfDefenseShip { //護衛艦
        [Column(Order = 0)]
        [Required]
        public virtual EscortDivision EscortDivision { get; set; }  //所属
        [Column(Order = 1)]
        [Required]
        public virtual HullCode HullCode { get; set; }  //艦種記号
        [Key]
        [Column(Order = 2)]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ShipNumber { get; set; }     //艦識別番号
        [Column(Order = 3)]
        [Required]
        public string ShipName { get; set; }    //艦名
        [Column(Order = 4)]
        [Required]
        public virtual ShipClass ShipClass { get; set; }    //艦種型
        [Column(Order = 5)]
        [Required]
        public int StandardDisplacement { get; set; }   //基準排水量（トン）
        [Column(Order = 6)]
        [Required]
        public int FullLoadDisplacement { get; set; }   //満載排水量（トン）
        [Column(Order = 7)]
        [Required]
        public double FullLength { get; set; }  //全長（メートル）
        [Column(Order = 8)]
        [Required]
        public double FullWidth { get; set; }   //全幅（メートル）
        [Column(Order = 9)]
        [Required]
        public DateTime CommissionYear { get; set; } //就役（年）
    }
}
