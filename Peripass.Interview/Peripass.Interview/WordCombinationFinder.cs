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

  public IEnumerable<WordCombination> FindCombinations() {
    var targets = words.Where(w => w.Length == targetLength);

    foreach (var target in targets) {
      foreach (var parts in Decompose(target))
        if (parts.Count > 1)
          yield return new WordCombination(parts, target);
    }
  }

  private IEnumerable<IReadOnlyList<string>> Decompose(string remaining) {
    if (words.Contains(remaining))
      yield return new List<string> { remaining };

    for (var i = 1; i < remaining.Length; i++) {
      var prefix = remaining[..i];
      if (!words.Contains(prefix))
        continue;

      foreach (var suffixParts in Decompose(remaining[i..])) {
        var parts = new List<string> { prefix };
        parts.AddRange(suffixParts);
        yield return parts;
      }
    }
  }
}