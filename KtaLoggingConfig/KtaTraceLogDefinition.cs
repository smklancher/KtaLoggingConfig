using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDiagnosticsConfig;

namespace KtaLoggingConfig
{
    public class KtaTraceLogDefinition : TraceLogDefinition
    {
        public KtaTraceLogDefinition(ConfigFile config): base(config)
        {

        }

        protected override string DefaultListenerName => "KTALog";

        protected override string DefaultListenerType => "System.Diagnostics.TextWriterTraceListener";

        public override string DefaultLocation { get; set; } = @"c:\temp\KTALog.txt";

        public override string Name => "KTA Trace";
        
    }
}
