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
            this.startSimBtn = new System.Windows.Forms.Button();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.logLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.VariationPercentTrack = new System.Windows.Forms.TrackBar();
            this.MutationRateTrack = new System.Windows.Forms.TrackBar();
            this.PopulationSizeBox = new System.Windows.Forms.TextBox();
            this.MaxGenerationCBox = new System.Windows.Forms.TextBox();
            this.StagnationLimitBox = new System.Windows.Forms.TextBox();
            this.EliteCountBox = new System.Windows.Forms.TextBox();
            this.VariationPercentLable = new System.Windows.Forms.Label();
            this.MutationRateLabel = new System.Windows.Forms.Label();
            this.SelectionAmountTrack = new System.Windows.Forms.TrackBar();
            this.SelectionAmountLabel = new System.Windows.Forms.Label();
            this.MutationAmountBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.VariationPercentTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MutationRateTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectionAmountTrack)).BeginInit();
            this.SuspendLayout();
            // 
            // startSimBtn
            // 
            this.startSimBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startSimBtn.Location = new System.Drawing.Point(266, 393);
            this.startSimBtn.Name = "startSimBtn";
            this.startSimBtn.Size = new System.Drawing.Size(129, 61);
            this.startSimBtn.TabIndex = 0;
            this.startSimBtn.Text = "Start simulation";
            this.startSimBtn.UseVisualStyleBackColor = true;
            this.startSimBtn.Click += new System.EventHandler(this.startSimBtn_Click);
            // 
            // LogTextBox
            // 
            this.LogTextBox.Location = new System.Drawing.Point(12, 25);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.Size = new System.Drawing.Size(236, 429);
            this.LogTextBox.TabIndex = 1;
            // 
            // logLabel
            // 
            this.logLabel.AutoSize = true;
            this.logLabel.Location = new System.Drawing.Point(113, 9);
            this.logLabel.Name = "logLabel";
            this.logLabel.Size = new System.Drawing.Size(25, 13);
            this.logLabel.TabIndex = 2;
            this.logLabel.Text = "Log";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(285, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Population size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Max generation count";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(285, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Selection amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(285, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mutation rate";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(285, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Mutation amount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(285, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Stagnation limit";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(285, 282);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Elite count";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(285, 321);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Variation percent";
            // 
            // VariationPercentTrack
            // 
            this.VariationPercentTrack.Location = new System.Drawing.Point(288, 337);
            this.VariationPercentTrack.Maximum = 100;
            this.VariationPercentTrack.Name = "VariationPercentTrack";
            this.VariationPercentTrack.Size = new System.Drawing.Size(104, 45);
            this.VariationPercentTrack.TabIndex = 11;
            this.VariationPercentTrack.Value = 35;
            this.VariationPercentTrack.ValueChanged += new System.EventHandler(this.VariationPercentTrack_ValueChanged);
            // 
            // MutationRateTrack
            // 
            this.MutationRateTrack.Location = new System.Drawing.Point(287, 208);
            this.MutationRateTrack.Maximum = 100;
            this.MutationRateTrack.Name = "MutationRateTrack";
            this.MutationRateTrack.Size = new System.Drawing.Size(104, 45);
            this.MutationRateTrack.TabIndex = 12;
            this.MutationRateTrack.Value = 20;
            this.MutationRateTrack.ValueChanged += new System.EventHandler(this.MutationRateTrack_ValueChanged);
            // 
            // PopulationSizeBox
            // 
            this.PopulationSizeBox.Location = new System.Drawing.Point(288, 41);
            this.PopulationSizeBox.Name = "PopulationSizeBox";
            this.PopulationSizeBox.Size = new System.Drawing.Size(100, 20);
            this.PopulationSizeBox.TabIndex = 14;
            this.PopulationSizeBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PopulationSizeBox_KeyPress);
            // 
            // MaxGenerationCBox
            // 
            this.MaxGenerationCBox.Location = new System.Drawing.Point(288, 80);
            this.MaxGenerationCBox.Name = "MaxGenerationCBox";
            this.MaxGenerationCBox.Size = new System.Drawing.Size(100, 20);
            this.MaxGenerationCBox.TabIndex = 15;
            this.MaxGenerationCBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MaxGenerationCBox_KeyPress);
            // 
            // StagnationLimitBox
            // 
            this.StagnationLimitBox.Location = new System.Drawing.Point(288, 259);
            this.StagnationLimitBox.Name = "StagnationLimitBox";
            this.StagnationLimitBox.Size = new System.Drawing.Size(100, 20);
            this.StagnationLimitBox.TabIndex = 17;
            this.StagnationLimitBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StagnationLimitBox_KeyPress);
            // 
            // EliteCountBox
            // 
            this.EliteCountBox.Location = new System.Drawing.Point(287, 298);
            this.EliteCountBox.Name = "EliteCountBox";
            this.EliteCountBox.Size = new System.Drawing.Size(100, 20);
            this.EliteCountBox.TabIndex = 18;
            this.EliteCountBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EliteCountBox_KeyPress);
            // 
            // VariationPercentLable
            // 
            this.VariationPercentLable.AutoSize = true;
            this.VariationPercentLable.Location = new System.Drawing.Point(319, 358);
            this.VariationPercentLable.Name = "VariationPercentLable";
            this.VariationPercentLable.Size = new System.Drawing.Size(27, 13);
            this.VariationPercentLable.TabIndex = 19;
            this.VariationPercentLable.Text = "35%";
            // 
            // MutationRateLabel
            // 
            this.MutationRateLabel.AutoSize = true;
            this.MutationRateLabel.Location = new System.Drawing.Point(319, 230);
            this.MutationRateLabel.Name = "MutationRateLabel";
            this.MutationRateLabel.Size = new System.Drawing.Size(27, 13);
            this.MutationRateLabel.TabIndex = 20;
            this.MutationRateLabel.Text = "20%";
            // 
            // SelectionAmountTrack
            // 
            this.SelectionAmountTrack.Location = new System.Drawing.Point(284, 118);
            this.SelectionAmountTrack.Maximum = 100;
            this.SelectionAmountTrack.Name = "SelectionAmountTrack";
            this.SelectionAmountTrack.Size = new System.Drawing.Size(104, 45);
            this.SelectionAmountTrack.TabIndex = 21;
            this.SelectionAmountTrack.Value = 20;
            this.SelectionAmountTrack.ValueChanged += new System.EventHandler(this.SelectionAmountTrack_ValueChanged);
            // 
            // SelectionAmountLabel
            // 
            this.SelectionAmountLabel.AutoSize = true;
            this.SelectionAmountLabel.Location = new System.Drawing.Point(319, 140);
            this.SelectionAmountLabel.Name = "SelectionAmountLabel";
            this.SelectionAmountLabel.Size = new System.Drawing.Size(27, 13);
            this.SelectionAmountLabel.TabIndex = 22;
            this.SelectionAmountLabel.Text = "20%";
            // 
            // MutationAmountBox
            // 
            this.MutationAmountBox.Location = new System.Drawing.Point(288, 169);
            this.MutationAmountBox.Name = "MutationAmountBox";
            this.MutationAmountBox.Size = new System.Drawing.Size(100, 20);
            this.MutationAmountBox.TabIndex = 23;
            this.MutationAmountBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MutationAmountBox_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 461);
            this.Controls.Add(this.MutationAmountBox);
            this.Controls.Add(this.SelectionAmountLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.MutationRateLabel);
            this.Controls.Add(this.VariationPercentLable);
            this.Controls.Add(this.EliteCountBox);
            this.Controls.Add(this.StagnationLimitBox);
            this.Controls.Add(this.MaxGenerationCBox);
            this.Controls.Add(this.PopulationSizeBox);
            this.Controls.Add(this.MutationRateTrack);
            this.Controls.Add(this.VariationPercentTrack);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logLabel);
            this.Controls.Add(this.LogTextBox);
            this.Controls.Add(this.startSimBtn);
            this.Controls.Add(this.SelectionAmountTrack);
            this.Name = "Form1";
            this.Text = "Genetic algo";
            ((System.ComponentModel.ISupportInitialize)(this.VariationPercentTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MutationRateTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectionAmountTrack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

