namespace TreehouseDefense {

    class Shielded_Invader : Invader {

        private static System.Random _random = new System.Random ();
        public override int Health { get; protected set; } = 3;

        public Shielded_Invader (Path path) : base (path) {

        }

        public override void DecreaseHealth (int factor) {

            if (_random.NextDouble () < .5) {
                base.DecreaseHealth (factor);
            }
            else {
                System.Console.WriteLine ("Shot at a shielded invader but it sustained no damage.");
            }

        }
    }
}