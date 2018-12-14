
/*
    Object Project
    Current Version - 1.0
    Date - 12/13/18
    Author - Clayton Lewis

    Version 1.0 - 12/13/18
        - Object Project started!!!
*/

using System;

namespace TreehouseDefense {

    class Game {

        static void Main () {

            Map map = new Map (8, 5);
            
            try {
                MapLocation mapLocation = new MapLocation(20, 20, map);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);

            }

            Console.ReadKey();

        }
    }
}