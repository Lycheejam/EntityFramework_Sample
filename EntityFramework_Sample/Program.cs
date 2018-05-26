using EntityFramework_Sample.DataStore;
using System;

namespace EntityFramework_Sample {
    class Program {
        static void Main(string[] args) {
            //CRUD

            //Create
            //初回のみ実行すること
            var insData = new InsertDataStore();
            //insData.InsertHullCode();   //艦種コードの追加
            //insData.InsertShipClass();  //艦型コードの追加
            //insData.InsertFlotillaData(); //護衛隊群の追加
            //insData.InsertDivisionData();   //護衛隊コードの追加
            //insData.InsertShipData();   //艦船データ
            //insData.InsertTestShipData();   //テスト用データの追加

            //Read
            var readData = new ReadDataStore();

            //全護衛隊群読み込み
            //var fd = readData.ReadFlotilla();
            //foreach (var f in fd) {
            //    Console.WriteLine(f.EscortFlotillaName);
            //}

            //護衛隊群+隷下の護衛隊全読み込み
            //var fd = readData.ReadFlotillaAll();
            //foreach (var f in fd) {
            //    Console.WriteLine(f.EscortFlotillaName);
            //    foreach (var divi in f.EscortDivision) {
            //        Console.WriteLine(" - " + divi.EscortDivisionName);
            //    }
            //}

            //護衛隊群+隷下の護衛隊+護衛隊隷下の護衛艦全読み込み
            //var fd = readData.ReadFlotillaNest();
            //foreach (var f in fd) { //護衛隊群のforeach
            //    Console.WriteLine(f.EscortFlotillaName);
            //    foreach (var divi in f.EscortDivision) {    //護衛隊のforeach
            //        Console.WriteLine(" - {0}", divi.EscortDivisionName);
            //        foreach (var sds in divi.SelfDefenseShips) {    //護衛艦のforeach
            //            Console.WriteLine("  - {0}", sds.ShipName);
            //        }
            //    }
            //}

            //護衛隊群を指定して読み込み
            //var fd = readData.ReadFlotilla(1);
            //Console.WriteLine(fd.EscortFlotillaName);
            //foreach (var divi in fd.EscortDivision) {
            //    Console.WriteLine(" - " + divi.EscortDivisionName);
            //}

            //護衛隊の全データと所属する護衛隊群
            //var dd = readData.ReadDivisionAll();

            //foreach (var d in dd) {
            //    Console.WriteLine("護衛隊：{0} - 所属護衛隊群：{1}", d.EscortDivisionName, d.EscortFlotilla.EscortFlotillaName);
            //    foreach (var sds in d.SelfDefenseShips) {
            //        Console.WriteLine(" - {0}-{1}：{2}", sds.HullCode.HullCodeSymbol, sds.ShipNumber, sds.ShipName);
            //    }
            //}
            //var ed = readData.LazyLoadingTest();
            //foreach (var divisions in ed) {
            //    Console.WriteLine("所属護衛隊群：{0} - 所属護衛隊：{1}",
            //        divisions.EscortFlotilla.EscortFlotillaName, divisions.EscortDivisionName);
            //    foreach (var ships in divisions.SelfDefenseShips) {
            //        Console.WriteLine("{0}-{1}:{2}",ships.HullCode.HullCodeSymbol,ships.ShipNumber,
            //            ships.ShipName);
            //    }
            //}

            //Update
            var updateData = new UpdateDataStore();
            //updateData.UpdateShipDivision("第1護衛隊", "てすと１");
            //updateData.UpdateShipName("てすと１", "変更てすと");

            //Delete
            var deleteData = new DeleteDataStore();
            //deleteData.DeleteShipData("てすと２");
            //deleteData.DeleteShipNumberRange(9998);
            //deleteData.DeleteDivisionRelation("テスト護衛隊");
        }
    }
}
