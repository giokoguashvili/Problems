using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Problems.C
{
    public class ProblemCOutput 
    {
        private readonly IContent<string> _view;
        private readonly TextWriter _textWriter;
        public ProblemCOutput(IEnumerable<IContent<string>> answers, TextWriter textWriter)
            : this(new ProblemCOutputView(answers), textWriter) {}
        public ProblemCOutput(IContent<string> view, TextWriter textWriter)
        {
            _view = view;
            _textWriter = textWriter;
        }
        public void Show()
        {
            _textWriter
                .WriteLine(
                    _view.Value()
                );
        }
    }
}
