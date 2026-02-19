# Peripass.Interview - 6-Letter Word Combinations

Finds all ways to combine shorter words from a list into 6 letter words that also appear in the list.

## How to run

```bash
dotnet run --project .\Peripass.Interview
```

This reads `input.txt` from the solution folder by default.

## Custom input & tests

Pass a different file as a CLI argument:

```bash
dotnet run --project .\Peripass.Interview -- ..\path\to\other.txt
```

Run the unit tests:

```bash
dotnet test Peripass.Interview.Tests
```

## Improvements with more time

- **Memoization** in the recursive search to avoid re-exploring the same sub-problems
- **Async file reading** for larger input files so the UI thread stays responsive
- **DI container** so `IWordLoader` implementations can be swapped, reused, and tested without changing consuming code
- **Benchmark tests**  to track performance regressions across commits