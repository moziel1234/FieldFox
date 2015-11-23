namespace FieldFox_1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.Start_Freq_textBox = new System.Windows.Forms.TextBox();
            this.End_Freq_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Points_num_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.IF_bandW_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Send_param_button = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Log_textBox = new System.Windows.Forms.TextBox();
            this.Avg_num_textBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Point_radioButton = new System.Windows.Forms.RadioButton();
            this.Sweep_radioButton = new System.Windows.Forms.RadioButton();
            this.Folder_name_textBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Measure_button = new System.Windows.Forms.Button();
            this.Meas_time_textBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numOfIterations_textBox = new System.Windows.Forms.TextBox();
            this.stopMeasByIterNum_radioButton = new System.Windows.Forms.RadioButton();
            this.stopMeasByTime_radioButton = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.betweenMeasDelay_textBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.freqCenter_textBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.freqSpan_textBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.startStopFreq_checkBox = new System.Windows.Forms.CheckBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_pulseMeter = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start Freq";
            // 
            // Start_Freq_textBox
            // 
            this.Start_Freq_textBox.Location = new System.Drawing.Point(96, 28);
            this.Start_Freq_textBox.Name = "Start_Freq_textBox";
            this.Start_Freq_textBox.Size = new System.Drawing.Size(99, 20);
            this.Start_Freq_textBox.TabIndex = 1;
            // 
            // End_Freq_textBox
            // 
            this.End_Freq_textBox.Location = new System.Drawing.Point(96, 63);
            this.End_Freq_textBox.Name = "End_Freq_textBox";
            this.End_Freq_textBox.Size = new System.Drawing.Size(99, 20);
            this.End_Freq_textBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "End Freq";
            // 
            // Points_num_textBox
            // 
            this.Points_num_textBox.Location = new System.Drawing.Point(96, 174);
            this.Points_num_textBox.Name = "Points_num_textBox";
            this.Points_num_textBox.Size = new System.Drawing.Size(99, 20);
            this.Points_num_textBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Points Num";
            // 
            // IF_bandW_textBox
            // 
            this.IF_bandW_textBox.Location = new System.Drawing.Point(96, 209);
            this.IF_bandW_textBox.Name = "IF_bandW_textBox";
            this.IF_bandW_textBox.Size = new System.Drawing.Size(99, 20);
            this.IF_bandW_textBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "IF bandW";
            // 
            // Send_param_button
            // 
            this.Send_param_button.Location = new System.Drawing.Point(40, 321);
            this.Send_param_button.Name = "Send_param_button";
            this.Send_param_button.Size = new System.Drawing.Size(75, 23);
            this.Send_param_button.TabIndex = 8;
            this.Send_param_button.Text = "Send Param";
            this.Send_param_button.UseVisualStyleBackColor = true;
            this.Send_param_button.Click += new System.EventHandler(this.Send_param_button_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(201, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "MHz";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(201, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "MHz";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(201, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Hz";
            // 
            // Log_textBox
            // 
            this.Log_textBox.Location = new System.Drawing.Point(250, 28);
            this.Log_textBox.Multiline = true;
            this.Log_textBox.Name = "Log_textBox";
            this.Log_textBox.Size = new System.Drawing.Size(403, 190);
            this.Log_textBox.TabIndex = 12;
            // 
            // Avg_num_textBox
            // 
            this.Avg_num_textBox.Location = new System.Drawing.Point(96, 244);
            this.Avg_num_textBox.Name = "Avg_num_textBox";
            this.Avg_num_textBox.Size = new System.Drawing.Size(99, 20);
            this.Avg_num_textBox.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 246);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Avg Num";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Point_radioButton);
            this.groupBox1.Controls.Add(this.Sweep_radioButton);
            this.groupBox1.Location = new System.Drawing.Point(40, 270);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 45);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Avg Mode";
            // 
            // Point_radioButton
            // 
            this.Point_radioButton.AutoSize = true;
            this.Point_radioButton.Location = new System.Drawing.Point(97, 17);
            this.Point_radioButton.Name = "Point_radioButton";
            this.Point_radioButton.Size = new System.Drawing.Size(49, 17);
            this.Point_radioButton.TabIndex = 1;
            this.Point_radioButton.TabStop = true;
            this.Point_radioButton.Text = "Point";
            this.Point_radioButton.UseVisualStyleBackColor = true;
            // 
            // Sweep_radioButton
            // 
            this.Sweep_radioButton.AutoSize = true;
            this.Sweep_radioButton.Location = new System.Drawing.Point(17, 17);
            this.Sweep_radioButton.Name = "Sweep_radioButton";
            this.Sweep_radioButton.Size = new System.Drawing.Size(58, 17);
            this.Sweep_radioButton.TabIndex = 0;
            this.Sweep_radioButton.TabStop = true;
            this.Sweep_radioButton.Text = "Sweep";
            this.Sweep_radioButton.UseVisualStyleBackColor = true;
            // 
            // Folder_name_textBox
            // 
            this.Folder_name_textBox.Location = new System.Drawing.Point(308, 234);
            this.Folder_name_textBox.Name = "Folder_name_textBox";
            this.Folder_name_textBox.Size = new System.Drawing.Size(345, 20);
            this.Folder_name_textBox.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(249, 236);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Test name";
            // 
            // Measure_button
            // 
            this.Measure_button.Location = new System.Drawing.Point(578, 295);
            this.Measure_button.Name = "Measure_button";
            this.Measure_button.Size = new System.Drawing.Size(75, 23);
            this.Measure_button.TabIndex = 19;
            this.Measure_button.Text = "Measure";
            this.Measure_button.UseVisualStyleBackColor = true;
            this.Measure_button.Click += new System.EventHandler(this.Measure_button_Click);
            // 
            // Meas_time_textBox
            // 
            this.Meas_time_textBox.Location = new System.Drawing.Point(69, 22);
            this.Meas_time_textBox.Name = "Meas_time_textBox";
            this.Meas_time_textBox.Size = new System.Drawing.Size(46, 20);
            this.Meas_time_textBox.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(69, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 13);
            this.label10.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(117, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Sec";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numOfIterations_textBox);
            this.groupBox2.Controls.Add(this.stopMeasByIterNum_radioButton);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.stopMeasByTime_radioButton);
            this.groupBox2.Controls.Add(this.Meas_time_textBox);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(259, 295);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(286, 72);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Measurment options";
            // 
            // numOfIterations_textBox
            // 
            this.numOfIterations_textBox.Location = new System.Drawing.Point(89, 45);
            this.numOfIterations_textBox.Name = "numOfIterations_textBox";
            this.numOfIterations_textBox.Size = new System.Drawing.Size(46, 20);
            this.numOfIterations_textBox.TabIndex = 23;
            // 
            // stopMeasByIterNum_radioButton
            // 
            this.stopMeasByIterNum_radioButton.AutoSize = true;
            this.stopMeasByIterNum_radioButton.Location = new System.Drawing.Point(15, 45);
            this.stopMeasByIterNum_radioButton.Name = "stopMeasByIterNum_radioButton";
            this.stopMeasByIterNum_radioButton.Size = new System.Drawing.Size(68, 17);
            this.stopMeasByIterNum_radioButton.TabIndex = 1;
            this.stopMeasByIterNum_radioButton.TabStop = true;
            this.stopMeasByIterNum_radioButton.Text = "Iterations";
            this.stopMeasByIterNum_radioButton.UseVisualStyleBackColor = true;
            // 
            // stopMeasByTime_radioButton
            // 
            this.stopMeasByTime_radioButton.AutoSize = true;
            this.stopMeasByTime_radioButton.Location = new System.Drawing.Point(15, 22);
            this.stopMeasByTime_radioButton.Name = "stopMeasByTime_radioButton";
            this.stopMeasByTime_radioButton.Size = new System.Drawing.Size(48, 17);
            this.stopMeasByTime_radioButton.TabIndex = 0;
            this.stopMeasByTime_radioButton.TabStop = true;
            this.stopMeasByTime_radioButton.Text = "Time";
            this.stopMeasByTime_radioButton.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(256, 268);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Delay";
            // 
            // betweenMeasDelay_textBox
            // 
            this.betweenMeasDelay_textBox.Location = new System.Drawing.Point(296, 267);
            this.betweenMeasDelay_textBox.Name = "betweenMeasDelay_textBox";
            this.betweenMeasDelay_textBox.Size = new System.Drawing.Size(60, 20);
            this.betweenMeasDelay_textBox.TabIndex = 25;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(362, 270);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = "ms";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(201, 101);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "MHz";
            // 
            // freqCenter_textBox
            // 
            this.freqCenter_textBox.Location = new System.Drawing.Point(96, 98);
            this.freqCenter_textBox.Name = "freqCenter_textBox";
            this.freqCenter_textBox.Size = new System.Drawing.Size(99, 20);
            this.freqCenter_textBox.TabIndex = 28;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(37, 100);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 13);
            this.label15.TabIndex = 27;
            this.label15.Text = "Freq Center";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(201, 137);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 13);
            this.label16.TabIndex = 32;
            this.label16.Text = "MHz";
            // 
            // freqSpan_textBox
            // 
            this.freqSpan_textBox.Location = new System.Drawing.Point(96, 134);
            this.freqSpan_textBox.Name = "freqSpan_textBox";
            this.freqSpan_textBox.Size = new System.Drawing.Size(99, 20);
            this.freqSpan_textBox.TabIndex = 31;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(37, 136);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 13);
            this.label17.TabIndex = 30;
            this.label17.Text = "Freq Span";
            // 
            // startStopFreq_checkBox
            // 
            this.startStopFreq_checkBox.AutoSize = true;
            this.startStopFreq_checkBox.Location = new System.Drawing.Point(19, 30);
            this.startStopFreq_checkBox.Name = "startStopFreq_checkBox";
            this.startStopFreq_checkBox.Size = new System.Drawing.Size(15, 14);
            this.startStopFreq_checkBox.TabIndex = 33;
            this.startStopFreq_checkBox.UseVisualStyleBackColor = true;
            this.startStopFreq_checkBox.CheckedChanged += new System.EventHandler(this.startStopFreq_checkBox_CheckedChanged);
            // 
            // chart1
            // 
            chartArea1.AxisX.LabelStyle.Enabled = false;
            chartArea1.AxisY.LabelStyle.Enabled = false;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(691, 40);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(250, 177);
            this.chart1.TabIndex = 34;
            this.chart1.Text = "chart1";
            // 
            // button_pulseMeter
            // 
            this.button_pulseMeter.Location = new System.Drawing.Point(692, 240);
            this.button_pulseMeter.Name = "button_pulseMeter";
            this.button_pulseMeter.Size = new System.Drawing.Size(78, 23);
            this.button_pulseMeter.TabIndex = 35;
            this.button_pulseMeter.Text = "Start ";
            this.button_pulseMeter.UseVisualStyleBackColor = true;
            this.button_pulseMeter.Click += new System.EventHandler(this.button_pulseMeter_Click_1);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // timer2
            // 
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 494);
            this.Controls.Add(this.button_pulseMeter);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.startStopFreq_checkBox);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.freqSpan_textBox);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.freqCenter_textBox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.betweenMeasDelay_textBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Measure_button);
            this.Controls.Add(this.Folder_name_textBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Avg_num_textBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Log_textBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Send_param_button);
            this.Controls.Add(this.IF_bandW_textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Points_num_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.End_Freq_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Start_Freq_textBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Start_Freq_textBox;
        private System.Windows.Forms.TextBox End_Freq_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Points_num_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox IF_bandW_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Send_param_button;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Log_textBox;
        private System.Windows.Forms.TextBox Avg_num_textBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton Point_radioButton;
        private System.Windows.Forms.RadioButton Sweep_radioButton;
        private System.Windows.Forms.TextBox Folder_name_textBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Measure_button;
        private System.Windows.Forms.TextBox Meas_time_textBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton stopMeasByIterNum_radioButton;
        private System.Windows.Forms.RadioButton stopMeasByTime_radioButton;
        private System.Windows.Forms.TextBox numOfIterations_textBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox betweenMeasDelay_textBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox freqCenter_textBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox freqSpan_textBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox startStopFreq_checkBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button_pulseMeter;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}

