
namespace Gomoku
{
    partial class RulesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RulesForm));
            this.BNext = new System.Windows.Forms.Button();
            this.ExitMainButton = new System.Windows.Forms.Button();
            this.LNameRules = new System.Windows.Forms.Label();
            this.BBackRules = new System.Windows.Forms.Button();
            this.LFirstRule = new System.Windows.Forms.Label();
            this.LSecondRule = new System.Windows.Forms.Label();
            this.PBRules = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PBRules)).BeginInit();
            this.SuspendLayout();
            // 
            // BNext
            // 
            this.BNext.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BNext.Image = ((System.Drawing.Image)(resources.GetObject("BNext.Image")));
            this.BNext.Location = new System.Drawing.Point(662, 366);
            this.BNext.Name = "BNext";
            this.BNext.Size = new System.Drawing.Size(79, 57);
            this.BNext.TabIndex = 0;
            this.BNext.UseVisualStyleBackColor = true;
            this.BNext.Click += new System.EventHandler(this.BNext_Click);
            // 
            // ExitMainButton
            // 
            this.ExitMainButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ExitMainButton.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ExitMainButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitMainButton.Image = ((System.Drawing.Image)(resources.GetObject("ExitMainButton.Image")));
            this.ExitMainButton.Location = new System.Drawing.Point(375, 366);
            this.ExitMainButton.Name = "ExitMainButton";
            this.ExitMainButton.Size = new System.Drawing.Size(62, 57);
            this.ExitMainButton.TabIndex = 7;
            this.ExitMainButton.UseVisualStyleBackColor = false;
            // 
            // LNameRules
            // 
            this.LNameRules.AutoSize = true;
            this.LNameRules.Font = new System.Drawing.Font("Segoe UI Symbol", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNameRules.Location = new System.Drawing.Point(242, 21);
            this.LNameRules.Name = "LNameRules";
            this.LNameRules.Size = new System.Drawing.Size(111, 45);
            this.LNameRules.TabIndex = 8;
            this.LNameRules.Text = "label1";
            // 
            // BBackRules
            // 
            this.BBackRules.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBackRules.Image = ((System.Drawing.Image)(resources.GetObject("BBackRules.Image")));
            this.BBackRules.Location = new System.Drawing.Point(80, 366);
            this.BBackRules.Name = "BBackRules";
            this.BBackRules.Size = new System.Drawing.Size(79, 57);
            this.BBackRules.TabIndex = 9;
            this.BBackRules.UseVisualStyleBackColor = true;
            this.BBackRules.Visible = false;
            this.BBackRules.Click += new System.EventHandler(this.BBackRules_Click);
            // 
            // LFirstRule
            // 
            this.LFirstRule.AutoSize = true;
            this.LFirstRule.Font = new System.Drawing.Font("Segoe UI Symbol", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFirstRule.Location = new System.Drawing.Point(94, 121);
            this.LFirstRule.Name = "LFirstRule";
            this.LFirstRule.Size = new System.Drawing.Size(96, 37);
            this.LFirstRule.TabIndex = 10;
            this.LFirstRule.Text = "label1";
            // 
            // LSecondRule
            // 
            this.LSecondRule.AutoSize = true;
            this.LSecondRule.Font = new System.Drawing.Font("Segoe UI Symbol", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LSecondRule.Location = new System.Drawing.Point(94, 245);
            this.LSecondRule.Name = "LSecondRule";
            this.LSecondRule.Size = new System.Drawing.Size(96, 37);
            this.LSecondRule.TabIndex = 11;
            this.LSecondRule.Text = "label1";
            // 
            // PBRules
            // 
            this.PBRules.Location = new System.Drawing.Point(509, 121);
            this.PBRules.Name = "PBRules";
            this.PBRules.Size = new System.Drawing.Size(232, 199);
            this.PBRules.TabIndex = 12;
            this.PBRules.TabStop = false;
            // 
            // RulesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PBRules);
            this.Controls.Add(this.LSecondRule);
            this.Controls.Add(this.LFirstRule);
            this.Controls.Add(this.BBackRules);
            this.Controls.Add(this.LNameRules);
            this.Controls.Add(this.ExitMainButton);
            this.Controls.Add(this.BNext);
            this.Name = "RulesForm";
            this.Text = "Rules";
            this.Load += new System.EventHandler(this.Rules_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PBRules)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BNext;
        private System.Windows.Forms.Button ExitMainButton;
        private System.Windows.Forms.Label LNameRules;
        private System.Windows.Forms.Button BBackRules;
        private System.Windows.Forms.Label LFirstRule;
        private System.Windows.Forms.Label LSecondRule;
        private System.Windows.Forms.PictureBox PBRules;
    }
}