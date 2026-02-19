using Peripass.Interview;

var filePath = args.Length > 0 ? args[0] : "input.txt";
var loader = new FileWordLoader(filePath);
var words = loader.Load();

var finder = new WordCombinationFinder(words);

foreach (var combination in finder.FindTwoWordCombinations())
  Console.WriteLine(combination);