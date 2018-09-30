using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDiagnosticsConfig;

namespace KtaLoggingConfig
{
    public class KtaTraceListenerLog : LogListener
    {
        public KtaTraceListenerLog(SystemDiagnosticsConfigCT SysDiag, ListenerElementCT listener) : base(SysDiag,listener)
        {

        }

        //public static KtaTraceListenerLog FindExisting(LogListenerCollection listeners)
        //{
        //    foreach (var l in listeners)
        //    {
        //        if (l.ListenerName.ToLower() == "ktalog")
        //        {

        //            return new KtaTraceListenerLog(SysDiag, l.listener);
        //        }
        //    }

        //    return null;
        //}

        //        private ListenerElementCT SetKtaTraceListener(string filename)
        //        {
        //            return ConfigHelper.SetTraceListener(SysDiag, "KTALog", "System.Diagnostics.TextWriterTraceListener", filename);
        //        }

        //        //public override string LogFileName
        //        //{
        //        //    get
        //        //    {
        //        //        var filename = this?.SysDiag?.Trace?.Listeners?.Add?.Where(x => x.Name == "KTALog").FirstOrDefault()?.InitializeData;
        //        //        return (string.IsNullOrEmpty(filename)) ? string.Empty : filename;
        //        //    }

        //        //    set
        //        //    {
        //        //        SetKtaTraceListener(value);
        //        //    }
        //        //}



        public bool Enabled
        {
            get
            {
                bool NamedListenerExists = (SysDiag?.Trace?.Listeners?.Add?.Where(x => x.Name == "KTALog").FirstOrDefault() != null);
                return !SysDiag.IsComment && NamedListenerExists;
            }
            set
            {
                // Flag or unflag as comment according to whether enabled
                SysDiag.IsComment = !value;

                // If enabling, ensure that basic settings exist by setting the log file name (to itself in case already exists)
                if (value)
                {
                    //LogFileName = LogFileName;
                }
            }
        }


    }
}
