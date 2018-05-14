using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayzyLoading_Sample {
    class Program {
        static void Main(string[] args) {
            var ship = new SelfDefenseShip[] {
                new SelfDefenseShip{ id = "DDH-181", name = "ひゅうが" },
                new SelfDefenseShip{ id = "DDH-182", name = "いせ" },
                new SelfDefenseShip{ id = "DDH-183", name = "いずも" },
                new SelfDefenseShip{ id = "DDH-184", name = "かが" }
            };

            var layzyquery = ship.SingleOrDefault(x => x.name == "いずも");
            var eagerlyquery = ship.ToList().SingleOrDefault(x => x.name == "いずも");

            foreach (var s in ship) {
                s.id = "テスト";
            }

            Console.WriteLine("遅延実行：{0} : {1}", layzyquery.id, layzyquery.name);
            Console.WriteLine("即時実行：{0} : {1}", eagerlyquery.id, eagerlyquery.name);
        }
    }
    class SelfDefenseShip {
        public string id { get; set; }
        public string name { get; set; }
    }
}
