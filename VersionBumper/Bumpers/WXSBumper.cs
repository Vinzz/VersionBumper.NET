// -----------------------------------------------------------------------
// <copyright file="WXSBumper.cs" company="Yocto projects">
// Copyright (c) 2012 - Vincent Tollu.
// </copyright>
// -----------------------------------------------------------------------
namespace VersionBumper.Bumpers
{
    using System.IO;
    using System.Text.RegularExpressions;
    using VersionBumper.FileWriter;

    /// <summary>
    /// Version bumper for the WIX product.wxs files
    /// </summary>
    public class WXSBumper
    {
        /// <summary>
        /// Regex to locate the version tag
        /// </summary>
        private static Regex wxsBumpRegex = new Regex(@"Version=\""\d\.\d\.\d\.\d\""");

        /// <summary>
        /// Bumps it.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="major">The major.</param>
        /// <param name="minor">The minor.</param>
        /// <param name="build">The build.</param>
        /// <param name="revision">The revision.</param>
        public static void BumpIt(FileInfo input, int major, int minor, int build, int revision)
        {
            string content = string.Empty;
            using (StreamReader reader = input.OpenText())
            {
                content = reader.ReadToEnd();
            }

            content = BumpIt(content, major, minor, build, revision);

            WriteFile.WriteInFile(input, content);
        }

        /// <summary>
        /// Bumps it.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="major">The major.</param>
        /// <param name="minor">The minor.</param>
        /// <param name="build">The build.</param>
        /// <param name="revision">The revision.</param>
        /// <returns>
        /// the bumped file
        /// </returns>
        public static string BumpIt(string input, int major, int minor, int build, int revision)
        {
            string newVersion = string.Format(@"Version=""{0}.{1}.{2}.{3}""", major, minor, build, revision);

            return wxsBumpRegex.Replace(input, newVersion);
        }
    }
}
