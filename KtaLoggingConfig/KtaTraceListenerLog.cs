using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDiagnosticsConfig;

namespace KtaLoggingConfig
{
    public class KtaTraceListenerLog : LogConfig
    {
        public KtaTraceListenerLog(SystemDiagnosticsConfigCT SysDiag) : base(SysDiag)
        {

        }

        private ListenerElementCT SetKtaTraceListener(string filename)
        {
            return ConfigHelper.SetTraceListener(SysDiag, "KTALog", "System.Diagnostics.TextWriterTraceListener", filename);
        }

        public override string LogFileName
        {
            get
            {
                var filename = this?.SysDiag?.Trace?.Listeners?.Add[0]?.InitializeData;
                return (string.IsNullOrEmpty(filename)) ? string.Empty : filename;
            }

            set
            {
                SetKtaTraceListener(value);
            }
        }



        public override bool Enabled
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
                    LogFileName = LogFileName;
                }
            }
        }


    }
}
