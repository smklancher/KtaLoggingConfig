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
    public class CspsLogDefinition : LogDefinition
    {
        public CspsLogDefinition(ConfigFile config): base(config)
        {

        }

        protected override string DefaultListenerName => "CSPSLogTxt";

        protected override string DefaultListenerType => "Kofax.CEBPM.ProcessingService.Core.DateTimeTaggedTraceListener, Kofax.CEBPM.ProcessingService.Core";

        public override string DefaultLocation { get; set; } = @"KofaxCSPSLog.log";

        public override string Name => "CSPS";

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
            var l = Config.SysDiag.SharedListenersEx.Add.Where(x => x.Type.ToLower() == DefaultListenerType.ToLower()).FirstOrDefault();
            l = (l != null) ? l : Config.SysDiag.SharedListenersEx.Add.Where(x => x.Name.ToLower() == DefaultListenerName.ToLower()).FirstOrDefault();

            return l;
        }

        protected override void CreateDependentElements()
        {
            var source = Listener.AddReferenceToSource(Config.SysDiag, "Kofax.CEBPM.ProcessingService.Host");
            var sw = source.AddReferenceToSwitch(Config.SysDiag, "TraceLevelSwitch", "Warning");
            source = Listener.AddReferenceToSource(Config.SysDiag, "Kofax.CEBPM.ProcessingService.Core");
            sw = source.AddReferenceToSwitch(Config.SysDiag, "TraceLevelSwitch", "Warning");
            source = Listener.AddReferenceToSource(Config.SysDiag, "Kofax.CEBPM.CPUServer.Common");
            sw = source.AddReferenceToSwitch(Config.SysDiag, "TraceLevelSwitch", "Warning");
            source = Listener.AddReferenceToSource(Config.SysDiag, "Kofax.CEBPM.DataLayer.Imaging");
            sw = source.AddReferenceToSwitch(Config.SysDiag, "TraceLevelSwitch", "Warning");
            source = Listener.AddReferenceToSource(Config.SysDiag, "Kofax.CEBPM.eVRSWrapper");
            sw = source.AddReferenceToSwitch(Config.SysDiag, "TraceLevelSwitch", "Warning");
        }

    }
}
