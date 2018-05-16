using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Problems.C
{
    public interface IThunk<TInput, TOutput>
    {
        TOutput Result(TInput input);
    }
    public class Thunk<TInput, TOutput> : IThunk<TInput, TOutput>
    {
        private readonly Func<TInput, TOutput> _func;

        public Thunk(Func<TInput,TOutput> func)
        {
            _func = func;
        }
        public TOutput Result(TInput input)
        {
            return _func(input);
        }
    }
    public static class new_
    {
        public static IEnumerable<TResult> Maped<T,TResult>(IEnumerable<T> array, Func<T,TResult> mapper)
        {
            return Maped(array, new Thunk<T, TResult>(mapper));
        }
        public static IEnumerable<TResult> Maped<T, TResult>(IEnumerable<T> array, IThunk<T, TResult> thunk)
        {
            return array.Select(thunk.Result);
        }


    }

    public class StringThunk : IThunk<int, string>
    {
        public string Result(int input)
        {
            return input.ToString();
        }
    }

    // https://code.google.com/codejam/contest/dashboard?c=351101#s=p2
    class Program
    {
        static void Main(string[] args)
        {
            new_.Maped(
                new List<int>(),
                new StringThunk()
            );
            new ProblemCOutput(
                new T9SpellingAnswers(
                    new KeyMap(
                        new KeyPad()
                    ),
                    new ProblemCInput(
                        Console.In
                    )
                ),
                Console.Out
            ).Show();

            ReadLine();
        }
    }
}
