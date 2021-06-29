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
            this.btnPrint = new System.Windows.Forms.Button();
            this.dgvChannel = new System.Windows.Forms.DataGridView();
            this.Channel_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChannelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSaveAs = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TempChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChannel)).BeginInit();
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
            series1.Name = "Temperature";
            this.TempChart.Series.Add(series1);
            this.TempChart.Size = new System.Drawing.Size(914, 455);
            this.TempChart.TabIndex = 0;
            this.TempChart.Text = "chart1";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(453, 629);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(50, 21);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // dgvChannel
            // 
            this.dgvChannel.AllowUserToAddRows = false;
            this.dgvChannel.AllowUserToDeleteRows = false;
            this.dgvChannel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChannel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Channel_ID,
            this.ChannelName,
            this.CreationDate});
            this.dgvChannel.Location = new System.Drawing.Point(308, 21);
            this.dgvChannel.Name = "dgvChannel";
            this.dgvChannel.ReadOnly = true;
            this.dgvChannel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChannel.Size = new System.Drawing.Size(435, 112);
            this.dgvChannel.TabIndex = 4;
            this.dgvChannel.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChannel_CellDoubleClick);
            this.dgvChannel.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvChannel_ColumnWidthChanged);
            // 
            // Channel_ID
            // 
            this.Channel_ID.DataPropertyName = "id";
            this.Channel_ID.HeaderText = "Channel ID";
            this.Channel_ID.Name = "Channel_ID";
            this.Channel_ID.ReadOnly = true;
            // 
            // ChannelName
            // 
            this.ChannelName.DataPropertyName = "name";
            this.ChannelName.HeaderText = "Name";
            this.ChannelName.Name = "ChannelName";
            this.ChannelName.ReadOnly = true;
            // 
            // CreationDate
            // 
            this.CreationDate.DataPropertyName = "created_at";
            this.CreationDate.HeaderText = "Created";
            this.CreationDate.Name = "CreationDate";
            this.CreationDate.ReadOnly = true;
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(547, 629);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAs.TabIndex = 5;
            this.btnSaveAs.Text = "Save As...";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // frmKilnFiringProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 683);
            this.Controls.Add(this.btnSaveAs);
            this.Controls.Add(this.dgvChannel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.TempChart);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmKilnFiringProfile";
            this.Text = "Kiln Firing Profile";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmKilnFiringProfile_FormClosing);
            this.Load += new System.EventHandler(this.frmKilnFiringProfile_Load);
            this.Shown += new System.EventHandler(this.frmKilnFiringProfile_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.TempChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChannel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart TempChart;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dgvChannel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Channel_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChannelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreationDate;
        private System.Windows.Forms.Button btnSaveAs;
    }
}

