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
    public class TransformationLogDefinition : LogDefinition
    {
        public TransformationLogDefinition(ConfigFile config): base(config)
        {

        }

        protected override string DefaultListenerName => "CPUServerLogTxt";

        protected override string DefaultListenerType => "Kofax.CEBPM.CPUServer.Common.Diagnostics.DateTimeTaggedTraceListener, Kofax.CEBPM.CPUServer.Common";

        public override string DefaultLocation { get; set; } = @"KofaxCPUServerLog.log";

        public override string Name => "TransformationServer";

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
            var l = Config.SysDiag.SharedListenersEx.Add.Where(x => x.Type.ToLower() == DefaultListenerType.ToLower()).FirstOrDefault();
            l = (l != null) ? l : Config.SysDiag.SharedListenersEx.Add.Where(x => x.Name.ToLower() == DefaultListenerName.ToLower()).FirstOrDefault();

            return l;
        }

        protected override void CreateDependentElements()
        {
            var source = Listener.AddReferenceToSource(Config.SysDiag, "Kofax.CEBPM.CPUServer.ServiceHost");
            var sw = source.AddReferenceToSwitch(Config.SysDiag, "TraceLevelSwitch", "Warning");
            source = Listener.AddReferenceToSource(Config.SysDiag, "Kofax.CEBPM.CPUServer.Core");
            sw = source.AddReferenceToSwitch(Config.SysDiag, "TraceLevelSwitch", "Warning");
            source = Listener.AddReferenceToSource(Config.SysDiag, "Kofax.CEBPM.CPUServer.Common");
            sw = source.AddReferenceToSwitch(Config.SysDiag, "TraceLevelSwitch", "Warning");
        }

    }
}
