namespace Win_Forms_GUI
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            startSimBtn = new Button();
            LogTextBox = new TextBox();
            logLabel = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            VariationPercentTrack = new TrackBar();
            MutationRateTrack = new TrackBar();
            PopulationSizeBox = new TextBox();
            MaxGenerationCBox = new TextBox();
            StagnationLimitBox = new TextBox();
            EliteCountBox = new TextBox();
            VariationPercentLable = new Label();
            MutationRateLabel = new Label();
            SelectionAmountTrack = new TrackBar();
            SelectionAmountLabel = new Label();
            MutationAmountBox = new TextBox();
            label9 = new Label();
            label10 = new Label();
            checkBox1 = new CheckBox();
            MatrixSizeBox = new TextBox();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            DataDiapasonMaxBox = new TextBox();
            DataDiapasonMinBox = new TextBox();
            label15 = new Label();
            DataXDiapasonMinBox = new TextBox();
            DataXDiapasonMaxBox = new TextBox();
            label16 = new Label();
            label17 = new Label();
            panel1 = new Panel();
            PathToFileBox = new TextBox();
            label18 = new Label();
            ((System.ComponentModel.ISupportInitialize)VariationPercentTrack).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MutationRateTrack).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SelectionAmountTrack).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // startSimBtn
            // 
            startSimBtn.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            startSimBtn.Location = new Point(331, 453);
            startSimBtn.Margin = new Padding(4, 3, 4, 3);
            startSimBtn.Name = "startSimBtn";
            startSimBtn.Size = new Size(120, 70);
            startSimBtn.TabIndex = 0;
            startSimBtn.Text = "Start simulation";
            startSimBtn.UseVisualStyleBackColor = true;
            startSimBtn.Click += startSimBtn_Click;
            // 
            // LogTextBox
            // 
            LogTextBox.Location = new Point(14, 29);
            LogTextBox.Margin = new Padding(4, 3, 4, 3);
            LogTextBox.Multiline = true;
            LogTextBox.Name = "LogTextBox";
            LogTextBox.ReadOnly = true;
            LogTextBox.ScrollBars = ScrollBars.Vertical;
            LogTextBox.Size = new Size(275, 494);
            LogTextBox.TabIndex = 1;
            // 
            // logLabel
            // 
            logLabel.AutoSize = true;
            logLabel.Font = new Font("Segoe UI", 14F);
            logLabel.Location = new Point(132, 2);
            logLabel.Margin = new Padding(4, 0, 4, 0);
            logLabel.Name = "logLabel";
            logLabel.Size = new Size(43, 25);
            logLabel.TabIndex = 2;
            logLabel.Text = "Log";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(332, 29);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 3;
            label1.Text = "Population size";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(332, 74);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(124, 15);
            label2.TabIndex = 4;
            label2.Text = "Max generation count";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(332, 119);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(100, 15);
            label3.TabIndex = 5;
            label3.Text = "Selection amount";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(332, 222);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(79, 15);
            label4.TabIndex = 6;
            label4.Text = "Mutation rate";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(332, 177);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(101, 15);
            label5.TabIndex = 7;
            label5.Text = "Mutation amount";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(332, 280);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(91, 15);
            label6.TabIndex = 8;
            label6.Text = "Stagnation limit";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(332, 325);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(63, 15);
            label7.TabIndex = 9;
            label7.Text = "Elite count";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(332, 370);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(96, 15);
            label8.TabIndex = 10;
            label8.Text = "Variation percent";
            // 
            // VariationPercentTrack
            // 
            VariationPercentTrack.Location = new Point(336, 389);
            VariationPercentTrack.Margin = new Padding(4, 3, 4, 3);
            VariationPercentTrack.Maximum = 99;
            VariationPercentTrack.Minimum = 1;
            VariationPercentTrack.Name = "VariationPercentTrack";
            VariationPercentTrack.Size = new Size(121, 45);
            VariationPercentTrack.TabIndex = 11;
            VariationPercentTrack.Value = 35;
            VariationPercentTrack.ValueChanged += VariationPercentTrack_ValueChanged;
            // 
            // MutationRateTrack
            // 
            MutationRateTrack.Location = new Point(335, 240);
            MutationRateTrack.Margin = new Padding(4, 3, 4, 3);
            MutationRateTrack.Maximum = 99;
            MutationRateTrack.Minimum = 1;
            MutationRateTrack.Name = "MutationRateTrack";
            MutationRateTrack.Size = new Size(121, 45);
            MutationRateTrack.TabIndex = 12;
            MutationRateTrack.Value = 20;
            MutationRateTrack.ValueChanged += MutationRateTrack_ValueChanged;
            // 
            // PopulationSizeBox
            // 
            PopulationSizeBox.Location = new Point(336, 47);
            PopulationSizeBox.Margin = new Padding(4, 3, 4, 3);
            PopulationSizeBox.Name = "PopulationSizeBox";
            PopulationSizeBox.Size = new Size(116, 23);
            PopulationSizeBox.TabIndex = 14;
            PopulationSizeBox.Text = "1000";
            PopulationSizeBox.KeyPress += PopulationSizeBox_KeyPress;
            // 
            // MaxGenerationCBox
            // 
            MaxGenerationCBox.Location = new Point(336, 92);
            MaxGenerationCBox.Margin = new Padding(4, 3, 4, 3);
            MaxGenerationCBox.Name = "MaxGenerationCBox";
            MaxGenerationCBox.Size = new Size(116, 23);
            MaxGenerationCBox.TabIndex = 15;
            MaxGenerationCBox.Text = "10000";
            MaxGenerationCBox.KeyPress += MaxGenerationCBox_KeyPress;
            // 
            // StagnationLimitBox
            // 
            StagnationLimitBox.Location = new Point(336, 299);
            StagnationLimitBox.Margin = new Padding(4, 3, 4, 3);
            StagnationLimitBox.Name = "StagnationLimitBox";
            StagnationLimitBox.Size = new Size(116, 23);
            StagnationLimitBox.TabIndex = 17;
            StagnationLimitBox.Text = "300";
            StagnationLimitBox.KeyPress += StagnationLimitBox_KeyPress;
            // 
            // EliteCountBox
            // 
            EliteCountBox.Location = new Point(335, 344);
            EliteCountBox.Margin = new Padding(4, 3, 4, 3);
            EliteCountBox.Name = "EliteCountBox";
            EliteCountBox.Size = new Size(116, 23);
            EliteCountBox.TabIndex = 18;
            EliteCountBox.Text = "5";
            EliteCountBox.KeyPress += EliteCountBox_KeyPress;
            // 
            // VariationPercentLable
            // 
            VariationPercentLable.AutoSize = true;
            VariationPercentLable.Location = new Point(372, 417);
            VariationPercentLable.Margin = new Padding(4, 0, 4, 0);
            VariationPercentLable.Name = "VariationPercentLable";
            VariationPercentLable.Size = new Size(29, 15);
            VariationPercentLable.TabIndex = 19;
            VariationPercentLable.Text = "35%";
            // 
            // MutationRateLabel
            // 
            MutationRateLabel.AutoSize = true;
            MutationRateLabel.Location = new Point(372, 265);
            MutationRateLabel.Margin = new Padding(4, 0, 4, 0);
            MutationRateLabel.Name = "MutationRateLabel";
            MutationRateLabel.Size = new Size(29, 15);
            MutationRateLabel.TabIndex = 20;
            MutationRateLabel.Text = "20%";
            // 
            // SelectionAmountTrack
            // 
            SelectionAmountTrack.Location = new Point(331, 136);
            SelectionAmountTrack.Margin = new Padding(4, 3, 4, 3);
            SelectionAmountTrack.Maximum = 99;
            SelectionAmountTrack.Minimum = 1;
            SelectionAmountTrack.Name = "SelectionAmountTrack";
            SelectionAmountTrack.Size = new Size(121, 45);
            SelectionAmountTrack.TabIndex = 21;
            SelectionAmountTrack.Value = 20;
            SelectionAmountTrack.ValueChanged += SelectionAmountTrack_ValueChanged;
            // 
            // SelectionAmountLabel
            // 
            SelectionAmountLabel.AutoSize = true;
            SelectionAmountLabel.Location = new Point(372, 162);
            SelectionAmountLabel.Margin = new Padding(4, 0, 4, 0);
            SelectionAmountLabel.Name = "SelectionAmountLabel";
            SelectionAmountLabel.Size = new Size(29, 15);
            SelectionAmountLabel.TabIndex = 22;
            SelectionAmountLabel.Text = "20%";
            // 
            // MutationAmountBox
            // 
            MutationAmountBox.Location = new Point(336, 195);
            MutationAmountBox.Margin = new Padding(4, 3, 4, 3);
            MutationAmountBox.Name = "MutationAmountBox";
            MutationAmountBox.Size = new Size(116, 23);
            MutationAmountBox.TabIndex = 23;
            MutationAmountBox.Text = "100";
            MutationAmountBox.KeyPress += MutationAmountBox_KeyPress;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14F);
            label9.Location = new Point(578, 4);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(51, 25);
            label9.TabIndex = 24;
            label9.Text = "Data";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 14F);
            label10.Location = new Point(336, 4);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(106, 25);
            label10.TabIndex = 25;
            label10.Text = "Parameters";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(530, 32);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(149, 19);
            checkBox1.TabIndex = 26;
            checkBox1.Text = "Generate data\\from file";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // MatrixSizeBox
            // 
            MatrixSizeBox.Location = new Point(530, 71);
            MatrixSizeBox.Margin = new Padding(4, 3, 4, 3);
            MatrixSizeBox.Name = "MatrixSizeBox";
            MatrixSizeBox.Size = new Size(116, 23);
            MatrixSizeBox.TabIndex = 27;
            MatrixSizeBox.Text = "10";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(530, 55);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(63, 15);
            label11.TabIndex = 28;
            label11.Text = "Matrix size";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(530, 100);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(82, 15);
            label12.TabIndex = 29;
            label12.Text = "Data diapason";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(530, 119);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(30, 15);
            label13.TabIndex = 30;
            label13.Text = "Max";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(530, 166);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(28, 15);
            label14.TabIndex = 31;
            label14.Text = "Min";
            // 
            // DataDiapasonMaxBox
            // 
            DataDiapasonMaxBox.Location = new Point(530, 136);
            DataDiapasonMaxBox.Margin = new Padding(4, 3, 4, 3);
            DataDiapasonMaxBox.Name = "DataDiapasonMaxBox";
            DataDiapasonMaxBox.Size = new Size(116, 23);
            DataDiapasonMaxBox.TabIndex = 32;
            DataDiapasonMaxBox.Text = "100";
            // 
            // DataDiapasonMinBox
            // 
            DataDiapasonMinBox.Location = new Point(530, 184);
            DataDiapasonMinBox.Margin = new Padding(4, 3, 4, 3);
            DataDiapasonMinBox.Name = "DataDiapasonMinBox";
            DataDiapasonMinBox.Size = new Size(116, 23);
            DataDiapasonMinBox.TabIndex = 33;
            DataDiapasonMinBox.Text = "-100";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(530, 210);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(92, 15);
            label15.TabIndex = 35;
            label15.Text = "Data X diapason";
            // 
            // DataXDiapasonMinBox
            // 
            DataXDiapasonMinBox.Location = new Point(530, 294);
            DataXDiapasonMinBox.Margin = new Padding(4, 3, 4, 3);
            DataXDiapasonMinBox.Name = "DataXDiapasonMinBox";
            DataXDiapasonMinBox.Size = new Size(116, 23);
            DataXDiapasonMinBox.TabIndex = 39;
            DataXDiapasonMinBox.Text = "-100";
            // 
            // DataXDiapasonMaxBox
            // 
            DataXDiapasonMaxBox.Location = new Point(530, 246);
            DataXDiapasonMaxBox.Margin = new Padding(4, 3, 4, 3);
            DataXDiapasonMaxBox.Name = "DataXDiapasonMaxBox";
            DataXDiapasonMaxBox.Size = new Size(116, 23);
            DataXDiapasonMaxBox.TabIndex = 38;
            DataXDiapasonMaxBox.Text = "100";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(530, 276);
            label16.Margin = new Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new Size(28, 15);
            label16.TabIndex = 37;
            label16.Text = "Min";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(530, 229);
            label17.Margin = new Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new Size(30, 15);
            label17.TabIndex = 36;
            label17.Text = "Max";
            // 
            // panel1
            // 
            panel1.Controls.Add(PathToFileBox);
            panel1.Controls.Add(label18);
            panel1.Location = new Point(517, 55);
            panel1.Name = "panel1";
            panel1.Size = new Size(162, 312);
            panel1.TabIndex = 40;
            panel1.Visible = false;
            // 
            // PathToFileBox
            // 
            PathToFileBox.Location = new Point(13, 19);
            PathToFileBox.Margin = new Padding(4, 3, 4, 3);
            PathToFileBox.Name = "PathToFileBox";
            PathToFileBox.Size = new Size(116, 23);
            PathToFileBox.TabIndex = 42;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(10, 0);
            label18.Margin = new Padding(4, 0, 4, 0);
            label18.Name = "label18";
            label18.Size = new Size(64, 15);
            label18.TabIndex = 41;
            label18.Text = "Path to file";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(703, 532);
            Controls.Add(panel1);
            Controls.Add(DataXDiapasonMinBox);
            Controls.Add(DataXDiapasonMaxBox);
            Controls.Add(label16);
            Controls.Add(label17);
            Controls.Add(label15);
            Controls.Add(DataDiapasonMinBox);
            Controls.Add(DataDiapasonMaxBox);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(MatrixSizeBox);
            Controls.Add(checkBox1);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(MutationAmountBox);
            Controls.Add(SelectionAmountLabel);
            Controls.Add(label6);
            Controls.Add(MutationRateLabel);
            Controls.Add(VariationPercentLable);
            Controls.Add(EliteCountBox);
            Controls.Add(StagnationLimitBox);
            Controls.Add(MaxGenerationCBox);
            Controls.Add(PopulationSizeBox);
            Controls.Add(MutationRateTrack);
            Controls.Add(VariationPercentTrack);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(logLabel);
            Controls.Add(LogTextBox);
            Controls.Add(startSimBtn);
            Controls.Add(SelectionAmountTrack);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Genetic algo";
            FormClosed += Form1_FormClosed;
            ((System.ComponentModel.ISupportInitialize)VariationPercentTrack).EndInit();
            ((System.ComponentModel.ISupportInitialize)MutationRateTrack).EndInit();
            ((System.ComponentModel.ISupportInitialize)SelectionAmountTrack).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button startSimBtn;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.Label logLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar VariationPercentTrack;
        private System.Windows.Forms.TrackBar MutationRateTrack;
        private System.Windows.Forms.TextBox PopulationSizeBox;
        private System.Windows.Forms.TextBox MaxGenerationCBox;
        private System.Windows.Forms.TextBox StagnationLimitBox;
        private System.Windows.Forms.TextBox EliteCountBox;
        private System.Windows.Forms.Label VariationPercentLable;
        private System.Windows.Forms.Label MutationRateLabel;
        private System.Windows.Forms.TrackBar SelectionAmountTrack;
        private System.Windows.Forms.Label SelectionAmountLabel;
        private System.Windows.Forms.TextBox MutationAmountBox;
        private Label label9;
        private Label label10;
        private CheckBox checkBox1;
        private TextBox MatrixSizeBox;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private TextBox DataDiapasonMaxBox;
        private TextBox DataDiapasonMinBox;
        private Label label15;
        private TextBox DataXDiapasonMinBox;
        private TextBox DataXDiapasonMaxBox;
        private Label label16;
        private Label label17;
        private Panel panel1;
        private TextBox PathToFileBox;
        private Label label18;
    }
}

