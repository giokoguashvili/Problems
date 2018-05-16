using System.Collections.Generic;
using System.Text;

namespace Problems.C
{
    public class KeyPad : DictionaryEnvelop<int, string>
    {
        public KeyPad() : base(new Dictionary<int, string>()
        {
            [2] = "ABC",
            [3] = "DEF",
            [4] = "GHI",
            [5] = "JKL",
            [6] = "MNO",
            [7] = "PQRS",
            [8] = "TUV",
            [9] = "WXYZ",
            [0] = " "
        })
        {}
    }
}
