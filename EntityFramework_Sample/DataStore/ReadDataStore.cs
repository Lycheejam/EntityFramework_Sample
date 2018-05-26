using EntityFramework_Sample.Models;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Diagnostics;
using System;

namespace EntityFramework_Sample.DataStore {
    class ReadDataStore {
        /// <summary>
        /// 護衛隊群全読み込み
        /// </summary>
        /// <returns>List<護衛隊群></returns>
        public List<EscortFlotilla> ReadFlotilla() {
            using (var db = new ShipsDbContext()) {
                db.Database.Log = sql => { Debug.Write(sql); };
                var fd = db.EscortFlotillas.ToList();
                return fd;
            }
        }
        /// <summary>
        /// 護衛隊群と隷下の護衛隊全読み込み
        /// </summary>
        /// <returns>List<護衛隊群<護衛隊>></returns>
        public List<EscortFlotilla> ReadFlotillaAll() {
            using (var db = new ShipsDbContext()) {
                db.Database.Log = sql => { Debug.Write(sql); };
                var fd = db.EscortFlotillas.Include("EscortDivision")
                                           .ToList();
                return fd;
            }
        }
        /// <summary>
        /// 護衛隊群と隷下の護衛隊+護衛隊隷下の護衛艦全読み込み
        /// </summary>
        /// <returns>List<護衛隊群<護衛隊<護衛艦>>></returns>
        public List<EscortFlotilla> ReadFlotillaNest() {
            using (var db = new ShipsDbContext()) {
                db.Database.Log = sql => { Debug.Write(sql); };
                var fd = db.EscortFlotillas//.Include(x => x.EscortDivision)
                                           .Include(x => x.EscortDivision
                                                .Select(y => y.SelfDefenseShips))
                                           .ToList();
                return fd;
            }
        }
        public EscortFlotilla ReadFlotilla(int fId) {
            using (var db = new ShipsDbContext()) {
                var fd = db.EscortFlotillas.Where(x => x.EscortFlotillaId == fId)
                                           .Include("EscortDivision")
                                           .SingleOrDefault();
                return fd;
            }
        }
        public ICollection<EscortDivision> ReadDivisionAll() {
            using (var db = new ShipsDbContext()) {
                db.Database.Log = sql => { Debug.Write(sql); };
                var dd = db.EscortDivisions.Include(x => x.EscortFlotilla)
                                           .Include(x => x.SelfDefenseShips
                                                .Select(y => y.HullCode))
                                           .ToList();
                return dd;
            }

        }
        public EscortDivision ReadDivision(int dId) {
            using (var db = new ShipsDbContext()) {
                var dd = db.EscortDivisions.Where(x => x.EscortDivisionId == dId)
                                           .Include("EscortFlotilla")
                                           .SingleOrDefault();
                return dd;
            }
        }

        public ICollection<EscortDivision> LazyLoadingTest() {
            using (var db = new ShipsDbContext()) {
                db.Database.Log = sql => { Debug.Write(sql); };
                db.EscortFlotillas.Load();
                db.SelfDefenseShips.Load();
                db.HullCodes.Load();
                db.ShipClasses.Load();

                var ed = db.EscortDivisions.ToList();
                return ed;
            }
        }
    }
}
