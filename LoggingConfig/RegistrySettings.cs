using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemDiagnosticsConfig
{
    

    public class RegistrySettings : LogDisplay
    {
        public RegistryLocation RegLocation { get; set; }
        public RegistryLocation RegLevel { get; set; }


        public override string Details => string.Empty;

        public override bool Enabled { get => true; set { } }
        public override string Level { get => RegLevel?.Read() ?? string.Empty; set => RegLevel?.Write(value); }
        public override string LogLocation { get => RegLocation?.Read() ?? string.Empty; set => RegLocation?.Write(value); }
        

        public override string Name => RegLocation?.ToString() ?? string.Empty;

        public override string ConfigLocation { get => RegLocation?.ToString() ?? string.Empty; }

        public override void OpenConfig()
        {
            RegLocation.OpenRegEdit();
        }

        public override void OpenLog()
        {
            try
            {
                Process.Start($"{LogLocation}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public override void SaveConfig()
        {
            //autosave
            //throw new NotImplementedException();
        }

        

    }

}
