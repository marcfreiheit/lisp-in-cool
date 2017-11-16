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
        // [InlineData("(* (+ 5 (/ 50 5)) (* 7 (- 7 2)))", 350)] // not supported yet!
        public void NestedExpressionTests(string input, int result) {
            var resultFromParser = LispParser.doMagic(input);
            
            Assert.True(resultFromParser == result, "That should work!");
            // Assert.True(true);
        }

        [Theory]
        [InlineData("x", 5)]
        [InlineData("y", 15)]
        public void SetTests(string identifier, int value) {
            LispParser.doMagic(string.Format("(set! {0} {1})", identifier, value));
            var resultFromParser1 = LispParser.doMagic(string.Format("(+ {0} 0)", identifier));
            var resultFromParser2 = LispParser.doMagic(string.Format("(+ {0} 5)", identifier));
            Assert.True(resultFromParser1 == value);
            Assert.True(resultFromParser2 == (value + 5));
        }
    }
}
