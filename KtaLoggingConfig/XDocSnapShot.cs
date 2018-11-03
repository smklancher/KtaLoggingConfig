using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDiagnosticsConfig;

namespace KtaLoggingConfig
{
    public class XDocSnapShot : RegistrySettings
    {
        //public override string ConfigFilename => @"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Kofax\Transformation\4.0\Server\SnapShotPath";
        
        public XDocSnapShot()
        {
            RegLocation = new RegistryLocation()
            {
                SubKey = @"SOFTWARE\Wow6432Node\Kofax\Transformation\4.0\Server",
                KeyName = "SnapShotPath"
            };
        }

        //public override string Details => string.Empty;

        //public override bool Enabled { get; set; }

        public override string Name => "XDoc Snapshot";
    }
}
