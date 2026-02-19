using Peripass.Interview;

var filePath = args.Length > 0 ? args[0] : "input.txt";
var loader = new FileWordLoader(filePath);
var words = loader.Load();

Console.WriteLine($"Loaded {words.Count} unique words");
