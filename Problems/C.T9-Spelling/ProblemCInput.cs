using System;
using System.IO;
using System.Linq;

namespace Problems.C
{
    public class ProblemCInput : IContent<ProblemCInputModel>
    {
        private readonly TextReader _textReader;

        public ProblemCInput(TextReader textReader)
        {
            _textReader = textReader;
        }
        public ProblemCInputModel Value()
        {
            var N = _textReader.ReadLine();
            var casesCount = Int32.Parse(N);
            var Cases = Enumerable
                .Range(0, casesCount)
                .Select(_ => _textReader.ReadLine());

            return new ProblemCInputModel(casesCount, Cases);
        }
    }
}
