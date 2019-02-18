using System;

namespace Treehouse.CodeChallenges {
    public abstract class SequenceDetector {
        public virtual string Description => "";

        public int[] LastScannedSequence { get; protected set; }

        public abstract bool Scan (int[] sequence);
    }
}