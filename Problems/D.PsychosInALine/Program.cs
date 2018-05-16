using System;
using System.Collections.Generic;
using System.Linq;

namespace D.PsychosInALine
{
    // http://codeforces.com/problemset/problem/320/d
    class Program
    {
        static void Main(string[] args)
        {
            var N = Int32.Parse(Console.ReadLine());
            var line = Console.ReadLine();

            var psychos =
                    line
                    .Split(new[] { ' ' })
                    .Select(item => Int32.Parse(item));

            var answer = Solve(psychos);
            Console.WriteLine(answer);
        }

        static int Solve(IEnumerable<int> psychos)
        {
            int answer = 0;
            while (true)
            {
                var next = Step(psychos.Reverse()); 
                if (next.Check)
                {
                    psychos = next.Step;
                    answer++;
                }
                else
                {
                    break;
                };
                
            }
            return answer;
        }
        static Res Step(IEnumerable<int> array)
        {
            bool b = false;
            var result = new List<int>();
            var res = array
                .Skip(1)
                .Aggregate(
                    new Stack<int>(new[] { array.First() }),
                    (prev, next) =>
                    {
                        if (prev.Peek() < next)
                        {
                            b = true;
                            prev.Pop();
                        }
                        else 
                        {
                            result.Add(prev.Peek());
                            prev.Push(next);
                        }
                        
                        return prev;
                    });
            return new Res() {
                Check = b,
                Step = result
            };
        }

        public class Res
        {
            public IEnumerable<int> Step {get; set;}
            public bool Check{ get; set; }
        }
    }
}
