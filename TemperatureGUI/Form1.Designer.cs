namespace TemperatureGUI
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.statusLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tempTxt = new System.Windows.Forms.TextBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.recordChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.resetBtn = new System.Windows.Forms.Button();
            this.fetchTop3 = new System.Windows.Forms.Button();
            this.fetStatusLBL = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.recordChart)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input Temperature: ";
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.ForeColor = System.Drawing.Color.RosyBrown;
            this.statusLbl.Location = new System.Drawing.Point(152, 58);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(0, 13);
            this.statusLbl.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Record:";
            // 
            // tempTxt
            // 
            this.tempTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tempTxt.Location = new System.Drawing.Point(149, 17);
            this.tempTxt.Name = "tempTxt";
            this.tempTxt.Size = new System.Drawing.Size(100, 32);
            this.tempTxt.TabIndex = 3;
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.addBtn.Location = new System.Drawing.Point(266, 18);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(89, 34);
            this.addBtn.TabIndex = 4;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // flowPanel
            // 
            this.flowPanel.AutoScroll = true;
            this.flowPanel.Location = new System.Drawing.Point(109, 79);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Size = new System.Drawing.Size(837, 154);
            this.flowPanel.TabIndex = 5;
            this.flowPanel.WrapContents = false;
            // 
            // recordChart
            // 
            chartArea1.Name = "ChartArea1";
            this.recordChart.ChartAreas.Add(chartArea1);
            this.recordChart.Location = new System.Drawing.Point(46, 239);
            this.recordChart.Name = "recordChart";
            series1.ChartArea = "ChartArea1";
            series1.LabelForeColor = System.Drawing.Color.DarkSeaGreen;
            series1.Name = "Temperature";
            this.recordChart.Series.Add(series1);
            this.recordChart.Size = new System.Drawing.Size(932, 310);
            this.recordChart.TabIndex = 6;
            this.recordChart.Text = "chart1";
            // 
            // resetBtn
            // 
            this.resetBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.resetBtn.Location = new System.Drawing.Point(361, 18);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(88, 34);
            this.resetBtn.TabIndex = 7;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = false;
            this.resetBtn.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // fetchTop3
            // 
            this.fetchTop3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.fetchTop3.Location = new System.Drawing.Point(480, 594);
            this.fetchTop3.Name = "fetchTop3";
            this.fetchTop3.Size = new System.Drawing.Size(88, 34);
            this.fetchTop3.TabIndex = 8;
            this.fetchTop3.Text = "Fetch Top 3";
            this.fetchTop3.UseVisualStyleBackColor = false;
            this.fetchTop3.Click += new System.EventHandler(this.fetchTop3_Click);
            // 
            // fetStatusLBL
            // 
            this.fetStatusLBL.AutoSize = true;
            this.fetStatusLBL.ForeColor = System.Drawing.Color.Red;
            this.fetStatusLBL.Location = new System.Drawing.Point(401, 552);
            this.fetStatusLBL.Name = "fetStatusLBL";
            this.fetStatusLBL.Size = new System.Drawing.Size(0, 13);
            this.fetStatusLBL.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 653);
            this.Controls.Add(this.fetStatusLBL);
            this.Controls.Add(this.fetchTop3);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.recordChart);
            this.Controls.Add(this.flowPanel);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.tempTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teperature Controll";
            this.TransparencyKey = System.Drawing.Color.LightSalmon;
            ((System.ComponentModel.ISupportInitialize)(this.recordChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tempTxt;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.FlowLayoutPanel flowPanel;
        private System.Windows.Forms.DataVisualization.Charting.Chart recordChart;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Button fetchTop3;
        public System.Windows.Forms.Label fetStatusLBL;
    }
}

