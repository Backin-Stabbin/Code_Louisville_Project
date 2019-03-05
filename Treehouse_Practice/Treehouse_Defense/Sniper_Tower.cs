namespace TreehouseDefense {

    class Sniper_Tower : Tower {

        protected override double Accuracy { get; } = 1.00;

        public Sniper_Tower (MapLocation location) : base (location) {

        }

    }
}