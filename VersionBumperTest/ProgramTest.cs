// -----------------------------------------------------------------------
// <copyright file="ProgramTest.cs" company="Yocto projects">
// Copyright (c) 2012 - Vincent Tollu.
// </copyright>
// -----------------------------------------------------------------------
namespace VersionBumperTest
{
    using System.Collections.Generic;
    using System.IO;
    using NUnit.Framework;
    using VersionBumper;
    using System;

    /// <summary>
    /// Tests for the program
    /// </summary>
    [TestFixture]
    public class ProgramTest
    {
        /// <summary>
        /// Tests the program.
        /// </summary>
        [Test]
        public void TestProgram()
        {
            List<string> args = new List<string>();

            string newTestFiles = @".\TestInputsProgram" + DateTime.Now.Ticks;

            new Microsoft.VisualBasic.Devices.Computer().FileSystem.CopyDirectory(@".\TestInputs", newTestFiles);


            args.Add(@"-test");
            args.Add(@"-d");
            args.Add(newTestFiles);
            args.Add(@"-v");
            args.Add(@"1");
            args.Add(@"2");
            args.Add(@"3");
            args.Add(@"4");

            Program.Main(args.ToArray());

            string content = FileReader.ReadFileContent(newTestFiles + @"\Project1\Properties\AssemblyInfo.cs");
            Assert.IsTrue(content.Contains(@"[assembly: AssemblyVersion(""1.2.3.4"")]"));
            Assert.IsTrue(content.Contains(@"[assembly: AssemblyFileVersion(""1.2.3.4"")]"));

            content = FileReader.ReadFileContent(newTestFiles + @"\Project3\Product.wxs");
            Assert.IsTrue(content.Contains(@"Version=""1.2.3.4"""));

            Directory.Delete(newTestFiles, true);
        }

        /// <summary>
        /// Tests the program on a TFS codebase (not run automatically though).
        /// </summary>
        //[Test]
        public void TestProgramTFS()
        {
            List<string> args = new List<string>();

            args.Add(@"-d");
            args.Add(@"D:\Projets\GCS - RefonteCouts\Trunk\GCS.StandardCost");
            args.Add(@"-v");
            args.Add(@"1");
            args.Add(@"2");
            args.Add(@"3");
            args.Add(@"4");

            Program.Main(args.ToArray());

            string content = new FileInfo(@"D:\Projets\GCS - RefonteCouts\Trunk\GCS.StandardCost\GCS.StandardCosting.Core\Properties\AssemblyInfo.cs").OpenText().ReadToEnd();
            Assert.IsTrue(content.Contains(@"[assembly: AssemblyVersion(""1.2.3.4"")]"));
            Assert.IsTrue(content.Contains(@"[assembly: AssemblyFileVersion(""1.2.3.4"")]"));

            content = new FileInfo(@"D:\Projets\GCS - RefonteCouts\Trunk\GCS.StandardCost\GCS.StandardCosting.ClientService.Setup\Product.wxs").OpenText().ReadToEnd();
            Assert.IsTrue(content.Contains(@"Version=""1.2.3.4"""));
        }
    }
}
