using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;
using WindGeneratorLib;
using WindRestAPI.Database;

namespace WindRestAPI.Managers {
    public class DBWindManager{
        private WindDataDBContext _context = new WindDataDBContext();

        public DBWindManager(){

        }

        public IEnumerable<WindData> GetAll(int? speed){
            IEnumerable<WindData> result = _context.WindData;
            if (speed != null){
                return result.Where(d => d.Speed > speed);
            }

            return result;
        }

        public WindData AddWindData(WindData newData) {
            newData.Id = 0;
            _context.WindData.Add(newData);
            _context.SaveChanges();
            return newData;
        }

    }
}
