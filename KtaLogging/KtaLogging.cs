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
using System.Diagnostics;

namespace KtaLogging
{
    public partial class KtaLogging : Form
    {
        private BindingSource bs = new BindingSource();
        private ConfigCollection configs;
        private DisplayHelper dh = new DisplayHelper();

        public KtaLogging()
        {
            InitializeComponent();
        }

        private void KtaLogging_Load(object sender, EventArgs e)
        {
            dh.DataGridView = dataGridView1;
            dh.PropertyGrid = LogProperties;
            dh.TextBox = DetailTextBox;

            configs = KtaHelper.KtaConfigs();
            dh.DisplayConfigs(configs);
            dh.AddLog(new XDocSnapShot());
            dh.AddLog(new ExtractionSchedulerRegistry());


            //var logs = configs.SelectMany(x => x.Listeners);


            //dataGridView1.AutoGenerateColumns = true;

            //var web = configs.OfType<WebConfig>().FirstOrDefault();
            //var y = web.Definitions;
            //foreach(var z in y)
            //{
            //    Debug.Write(z.ToString());
            //}
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(var c in configs)
            {
                c.SaveXml();
            }
        }

        private void logDefinitionBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
        

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            dh.SelectedLogDefChanged();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //dh.SelectedLogDefChanged(); 
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //dh.SelectedLogDefChanged(); 
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dh.SelectedLogDefChanged(); 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //e.Cancel = true;
            //e.ThrowException = false;
        }
        
        private void OpenButton_Click_1(object sender, EventArgs e)
        {
            dh.OpenLog();
        }

        private void BackupButton_Click(object sender, EventArgs e)
        {
            string msg=dh.BackupConfigs(configs);
            MessageBox.Show(msg);
        }

        private void OpenConfigButton_Click(object sender, EventArgs e)
        {
            dh.OpenConfig();
        }

        private void SaveSelectedButton_Click(object sender, EventArgs e)
        {
            var log = dh.SelectedLogDef;
            if (log == null) return;
            log.SaveConfig();


        }
    }
}
