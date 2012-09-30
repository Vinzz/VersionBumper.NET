using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace VersionBumperTest
{
    public class FileReader
    {
        internal static string ReadFileContent(string p)
        {
            FileInfo fi = new FileInfo(p);

            using (StreamReader sr = fi.OpenText())
            {
                return sr.ReadToEnd();
            }
        }
    }
}
