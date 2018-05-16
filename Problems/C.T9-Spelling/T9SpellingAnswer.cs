using System.Collections.Generic;
using System.Linq;

namespace Problems.C
{
    public class T9SpellingAnswer : IContent<string>
    {
        private readonly string _case;
        private readonly IDictionary<char, string> _keyMap;

        public T9SpellingAnswer(string @case, IDictionary<char, string> keyMap)
        {
            _case = @case;
            _keyMap = keyMap;
        }
        public string Value()
        {
            return _case
                .ToUpper()
                .ToCharArray()
                .Select(ch => _keyMap[ch])
                .Aggregate(" ", (prev, next) => $"{prev}{new NeedSpace(prev, next).Value()}{next}")
                .Trim();
        }
    }
}
