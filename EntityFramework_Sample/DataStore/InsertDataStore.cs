using EntityFramework_Sample.Models;
using System;
using System.IO;
using System.Linq;

namespace EntityFramework_Sample.DataStore {
    class InsertDataStore {
        public void InsertFlotillaData() {
            using (var db = new ShipsDbContext()) {
                var f1 = new EscortFlotilla {
                    EscortFlotillaName = "第1護衛隊群"
                };
                db.EscortFlotillas.Add(f1);

                var f2 = new EscortFlotilla {
                    EscortFlotillaName = "第2護衛隊群"
                };
                db.EscortFlotillas.Add(f2);

                var f3 = new EscortFlotilla {
                    EscortFlotillaName = "第3護衛隊群"
                };
                db.EscortFlotillas.Add(f3);

                var f4 = new EscortFlotilla {
                    EscortFlotillaName = "第4護衛隊群"
                };
                db.EscortFlotillas.Add(f4);

                var f5 = new EscortFlotilla {
                    EscortFlotillaName = "地域配備部隊"
                };
                db.EscortFlotillas.Add(f5);

                db.SaveChanges();
            }
        }

        public void InsertDivisionData() {
            using (var db = new ShipsDbContext()) {
                using (var sr = new StreamReader(@"..\..\Data\DivisionData.txt")) {
                    var tmp = sr.ReadToEnd().Split(new string[] { "\r\n" }
                                                  , StringSplitOptions.None);

                    for (int i = 0; i < tmp.Length; i++) {
                        var edtmp = tmp[i].Split(new string[] { "\t" }, StringSplitOptions.None);
                        //ラムダ式内で配列を使用出来ないため。
                        var efname = edtmp[1];
                        var ed = new EscortDivision {
                            EscortDivisionName = edtmp[0],
                            EscortFlotilla = db.EscortFlotillas.Single(x =>
                                                x.EscortFlotillaName == efname)
                        };
                        db.EscortDivisions.Add(ed); //インサート
                    }
                    db.SaveChanges();   //DBコミット
                }
            }
        }
        //艦種コードのインサート
        public void InsertHullCode() {
            using (var db = new ShipsDbContext()) {
                using (var sr = new StreamReader(@"..\..\Data\HullCodeData.txt")) {
                    var tmp = sr.ReadToEnd().Split(new string[] { "\r\n" }
                                                  , StringSplitOptions.None);

                    for (int i = 0; i < tmp.Length; i++) {
                        var hc = new HullCode {
                            HullCodeSymbol = tmp[i]
                        };
                        db.HullCodes.Add(hc);   //データをインサート
                    }
                    db.SaveChanges();   //DBコミット
                }
            }
        }
        //艦型のインサート
        public void InsertShipClass() {
            using (var db = new ShipsDbContext()) {
                using (var sr = new StreamReader(@"..\..\Data\ShipClassData.txt")) {
                    var tmp = sr.ReadToEnd().Split(new string[] { "\r\n" }
                                                  , StringSplitOptions.None);

                    for (int i = 0; i < tmp.Length; i++) {
                        var sc = new ShipClass {
                            ShipClassName = tmp[i]
                        };
                        db.ShipClasses.Add(sc);   //データをインサート
                    }
                    db.SaveChanges();   //DBコミット
                }
            }
        }
        //艦情報のインサート
        public void InsertShipData() {
            using (var db = new ShipsDbContext()) {
                using (var sr = new StreamReader(@"..\..\Data\ShipData.txt")) {
                    var tmp = sr.ReadToEnd().Split(new string[] { "\r\n" }
                                                  , StringSplitOptions.None);

                    for (int i = 0; i < tmp.Length; i++) {
                        var sdstmp = tmp[i].Split(new string[] { "\t" }, StringSplitOptions.None);
                        //LINQ to Entitiesでは配列をラムダ式に適用できないので変数に入れる
                        var dname = sdstmp[0];
                        var hullcode = sdstmp[1];
                        var scname = sdstmp[4];
                        var dt = new DateTime(Int32.Parse(sdstmp[7]), 1, 1);

                        var sds = new SelfDefenseShip {
                            EscortDivision = db.EscortDivisions.Single(x =>
                                                                x.EscortDivisionName == dname),
                            HullCode = db.HullCodes.Single(x => x.HullCodeSymbol == hullcode),
                            ShipNumber = Int32.Parse(sdstmp[2]),
                            ShipName = sdstmp[3],
                            ShipClass = db.ShipClasses.Single(x => x.ShipClassName == scname),
                            StandardDisplacement = Int32.Parse(sdstmp[5]),
                            FullLoadDisplacement = Int32.Parse(sdstmp[6]),
                            CommissionYear = dt,
                            FullLength = Double.Parse(sdstmp[8]),
                            FullWidth = Double.Parse(sdstmp[9])
                        };
                        db.SelfDefenseShips.Add(sds);   //データをインサート
                    }
                    db.SaveChanges();   //DBコミット
                }
            }
        }
    }
}
