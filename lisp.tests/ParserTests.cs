using System;
using Xunit;
using lisp_in_cool;

namespace lisp.tests
{
    public class ParserTests 
    {
        [Fact]
        public void parseBasicBracketsTest()
        {
          var result = LispParser.doMagic("(+ 1 5)");

          Assert.True(result == 6, "That should work!");
        }
    }
}
