
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

                Path path = new Path(
                    new[] {
                        new MapLocation(0, 2, map),
                        new MapLocation(1, 2, map),
                        new MapLocation(2, 2, map),
                        new MapLocation(3, 2, map),
                        new MapLocation(4, 2, map),
                        new MapLocation(5, 2, map),
                        new MapLocation(6, 2, map),
                        new MapLocation(7, 2, map),
                    }
                );

                Invader invader = new Invader();
                MapLocation location = new MapLocation(0, 0, map);

                invader.Location = location;

                location = invader.Location;
            }
            catch (OutOfBoundsException ex) {
                Console.WriteLine(ex.Message);
            }
            catch (TreehouseDefenseException) {
                Console.WriteLine("Unhandled TreehouseDefenseException");
            }
            catch (Exception ex) {
                Console.WriteLine("Unhandled Exception" + ex);
            }

            Console.ReadKey();

        }
    }
}