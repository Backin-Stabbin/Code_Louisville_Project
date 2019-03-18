using System.Collections.Generic;
using System.Linq;

namespace Final_Project {

    public class Building {

        public static List<string> GetListOfBuildings(List<Computer> computerList) {
            var buildingList = new List<string>();

            var uniqueBuildings = computerList.GroupBy(computer => computer.Building).ToList();
            uniqueBuildings.ForEach(building => { buildingList.Add(building.Key); });

            return buildingList;
        }
    }
}
