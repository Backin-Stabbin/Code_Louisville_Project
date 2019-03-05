using System;
using System.Collections.Generic;
using System.Linq;

namespace Code_Louisville {

    class Computer {

        public string Computer_Name;
        public string Building;
        public bool Physical_Machine;
        public bool Active;

        public Computer(string computer_Name, string building, bool physical_Machine, bool active) {
            Computer_Name = computer_Name;
            Building = building;
            Physical_Machine = physical_Machine;
            Active = active;
        }

        public List<Computer> SelectComputersFromBuilding(List<Computer> computerListInput) {

            return computerListInput;

        }
    }
}
