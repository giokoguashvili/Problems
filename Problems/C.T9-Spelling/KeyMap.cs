using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems.C
{
    public class KeyMap : DictionaryEnvelop<char, string>
    {
        public KeyMap(IDictionary<int, string> keypad) 
            : base(() => keypad
                            .SelectMany(kv => kv.Value
                                                .Select((ch, index) => new
                                                {
                                                    Symbol = ch,
                                                    val = Enumerable
                                                            .Range(0, index + 1)
                                                            .Select(_ => kv.Key.ToString())
                                                }))
                            .ToDictionary(key => key.Symbol, value => String.Join("", value.val))
            ){}
    }
}
