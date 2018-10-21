using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDiagnosticsConfig;
using System.IO;

namespace KtaLoggingConfig
{
    public class KtaHelper
    {
        public static ConfigCollection KtaConfigs()
        {
            KtaConfig c;
            LogDefinition ld;
            var list = new ConfigCollection();

            KtaPath.TryGetFolder(KtaFolder.Logs, out string logsPath);

            string path;
            if (TryGetFile(KtaFolder.Web,"web.config", out path))
            {
                list.Add(new WebConfig(path));
            }

            if (TryGetFile(KtaFolder.Web, "web.config", out path))
            {
                c = new KtaConfig(path);
                
                list.Add(c);
            }

            if (TryGetFile(KtaFolder.CoreWorker, "Agility.Server.Core.WorkerService.exe.config", out path))
            {
                c = new KtaConfig(path);
                c.AddDefinition<KtaTraceLogDefinition>();
                list.Add(c);
            }

            if (TryGetFile(KtaFolder.Reporting, "Kofax.CEBPM.Reporting.TAService.exe.config", out path))
            {
                c = new KtaConfig(path);
                ld = c.AddDefinition<ReportingLogDefinition>();
                ((ReportingLogDefinition)ld).IsServiceLog = true;
                list.Add(c);
            }

            if (TryGetFile(KtaFolder.Reporting, "Kofax.CEBPM.Reporting.AzureETL.exe.config", out path))
            {
                c = new KtaConfig(path);
                ld = c.AddDefinition<ReportingLogDefinition>();
                ((ReportingLogDefinition)ld).IsServiceLog = false;
                list.Add(c);
            }

            if (TryGetFile(KtaFolder.Transformation, "Kofax.CEBPM.CPUServer.ServiceHost.exe.config", out path))
            {
                c = new KtaConfig(path);
                ld = c.AddDefinition<TransformationLogDefinition>();
                list.Add(c);
            }

            if (TryGetFile(KtaFolder.CoreWorker, "Agility.Server.Core.ExportWorker.Host.exe.config", out path))
            {
                c = new KtaConfig(path);
                ld = c.AddDefinition<KtaTraceLogDefinition>();
                ((KtaTraceLogDefinition)ld).DefaultLocation = Path.Combine(logsPath, "ExportService.log");
                list.Add(c);
            }

            if (TryGetFile(KtaFolder.Streaming, "Agility.Server.StreamingService.exe.config", out path))
            {
                c = new KtaConfig(path);
                ld = c.AddDefinition<ActivityTraceLogDefinition>();
                ((ActivityTraceLogDefinition)ld).DefaultLocation = Path.Combine(logsPath, "StreamingService.svclog");
                ld = c.AddDefinition<KtaTraceLogDefinition>();
                ((KtaTraceLogDefinition)ld).DefaultLocation = Path.Combine(logsPath, "StreamingService.log");
                list.Add(c);
            }


            if (TryGetFile(KtaFolder.Transformation, "Kofax.CEBPM.ProcessingService.Host.exe.config", out path))
            {
                c = new KtaConfig(path);
                ld = c.AddDefinition<ActivityTraceLogDefinition>();
                ((ActivityTraceLogDefinition)ld).DefaultLocation = Path.Combine(logsPath, "KofaxCSPSLog.svclog");
                ld = c.AddDefinition<CspsLogDefinition>();
                list.Add(c);
            }


            //list.Add(new KtaConfig(@"C:\Program Files (x86)\Kofax\TotalAgility\Transformation Designer\Kofax.ProjectBuilder.exe.config"));

            //C:\Program Files\Kofax\TotalAgility\Transformation Server\Kofax.CEBPM.DocumentConversionService.Host.exe.config


            return list;
        }

        private static bool TryGetFile(KtaFolder folder, string file, out string outPath)
        {
            if(KtaPath.TryGetFolder(folder,out string folderpath))
            {
                outPath = Path.Combine(folderpath, file);
                return File.Exists(outPath);
            }
            outPath = string.Empty;
            return false;
        }
    }
}
