using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Problems.C
{
    public class T9SpellingAnswers : IEnumerable<IContent<string>> 
    {
        private readonly IDictionary<char, string> _keyMap;
        private readonly IContent<ProblemCInputModel> _input;

        public T9SpellingAnswers(IDictionary<char, string> keyMap, IContent<ProblemCInputModel> input)
        {
            _keyMap = keyMap;
            _input = input;
        }
        public IEnumerator<IContent<string>> GetEnumerator()
        {
            return _input
                .Value()
                .Cases
                .Select(@case => new T9SpellingAnswer(@case, _keyMap))
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
