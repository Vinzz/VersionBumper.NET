// -----------------------------------------------------------------------
// <copyright file="BumpAssemblyInfoTest.cs" company="Yocto projects">
// Copyright (c) 2012 - Vincent Tollu.
// </copyright>
// -----------------------------------------------------------------------
namespace VersionBumperTest
{
    using System.IO;
    using NUnit.Framework;
    using VersionBumper.Bumpers;

    /// <summary>
    /// Test for the assembly bumper
    /// </summary>
    [TestFixture]
    public class BumpAssemblyInfoTest
    {
        /// <summary>
        /// Bumps the assembly file.
        /// </summary>
        [Test]
        public void BumpAssemblyFile()
        {
            AssemblyBumper.BumpIt(new FileInfo(@".\TestInputs\Project1\Properties\AssemblyInfo.cs"), 9, 9, 9, 9);

            string content = new FileInfo(@".\TestInputs\Project1\Properties\AssemblyInfo.cs").OpenText().ReadToEnd();
            Assert.IsTrue(content.Contains(@"[assembly: AssemblyVersion(""9.9.9.9"")]"));
            Assert.IsTrue(content.Contains(@"[assembly: AssemblyFileVersion(""9.9.9.9"")]"));
        }

        /// <summary>
        /// Bumps the assembly info.
        /// </summary>
        [Test]
        public void BumpAssemblyInfo()
        {
            string input = @"using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
[assembly: AssemblyTitle(""VersionBumper"")]
[assembly: AssemblyDescription("""")]
[assembly: AssemblyConfiguration("""")]
[assembly: AssemblyCompany("""")]
[assembly: AssemblyProduct(""VersionBumper"")]
[assembly: AssemblyCopyright(""Copyright ©  2012"")]
[assembly: AssemblyTrademark("""")]
[assembly: AssemblyCulture("""")]
[assembly: ComVisible(false)]
[assembly: Guid(""a46a3a06-8f5e-4fb8-82b1-a31f17f73b32"")]
[assembly: AssemblyVersion(""1.0.0.0"")]
[assembly: AssemblyFileVersion(""1.0.*"")]";

            input = AssemblyBumper.BumpIt(input, 9, 9, 9, 9);

            Assert.IsTrue(input.Contains(@"[assembly: AssemblyVersion(""9.9.9.9"")]"));
            Assert.IsTrue(input.Contains(@"[assembly: AssemblyFileVersion(""9.9.9.9"")]"));
        }
    }
}
