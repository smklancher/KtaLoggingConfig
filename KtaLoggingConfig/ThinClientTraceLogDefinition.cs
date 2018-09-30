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

        protected override string DefaultLocation => @"c:\temp\ThinClientServerLog.txt";
        public  override string Name => "Web.config Thin Client Trace";

        public override IEnumerable<string> AvailableLevels
        {
            get
            {
                //Off, Critical, Error, Warning, Information, Verbose or All)
                yield return "Off";
                yield return "Critical";
                yield return "Error";
                yield return "Warning";
                yield return "Information";
                yield return "Verbose";
                yield return "All";
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
