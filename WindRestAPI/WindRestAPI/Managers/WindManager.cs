using System.Collections.Generic;
using System.Linq.Expressions;
using WindGeneratorLib;

namespace WindRestAPI.Managers {
    public class WindManager{
        private static int nextId = 1;
        private static List<WindData> windList = new List<WindData>(){
            new WindData(){Direction = "W", Speed = 6, Id = nextId++},
            new WindData(){Direction = "NW", Speed = 9, Id = nextId++},
            new WindData(){Direction = "NE", Speed = 11, Id = nextId++},
            new WindData(){Direction = "N", Speed = 23, Id = nextId++},
            new WindData(){Direction = "SW", Speed = 3, Id = nextId++},
        };

        public IEnumerable<WindData> GetAll(int? filter){

            List<WindData> result = new List<WindData>(windList);
            if (filter != null){
                result = result.FindAll(w => w.Speed > filter);
            }
            return result;
        }

        public WindData AddWindData(WindData newWind){
            newWind.Id = nextId++;
            windList.Add(newWind);
            return newWind;
        }
    }
}
