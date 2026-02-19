namespace Peripass.Interview;

public record WordCombination(IReadOnlyList<string> Parts, string Combined) {
  public override string ToString() {
    return string.Join("+", Parts) + "=" + Combined;
  }
}