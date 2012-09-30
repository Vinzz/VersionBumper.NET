// -----------------------------------------------------------------------
// <copyright file="VersionBumperFacade.cs" company="Yocto projects">
// Copyright (c) 2012 - Vincent Tollu.
// </copyright>
// -----------------------------------------------------------------------
namespace VersionBumper.Facade
{
    using System;
    using System.IO;
    using VersionBumper.Bumpers;
    using VersionBumper.Explorer;

    /// <summary>
    /// Facade for the  version bumper service
    /// </summary>
    public class VersionBumperFacade
    {
        /// <summary>
        /// Bumps it.
        /// </summary>
        /// <param name="srcDir">The SRC dir.</param>
        /// <param name="major">The major.</param>
        /// <param name="minor">The minor.</param>
        /// <param name="build">The build.</param>
        /// <param name="revision">The revision.</param>
        public static void BumpIt(DirectoryInfo srcDir, int major, int minor, int build, int revision)
        {
            foreach (FileInfo fi in FileSearcher.SearchForfiles(srcDir))
            {
                switch (fi.Extension)
                {
                    case ".cs":
                        if (fi.Name == "AssemblyInfo.cs")
                        {
                            AssemblyBumper.BumpIt(fi, major, minor, build, revision);
                        }
                        break;
                    case ".wxs":
                        WXSBumper.BumpIt(fi, major, minor, build, revision);
                        break;
                    default:
                        throw new Exception("can not handle such a file yet: " + fi.Name);
                }
            }
        }
    }
}
