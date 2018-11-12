using IniParser.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDiagnosticsConfig;
using static System.Environment;

namespace KtaLoggingConfig
{
    public class WcsConfig : IniFile
    {
        //%LOCALAPPDATA%\VirtualStore\Windows\win.ini
        //%SystemRoot%\win.ini

        //[KDB]
        //FileName=c:\temp\kdb.log
        //File = on
        //Flush=on
        //TraceAllOther = on
        //Assert=on
        //DebugFlags = 7FFFFFFF

        private KeyDataCollection Core { get => data[@"Core"]; }
        private KeyDataCollection FileSink { get => data[@"Sinks.FileSink"]; }

        public WcsConfig(string file) : base(file)
        {
        }

        public static WcsConfig FromScanWorker()
        {
            string WinIniFile = @"C:\ProgramData\Kofax\WebCapture\Kofax.WebCapture.ScanWorker.exe.log.config";
            return new WcsConfig(WinIniFile);
        }
        public static WcsConfig FromHost()
        {
            string WinIniFile = @"C:\ProgramData\Kofax\WebCapture\Kofax.WebCapture.Host.exe.log.config";
            return new WcsConfig(WinIniFile);
        }

        public override string LogLocation { get => GetValue("FileName").Replace("\"",string.Empty); set => FileSink["FileName"] = $"\"{value}\""; }

        private string GetValue(string key)
        {
            return FileSink.ContainsKey(key) ? FileSink[key] : string.Empty;
        }

        public bool DisableLogging
        {
            get
            {
                if(bool.TryParse(Core["DisableLogging"],out bool value))
                {
                    return value;
                }
                return false;
            }
            set
            {
                Core["DisableLogging"] = value.ToString().ToLower();
            }
        }

        public override IEnumerable<string> AvailableLevels
        {
            get
            {
                yield return "fatal";
                yield return "error";
                yield return "warning";
                yield return "info";
                yield return "debug";
                yield return "trace";
            }
        }


        public override string Level { get => Filter.Replace("%Severity% >= ",string.Empty); set => Filter=$"%Severity% >= {value}"; }
        public string Filter { get => Core["Filter"].Replace("\"", string.Empty); set => Core["Filter"] = $"\"{value}\""; }


        public override bool Enabled { get => !DisableLogging; set => DisableLogging = !value; }
    }
}
