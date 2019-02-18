namespace TreehouseDefense {

    class LongRange_Tower : Tower {

        protected override int Range { get; } = 2;

        public LongRange_Tower (MapLocation location) : base (location) {

        }

    }
}