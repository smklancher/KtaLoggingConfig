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
            //TraceListenerLog = new KtaTraceListenerLog(SysDiag);
            // ThinClientTraceListenerLog = new ThinClientTraceListenerLog(SysDiag);
            //TraceListenerLog = KtaTraceListenerLog.FindExisting(this.Listeners);


            KtaTrace = new KtaTraceLogDefinition(this);
            ThinClientTrace = new ThinClientTraceLogDefinition(this);
        }

        public static WebConfig LoadFromDefaultLocation()
        {
            var filename = @"C:\Program Files\Kofax\TotalAgility\Agility.Server.Web\web.config";
            return new WebConfig(filename);
        }

        public KtaTraceListenerLog TraceListenerLog { get; set; }

        public KtaTraceLogDefinition KtaTrace { get; } 

        public ThinClientTraceLogDefinition ThinClientTrace { get;  }
    }
}
