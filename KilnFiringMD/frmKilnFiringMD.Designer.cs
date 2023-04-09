namespace KilnFiringMD
{
    partial class frmKilnFiringMD
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.TempChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvFiring = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.created_at = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.TempChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiring)).BeginInit();
            this.SuspendLayout();
            // 
            // TempChart
            // 
            chartArea1.Name = "ChartArea1";
            this.TempChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.TempChart.Legends.Add(legend1);
            this.TempChart.Location = new System.Drawing.Point(12, 226);
            this.TempChart.Name = "TempChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.TempChart.Series.Add(series1);
            this.TempChart.Size = new System.Drawing.Size(1045, 397);
            this.TempChart.TabIndex = 0;
            this.TempChart.Text = "TempChart";
            this.TempChart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TempChart_MouseClick);
            this.TempChart.MouseLeave += new System.EventHandler(this.TempChart_MouseLeave);
            this.TempChart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TempChart_MouseMove);
            // 
            // dgvFiring
            // 
            this.dgvFiring.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiring.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.title,
            this.created_at,
            this.description});
            this.dgvFiring.Location = new System.Drawing.Point(111, 32);
            this.dgvFiring.Name = "dgvFiring";
            this.dgvFiring.Size = new System.Drawing.Size(785, 159);
            this.dgvFiring.TabIndex = 1;
            this.dgvFiring.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFiring_CellValueChanged);
            this.dgvFiring.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvFiring_ColumnWidthChanged);
            this.dgvFiring.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvFiring_RowStateChanged);
            this.dgvFiring.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvFiring_UserDeletingRow);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            // 
            // title
            // 
            this.title.DataPropertyName = "title";
            this.title.HeaderText = "Title";
            this.title.Name = "title";
            // 
            // created_at
            // 
            this.created_at.DataPropertyName = "started_at";
            this.created_at.HeaderText = "Created At";
            this.created_at.Name = "created_at";
            // 
            // description
            // 
            this.description.DataPropertyName = "description";
            this.description.HeaderText = "Description";
            this.description.Name = "description";
            // 
            // frmKilnFiringMD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 635);
            this.Controls.Add(this.dgvFiring);
            this.Controls.Add(this.TempChart);
            this.Name = "frmKilnFiringMD";
            this.Text = "Kiln Firing Run (MariaDB)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmKilnFiringMD_FormClosing);
            this.Load += new System.EventHandler(this.frmKilnFiringMD_Load);
            this.Shown += new System.EventHandler(this.frmKilnFiringMD_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.TempChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiring)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart TempChart;
        private System.Windows.Forms.DataGridView dgvFiring;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn created_at;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
    }
}

