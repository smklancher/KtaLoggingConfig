using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemDiagnosticsConfig
{
    public class DisplayHelper
    {
        BindingSource bs=new BindingSource();

        #region "Controls"
        private DataGridView dgv;

        private DataGridViewCheckBoxColumn enabledColumn = new DataGridViewCheckBoxColumn();
        private DataGridViewTextBoxColumn fileColumn = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
        private DataGridViewComboBoxColumn Level=new DataGridViewComboBoxColumn();
        private DataGridViewTextBoxColumn Location=new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn Details= new DataGridViewTextBoxColumn();

        public DataGridView DataGridView
        {
            get
            {
                return dgv;
            }
            set
            {
                dgv = value;

                ((System.ComponentModel.ISupportInitialize)(dgv)).BeginInit();

                //if not in this mode, must click twice to select row then edit/open dropdown
                dgv.EditMode = DataGridViewEditMode.EditOnEnter;
                dgv.AllowUserToAddRows = false;
                dgv.AllowUserToDeleteRows = false;
                dgv.AutoGenerateColumns = false;
                dgv.MultiSelect = false;
                dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;

                // 
                // Enabled
                // 
                enabledColumn.DataPropertyName = "Enabled";
                enabledColumn.HeaderText = "Enabled";
                enabledColumn.Name = "Enabled";
                // 
                // 
                // Name
                // 
                nameColumn.DataPropertyName = "Name";
                nameColumn.HeaderText = "Name";
                nameColumn.Name = "Name";
                // 
                // 
                // File
                // 
                fileColumn.DataPropertyName = "ConfigLocation";
                fileColumn.HeaderText = "ConfigLocation";
                fileColumn.Name = "ConfigLocation";
                // 
                // 
                // Level
                // 
                Level.DataPropertyName = "Level";
                Level.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                Level.HeaderText = "Level";
                Level.Name = "Level";
                Level.Resizable = DataGridViewTriState.True;
                Level.SortMode = DataGridViewColumnSortMode.Automatic;
                // 
                // Location
                // 
                Location.DataPropertyName = "LogLocation";
                Location.HeaderText = "LogLocation";
                Location.Name = "LogLocation";
                // 
                // Details
                // 
                Details.DataPropertyName = "Details";
                Details.HeaderText = "Details";
                Details.Name = "Details";
                Details.ReadOnly = true;


                dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                dgv.Columns.Clear();
                dgv.Columns.AddRange(
                    new DataGridViewColumn[] {enabledColumn, fileColumn, nameColumn,Level,Location,Details}
                    );

                bs.DataSource = typeof(LogDisplay);
                dgv.DataSource = bs;
                
                ((System.ComponentModel.ISupportInitialize)(dgv)).EndInit();
            }
        }
        public TextBox TextBox { get; set; }
        public PropertyGrid PropertyGrid { get; set; }
        #endregion

        public LogDisplay SelectedLogDef
        {
            get
            {
                DataGridViewRow row=null;
                if (dgv.SelectedCells.Count > 0)
                {
                    row = dgv.SelectedCells[0].OwningRow;
                }
                if (dgv.SelectedRows.Count > 0)
                {
                    row = dgv.SelectedRows[0];
                }
                if (row?.DataBoundItem is LogDisplay ld)
                {
                    return ld;
                }
                return null;
            }
        }

        public void SelectedLogDefChanged()
        {
            LogDisplay log = SelectedLogDef;
            if (log != null)
            {
                PropertyGrid.SelectedObject = log;
            }

            LogDefinition def = log as LogDefinition;
            if (def != null)
            {
                TextBox.Text = def.Config.SysDiagObjXml().ToString();
            }

        }

        private void SizeDataGridColumns()
        {
            for (int i = 0; i < dgv.Columns.Count-1; i++)
            {
                dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                int colw = dgv.Columns[i].Width;
                dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgv.Columns[i].Width = colw;
            }

            dgv.Columns[dgv.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }


        public void DisplayConfigs(ConfigCollection configs)
        {
            // Display configs in property grid
            PropertyGrid.SelectedObject = configs;
            PropertyGrid.ExpandAllGridItems();

            // Display log defs in datagrid
            var defs = configs.SelectMany(x => x.Definitions);
            bs.Clear();
            foreach (var l in defs)
            {
                //l.Details = l.LogFileSize==string.Empty ? l.Details : $"{l.LogFileSize}, {l.Details}";
                bs.Add(l);
            }

            // Bind dropdown to available levels per def type
            foreach (DataGridViewRow row in dgv.Rows)
            {
                var def = (LogDisplay)row.DataBoundItem;
                DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)(row.Cells["Level"]);
                cell.DataSource = def.AvailableLevels.ToList();
            }

            SizeDataGridColumns();
        }

        public void AddLog(LogDisplay ld)
        {
            bs.Add(ld);

            // Bind dropdown to available levels per def type
            foreach (DataGridViewRow row in dgv.Rows)
            {
                var def = (LogDisplay)row.DataBoundItem;
                DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)(row.Cells["Level"]);
                cell.DataSource = def.AvailableLevels.ToList();
            }
        }


        public void OpenConfig()
        {
            LogDisplay log = SelectedLogDef;
            if (log == null) return;

            log.OpenConfig();

            //Process.Start(log.Config.Filename);
        }

        public void OpenLog()
        {
            var log = SelectedLogDef;
            if (log == null) return;

            log.OpenLog();

            
        }

        public string BackupConfigs(ConfigCollection configs)
        {
            StringBuilder msg = new StringBuilder("Config backup results:\n");
            foreach(var c in configs)
            {
                string bkname = Path.GetFileNameWithoutExtension(c.Filename);
                string timestamp = DateTime.Now.ToString("s").Replace(":", ".");
                bkname = Path.Combine(Path.GetDirectoryName(c.Filename),$"{bkname}_{timestamp}.config");

                try
                {
                    File.Copy(c.Filename, bkname,true);
                    msg.AppendLine($"SUCCESS: {bkname}");
                }
                catch (Exception ex)
                {
                    msg.AppendLine($"ERROR: {bkname}");
                    msg.AppendLine($"\t{ex.Message}");
                }
            }
            return msg.ToString();
        }
    }
}
