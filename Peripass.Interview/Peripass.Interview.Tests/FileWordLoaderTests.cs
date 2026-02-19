using Xunit;

namespace Peripass.Interview.Tests;

public class FileWordLoaderTests {
  [Fact]
  public void Load_ReturnsUniqueWords() {
    var path = Path.GetTempFileName();
    File.WriteAllLines(path, ["hello", "world", "hello", "test"]);

    var loader = new FileWordLoader(path);
    var words = loader.Load();

    Assert.Equal(3, words.Count);
    Assert.Contains("hello", words);
    Assert.Contains("world", words);
    Assert.Contains("test", words);

    File.Delete(path);
  }

  [Fact]
  public void Load_SkipsEmptyLines() {
    var path = Path.GetTempFileName();
    File.WriteAllLines(path, ["hello", "", "  ", "world"]);

    var loader = new FileWordLoader(path);
    var words = loader.Load();

    Assert.Equal(2, words.Count);

    File.Delete(path);
  }

  [Fact]
  public void Load_ThrowsForMissingFile() {
    var loader = new FileWordLoader("nonexistent.txt");
    Assert.Throws<FileNotFoundException>(() => loader.Load());
  }
}