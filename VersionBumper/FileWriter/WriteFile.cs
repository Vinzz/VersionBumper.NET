// -----------------------------------------------------------------------
// <copyright file="WriteFile.cs" company="Yocto projects">
// Copyright (c) 2012 - Vincent Tollu.
// </copyright>
// -----------------------------------------------------------------------
namespace VersionBumper.FileWriter
{
    using System.IO;
    using System.Text;
    using VersionBumper.Explorer;

    /// <summary>
    /// Helper to write a content in a file
    /// </summary>
    public class WriteFile
    {
        /// <summary>
        /// Writes the in file.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="content">The content.</param>
        public static void WriteInFile(System.IO.FileInfo input, string content)
        {
            bool isOK = true;

            if (input.IsReadOnly)
            {
                if (TFSCheckOutHelper.TryTFSMode(input) == 0)
                {
                    isOK = false;
                }
            }

            if (isOK)
            {
                using (StreamWriter strOut = new StreamWriter(input.FullName, false, Encoding.UTF8))
                {
                    strOut.Write(content);
                }
            }
        }
    }
}
