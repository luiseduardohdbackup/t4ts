using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using T4TS.Example.Models;
using T4TS.Tests.Models;
using T4TS.Tests.Utils;

namespace T4TS.Tests.Traversal
{
    [TestClass]
    public class SolutionTraverserTests
    {
        [TestMethod]
        public void ShouldVisitEachNamespace()
        {
            var solution = DTETransformer.BuildDteSolution(
                typeof(LocalModel),
                typeof(ModelFromDifferentProject)
            );

            int callCount = 0;
            var expectedNames = new string[] { "T4TS.Tests.Models", "T4TS.Example.Models" };

            new SolutionTraverser(solution, (ns) =>
            {
                Assert.AreEqual(expectedNames[callCount++], ns.Name);
            });

            Assert.AreEqual(2, callCount);
        }
    }
}
