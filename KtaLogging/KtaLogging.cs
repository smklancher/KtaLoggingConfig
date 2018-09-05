using KtaLoggingConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using SystemDiagnosticsConfig;

namespace KtaLogging
{
    public partial class KtaLogging : Form
    {
        public CoreWorkerConfig config;

        public KtaLogging()
        {
            InitializeComponent();
        }

        private void KtaLogging_Load(object sender, EventArgs e)
        {


            //const string File = @"C:\WorkingCopy\KtaLoggingConfig\Misc\Agility.Server.Core.WorkerService.exe.config";
            //const string File2 = @"C:\WorkingCopy\KtaLoggingConfig\Misc\Kofax.CEBPM.Reporting.AzureETL.exe.config";
            //var x = new CoreWorker(File2);

            config = CoreWorkerConfig.LoadFromDefaultLocation();
            checkBox1.Checked = config.TraceListenerLog.Enabled;
            textBox1.Text = config.TraceListenerLog.LogFileName;

            //var logs = new List<LogConfig>();
            //logs.Add(CoreWorkerConfig.LoadFromDefaultLocation().TraceListenerLog);
            //logs.Add(WebConfig.LoadFromDefaultLocation().TraceListenerLog);
            //logs.Add(WebConfig.LoadFromDefaultLocation().ThinClientTraceListenerLog);
            //LogProperties.SelectedObject = logs.ToArray();


            var configs = new ConfigCollection();
            configs.Add(config);
            configs.Add(WebConfig.LoadFromDefaultLocation());
            LogProperties.SelectedObject = configs;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            config.TraceListenerLog.Enabled = checkBox1.Checked;
            config.TraceListenerLog.LogFileName = textBox1.Text;
            config.SaveXml();
        }
    }
}
