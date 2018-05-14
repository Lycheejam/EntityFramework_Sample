using LayzyLoadingTest.Models;
using System;
using System.IO;
using System.Linq;

namespace LayzyLoadingTest.DataStore {
    //class InsertDataStore {
    //    /// <summary>
    //    /// 護衛隊群データをインサート（登録）
    //    /// </summary>
    //    public void InsertFlotillaData() {
    //        using (var db = new ShipsDbContext()) {
    //            //Addを使った方法
    //            //var ef1 = new EscortFlotilla {
    //            //    EscortFlotillaName = "第1護衛隊群"
    //            //};
    //            //db.EscortFlotillas.Add(f1);

    //            //var ef2 = new EscortFlotilla {
    //            //    EscortFlotillaName = "第2護衛隊群"
    //            //};
    //            //db.EscortFlotillas.Add(f2);

    //            //var ef3 = new EscortFlotilla {
    //            //    EscortFlotillaName = "第3護衛隊群"
    //            //};
    //            //db.EscortFlotillas.Add(f3);

    //            //var ef4 = new EscortFlotilla {
    //            //    EscortFlotillaName = "第4護衛隊群"
    //            //};
    //            //db.EscortFlotillas.Add(f4);

    //            //var ef5 = new EscortFlotilla {
    //            //    EscortFlotillaName = "地域配備部隊"
    //            //};
    //            //db.EscortFlotillas.Add(f5);

    //            //AddRangeを使った方法
    //            var ef = new EscortFlotilla[] {
    //                new EscortFlotilla { EscortFlotillaName = "第1護衛隊群" },
    //                new EscortFlotilla { EscortFlotillaName = "第2護衛隊群" },
    //                new EscortFlotilla { EscortFlotillaName = "第3護衛隊群" },
    //                new EscortFlotilla { EscortFlotillaName = "第4護衛隊群" },
    //                new EscortFlotilla { EscortFlotillaName = "地域配備部隊" }
    //            };
    //            db.EscortFlotillas.AddRange(ef);
    //            db.SaveChanges();
    //        }
    //    }
    //    /// <summary>
    //    /// 護衛隊データをインサート（登録）
    //    /// </summary>
    //    public void InsertDivisionData() {
    //        using (var db = new ShipsDbContext())
    //        using (var sr = new StreamReader(@"..\..\Data\DivisionData.txt")) {
    //            var tmp = sr.ReadToEnd().Split(new string[] { "\r\n" }
    //                                          , StringSplitOptions.None);

    //            for (int i = 0; i < tmp.Length; i++) {
    //                var edtmp = tmp[i].Split(new string[] { "\t" }, StringSplitOptions.None);
    //                //ラムダ式内で配列を使用出来ないため。
    //                var efname = edtmp[1];
    //                var ed = new EscortDivision {
    //                    EscortDivisionName = edtmp[0],
    //                    EscortFlotilla = db.EscortFlotillas.Single(x =>
    //                                        x.EscortFlotillaName == efname)
    //                };
    //                db.EscortDivisions.Add(ed); //インサート
    //            }
    //            db.SaveChanges();   //DBコミット
    //        }
    //    }
    //    /// <summary>
    //    /// 艦種コードをインサート
    //    /// ex.DD,DE,DDG,DDH
    //    /// </summary>
    //    public void InsertHullCode() {
    //        using (var db = new ShipsDbContext())
    //        using (var sr = new StreamReader(@"..\..\Data\HullCodeData.txt")) {
    //            var tmp = sr.ReadToEnd().Split(new string[] { "\r\n" }
    //                                          , StringSplitOptions.None);

    //            for (int i = 0; i < tmp.Length; i++) {
    //                var hc = new HullCode {
    //                    HullCodeSymbol = tmp[i]
    //                };
    //                db.HullCodes.Add(hc);   //データをインサート
    //            }
    //            db.SaveChanges();   //DBコミット
    //        }
    //    }
    //    /// <summary>
    //    /// 艦種型データのインサート（登録）
    //    /// ex.こんごう型,いずも型,ひゅうが型
    //    /// </summary>
    //    public void InsertShipClass() {
    //        using (var db = new ShipsDbContext())
    //        using (var sr = new StreamReader(@"..\..\Data\ShipClassData.txt")) {
    //            var tmp = sr.ReadToEnd().Split(new string[] { "\r\n" }
    //                                          , StringSplitOptions.None);

