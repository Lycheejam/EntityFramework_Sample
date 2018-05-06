using EntityFramework_Sample.DataStore;
using System;

namespace EntityFramework_Sample {
    class Program {
        static void Main(string[] args) {
            //CRUD

            //Create
            //初回のみ実行すること
            //var insData = new InsertDataStore();
            //insData.InsertHullCode();   //艦種コードの追加
            //insData.InsertShipClass();  //艦型コードの追加
            //insData.InsertFlotillaData(); //護衛隊群の追加
            //insData.InsertDivisionData();   //護衛隊コードの追加
            //insData.InsertShipData();   //艦船データ

            //Read
            var readData = new ReadDataStore();
            //護衛隊群全データ読み込み
            //var fd = readData.ReadFlotillaAllData();
            //foreach (var f in fd) {
            //    Console.WriteLine(f.EscortFlotillaName);
            //    foreach (var divi in f.EscortDivision) {
            //        Console.WriteLine(" - " + divi.EscortDivisionName);
            //    }
            //}
            //護衛隊群を指定して読み込み
            //var fd = readData.ReadFlotillaData(1);
            //Console.WriteLine(fd.EscortFlotillaName);
            //foreach (var divi in fd.EscortDivision) {
            //    Console.WriteLine(" - " + divi.EscortDivisionName);
            //}

            //護衛隊の全データと所属する護衛隊群
            var dd = readData.ReadDivisionAllData();

            foreach (var d in dd) {
                Console.WriteLine("護衛隊：{0} - 所属護衛隊群：{1}", d.EscortDivisionName, d.EscortFlotilla.EscortFlotillaName);
                foreach (var sds in d.SelfDefenseShips) {
                    Console.WriteLine(" - {0}-{1}：{2}", sds.HullCode.HullCodeSymbol, sds.ShipNumber, sds.ShipName);
                }
            }


            //Update


            //Delete
        }
    }
}
