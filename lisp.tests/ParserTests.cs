using System;
using Xunit;
using lisp_in_cool;

namespace lisp.tests
{
    public class ParserTests 
    {
        [Theory]
        [InlineData("(+ 1 5)", 6)]
        [InlineData("(- 5 3)", 2)]
        [InlineData("(* 5 2)", 10)]
        [InlineData("(/ 15 3)", 5)]
        public void BasicMathOperationTests(string input, int result)
        {
          var resultFromParser = LispParser.doMagic(input);

          Assert.True(resultFromParser == result, "That should work!");
        }

        [Theory]
        [InlineData("(+ (+ 1 2) 3)", 6)]
        [InlineData("(* 5 (* 7 5))", 175)]
        [InlineData("(* (+ 5 5) (* 7 5))", 350)]
        public void NestedExpressionTests(string input, int result) {
            var resultFromParser = LispParser.doMagic(input);
            
            Assert.True(resultFromParser == result, "That should work!");
            // Assert.True(true);
        }
    }
}
