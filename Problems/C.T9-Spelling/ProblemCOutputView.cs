using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems.C
{
    public class ProblemCOutputView : IContent<string>
    {
        private readonly IEnumerable<IContent<string>> _answers;
        private readonly string _outputFormat = "Case #{0}: {1}";
        public ProblemCOutputView(IEnumerable<IContent<string>> answers)
        {
            _answers = answers;
        }
        public string Value()
        {
            return String
                .Join(
                    Environment.NewLine,
                    _answers
                        .Select((answer, index) => String.Format(_outputFormat, index + 1, answer.Value()))
                );
        }
    }
}
