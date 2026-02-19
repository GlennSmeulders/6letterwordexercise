namespace Peripass.Interview;

public class WordCombinationFinder(IReadOnlySet<string> words, int targetLength = 6) {
  public IEnumerable<WordCombination> FindTwoWordCombinations() {
    var targets = words.Where(w => w.Length == targetLength);

    foreach (var target in targets) {
      for (var i = 1; i < target.Length; i++) {
        var left = target[..i];
        var right = target[i..];

        if (words.Contains(left) && words.Contains(right))
          yield return new WordCombination([left, right], target);
      }
    }
  }
}