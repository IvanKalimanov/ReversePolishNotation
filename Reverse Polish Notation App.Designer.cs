namespace Reverse_Polish_Notation
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
            this.SelectFileButton = new System.Windows.Forms.Button();
            this.InitialExpression = new System.Windows.Forms.TextBox();
            this.RpnExpression = new System.Windows.Forms.TextBox();
            this.NextLineButton = new System.Windows.Forms.Button();
            this.Result = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonForHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SelectFileButton
            // 
            this.SelectFileButton.Location = new System.Drawing.Point(64, 141);
            this.SelectFileButton.Name = "SelectFileButton";
            this.SelectFileButton.Size = new System.Drawing.Size(207, 44);
            this.SelectFileButton.TabIndex = 0;
            this.SelectFileButton.Text = "Select File";
            this.SelectFileButton.UseVisualStyleBackColor = true;
            this.SelectFileButton.Click += new System.EventHandler(this.SelectFileButton_Click);
            // 
            // InitialExpression
            // 
            this.InitialExpression.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InitialExpression.Location = new System.Drawing.Point(358, 107);
            this.InitialExpression.Name = "InitialExpression";
            this.InitialExpression.Size = new System.Drawing.Size(259, 44);
            this.InitialExpression.TabIndex = 1;
            // 
            // RpnExpression
            // 
            this.RpnExpression.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RpnExpression.Location = new System.Drawing.Point(689, 107);
            this.RpnExpression.Name = "RpnExpression";
            this.RpnExpression.ReadOnly = true;
            this.RpnExpression.Size = new System.Drawing.Size(277, 44);
            this.RpnExpression.TabIndex = 2;
            // 
            // NextLineButton
            // 
            this.NextLineButton.Location = new System.Drawing.Point(64, 206);
            this.NextLineButton.Name = "NextLineButton";
            this.NextLineButton.Size = new System.Drawing.Size(207, 43);
            this.NextLineButton.TabIndex = 3;
            this.NextLineButton.Text = "Next line";
            this.NextLineButton.UseVisualStyleBackColor = true;
            this.NextLineButton.Click += new System.EventHandler(this.NextLineButton_Click);
            // 
            // Result
            // 
            this.Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Result.Location = new System.Drawing.Point(610, 206);
            this.Result.Name = "Result";
            this.Result.ReadOnly = true;
            this.Result.Size = new System.Drawing.Size(101, 44);
            this.Result.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(351, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 37);
            this.label1.TabIndex = 5;
            this.label1.Text = "Initial Expression:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(682, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(284, 37);
            this.label2.TabIndex = 6;
            this.label2.Text = "Expression in Rpn:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(603, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 37);
            this.label3.TabIndex = 7;
            this.label3.Text = "Value:";
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(64, 78);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(207, 44);
            this.CalculateButton.TabIndex = 8;
            this.CalculateButton.Text = "Calculate";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(38, 327);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(978, 447);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // buttonForHelp
            // 
            this.buttonForHelp.Location = new System.Drawing.Point(13, 13);
            this.buttonForHelp.Name = "buttonForHelp";
            this.buttonForHelp.Size = new System.Drawing.Size(40, 46);
            this.buttonForHelp.TabIndex = 11;
            this.buttonForHelp.Text = "?";
            this.buttonForHelp.UseVisualStyleBackColor = true;
            this.buttonForHelp.Click += new System.EventHandler(this.ButtonForHelp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 829);
            this.Controls.Add(this.buttonForHelp);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.NextLineButton);
            this.Controls.Add(this.RpnExpression);
            this.Controls.Add(this.InitialExpression);
            this.Controls.Add(this.SelectFileButton);
            this.MaximumSize = new System.Drawing.Size(1080, 900);
            this.MinimumSize = new System.Drawing.Size(1075, 850);
            this.Name = "Form1";
            this.Text = "RPN Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectFileButton;
        public System.Windows.Forms.TextBox InitialExpression;
        private System.Windows.Forms.TextBox RpnExpression;
        private System.Windows.Forms.Button NextLineButton;
        private System.Windows.Forms.TextBox Result;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonForHelp;
    }
}

