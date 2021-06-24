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
            this.dtpFiringDate = new System.Windows.Forms.DateTimePicker();
            this.btnFetch = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TempChart)).BeginInit();
            this.SuspendLayout();
            // 
            // TempChart
            // 
            chartArea1.Name = "ChartArea1";
            this.TempChart.ChartAreas.Add(chartArea1);
            this.TempChart.Location = new System.Drawing.Point(8, 8);
            this.TempChart.Margin = new System.Windows.Forms.Padding(2);
            this.TempChart.Name = "TempChart";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Temperature";
            this.TempChart.Series.Add(series1);
            this.TempChart.Size = new System.Drawing.Size(597, 370);
            this.TempChart.TabIndex = 0;
            this.TempChart.Text = "chart1";
            // 
            // dtpFiringDate
            // 
            this.dtpFiringDate.Location = new System.Drawing.Point(29, 398);
            this.dtpFiringDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFiringDate.Name = "dtpFiringDate";
            this.dtpFiringDate.Size = new System.Drawing.Size(135, 20);
            this.dtpFiringDate.TabIndex = 1;
            // 
            // btnFetch
            // 
            this.btnFetch.Location = new System.Drawing.Point(185, 396);
            this.btnFetch.Margin = new System.Windows.Forms.Padding(2);
            this.btnFetch.Name = "btnFetch";
            this.btnFetch.Size = new System.Drawing.Size(50, 21);
            this.btnFetch.TabIndex = 2;
            this.btnFetch.Text = "Fetch";
            this.btnFetch.UseVisualStyleBackColor = true;
            this.btnFetch.Click += new System.EventHandler(this.btnFetch_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(261, 396);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(50, 21);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // frmKilnFiringProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 479);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnFetch);
            this.Controls.Add(this.dtpFiringDate);
            this.Controls.Add(this.TempChart);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmKilnFiringProfile";
            this.Text = "Kiln Firing Profile";
            ((System.ComponentModel.ISupportInitialize)(this.TempChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart TempChart;
        private System.Windows.Forms.DateTimePicker dtpFiringDate;
        private System.Windows.Forms.Button btnFetch;
        private System.Windows.Forms.Button btnPrint;
    }
}

