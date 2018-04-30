﻿using System;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework_Sample.Models {
    class SelfDefenseShip { //護衛艦
        public virtual EscortDivision EscortDivision { get; set; }  //所属
        public virtual HullCode HullCode { get; set; }  //艦種記号
        [Key]
        public int ShipNumber { get; set; }     //艦識別番号
        public string ShipName { get; set; }    //艦名
        public virtual ShipClass ShipClass { get; set; }    //艦種型
        public int StandardDisplacement { get; set; }   //基準排水量（トン）
        public int FullLoadDisplacement { get; set; }   //満載排水量（トン）
        public double FullLength { get; set; }  //全長（メートル）
        public double FullWidth { get; set; }   //全幅（メートル）
        public DateTime CommissionYear { get; set; } //就役（年）
    }
}
