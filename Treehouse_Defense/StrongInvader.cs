namespace TreehouseDefense {

    class Strong_Invader : Invader {

        public override int Health { get; protected set; } = 2;

        public Strong_Invader (Path path) : base (path) {

        }
    }
}