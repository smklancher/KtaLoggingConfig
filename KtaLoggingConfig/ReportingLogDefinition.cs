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
    public class ReportingLogDefinition : LogDefinition
    {
        public ReportingLogDefinition(ConfigFile config): base(config)
        {

        }

        protected override string DefaultListenerName => "ReportingLogTxt";

        protected override string DefaultListenerType => "Kofax.Reporting.Common.Logging.TenantBasedTraceListener, Kofax.Reporting.Common";

        public override string DefaultLocation
        {
            get
            {
                if (IsServiceLog)
                {
                    return @"C:\ProgramData\Kofax\TotalAgility\Reporting\Log\WorkerRole.log";
                }
                else
                {
                    return @"C:\ProgramData\Kofax\TotalAgility\Reporting\Log\ETLApp_{0}.log";
                }
            }
            set
            {

            }
        }

        public bool IsServiceLog { get; set; }

        public override string Name => "Reporting";

        protected override bool IsTrace => false;
        
        public override string Level
        {
            get
            {
                var sw=Config.SysDiag.Switches?.Add?.Where(x => x.Name.ToLower() == "tracelevelswitch").FirstOrDefault();
                return sw?.Value;
            }
            set
            {
                var sw = Config.SysDiag.Switches?.Add?.Where(x => x.Name.ToLower() == "tracelevelswitch").FirstOrDefault();
                sw.Value = value;
            }
        }

        public override IEnumerable<string> AvailableLevels
        {
            get
            {
                return StandardLevels;
            }
        }

        protected override ListenerElementCT FindExistingListener()
        {
            //find source
            var source = Config.SysDiag.Sources?.Where(x => x.Name.ToLower() == "reporting").FirstOrDefault();
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
            var source = Listener.AddReferenceToSource(Config.SysDiag, "Reporting");
            var sw = source.AddReferenceToSwitch(Config.SysDiag, "TraceLevelSwitch", "Warning");
        }

    }
}
