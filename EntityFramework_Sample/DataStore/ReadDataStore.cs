﻿using EntityFramework_Sample.Models;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Diagnostics;

namespace EntityFramework_Sample.DataStore {
    class ReadDataStore {
        public ICollection<EscortFlotilla> ReadFlotillaAll() {
            using (var db = new ShipsDbContext()) {
                var fd = db.EscortFlotillas.Include("EscortDivision")
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
    }
}
