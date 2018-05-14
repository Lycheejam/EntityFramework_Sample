using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayzyLoading_Sample {
    class Program {
        static void Main(string[] args) {
            ArrayTest();
        }
        public static void ArrayTest() {
            string[] ships = { "ひゅうが", "いせ", "いずも", "かが" };

            //遅延実行
            var layzyquery = ships.Where(x => x.Length <= 2);
            //即時実行
            var eagerlyquery = ships.Where(x => x.Length <= 2).ToList();

            //配列内容を変更する
            for (int i = 0; i < ships.Length; i++) {
                ships[i] = "テ" + i;
            }

            foreach (var lq in layzyquery) {    //遅延実行結果出力
                Console.WriteLine(lq);
            }
            Console.WriteLine("-------------------");
            foreach (var eq in eagerlyquery) {  //即時実行結果出力
                Console.WriteLine(eq);
            }
        }
        public void ObjectTest() {
            var ship = new SelfDefenseShip[] {
                new SelfDefenseShip{ id = "DDH-181", name = "ひゅうが" },
                new SelfDefenseShip{ id = "DDH-182", name = "いせ" },
                new SelfDefenseShip{ id = "DDH-183", name = "いずも" },
                new SelfDefenseShip{ id = "DDH-184", name = "かが" }
            };

            var layzyquery = ship.Where(x => x.name == "いずも");
            var eagerlyquery = ship.Where(x => x.name == "いずも").ToList();

            foreach (var layzy in layzyquery) {
                Console.WriteLine("遅延実行：{0} : {1}", layzy.id, layzy.name);
            }
            Console.WriteLine("-------------------");
            foreach (var eagerly in eagerlyquery) {
                Console.WriteLine("即時実行：{0} : {1}", eagerly.id, eagerly.name);
            }

            foreach (var s in ship) {
                s.id = "テスト";
            }

            foreach (var layzy in layzyquery) {
                Console.WriteLine("遅延実行：{0} : {1}", layzy.id, layzy.name);
            }
            foreach (var eagerly in eagerlyquery) {
                Console.WriteLine("即時実行：{0} : {1}", eagerly.id, eagerly.name);
            }
        }
    }

    class SelfDefenseShip {
        public string id { get; set; }
        public string name { get; set; }
    }
}
