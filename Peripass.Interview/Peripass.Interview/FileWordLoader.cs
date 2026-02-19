namespace Peripass.Interview;

public class FileWordLoader(string filePath) : IWordLoader {
  public IReadOnlySet<string> Load() {
    var words = new HashSet<string>();

    foreach (var line in File.ReadLines(filePath)) {
      var trimmed = line.Trim();
      if (!string.IsNullOrEmpty(trimmed))
        words.Add(trimmed);
    }

    return words;
  }
}