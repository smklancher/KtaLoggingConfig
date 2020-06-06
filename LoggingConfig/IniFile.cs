using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemDiagnosticsConfig
{
    public abstract class IniFile : LogDisplay
    {
        public string FileName { get; private set; }
        //private KeyDataCollection Colors { get => data[@"Control Panel\Colors"]; }

        protected IniData data;

        /// <summary>
        /// Load a theme file
        /// </summary>
        /// <param name="file"></param>
        public IniFile(string file)
        {
            FileName = file;
            var parser = new FileIniDataParser();
            //TODO: decide how to handle parse error
            data = parser.ReadFile(file);
        }

        public override string ConfigLocation => FileName;

        public override string Name => Path.GetFileName(FileName);

        public override void SaveConfig()
        {
            var parser = new FileIniDataParser();
            parser.WriteFile(FileName, data);
        }
    }
}
