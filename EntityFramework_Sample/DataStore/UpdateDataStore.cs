using System.Linq;

namespace EntityFramework_Sample.DataStore {
    class UpdateDataStore {
        /// <summary>
        /// 艦船名の変更(更新)
        /// </summary>
        /// <param name="oldname">対象艦船名</param>
        /// <param name="newname">新艦船名</param>
        public void UpdateShipName(string oldname, string newname) {
            using (var db = new ShipsDbContext()) {
                var sds = db.SelfDefenseShips.SingleOrDefault(x => x.ShipName == oldname);
                if (sds != null) {
                    sds.ShipName = newname;
                    db.SaveChanges();
                }
            }
        }
        /// <summary>
        /// 艦船の所属護衛隊を変更(更新)します。
        /// </summary>
        /// <param name="dname">変更先の護衛隊名</param>
        /// <param name="sname">所属変更する艦船名</param>
        public void UpdateShipDivision(string dname, string sname) {
            using (var db = new ShipsDbContext()) {
                //所属護衛隊の変更先を検索
                var ed = db.EscortDivisions.SingleOrDefault(x => x.EscortDivisionName == dname);
                //所属護衛隊を変更する艦船を検索
                var sds = db.SelfDefenseShips.SingleOrDefault(x => x.ShipName == sname);
                if (ed != null && sds != null) {
                    //所属先護衛隊のみを変更(更新)
                    sds.EscortDivision = ed;
                    db.SaveChanges();
                }
            }
        }
    }
}