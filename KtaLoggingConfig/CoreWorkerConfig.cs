using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Diagnostics;
using SystemDiagnosticsConfig;
using System.Linq.Expressions;

namespace KtaLoggingConfig
{
    public class CoreWorkerConfig : ConfigFile
    {
        //<!-- core worker -->
        //<!--to enable TA Logging specify a trace listener with KTALog as name-->
        //<!--<system.diagnostics>
	       // <trace autoflush = "true" indentsize="4">
	       //   <listeners>
		      //  <add name = "KTALog" type="System.Diagnostics.TextWriterTraceListener" initializeData="c:\temp\KTALog.txt">
		      //  </add>
	       //   </listeners>
	       // </trace>
        //</system.diagnostics>-->


        public CoreWorkerConfig(string file) : base(file)
        {
           // TraceListenerLog = new KtaTraceListenerLog(SysDiag);
        }

        //public KtaTraceListenerLog TraceListenerLog {get;set;}


        public static CoreWorkerConfig LoadFromDefaultLocation()
        {
            var filename = @"C:\Program Files\Kofax\TotalAgility\CoreWorkerService\Agility.Server.Core.WorkerService.exe.config";
            return new CoreWorkerConfig(filename);
        }


    }
}
