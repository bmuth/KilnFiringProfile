namespace KilnFiringProfile
{
    partial class frmKilnFiringProfile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.TempChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvChannel = new System.Windows.Forms.DataGridView();
            this.Channel_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChannelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.TempChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChannel)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TempChart
            // 
            chartArea1.Name = "ChartArea1";
            this.TempChart.ChartAreas.Add(chartArea1);
            this.TempChart.Location = new System.Drawing.Point(74, 151);
            this.TempChart.Margin = new System.Windows.Forms.Padding(2);
            this.TempChart.Name = "TempChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Temperature";
            this.TempChart.Series.Add(series1);
            this.TempChart.Size = new System.Drawing.Size(914, 455);
            this.TempChart.TabIndex = 0;
            this.TempChart.Text = "chart1";
            // 
            // dgvChannel
            // 
            this.dgvChannel.AllowUserToAddRows = false;
            this.dgvChannel.AllowUserToDeleteRows = false;
            this.dgvChannel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChannel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Channel_ID,
            this.ChannelName,
            this.CreationDate,
            this.Description});
            this.dgvChannel.Location = new System.Drawing.Point(130, 27);
            this.dgvChannel.Name = "dgvChannel";
            this.dgvChannel.RowHeadersWidth = 62;
            this.dgvChannel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChannel.Size = new System.Drawing.Size(761, 112);
            this.dgvChannel.TabIndex = 4;
            this.dgvChannel.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChannel_CellDoubleClick);
            this.dgvChannel.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChannel_CellLeave);
            this.dgvChannel.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChannel_CellValueChanged);
            this.dgvChannel.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvChannel_ColumnWidthChanged);
            // 
            // Channel_ID
            // 
            this.Channel_ID.DataPropertyName = "id";
            this.Channel_ID.HeaderText = "Channel ID";
            this.Channel_ID.MinimumWidth = 8;
            this.Channel_ID.Name = "Channel_ID";
            this.Channel_ID.ReadOnly = true;
            this.Channel_ID.Width = 150;
            // 
            // ChannelName
            // 
            this.ChannelName.DataPropertyName = "name";
            this.ChannelName.HeaderText = "Name";
            this.ChannelName.MinimumWidth = 8;
            this.ChannelName.Name = "ChannelName";
            this.ChannelName.ReadOnly = true;
            this.ChannelName.Width = 150;
            // 
            // CreationDate
            // 
            this.CreationDate.DataPropertyName = "created_at";
            this.CreationDate.HeaderText = "Created";
            this.CreationDate.MinimumWidth = 8;
            this.CreationDate.Name = "CreationDate";
            this.CreationDate.ReadOnly = true;
            this.CreationDate.Width = 150;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "description";
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 8;
            this.Description.Name = "Description";
            this.Description.Width = 150;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1185, 31);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.printSetupToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.printToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(267, 6);
            // 
            // printSetupToolStripMenuItem
            // 
            this.printSetupToolStripMenuItem.Name = "printSetupToolStripMenuItem";
            this.printSetupToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.printSetupToolStripMenuItem.Text = "P&rint Setup";
            this.printSetupToolStripMenuItem.Click += new System.EventHandler(this.printSetupToolStripMenuItem_Click);
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.printPreviewToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.printToolStripMenuItem.Text = "&Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(267, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.exitToolStripMenuItem.Text = "&Exit";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.saveAsToolStripMenuItem.Text = "Save &As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // frmKilnFiringProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 683);
            this.Controls.Add(this.dgvChannel);
            this.Controls.Add(this.TempChart);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmKilnFiringProfile";
            this.Text = "Kiln Firing Profile";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmKilnFiringProfile_FormClosing);
            this.Load += new System.EventHandler(this.frmKilnFiringProfile_Load);
            this.Shown += new System.EventHandler(this.frmKilnFiringProfile_Shown);
            this.SizeChanged += new System.EventHandler(this.frmKilnFiringProfile_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.TempChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChannel)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart TempChart;
        private System.Windows.Forms.DataGridView dgvChannel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Channel_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChannelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
    }
}

