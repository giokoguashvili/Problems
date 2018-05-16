using System.Collections.Generic;
using System.Linq;

namespace Problems.C
{
    public class ProblemCInputModel
    {
        public int CasesCount { get; }
        public IEnumerable<string> Cases { get; }

        public ProblemCInputModel(int casesCount, params string[] cases)
            : this(casesCount, cases.ToList()) {}
        public ProblemCInputModel(int casesCount, IEnumerable<string> cases)
        {
            CasesCount = casesCount;
            Cases = cases;
        }
    }
}
