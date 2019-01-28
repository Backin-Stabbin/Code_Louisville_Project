namespace TreehouseDefense {

    class Fast_Invader : Invader {

        protected override int StepSize { get; } = 2;

        public Fast_Invader (Path path) : base (path) {

        }
    }
}