using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualTest.DataStore {
    class DeleteDataStore {
        /// <summary>
        /// 指定した艦船情報を削除する
        /// </summary>
        /// <param name="targetship">削除対象艦船</param>
        public void DeleteShipData(string targetship) {
            using (var db = new VirtualDbContext()) {
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
            using (var db = new VirtualDbContext()) {
                var sds = db.SelfDefenseShips.Where(x => x.ShipNumber >= targetnumber);
                if (sds != null) {
                    db.SelfDefenseShips.RemoveRange(sds);
                    db.SaveChanges();
                }
            }
        }
        /// <summary>
        /// 護衛隊を選択し、それに関連するデータも一括で削除する
        /// </summary>
        /// <param name="targetdivision">削除対象の護衛隊</param>
        public void DeleteDivisionRelation(string targetdivision) {
            using (var db = new VirtualDbContext()) {
                var ed = db.EscortDivisions.Where(x => x.EscortDivisionName == targetdivision)
                                           .Include(x => x.EscortFlotilla)
                                           .SingleOrDefault();
                var sds = db.SelfDefenseShips.Where(x => x.EscortDivision.EscortDivisionId == ed.EscortDivisionId)
                                             .Include(x => x.HullCode)
                                             .Include(x => x.ShipClass);
                if (ed != null) {
                    db.SelfDefenseShips.RemoveRange(sds);
                    db.EscortDivisions.Remove(ed);
                    db.SaveChanges();
                }
            }
        }
    }
}
