using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Sample.DataStore {
    class DeleteDataStore {
        /// <summary>
        /// 指定した艦船情報を削除する
        /// </summary>
        /// <param name="targetship">削除対象艦船</param>
        public void DeleteShipData(string targetship) {
            using (var db = new ShipsDbContext()) {
                var sds = db.SelfDefenseShips.SingleOrDefault(x => x.ShipName == targetship);
                if (sds != null) {
                    db.SelfDefenseShips.Remove(sds);
                    db.SaveChanges();
                }
            }
        }
        /// <summary>
        /// 指定した艦船番号以上のデータを削除する
        /// </summary>
        /// <param name="targetnumber">削除の起点となる艦船番号</param>
        public void DeleteShipNumberRange(int targetnumber) {
            using (var db = new ShipsDbContext()) {
                var sds = db.SelfDefenseShips.Where(x => x.ShipNumber >= targetnumber);
                if (sds != null) {
                    db.SelfDefenseShips.RemoveRange(sds);
                    db.SaveChanges();
                }
            }
        }
    }
}
