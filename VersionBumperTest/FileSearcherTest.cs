// -----------------------------------------------------------------------
// <copyright file="FileSearcherTest.cs" company="Yocto projects">
// Copyright (c) 2012 - Vincent Tollu.
// </copyright>
// -----------------------------------------------------------------------
namespace VersionBumperTest
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using NUnit.Framework;
    using VersionBumper.Explorer;

    /// <summary>
    /// Test for the file seacher component
    /// </summary>
    [TestFixture]
    public class FileSearcherTest
    {
        /// <summary>
        /// Tests the file searcher.
        /// </summary>
        [Test]
        public void TestFileSearcher()
        {
            Stack<FileInfo> found = FileSearcher.SearchForfiles(new DirectoryInfo(@".\TestInputs"));

            Assert.IsTrue(found.Where(x => x.Name == "AssemblyInfo.cs").Count() == 2);
            Assert.IsTrue(found.Where(x => x.Name == "Product.wxs").Count() == 1);
        }
    }
}
