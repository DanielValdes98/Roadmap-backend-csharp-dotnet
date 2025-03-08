using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StringManipulation.Test
{
    public class StringOperationTest
    {
        [Fact]
        public void ConcatenateStrings()
        {
            var strOperation = new StringOperations();
            var result = strOperation.ConcatenateStrings("Hello", "World");
            Assert.Equal("Hello World", result);
        }
    }
}
