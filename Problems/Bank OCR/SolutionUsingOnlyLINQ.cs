var digitsTemplate = @"
 _     _  _     _  _  _  _  _ 
| |  | _| _||_||_ |_   ||_||_|
|_|  ||_  _|  | _||_|  ||_| _|";

var digits = @"
 _     _  _  _ 
| |  | _|  ||_|
|_|  ||_   | _|";

Console.WriteLine(AsNumber(digitsTemplate, digits) == 1279); // true

int AsNumber(string template, string input, int width = 3, int height = 3) 
    => new List<string>() { template, input }
            .Select(item => item
                                .Split("\r\n", StringSplitOptions.None)
                                .Skip(1)
                                .Aggregate(
                                        Enumerable.Repeat(String.Empty, 1),
                                        (prev, next) => prev.Select(i => i + next)
                                )
                                .SelectMany(oneLine => Enumerable
                                                        .Range(0, (oneLine.Length / (width * height)))
                                                        .Select(numberIndex => String
                                                                                .Join(
                                                                                    Environment.NewLine,
                                                                                    Enumerable
                                                                                        .Range(0, width * height)
                                                                                        .Select(i => oneLine[
                                                                                                        numberIndex * width
                                                                                                        + i % width
                                                                                                        + (i / width) * width * (oneLine.Length / (width * height))
                                                                                                        ]
                                                                                        )
                                                                                        .Chunk(width)
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
                            .Select((number, index) => (number, index))
                            .ToDictionary(x => x.number),
                Numbers = g.Last()
            })
            .SelectMany(item => item
                                    .Numbers
                                    .Select(n => item.Template[n].index)
            )
            .Reverse()
            .Select((number, index) => (number, index))
            .Reverse()
            .Aggregate(0, (prev, next) => prev + (next.number * (int)Math.Pow(10, next.index)));
