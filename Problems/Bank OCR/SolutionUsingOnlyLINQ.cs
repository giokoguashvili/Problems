var digitsTemplate = @"
 _     _  _     _  _  _  _  _ 
| |  | _| _||_||_ |_   ||_||_|
|_|  ||_  _|  | _||_|  ||_| _|";

var digits1 = @"
 _     _  _  _ 
| |  | _|  ||_|
|_|  ||_   | _|";

var digits2 = @"
 _  _  _ 
|_| _|| |
|_||_ |_|";

var digits3 = @"
 _  _  _  _  _     _  _     _ 
|_||_|  ||_ |_ |_| _| _|  || |
 _||_|  ||_| _|  | _||_   ||_|";

var digits4 = @"
 _  _  _  _  _  _     _  _     _  _ 
| ||_||_|  ||_ |_ |_| _| _|  || || |
|_| _||_|  ||_| _|  | _||_   ||_||_|";

Console.WriteLine(AsNumber(digitsTemplate, digitsTemplate)  == 123456789);      // true
Console.WriteLine(AsNumber(digitsTemplate, digits1)         == 1279);           // true
Console.WriteLine(AsNumber(digitsTemplate, digits2)         == 820);            // true
Console.WriteLine(AsNumber(digitsTemplate, digits3)         == 9876543210);     // true
Console.WriteLine(AsNumber(digitsTemplate, digits4)         == 98765432100);    // true

long AsNumber(string template, string input, int width = 3, int height = 3) 
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
                                                        .Select(digitIndex => String
                                                                                .Join(
                                                                                    Environment.NewLine,
                                                                                    Enumerable
                                                                                        .Range(0, width * height)
                                                                                        .Select(i => oneLine[
                                                                                                        digitIndex * width
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
                DigitsTemplateAsDictionary = g
                            .First()
                            .Select((digit, index) => (digit, index))
                            .ToDictionary(x => x.digit),
                Digits = g.Last()
            })
            .SelectMany(item => item
                                    .Digits
                                    .Select(digit => item.DigitsTemplateAsDictionary[digit].index)
            )
            .Reverse()
            .Select((digit, index) => (digit, index))
            .Reverse()
            .Aggregate((long)0, (prev, next) => prev + (next.digit * (long)Math.Pow(10, next.index)));
