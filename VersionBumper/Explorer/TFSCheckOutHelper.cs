// -----------------------------------------------------------------------
// <copyright file="TFSCheckOutHelper.cs" company="Yocto projects">
// Copyright (c) 2012 - Vincent Tollu.
// </copyright>
// -----------------------------------------------------------------------
namespace VersionBumper.Explorer
{
    using System;
    using System.Net;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.VersionControl.Client;

    /// <summary>
    /// TFS Check out
    /// </summary>
    public class TFSCheckOutHelper
    {
        /// <summary>
        /// Tries the TFS mode.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>the number of checkedout files</returns>
        internal static int TryTFSMode(System.IO.FileInfo input)
        {
            try
            {
                var tfs = new TeamFoundationServer(Properties.Settings.Default.TFSServer, new NetworkCredential(Properties.Settings.Default.TFSLogin, Properties.Settings.Default.TFSPassword));
                var version = (VersionControlServer)tfs.GetService(typeof(VersionControlServer));
                var workspace = version.GetWorkspace(Properties.Settings.Default.TFSWorkspace, version.AuthorizedUser);
                int ans = workspace.PendEdit(input.FullName);
                return ans;
            }
            catch (Exception)
            {
                Console.WriteLine(
                    string.Format(
@"
/!\The file {0} is read only
please make sure the TFS app settings are OK

Stack trace:

",
input.FullName));
                throw;
            }
        }
    }
}
