using EntityFramework_Sample.DataStore;

namespace EntityFramework_Sample {
    class Program {
        static void Main(string[] args) {
            var insData = new InsertDataStore();
            insData.InsertHullCode();   //艦種コードの追加
            insData.InsertShipClass();  //艦型コードの追加
            insData.InsertFlotillaData(); //護衛隊群の追加
            insData.InsertDivisionData();   //護衛隊コードの追加
            insData.InsertShipData();   //艦船データ
        }
    }
}
