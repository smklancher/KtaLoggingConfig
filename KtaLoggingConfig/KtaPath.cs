using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using SystemDiagnosticsConfig;

namespace KtaLoggingConfig
{
    public enum KtaFolder
    {
        Base,
        Web,
        WebBin,
        CoreWorker,
        Reporting,
        Transformation,
        LicenseClient,
        Streaming,
        Logs
    }


    public static class KtaPath
    {
        private const string ServicesKey = "SYSTEM\\CurrentControlSet\\Services\\";
        private const string StreamingServiceName = "TotalAgility Streaming Service";
        private const string CoreWorkerServiceName = "TotalAgility Core Worker";
        private const string TransformationServiceName = "KofaxTransformationServerService";
        private const string ReportingServiceName = "KofaxTAReportingServerService";
        private const string KicServiceName = "KIC-ED-MC";
        private const string KsalServiceName = "KSALicenseService";

        /// <summary>
        /// When KTA libraries are needed, add to resolve handler upon startup:
        /// AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf LocalSystem.SdkResolveHandler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static Assembly SdkResolveHandler(object sender, ResolveEventArgs args)
        {
            string AssemblyNameToLoad = args.Name.Split(',')[0] + ".dll";
            List<DirectoryInfo> Folders = ApiFolders();
            foreach (var f in Folders)
            {
                string FullPath = Path.Combine(f.FullName, AssemblyNameToLoad);
                if (File.Exists(FullPath))
                {
                    // Load file from first place it exists
                    // No attempt is made to load subsequent files from the same folder
                    // This could be a problem if files were missing from one folder and different version from another, but low chance of that
                    return Assembly.LoadFile(FullPath);
                }
            }

            return null;
        }

        public static List<DirectoryInfo> ApiFolders()
        {
            List<DirectoryInfo> Folders = new List<DirectoryInfo>();
            Folders.Add(ServiceFolder(CoreWorkerServiceName));
            if (WebFolder() != string.Empty)
            {
                Folders.Add(new DirectoryInfo(WebFolder()));
                Folders.Add(new DirectoryInfo(Path.Combine(WebFolder(), "bin")));
            }
            Folders.Add(ServiceFolder(TransformationServiceName));
            Folders.Add(ServiceFolder(ReportingServiceName));

            return Folders;
        }

        public static List<string> ConfigFiles()
        {
            // Add the folders to consider
            List<DirectoryInfo> Folders = ApiFolders();
            // Try default path for repo browser
            Folders.Add(new DirectoryInfo("C:\\Program Files (x86)\\Kofax\\TotalAgility Repository Browser\\"));
            // Collect all of the config file paths in all folders
            List<string> Files = new List<string>();
            foreach (DirectoryInfo CurFolder in Folders)
            {
                if (CurFolder.Exists)
                {
                    Files.AddRange(CurFolder.EnumerateFiles("*.config").Select(File => File.FullName));
                }
            }

            return Files;
        }

        private static DirectoryInfo ServiceFolder(string ServiceName)
        {
            //TODO: change callers
            string FileString = ServiceFolderString(ServiceName);

            // Fileinfo can handle paths that don't exist, but not blank, so this is a silly workaround for a valid non existant path
            // Could allow returning nulls (and adapt callers) instead of this
            if (FileString == string.Empty)
            {
                FileString = Path.Combine("C:\\", Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
            }
            return new DirectoryInfo(FileString);
        }

        private static string ServiceFolderString(string ServiceName)
        {
            RegistryLocation RegLocation = new RegistryLocation()
            {
                BaseKey = RegistryHive.LocalMachine,
                SubKey = ServicesKey + ServiceName,
                KeyName = "ImagePath"
            };

            string FileString = RegLocation.Read();
            // Take the quoted path ignoring any command lines added after
            if (FileString.StartsWith("\""))
            {
                Match m = Regex.Match(FileString, "\"(.*?)\"");
                FileString = m.Groups[1].Value;
            }

            return Path.GetDirectoryName(FileString);
        }

        /// <summary>
        /// Base folder used for the website which defaults to C:\Program Files\Kofax\TotalAgility\Agility.Server.Web\
        /// </summary>
        /// <returns></returns>
        public static string WebFolder()
        {
            return (KtaBaseFolder() == string.Empty) ? string.Empty : Path.Combine(KtaBaseFolder(), "Agility.Server.Web");
        }

        /// <summary>
        /// Base folder which defaults to C:\Program Files\Kofax\TotalAgility\
        /// </summary>
        /// <returns></returns>
        public static string KtaBaseFolder()
        {
            // parent of core worker folder if available
            DirectoryInfo CurFolder = ServiceFolder(CoreWorkerServiceName);
            if (CurFolder.Exists)
                return CurFolder.Parent.FullName;
            // two levels up from streaming service on web
            CurFolder = ServiceFolder(StreamingServiceName);
            if (CurFolder.Exists)
                return CurFolder.Parent.Parent.FullName;
            // or KTA not installed
            return string.Empty;
        }
        
        

        /// <summary>
        /// false if folder does not exist
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool TryGetFolder(KtaFolder folder, out string path)
        {
            path = string.Empty;
            switch (folder)
            {
                case KtaFolder.Base:
                    path = KtaBaseFolder();
                    break;
                case KtaFolder.Web:
                    path = Path.Combine(KtaBaseFolder(), "Agility.Server.Web");
                    break;
                case KtaFolder.WebBin:
                    path = Path.Combine(WebFolder(), "Agility.Server.Web\bin");
                    break;
                case KtaFolder.CoreWorker:
                    path = ServiceFolderString(CoreWorkerServiceName);
                    break;
                case KtaFolder.Reporting:
                    path = ServiceFolderString(ReportingServiceName);
                    break;
                case KtaFolder.Streaming:
                    path = ServiceFolderString(StreamingServiceName);
                    break;
                case KtaFolder.Transformation:
                    path = ServiceFolderString(TransformationServiceName);
                    break;
                case KtaFolder.LicenseClient:
                    path = Path.Combine(KtaBaseFolder(), "Licensing");
                    break;
                case KtaFolder.Logs:
                    path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"Kofax\TotalAgility\Logs");
                    //asking for this path would be followed by creating it, so do that here
                    try
                    {
                        Directory.CreateDirectory(path);
                    }
                    catch (Exception) { }
                    break;
                default:
                    return false;
            }
            if (Path.IsPathRooted(path) && Directory.Exists(path))
            {
                return true;
            }
            return false;
        }

    }

}
