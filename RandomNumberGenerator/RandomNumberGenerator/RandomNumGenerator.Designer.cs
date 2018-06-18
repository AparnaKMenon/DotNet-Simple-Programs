using System;
using System.Windows.Forms;

namespace RandomNumberGenerator
{
    partial class RandomNumGeneratorUI
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
            this.txtBoxMaxVal = new System.Windows.Forms.TextBox();
            this.txtBoxMinVal = new System.Windows.Forms.TextBox();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtBoxResult = new System.Windows.Forms.TextBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBoxMaxVal
            // 
            this.txtBoxMaxVal.Location = new System.Drawing.Point(160, 55);
            this.txtBoxMaxVal.Name = "txtBoxMaxVal";
            this.txtBoxMaxVal.Size = new System.Drawing.Size(120, 26);
            this.txtBoxMaxVal.TabIndex = 1;
            // 
            // txtBoxMinVal
            // 
            this.txtBoxMinVal.Location = new System.Drawing.Point(19, 55);
            this.txtBoxMinVal.Name = "txtBoxMinVal";
            this.txtBoxMinVal.Size = new System.Drawing.Size(120, 26);
            this.txtBoxMinVal.TabIndex = 0;
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(55, 27);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(34, 20);
            this.lblMin.TabIndex = 0;
            this.lblMin.Text = "Min";
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(204, 27);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(38, 20);
            this.lblMax.TabIndex = 0;
            this.lblMax.Text = "Max";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(95, 133);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(110, 34);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtBoxResult
            // 
            this.txtBoxResult.Location = new System.Drawing.Point(90, 211);
            this.txtBoxResult.Name = "txtBoxResult";
            this.txtBoxResult.Size = new System.Drawing.Size(120, 26);
            this.txtBoxResult.TabIndex = 3;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.btnGenerate);
            this.groupBox.Controls.Add(this.lblMax);
            this.groupBox.Controls.Add(this.lblMin);
            this.groupBox.Controls.Add(this.txtBoxResult);
            this.groupBox.Controls.Add(this.txtBoxMinVal);
            this.groupBox.Controls.Add(this.txtBoxMaxVal);
            this.groupBox.Location = new System.Drawing.Point(12, 12);
            this.groupBox.MaximumSize = new System.Drawing.Size(300, 300);
            this.groupBox.MinimumSize = new System.Drawing.Size(300, 300);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(300, 300);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            // 
            // RandomNumGeneratorUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 325);
            this.Controls.Add(this.groupBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RandomNumGeneratorUI";
            this.Text = "RandomNumberGenerator";
            this.TopMost = true;
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxMaxVal;
        private System.Windows.Forms.TextBox txtBoxMinVal;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txtBoxResult;
        private System.Windows.Forms.GroupBox groupBox;
    }
}

