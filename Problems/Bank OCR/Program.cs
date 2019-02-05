using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;

namespace ConsoleApp3
{
    class Program
    {
        public static IEnumerable<string> NumbersAsSymbols(IEnumerable<IEnumerable<string>> chunks)
        {
            return Enumerable
                            .Zip(
                                Enumerable
                                    .Zip(
                                        chunks.ElementAt(0),
                                        chunks.ElementAt(1),
                                        (a, b) => a.ToString() + "\n" + b.ToString()
                                     ),
                                chunks.ElementAt(2),
                                (ab, c) => ab + "\n" + c.ToString()
                            );
        }

        private static IEnumerable<IEnumerable<string>> Chunks(string numbers)
        {
            return numbers
                        .Split("\r\n", StringSplitOptions.None)
                        .Skip(1)
                        .Select(str => str
                                        .ToObservable()
                                        .Buffer(3)
                                        .Select(s => new string(s.ToArray()))
                                        .ToEnumerable()
                        );
        }

        public static Dictionary<string, int> AsDictionary(IEnumerable<string> numbers)
        {
            return numbers
                .Select((Str, Index) => new
                {
                    Index,
                    Str,
                })
                .ToDictionary(
                    key => key.Str,
                    val => val.Index
                 );
        }

        public static int Numbers(Dictionary<string, int> dict, IEnumerable<string> numbers)
        {
            return numbers.Aggregate(0, (prev, n) => prev * 10 + dict[n]);
        }

        static void Main(string[] args)
        {
            var symbolsForDictionary = @"
 _     _  _     _  _  _  _  _ 
| |  | _| _||_||_ |_   ||_||_|
|_|  ||_  _|  | _||_|  ||_| _|";


            var inputSymbols = @"
    _  _     _  _  _  _  _ 
  | _| _||_||_ |_   ||_||_|
  ||_  _|  | _||_|  ||_| _|";

            Console
                .WriteLine(
                    Numbers(
                        AsDictionary(
                            NumbersAsSymbols(
                                Chunks(symbolsForDictionary)
                            )
                        ),
                        NumbersAsSymbols(
                            Chunks(inputSymbols)
                        )
                    )
                );
        }
    }
}
