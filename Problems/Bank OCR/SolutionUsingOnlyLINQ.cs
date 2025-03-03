var template = @"
 _     _  _     _  _  _  _  _ 
| |  | _| _||_||_ |_   ||_||_|
|_|  ||_  _|  | _||_|  ||_| _|";

var input = @"
 _     _  _  _ 
| |  | _|  ||_|
|_|  ||_   | _|";

Console.WriteLine(Solve(template, input) == 1279); // true

int Solve(string template, string input, int withSymbols = 3, int highSymbols = 3) 
    => new List<string>() { template, input }
            .Select(item => item
                                .Split("\r\n", StringSplitOptions.None)
                                .Skip(1)
                                .Aggregate(
                                        Enumerable.Repeat(String.Empty, 1),
                                        (prev, next) => prev.Select(i => i + next)
                                )
                                .SelectMany(oneLine => Enumerable
                                                        .Range(0, (oneLine.Length / (withSymbols * highSymbols)))
                                                        .Select(numberIndex => String
                                                                                    .Join(
                                                                                        Environment.NewLine,
                                                                                        Enumerable
                                                                                            .Range(0, withSymbols * highSymbols)
                                                                                            .Select(i => oneLine[
                                                                                                            numberIndex * withSymbols
                                                                                                            + i % withSymbols
                                                                                                            + (i / withSymbols) * withSymbols * (oneLine.Length / (withSymbols * highSymbols))
                                                                                                            ]
                                                                                            )
                                                                                            .Chunk(withSymbols)
                                                                                            .Select(symbols => new String(symbols))
                                                                                    )
                                                        )
                                )
            )
            .GroupBy(g => 1)
            .Select(g => new
            {
                Template = g
                            .First()
                            .Select((n, i) => new { index = i, number = n })
                            .ToDictionary(x => x.number),
                Numbers = g.Last()
            })
            .SelectMany(item => item
                                    .Numbers
                                    .Select(n => item.Template[n].index)
            )
            .Reverse()
            .Select((n, i) => new { Index = i, Number = n })
            .Reverse()
            .Aggregate(0, (prev, next) => prev + (next.Number * (int)Math.Pow(10, next.Index)));
