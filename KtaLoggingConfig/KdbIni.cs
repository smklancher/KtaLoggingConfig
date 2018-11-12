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
    public class KdbIni : IniFile
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

        private KeyDataCollection Kdb { get => data[@"KDB"]; }

        public KdbIni(string file) : base(file)
        {
        }

        public static KdbIni FromWinIni()
        {
            string WinIniFile = Path.Combine(GetFolderPath(SpecialFolder.Windows), "win.ini");
            return new KdbIni(WinIniFile);
        }

        public override string LogLocation { get => GetValue("FileName"); set => Kdb["FileName"] = value; }

        private string GetValue(string key)
        {
            return Kdb.ContainsKey(key) ? Kdb[key] : string.Empty;
        }

        private bool FromOn(string on) => (on.ToLower() == "on");
        private string ToOn(bool value) => value ? "on" : "off";

        private bool GetOnOffBoolValue([System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
        {
            return FromOn(GetValue(memberName));
        }

        private void SetOnOffBoolValue(bool value, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
        {
            Kdb[memberName] = ToOn(value);
        }

        public override bool Enabled { get => FromOn(GetValue("File")); set => Kdb["File"]=ToOn(value); }

        public bool File { get => GetOnOffBoolValue(); set => SetOnOffBoolValue(value); }
        public bool Flush { get => GetOnOffBoolValue(); set => SetOnOffBoolValue(value); }
        public bool TraceAllOther { get => GetOnOffBoolValue(); set => SetOnOffBoolValue(value); }
        public bool Assert { get => GetOnOffBoolValue(); set => SetOnOffBoolValue(value); }


        //DebugFlags
        //1=Function Trace
        //2000000=Warnings
        //1000000=Errors
        //4000000=Verbose
        //800000=Timer output
        //787FFFFE=All other
        //7FFFFFFF=All check boxes
        public string DebugFlags { get => GetValue(nameof(DebugFlags)); set => Kdb[nameof(DebugFlags)] = value; }
    }
}
