// -----------------------------------------------------------------------
// <copyright file="BumpProductWXSTest.cs" company="Yocto projects">
// Copyright (c) 2012 - Vincent Tollu.
// </copyright>
// -----------------------------------------------------------------------
namespace VersionBumperTest
{
    using System.IO;
    using NUnit.Framework;
    using VersionBumper.Bumpers;

    /// <summary>
    /// Tests for the wxs bumper
    /// </summary>
    [TestFixture]
    public class BumpProductWXSTest
    {
        /// <summary>
        /// Bumps the assembly file.
        /// </summary>
        [Test]
        public void BumpAssemblyFile()
        {
            WXSBumper.BumpIt(new FileInfo(@".\TestInputs\Project3\Product.wxs"), 9, 9, 9, 9);

            string content = new FileInfo(@".\TestInputs\Project3\Product.wxs").OpenText().ReadToEnd();

            Assert.IsTrue(content.Contains(@"Version=""9.9.9.9"""));
        }

        /// <summary>
        /// Bumps the product WXS.
        /// </summary>
        [Test]
        public void BumpProductWXS()
        {
            string input = @"<Product Id=""9FD5BFCE-4B47-4CD0-9400-350C0C2A4E10"" Name=""GCS.StandardCosting.CentralService.Setup"" Language=""1033"" Version=""2.0.0.2"" Manufacturer=""GCS.StandardCosting.CentralService.Setup"" UpgradeCode=""D3FB2C99-0BC2-4BFA-914C-DD49CC628F70"">
		<Package InstallerVersion=""200"" Compressed=""yes"" />

		<Media Id=""1"" Cabinet=""media1.cab"" EmbedCab=""yes"" />";

            input = WXSBumper.BumpIt(input, 9, 9, 9, 9);

            Assert.IsTrue(input.Contains(@"Version=""9.9.9.9"""));
        }
    }
}
