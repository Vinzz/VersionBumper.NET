// -----------------------------------------------------------------------
// <copyright file="VersionBumperFacadeTest.cs" company="Yocto projects">
// Copyright (c) 2012 - Vincent Tollu.
// </copyright>
// -----------------------------------------------------------------------
namespace VersionBumperTest
{
    using System.IO;
    using NUnit.Framework;
    using VersionBumper.Facade;
    using System;

    /// <summary>
    /// Tests for the facade
    /// </summary>
    [TestFixture]
    public class VersionBumperFacadeTest
    {
        /// <summary>
        /// Tests the facade.
        /// </summary>
        [Test]
        public void TestFacade()
        {
            string newTestFiles = @".\TestInputsFacade" + DateTime.Now.Ticks;

            new Microsoft.VisualBasic.Devices.Computer().FileSystem.CopyDirectory(@".\TestInputs", newTestFiles);

            VersionBumperFacade.BumpIt(new DirectoryInfo(newTestFiles), 9, 8, 7, 6);

            string content = FileReader.ReadFileContent(newTestFiles + @"\Project1\Properties\AssemblyInfo.cs");
            Assert.IsTrue(content.Contains(@"[assembly: AssemblyVersion(""9.8.7.6"")]"));
            Assert.IsTrue(content.Contains(@"[assembly: AssemblyFileVersion(""9.8.7.6"")]"));

            content = FileReader.ReadFileContent(newTestFiles + @"\Project3\Product.wxs");
            Assert.IsTrue(content.Contains(@"Version=""9.8.7.6"""));

            Directory.Delete(newTestFiles, true);
        }
    }
}
