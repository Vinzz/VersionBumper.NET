// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Yocto projects">
// Copyright (c) 2012 - Vincent Tollu.
// </copyright>
// -----------------------------------------------------------------------
namespace VersionBumper
{
    using System;
    using System.IO;
    using VersionBumper.Facade;

    /// <summary>
    /// Main class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Mains the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        public static void Main(string[] args)
        {
            bool isTest = false;
            try
            {
                Settings setting = new Settings();

                if (args.Length > 1)
                {
                    for (int i = 0; i < args.Length; ++i)
                    {
                        switch (args[i])
                        {
                            case "-d":
                                setting.SourceDir = new DirectoryInfo(args[++i]);
                                break;
                            case "-v":
                                setting.Major = int.Parse(args[++i]);
                                setting.Minor = int.Parse(args[++i]);
                                setting.Build = int.Parse(args[++i]);
                                setting.Revision = int.Parse(args[++i]);
                                break;
                            case "-test":
                                isTest = true;
                                break;
                            default:
                                throw new ArgumentException("Unknown option: " + args[i]);
                        }
                    }
                }
                else
                {
                    PrintDoc();
                }

                if (!setting.SourceDir.Exists)
                { 
                    throw new ArgumentException("can't find source dir: " + setting.SourceDir);
                }

                Console.WriteLine(string.Format("Will bump the files contained in {0} to version {1}.{2}.{3}.{4}", setting.SourceDir.FullName, setting.Major, setting.Minor, setting.Build, setting.Revision));
                VersionBumperFacade.BumpIt(setting.SourceDir, setting.Major, setting.Minor, setting.Build, setting.Revision);

                Console.WriteLine("That's all folks");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                if (isTest)
                {
                    throw;
                }
            }
            finally
            {
                if (!isTest)
                {
                    Console.WriteLine("Press any key");
                    Console.Read();
                }
            }
        }

        /// <summary>
        /// Prints the doc.
        /// </summary>
        private static void PrintDoc()
        {
            Console.WriteLine("Version Bumper to version 1.1.2.1 : VersionBumper.exe -d <pathToSources> -v 1 1 2 1");
        }
    }
}
