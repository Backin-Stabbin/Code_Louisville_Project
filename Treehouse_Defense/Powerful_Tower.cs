namespace TreehouseDefense {

    class Powerful_Tower : Tower {

        protected override int Power { get;} = 3;

        public Powerful_Tower (MapLocation location) : base (location) {

        }

    }
}