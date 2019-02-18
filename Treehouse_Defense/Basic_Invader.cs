namespace TreehouseDefense {

    class Basic_Invader : Invader {

        public override int Health { get; protected set; } = 1;

        public Basic_Invader (Path path) : base (path) {

        }
    }
}