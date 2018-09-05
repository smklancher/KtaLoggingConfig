using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDiagnosticsConfig;

namespace KtaLoggingConfig
{
    public class WebConfig : ConfigFile
    {
        public WebConfig(string file) : base(file)
        {
            TraceListenerLog = new KtaTraceListenerLog(SysDiag);
            ThinClientTraceListenerLog = new ThinClientTraceListenerLog(SysDiag);
        }

        public static WebConfig LoadFromDefaultLocation()
        {
            var filename = @"C:\Program Files\Kofax\TotalAgility\Agility.Server.Web\web.config";
            return new WebConfig(filename);
        }

        public KtaTraceListenerLog TraceListenerLog { get; set; }

        public ThinClientTraceListenerLog ThinClientTraceListenerLog { get; set; }
    }
}
