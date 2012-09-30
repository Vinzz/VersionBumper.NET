// -----------------------------------------------------------------------
// <copyright file="FileSearcher.cs" company="Yocto projects">
// Copyright (c) 2012 - Vincent Tollu.
// </copyright>
// -----------------------------------------------------------------------
namespace VersionBumper.Explorer
{
    using System.Collections.Generic;
    using System.IO;
    using VersionBumper.Properties;

    /// <summary>
    /// File searcher
    /// </summary>
    public class FileSearcher
    {
        /// <summary>
        /// Searches for interest files in a path explored recursively.
        /// </summary>
        /// <param name="sourcePath">The source path.</param>
        /// <returns>a stack containing the interest files</returns>
        public static Stack<FileInfo> SearchForfiles(DirectoryInfo sourcePath)
        {
            Stack<DirectoryInfo> stackDirs = new Stack<DirectoryInfo>();
            Stack<FileInfo> stackPaths = new Stack<FileInfo>();

            stackDirs.Push(sourcePath);
            while (stackDirs.Count > 0)
            {
                DirectoryInfo currentDir = (DirectoryInfo)stackDirs.Pop();

                // Process .\files
                foreach (FileInfo fileInfo in currentDir.GetFiles())
                {
                    if (Settings.Default.InterestFilePattern.Contains(fileInfo.Name))
                    { 
                        stackPaths.Push(fileInfo);
                    }
                }

                // Process Subdirectories
                foreach (DirectoryInfo nextDir in currentDir.GetDirectories())
                { 
                    stackDirs.Push(nextDir);
                }
            }

            return stackPaths;
        }
    }
}
