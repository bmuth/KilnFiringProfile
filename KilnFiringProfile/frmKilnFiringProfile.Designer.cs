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
            this.btnFetch = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lbChannels = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.TempChart)).BeginInit();
            this.SuspendLayout();
            // 
            // TempChart
            // 
            chartArea1.Name = "ChartArea1";
            this.TempChart.ChartAreas.Add(chartArea1);
            this.TempChart.Location = new System.Drawing.Point(191, 302);
            this.TempChart.Margin = new System.Windows.Forms.Padding(2);
            this.TempChart.Name = "TempChart";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Temperature";
            this.TempChart.Series.Add(series1);
            this.TempChart.Size = new System.Drawing.Size(597, 370);
            this.TempChart.TabIndex = 0;
            this.TempChart.Text = "chart1";
            // 
            // btnFetch
            // 
            this.btnFetch.Location = new System.Drawing.Point(39, 33);
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
            this.btnPrint.Location = new System.Drawing.Point(115, 33);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(50, 21);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // lbChannels
            // 
            this.lbChannels.FormattingEnabled = true;
            this.lbChannels.Location = new System.Drawing.Point(306, 105);
            this.lbChannels.Name = "lbChannels";
            this.lbChannels.Size = new System.Drawing.Size(315, 95);
            this.lbChannels.TabIndex = 5;
            // 
            // frmKilnFiringProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 683);
            this.Controls.Add(this.lbChannels);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnFetch);
            this.Controls.Add(this.TempChart);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmKilnFiringProfile";
            this.Text = "Kiln Firing Profile";
            this.Load += new System.EventHandler(this.frmKilnFiringProfile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TempChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart TempChart;
        private System.Windows.Forms.Button btnFetch;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ListBox lbChannels;
    }
}

