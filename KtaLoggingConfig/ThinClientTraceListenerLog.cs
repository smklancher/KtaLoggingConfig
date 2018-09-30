using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDiagnosticsConfig;

namespace KtaLoggingConfig
{
    //public class ThinClientTraceListenerLog : LogListener
    //{
    //    public ThinClientTraceListenerLog(SystemDiagnosticsConfigCT SysDiag) : base(SysDiag)
    //    {

    //    }

    //    protected string LogName
    //    {
    //        get { return "ThinClientServer"; }
    //    }

    //    private ListenerElementCT SetTraceListener(string filename, SourceLevels level)
    //    {
    //        var x = ConfigHelper.SetTraceListener(SysDiag, LogName, "System.Diagnostics.TextWriterTraceListener", filename);
    //        x.Filter.Type = "System.Diagnostics.EventTypeFilter";
    //        x.Filter.InitializeData = level.ToString();
    //        return x;
    //    }

    //    //public override string LogFileName
    //    //{
    //    //    get
    //    //    {
    //    //        var filename = SysDiag?.Trace?.Listeners?.Add?.Where(x => x.Name == LogName).FirstOrDefault().InitializeData;

    //    //        if (!string.IsNullOrEmpty(filename))
    //    //        {
    //    //            return filename;
    //    //        }
    //    //        else
    //    //        {
    //    //            return ""; //Consider defaults
    //    //        }
    //    //    }

    //    //    set
    //    //    {
    //    //        SetTraceListener(value, Level); 
    //    //    }
    //    //}

    //    public SourceLevels Level
    //    {
    //        get
    //        {
    //            string lvlstr = SysDiag?.Trace?.Listeners?.Add?.Where(x => x.Name == LogName).FirstOrDefault()?.Filter?.InitializeData;
    //            if (Enum.TryParse(lvlstr, out SourceLevels lvl)){
    //                return lvl;
    //            }
    //            else
    //            {
    //                return SourceLevels.Warning;
    //            }
    //        }

    //        set
    //        {
    //            SetTraceListener(LogFileName, value);
    //        }
    //    }



    //    //public override bool Enabled
    //    //{
    //    //    get
    //    //    {
    //    //        bool NamedListenerExists = (SysDiag?.Trace?.Listeners?.Add?.Where(x => x.Name == LogName).FirstOrDefault() != null);
    //    //        return !SysDiag.IsComment && NamedListenerExists;
    //    //    }
    //    //    set
    //    //    {
    //    //        // Flag or unflag as comment according to whether enabled
    //    //        SysDiag.IsComment = !value;

    //    //        // If enabling, ensure that basic settings exist by setting the log file name (to itself in case already exists)
    //    //        if (value)
    //    //        {
    //    //            SetTraceListener(LogFileName, Level);
    //    //        }
    //    //    }
    //    //}


    //}
}
