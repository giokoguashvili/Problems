using System;
using System.Linq;

namespace Problems.C
{
    public class NeedSpace : IContent<string>
    {
        private readonly string _left;
        private readonly string _right;
        private readonly string _space = " ";
        public NeedSpace(string left, string right)
        {
            _left = left;
            _right = right;
        }

        public string Value()
        {
            if (_left.Last().Equals(_right.First()))
            {
                return _space;
            }
            return String.Empty;
        }
    }
}
