using Xunit;

namespace Peripass.Interview.Tests;

public class WordCombinationFinderTests {
  [Fact]
  public void FindTwoWordCombinations_FindsPairs() {
    var words = new HashSet<string> { "foo", "bar", "foobar" };
    var finder = new WordCombinationFinder(words);

    var results = finder.FindTwoWordCombinations().ToList();

    Assert.Single(results);
    Assert.Equal("foo+bar=foobar", results[0].ToString());
  }

  [Fact]
  public void FindTwoWordCombinations_OnlyReturnsTwoParts() {
    var words = new HashSet<string> { "foobar", "fo", "o", "bar", "foo" };
    var finder = new WordCombinationFinder(words);

    var results = finder.FindTwoWordCombinations().ToList();

    Assert.All(results, r => Assert.Equal(2, r.Parts.Count));
    Assert.Contains(results, r => r.ToString() == "foo+bar=foobar");
  }

  [Fact]
  public void FindTwoWordCombinations_RespectsTargetLength() {
    var words = new HashSet<string> { "ab", "cd", "abcd" };
    var finder = new WordCombinationFinder(words, targetLength: 4);

    var results = finder.FindTwoWordCombinations().ToList();

    Assert.Single(results);
    Assert.Equal("ab+cd=abcd", results[0].ToString());
  }

  [Fact]
  public void FindTwoWordCombinations_ReturnsEmptyForNoMatches() {
    var words = new HashSet<string> { "abc", "def", "ghijkl" };
    var finder = new WordCombinationFinder(words);

    var results = finder.FindTwoWordCombinations().ToList();

    Assert.Empty(results);
  }

  [Fact]
  public void FindCombinations_FindsMultiWordCombos() {
    var words = new HashSet<string> { "foobar", "fo", "o", "bar", "foo" };
    var finder = new WordCombinationFinder(words);

    var results = finder.FindCombinations().Select(r => r.ToString()).ToList();

    Assert.Contains("fo+o+bar=foobar", results);
    Assert.Contains("foo+bar=foobar", results);
  }

  [Fact]
  public void FindCombinations_ExcludesSingleWordDecompositions() {
    var words = new HashSet<string> { "foobar" };
    var finder = new WordCombinationFinder(words);

    var results = finder.FindCombinations().ToList();

    Assert.Empty(results);
  }

  [Fact]
  public void FindCombinations_RespectsTargetLength() {
    var words = new HashSet<string> { "a", "b", "c", "ab", "bc", "abc" };
    var finder = new WordCombinationFinder(words, targetLength: 3);

    var results = finder.FindCombinations().Select(r => r.ToString()).ToList();

    Assert.Contains("a+b+c=abc", results);
    Assert.Contains("ab+c=abc", results);
    Assert.Contains("a+bc=abc", results);
  }

  [Fact]
  public void WordCombination_ToStringFormatsCorrectly() {
    var combo = new WordCombination(["a", "bc", "def"], "abcdef");
    Assert.Equal("a+bc+def=abcdef", combo.ToString());
  }
}
