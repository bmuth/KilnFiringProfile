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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.TempChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dgvChannel = new System.Windows.Forms.DataGridView();
            this.Channel_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChannelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSaveAs = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TempChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChannel)).BeginInit();
            this.SuspendLayout();
            // 
            // TempChart
            // 
            chartArea4.Name = "ChartArea1";
            this.TempChart.ChartAreas.Add(chartArea4);
            this.TempChart.Location = new System.Drawing.Point(111, 232);
            this.TempChart.Name = "TempChart";
            series4.ChartArea = "ChartArea1";
            series4.Name = "Temperature";
            this.TempChart.Series.Add(series4);
            this.TempChart.Size = new System.Drawing.Size(1371, 700);
            this.TempChart.TabIndex = 0;
            this.TempChart.Text = "chart1";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(680, 968);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 32);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
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
            this.dgvChannel.Location = new System.Drawing.Point(195, 35);
            this.dgvChannel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvChannel.Name = "dgvChannel";
            this.dgvChannel.RowHeadersWidth = 62;
            this.dgvChannel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChannel.Size = new System.Drawing.Size(1142, 172);
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
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(820, 968);
            this.btnSaveAs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(112, 35);
            this.btnSaveAs.TabIndex = 5;
            this.btnSaveAs.Text = "Save As...";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // frmKilnFiringProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1778, 1051);
            this.Controls.Add(this.btnSaveAs);
            this.Controls.Add(this.dgvChannel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.TempChart);
            this.Name = "frmKilnFiringProfile";
            this.Text = "Kiln Firing Profile";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmKilnFiringProfile_FormClosing);
            this.Load += new System.EventHandler(this.frmKilnFiringProfile_Load);
            this.Shown += new System.EventHandler(this.frmKilnFiringProfile_Shown);
            this.SizeChanged += new System.EventHandler(this.frmKilnFiringProfile_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.TempChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChannel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart TempChart;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dgvChannel;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Channel_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChannelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
    }
}

