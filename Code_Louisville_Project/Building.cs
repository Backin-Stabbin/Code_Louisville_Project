using System.Collections.Generic;
using System.Linq;

namespace Final_Project {

    public class Building {

        public static List<string> Get_List_Of_Buildings(List<Computer> computers) {
            var buildingList = new List<string>();

            var uniqueBuildings = computers.GroupBy(computer => computer.Building).ToList();
            uniqueBuildings.ForEach(building => { buildingList.Add(building.Key); });

            return buildingList;
        }
    }
}
