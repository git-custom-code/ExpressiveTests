using CustomCode.ExpressiveTests;
using ExpressiveTests;
using ExpressiveTests.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.ExpressiveTests
{
    public sealed class Playground : TestCase
    {
        [Fact]
        [UnitTest]
        public void Success()
        {
            Given(() => new List<string>())
            .When(l => l.Add("a"))
            .Then(l =>
                {
                    l[0].Should().Be("b");
                });
        }
    }
}
