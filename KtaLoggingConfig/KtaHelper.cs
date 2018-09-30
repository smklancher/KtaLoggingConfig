using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDiagnosticsConfig;

namespace KtaLoggingConfig
{
    public class KtaHelper
    {
        public static ConfigCollection KtaConfigs()
        {
            var list = new ConfigCollection();
            list.Add(new ConfigFile(@"C:\Program Files\Kofax\TotalAgility\CoreWorkerService\Agility.Server.Core.WorkerService.exe.config"));
            list.Add(new WebConfig(@"C:\Program Files\Kofax\TotalAgility\Agility.Server.Web\web.config"));
            list.Add(new ConfigFile(@"C:\Program Files\Kofax\TotalAgility\CoreWorkerService\Agility.Server.Core.ExportWorker.Host.exe.config"));
            list.Add(new ConfigFile(@"C:\Program Files\Kofax\TotalAgility\CoreWorkerService\Agility.Server.StreamingService.exe.config"));
            list.Add(new ConfigFile(@"C:\Program Files\Kofax\TotalAgility\Reporting\Kofax.CEBPM.Reporting.TAService.exe.config"));
            list.Add(new ConfigFile(@"C:\Program Files\Kofax\TotalAgility\Reporting\Kofax.CEBPM.Reporting.AzureETL.exe.config"));
            list.Add(new ConfigFile(@"C:\Program Files\Kofax\TotalAgility\Transformation Server\Kofax.CEBPM.ProcessingService.Host.exe.config"));
            list.Add(new ConfigFile(@"C:\Program Files\Kofax\TotalAgility\Transformation Server\Kofax.CEBPM.CPUServer.ServiceHost.exe.config"));
            list.Add(new ConfigFile(@"C:\Program Files (x86)\Kofax\TotalAgility\Transformation Designer\Kofax.ProjectBuilder.exe.config"));


            return list;
        }
    }
}
