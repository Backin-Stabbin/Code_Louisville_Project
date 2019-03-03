using System;
using System.Collections.Generic;

namespace Treehouse.CodeChallenges {
    public class LexicalAnalysis {
        public Dictionary<string, int> WordCount = new Dictionary<string, int>();

        public void AddWord(string word) {
            bool check = false;

            foreach (string entry in WordCount.Keys) {
                if (entry == word) {
                    check = true;
                    break;
                }
            }

            if (check) {
                WordCount[word] += 1;
            }
            else {
                WordCount.Add(word, 1);
            }
        }

        public Dictionary<string, int> WordsWithCountGreaterThan(int i) {
            Dictionary<string, int> biggerWords = new Dictionary<string, int>();
            foreach (var word in WordCount.Keys) {
                if (WordCount[word] > i) {
                    biggerWords.Add(word, WordCount[word]);
                }
            }
            return biggerWords;
        }

    }
}
