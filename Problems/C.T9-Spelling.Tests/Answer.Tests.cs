using System;
using System.Collections.Generic;
using System.Text;
using Problems.C;
using Xunit;

namespace Problems.Tests
{
    public class AnswerTests
    {
        [Theory]
        [InlineData("hi", "44 444")]
        [InlineData("yes", "999337777")]
        [InlineData("foo  bar", "333666 6660 022 2777")]
        [InlineData("hello world", "4433555 555666096667775553")]
        public void CheckAnswers(string @case, string output)
        {
            Assert
                .Equal(
                    output,
                    new T9SpellingAnswer(
                        @case, 
                        new KeyMap(
                            new KeyPad()
                        )
                    ).Value()
                );
        }

        [Fact]
        public void Check()
        {

            Assert
                .Equal(
                    @"Case #1: 44 444
Case #2: 999337777
Case #3: 333666 6660 022 2777
Case #4: 4433555 555666096667775553",
                    new ProblemCOutputView(
                        new T9SpellingAnswers(
                            new KeyMap(
                                new KeyPad()
                            ),
                            new Content<ProblemCInputModel>(
                                new ProblemCInputModel(
                                    4,
                                    "hi",
                                    "yes",
                                    "foo  bar",
                                    "hello world"
                                )
                            )
                        )
                    ).Value()
                 );

        }
    }
}
