using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.C
{
    public interface IContent<out TValue>
    {
        TValue Value();
    }
}
