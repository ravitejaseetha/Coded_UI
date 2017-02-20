using Microsoft.Build.Evaluation;
using Microsoft.Build.Execution;
using Microsoft.Build.Framework;
using Microsoft.Build.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildPackageTool
{
    class Program
    {
        static void Main(string[] args)
        {
            string projectFileName = GetSolution();
            string binPath = projectFileName.Replace("SampeProgram.sln", "bin");
            //string binPath = string.Format(@"{0}\..\..\..\..\bin", Directory.GetCurrentDirectory());
            string DestinationToolsPath = projectFileName.Replace("SampeProgram.sln", @"bin\Tools");
            //string DestinationToolsPath = string.Format(@"{0}\..\..\..\..\bin\Tools", Directory.GetCurrentDirectory());
            string ToolsPath = projectFileName.Replace("SampeProgram.sln", "Tools");                       
            //string ToolsPath = string.Format(@"{0}\..\..\..\..\Tools", Directory.GetCurrentDirectory());
            
            string zipLocation = ConfigurationManager.AppSettings["ZipFileLocation"].ToString();            
            string zipFileName = ConfigurationManager.AppSettings["ZipFileName"].ToString();
            string version = ConfigurationManager.AppSettings["Version"].ToString();
            string zipFile = string.Format(@"{0}\{1}_{2}.zip", zipLocation, zipFileName, version);
            string buildLogFilePath = ConfigurationManager.AppSettings["BuildLogFilePath"].ToString();
            string buildLogFileName = string.Format(@"{0}.log",ConfigurationManager.AppSettings["BuildLogFileName"].ToString());
            string buildLogFile = string.Format(@"{0}\{1}", buildLogFilePath, buildLogFileName);
            string buildLogParam = string.Format(@"logfile={0}", buildLogFile);
            string toolPath = string.Format(@"{0}\{1}", Directory.GetCurrentDirectory(), zipFileName);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Cleaning previous build...");            
            DeleteDirectory(binPath);

            ProjectCollection pc = new ProjectCollection();
            Dictionary<string, string> GlobalProperty = new Dictionary<string, string>();
            //GlobalProperty.Add("Configuration", "Debug");
            GlobalProperty.Add("Configuration", "Debug");
            GlobalProperty.Add("Platform", "Any CPU");
            //GlobalProperty.Add("OutputPath", Directory.GetCurrentDirectory() + "\\build\\\bin\\Release");

            Console.WriteLine("Initializing build logger...");
            FileLogger logger = new FileLogger();
            DeleteFile(buildLogFile);
            CreateDirectory(buildLogFilePath);
            logger.Parameters = buildLogParam;

            Console.WriteLine("Initializing build parameters...");
            BuildRequestData BuidlRequest = new BuildRequestData(projectFileName, GlobalProperty, null, new string[] { "Build" }, null);
            var test1 = BuidlRequest.TargetNames;            
            BuildParameters buildParams = new BuildParameters(pc)
            {
                DetailedSummary = false,
                Loggers = new List<ILogger>() { logger }
            };

            Console.WriteLine("Solution file found in : {0}", projectFileName);
            Console.WriteLine("Started build ...");
            BuildResult buildResult = BuildManager.DefaultBuildManager.Build(buildParams, BuidlRequest);

            var test = buildResult.OverallResult;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Started build packaging ...");
            DirectoryCopy(ToolsPath, DestinationToolsPath, true);
            DeleteDirectory(toolPath);
            Directory.Move(binPath, toolPath);
            File.Move(buildLogFile, string.Format(@"{0}\{1}", toolPath, buildLogFileName));
            CreateZipFile(toolPath,zipFile);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Build packaging complete ...");
            Console.WriteLine("Package Create : {0}", zipFile);
            Console.Read();    

        }

        public static void DeleteDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path,true);
            }
        }

        public static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static void DeleteFile(string path)
        {
            if(File.Exists(path))
            {
                File.Delete(path);
            }
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the source directory does not exist, throw an exception.
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory does not exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }


            // Get the file contents of the directory to copy.
            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                // Create the path to the new copy of the file.
                string temppath = Path.Combine(destDirName, file.Name);

                // Copy the file.
                file.CopyTo(temppath, false);
            }

            // If copySubDirs is true, copy the subdirectories.
            if (copySubDirs)
            {

                foreach (DirectoryInfo subdir in dirs)
                {
                    // Create the subdirectory.
                    string temppath = Path.Combine(destDirName, subdir.Name);

                    // Copy the subdirectories.
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        private static void CreateZipFile(string toolPath, string zipFilePath)
        {
            if (File.Exists(zipFilePath))
            {
                File.Delete(zipFilePath);
            }
            ZipFile.CreateFromDirectory(toolPath, zipFilePath, CompressionLevel.Optimal, true);
        }

        private static string GetSolution()
        {
            string solutionFile = string.Format(@"{0}\..\..\..\..\SampeProgram.sln", Directory.GetCurrentDirectory());
            if(File.Exists(solutionFile))
            {
                return solutionFile;
            }
            else
            {
                return string.Format(@"{0}\SampeProgram.sln", ConfigurationManager.AppSettings["SolutionPath"].ToString());                
            }
        }
    }
}