    //            for (int i = 0; i < tmp.Length; i++) {
    //                var sc = new ShipClass {
    //                    ShipClassName = tmp[i]
    //                };
    //                db.ShipClasses.Add(sc);   //データをインサート
    //            }
    //            db.SaveChanges();   //DBコミット
    //        }
    //    }
    //    /// <summary>
    //    /// 艦船情報のインサート（登録）
    //    /// </summary>
    //    public void InsertShipData() {
    //        using (var db = new ShipsDbContext())
    //        using (var sr = new StreamReader(@"..\..\Data\ShipData.txt")) {
    //            var tmp = sr.ReadToEnd().Split(new string[] { "\r\n" }
    //                                          , StringSplitOptions.None);

    //            for (int i = 0; i < tmp.Length; i++) {
    //                var sdstmp = tmp[i].Split(new string[] { "\t" }, StringSplitOptions.None);
    //                /*
    //                 * LINQ to Entitiesでは配列をラムダ式に適用できないので変数に入れる
    //                 */
    //                var dname = sdstmp[0];  //所属護衛隊名
    //                var hullcode = sdstmp[1];   //艦種コード
    //                var scname = sdstmp[4]; //艦型
    //                var dt = new DateTime(Int32.Parse(sdstmp[7]), 1, 1);    //就役年

    //                var sds = new SelfDefenseShip {
    //                    EscortDivision = db.EscortDivisions.Single(x =>
    //                                                        x.EscortDivisionName == dname),
    //                    HullCode = db.HullCodes.Single(x => x.HullCodeSymbol == hullcode),
    //                    ShipNumber = Int32.Parse(sdstmp[2]),
    //                    ShipName = sdstmp[3],
    //                    ShipClass = db.ShipClasses.Single(x => x.ShipClassName == scname),
    //                    StandardDisplacement = Int32.Parse(sdstmp[5]),
    //                    FullLoadDisplacement = Int32.Parse(sdstmp[6]),
    //                    CommissionYear = dt,
    //                    FullLength = Double.Parse(sdstmp[8]),
    //                    FullWidth = Double.Parse(sdstmp[9])
    //                };
    //                db.SelfDefenseShips.Add(sds);   //データをインサート
    //            }
    //            db.SaveChanges();   //DBコミット
    //        }
    //    }
    //    /// <summary>
    //    /// テストデータの追加
    //    /// 護衛隊群,護衛隊,艦種コード,艦種型,艦船データをテスト用に新規に追加します。
    //    /// </summary>
    //    public void InsertTestShipData() {
    //        using (var db = new ShipsDbContext()) {
    //            var ef = new EscortFlotilla { //テスト用護衛隊群の追加
    //                EscortFlotillaName = "テスト護衛隊群"
    //            };
    //            var ed = new EscortDivision {   //テスト用護衛隊の追加
    //                EscortDivisionName = "テスト護衛隊"
    //                , EscortFlotilla = ef
    //            };
    //            var hc = new HullCode { //艦種コード
    //                HullCodeSymbol = "TEST"
    //            };
    //            var sc = new ShipClass {   //艦種型
    //                ShipClassName = "テスト型"
    //            };
    //            //1隻目
    //            var sds = new SelfDefenseShip {
    //                EscortDivision = ed,
    //                HullCode = hc,
    //                ShipNumber = 9998,   //艦船番号
    //                ShipName = "てすと１",   //艦名
    //                ShipClass = sc,
    //                StandardDisplacement = 9999,  //基準排水量
    //                FullLoadDisplacement = 9999,  //満載排水量
    //                FullLength = 999,  //全長
    //                FullWidth = 999,  //全幅
    //                CommissionYear = new DateTime(2018, 5, 7)   //就役
    //            };
    //            db.SelfDefenseShips.Add(sds);
    //            //2隻目
    //            sds = new SelfDefenseShip {
    //                EscortDivision = ed,
    //                HullCode = hc,
    //                ShipNumber = 9999,    //艦船番号
    //                ShipName = "てすと２",    //艦名
    //                ShipClass = sc,
    //                StandardDisplacement = 9999,   //基準排水量
    //                FullLoadDisplacement = 9999,  //満載排水量
    //                FullLength = 999,//全長
    //                FullWidth = 999,  //全幅
    //                CommissionYear = new DateTime(2018, 5, 7)   //就役
    //            };
    //            db.SelfDefenseShips.Add(sds);
    //            //コミット
    //            db.SaveChanges();
    //        }
    //    }
    //}
}
