using EntityFramework_Sample.Models;
using System;
using System.IO;
using System.Linq;

namespace EntityFramework_Sample {
    class Program {
        static void Main(string[] args) {
            var insData = new InsertData();
            insData.InsertFlotillaData(); //護衛隊群の追加
            insData.InsertDivisionData();   //護衛隊コードの追加
            insData.InsertHullCode();   //艦種コードの追加
            insData.InsertShipClass();  //艦型コードの追加
            insData.InsertShipData();   //艦船データ
        }
    }
    public class InsertData {
        public void InsertFlotillaData() {
            using (var db = new ShipsDbContext()) {
                var f1 = new EscortFlotilla {
                    EscortFlotillaId = 1,
                    EscortFlotillaName = "第1護衛隊群"
                };
                db.EscortFlotillas.Add(f1);

                var f2 = new EscortFlotilla {
                    EscortFlotillaId = 2,
                    EscortFlotillaName = "第2護衛隊群"
                };
                db.EscortFlotillas.Add(f2);

                var f3 = new EscortFlotilla {
                    EscortFlotillaId = 3,
                    EscortFlotillaName = "第3護衛隊群"
                };
                db.EscortFlotillas.Add(f3);

                var f4 = new EscortFlotilla {
                    EscortFlotillaId = 4,
                    EscortFlotillaName = "第4護衛隊群"
                };
                db.EscortFlotillas.Add(f4);

                var f5 = new EscortFlotilla {
                    EscortFlotillaId = 5,
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
                        var efname = edtmp[2];
                        var ed = new EscortDivision {
                            EscortDivisionId = Int32.Parse(edtmp[0]),
                            EscortDivisionName = edtmp[1],
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
                        var hctmp = tmp[i].Split(new string[] { "\t" }, StringSplitOptions.None);
                        var hc = new HullCode {
                            HullCodeId = Int32.Parse(hctmp[0]),
                            HullCodeSymbol = hctmp[1]
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
                        var hctmp = tmp[i].Split(new string[] { "\t" }, StringSplitOptions.None);
                        var sc = new ShipClass {
                            ShipClassId = Int32.Parse(hctmp[0]),
                            ShipClassName = hctmp[1]
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
                        var dt = new DateTime(Int32.Parse(sdstmp[7]),1,1);
                        var dname = sdstmp[0];
                        var hullcode = sdstmp[1];
                        var scname = sdstmp[4];
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
