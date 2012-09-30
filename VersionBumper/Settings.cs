// -----------------------------------------------------------------------
// <copyright file="Settings.cs" company="Yocto projects">
// Copyright (c) 2012 - Vincent Tollu.
// </copyright>
// -----------------------------------------------------------------------
namespace VersionBumper
{
    using System.IO;

    /// <summary>
    /// Stores the program settings
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Gets or sets the source dir.
        /// </summary>
        /// <value>
        /// The source dir.
        /// </value>
        public DirectoryInfo SourceDir { get; set; }

        /// <summary>
        /// Gets or sets the major.
        /// </summary>
        /// <value>
        /// The major.
        /// </value>
        public int Major { get; set; }

        /// <summary>
        /// Gets or sets the minor.
        /// </summary>
        /// <value>
        /// The minor.
        /// </value>
        public int Minor { get; set; }

        /// <summary>
        /// Gets or sets the build.
        /// </summary>
        /// <value>
        /// The build.
        /// </value>
        public int Build { get; set; }

        /// <summary>
        /// Gets or sets the revision.
        /// </summary>
        /// <value>
        /// The revision.
        /// </value>
        public int Revision { get; set; }
    }
}
