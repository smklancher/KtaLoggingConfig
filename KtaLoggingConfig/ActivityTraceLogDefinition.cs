using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using SystemDiagnosticsConfig;

namespace KtaLoggingConfig
{
    public class ActivityTraceLogDefinition : LogDefinition
    {
        public ActivityTraceLogDefinition(ConfigFile config): base(config)
        {

        }

        protected override string DefaultListenerName => "traceListener";

        protected override string DefaultListenerType => "System.Diagnostics.XmlWriterTraceListener";

        public override string DefaultLocation { get; set; } = @"c:\temp\WebActivity.svclog";

        public override string Name => "Activity Trace";

        protected override bool IsTrace => false;

        public override string Level { get => "N/A"; set => Debug.WriteLine("Level ignored"); }

        protected override ListenerElementCT FindExistingListener()
        {
            //find source
            var source = Config.SysDiag.Sources?.Where(x => x.Name.ToLower() == "system.servicemodel").FirstOrDefault();
            if (source == null)
            {
                return null;
            }

            // Not using any logic to determine correct listener if multiple
            var l=source.ListenersEx.Add.FirstOrDefault();

            // Could move source listeners to shared at this point

            // Return shared listener if this is a reference
            if (l.Location == ListenerLocation.ReferenceToShared)
            {
                return l.ReferencedListener(Config.SysDiag);
            }

            return l;
        }

        protected override void CreateDependentElements()
        {
            var source = Listener.AddReferenceToSource(Config.SysDiag, "System.ServiceModel");

            source.SwitchValue = "Information, ActivityTracing";
            source.propagateActivity = true;
        }

    }
}
