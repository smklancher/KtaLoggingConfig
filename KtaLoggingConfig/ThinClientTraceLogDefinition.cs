using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDiagnosticsConfig;

namespace KtaLoggingConfig
{
    public class ThinClientTraceLogDefinition : TraceLogDefinition
    {
        public ThinClientTraceLogDefinition(ConfigFile config): base(config)
        {

        }

        protected override string DefaultListenerName => "ThinClientServer";

        protected override string DefaultListenerType => "System.Diagnostics.TextWriterTraceListener";

        public override string DefaultLocation { get; set; } = @"c:\temp\ThinClientServerLog.txt";
        public  override string Name => "Thin Client Trace";

        public override IEnumerable<string> AvailableLevels
        {
            get
            {
                return StandardLevels;
            }
        }

        public override string Level
        {
            get
            {
                return Listener.Filter.InitializeData;
            }
            set
            {
                Listener.Filter.InitializeData = value;
            }
        }

    }
}
