// -----------------------------------------------------------------------
// <copyright file="AssemblyBumper.cs" company="Yocto projects">
// Copyright (c) 2012 - Vincent Tollu.
// </copyright>
// -----------------------------------------------------------------------
namespace VersionBumper.Bumpers
{
    using System.IO;
    using System.Text.RegularExpressions;
    using VersionBumper.FileWriter;

    /// <summary>
    /// Bumper for the assemblyInfo.cs files
    /// </summary>
    public class AssemblyBumper
    {
        /// <summary>
        /// Regex to find the version tag
        /// </summary>
        private static Regex assemblyBumpRegex = new Regex(@"Version\(\""\d\.\d\.\d\.\d\""\)\]");

        /// <summary>
        /// Regex to find the jockered version tag
        /// </summary>
        private static Regex assemblyJockerBumpRegex = new Regex(@"Version\(\""\d\.\d\.\*""\)\]");

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
        /// <returns>the bumped file</returns>
        public static string BumpIt(string input, int major, int minor, int build, int revision)
        {
            string newVersion = string.Format(@"Version(""{0}.{1}.{2}.{3}"")]", major, minor, build, revision);

            string ans = assemblyBumpRegex.Replace(input, newVersion);
            ans = assemblyJockerBumpRegex.Replace(ans, newVersion);
            return ans;
        }
    }
}
