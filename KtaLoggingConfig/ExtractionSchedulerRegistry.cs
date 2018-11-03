using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDiagnosticsConfig;

namespace KtaLoggingConfig
{
    public class ExtractionSchedulerRegistry : RegistrySettings
    {
        public ExtractionSchedulerRegistry()
        {
            RegLocation = new RegistryLocation()
            {
                SubKey = @"SOFTWARE\Wow6432Node\Kofax\Transformation\4.0\Server",
                KeyName = "LogFilePath",
                DefaultData = @"C:\Program Files (x86)\Common Files\Kofax\Server\"
            };

            RegLevel= new RegistryLocation()
            {
                SubKey = @"SOFTWARE\Wow6432Node\Kofax\Transformation\4.0\Server",
                KeyName = "LogLevel",
                DefaultData="3"
            };
        }

        public override string Name => "Extraction-Scheduler Log";

        public override IEnumerable<string> AvailableLevels
        {
            get
            {
                for(int i = 1; i < 6; i++)
                {
                    yield return i.ToString();
                }
            }
        }
    }
}
