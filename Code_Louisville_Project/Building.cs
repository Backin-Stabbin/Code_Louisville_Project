/*
    This is the Building Class

    Contains a method to gather a list of buildings
*/

using System.Collections.Generic;
using System.Linq;

namespace Final_Project {

    public class Building {

        // Returns a list of buildings avaiable based on list of computer given
        public static List<string> GetListOfBuildings(List<Computer> computerList) {
            var buildingList = new List<string>();

            var uniqueBuildings = computerList.GroupBy(computer => computer.Building).ToList();
            uniqueBuildings.ForEach(building => { buildingList.Add(building.Key); });

            return buildingList;
        }
    }
}
