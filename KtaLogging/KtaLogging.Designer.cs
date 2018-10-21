namespace KtaLogging
{
    partial class KtaLogging
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SaveButton = new System.Windows.Forms.Button();
            this.LogProperties = new System.Windows.Forms.PropertyGrid();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MainContainer = new System.Windows.Forms.SplitContainer();
            this.BottomContainer = new System.Windows.Forms.SplitContainer();
            this.DetailTextBox = new System.Windows.Forms.TextBox();
            this.OpenButton = new System.Windows.Forms.Button();
            this.BackupButton = new System.Windows.Forms.Button();
            this.OpenConfigButton = new System.Windows.Forms.Button();
            this.SaveSelectedButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).BeginInit();
            this.MainContainer.Panel1.SuspendLayout();
            this.MainContainer.Panel2.SuspendLayout();
            this.MainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BottomContainer)).BeginInit();
            this.BottomContainer.Panel1.SuspendLayout();
            this.BottomContainer.Panel2.SuspendLayout();
            this.BottomContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(713, 6);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Save All";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // LogProperties
            // 
            this.LogProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogProperties.Location = new System.Drawing.Point(0, 0);
            this.LogProperties.Name = "LogProperties";
            this.LogProperties.Size = new System.Drawing.Size(514, 400);
            this.LogProperties.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(776, 146);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // MainContainer
            // 
            this.MainContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainContainer.Location = new System.Drawing.Point(12, 35);
            this.MainContainer.Name = "MainContainer";
            this.MainContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainContainer.Panel1
            // 
            this.MainContainer.Panel1.Controls.Add(this.dataGridView1);
            // 
            // MainContainer.Panel2
            // 
            this.MainContainer.Panel2.Controls.Add(this.BottomContainer);
            this.MainContainer.Size = new System.Drawing.Size(776, 550);
            this.MainContainer.SplitterDistance = 146;
            this.MainContainer.TabIndex = 6;
            // 
            // BottomContainer
            // 
            this.BottomContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomContainer.Location = new System.Drawing.Point(0, 0);
            this.BottomContainer.Name = "BottomContainer";
            // 
            // BottomContainer.Panel1
            // 
            this.BottomContainer.Panel1.Controls.Add(this.DetailTextBox);
            // 
            // BottomContainer.Panel2
            // 
            this.BottomContainer.Panel2.Controls.Add(this.LogProperties);
            this.BottomContainer.Size = new System.Drawing.Size(776, 400);
            this.BottomContainer.SplitterDistance = 258;
            this.BottomContainer.TabIndex = 0;
            // 
            // DetailTextBox
            // 
            this.DetailTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailTextBox.Location = new System.Drawing.Point(0, 0);
            this.DetailTextBox.Multiline = true;
            this.DetailTextBox.Name = "DetailTextBox";
            this.DetailTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DetailTextBox.Size = new System.Drawing.Size(258, 400);
            this.DetailTextBox.TabIndex = 0;
            // 
            // OpenButton
            // 
            this.OpenButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenButton.Location = new System.Drawing.Point(632, 6);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(75, 23);
            this.OpenButton.TabIndex = 7;
            this.OpenButton.Text = "Open Log";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click_1);
            // 
            // BackupButton
            // 
            this.BackupButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BackupButton.Location = new System.Drawing.Point(446, 6);
            this.BackupButton.Name = "BackupButton";
            this.BackupButton.Size = new System.Drawing.Size(97, 23);
            this.BackupButton.TabIndex = 8;
            this.BackupButton.Text = "Backup Configs";
            this.BackupButton.UseVisualStyleBackColor = true;
            this.BackupButton.Click += new System.EventHandler(this.BackupButton_Click);
            // 
            // OpenConfigButton
            // 
            this.OpenConfigButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenConfigButton.Location = new System.Drawing.Point(549, 6);
            this.OpenConfigButton.Name = "OpenConfigButton";
            this.OpenConfigButton.Size = new System.Drawing.Size(75, 23);
            this.OpenConfigButton.TabIndex = 9;
            this.OpenConfigButton.Text = "Open Config";
            this.OpenConfigButton.UseVisualStyleBackColor = true;
            this.OpenConfigButton.Click += new System.EventHandler(this.OpenConfigButton_Click);
            // 
            // SaveSelectedButton
            // 
            this.SaveSelectedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveSelectedButton.Location = new System.Drawing.Point(348, 6);
            this.SaveSelectedButton.Name = "SaveSelectedButton";
            this.SaveSelectedButton.Size = new System.Drawing.Size(92, 23);
            this.SaveSelectedButton.TabIndex = 10;
            this.SaveSelectedButton.Text = "Save Selected";
            this.SaveSelectedButton.UseVisualStyleBackColor = true;
            this.SaveSelectedButton.Click += new System.EventHandler(this.SaveSelectedButton_Click);
            // 
            // KtaLogging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 597);
            this.Controls.Add(this.SaveSelectedButton);
            this.Controls.Add(this.OpenConfigButton);
            this.Controls.Add(this.BackupButton);
            this.Controls.Add(this.OpenButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.MainContainer);
            this.Name = "KtaLogging";
            this.Text = "KTA Logging";
            this.Load += new System.EventHandler(this.KtaLogging_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.MainContainer.Panel1.ResumeLayout(false);
            this.MainContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).EndInit();
            this.MainContainer.ResumeLayout(false);
            this.BottomContainer.Panel1.ResumeLayout(false);
            this.BottomContainer.Panel1.PerformLayout();
            this.BottomContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BottomContainer)).EndInit();
            this.BottomContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.PropertyGrid LogProperties;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer MainContainer;
        private System.Windows.Forms.SplitContainer BottomContainer;
        private System.Windows.Forms.TextBox DetailTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.Button BackupButton;
        private System.Windows.Forms.Button OpenConfigButton;
        private System.Windows.Forms.Button SaveSelectedButton;
    }
}

