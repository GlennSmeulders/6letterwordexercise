using System.Diagnostics;
using Peripass.Interview;

var filePath = args.Length > 0 ? args[0] : "input.txt";

if (!File.Exists(filePath)) {
  Console.Error.WriteLine($"File not found: {filePath}");
  return 1;
}

var loader = new FileWordLoader(filePath);
var words = loader.Load();
Console.WriteLine($"Loaded {words.Count} unique words");

var finder = new WordCombinationFinder(words);
var sw = Stopwatch.StartNew();

var count = 0;
foreach (var combination in finder.FindCombinations()) {
  Console.WriteLine(combination);
  count++;
}

sw.Stop();
Console.WriteLine($"\nFound {count} combinations in {sw.ElapsedMilliseconds}ms");

return 0;
