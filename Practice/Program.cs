using System;

class MyProgram {
    static void Main () {

        //Console.WriteLine ();
        //Console.WriteLine ("Press any key to close!");
        //Console.ReadKey ();
    }
}

class SequenceDetector {
    public virtual string Description => "";

    public virtual bool Scan (int[] sequence) {
        return true;
    }
}

class RepeatDetector : SequenceDetector {

    public override string Description => "Detects repetitions";

    public override bool Scan (int[] sequence) {
        if (sequence.Length < 2) {
            return false;
        }

        for (int i = 1; i < sequence.Length; ++i) {
            if (sequence[i] == sequence[i - 1]) {

                return true;
            }
        }

        return false;
    }
}