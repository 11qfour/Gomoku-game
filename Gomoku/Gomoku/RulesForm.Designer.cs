
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RulesForm));
            this.BNext = new System.Windows.Forms.Button();
            this.ExitMainButton = new System.Windows.Forms.Button();
            this.LNameRules = new System.Windows.Forms.Label();
            this.BBackRules = new System.Windows.Forms.Button();
            this.LFirstRule = new System.Windows.Forms.Label();
            this.LSecondRule = new System.Windows.Forms.Label();
            this.PB2Rules = new System.Windows.Forms.PictureBox();
            this.PB1Rules = new System.Windows.Forms.PictureBox();
            this.LUnderPic1Rules = new System.Windows.Forms.Label();
            this.LUnderPic2Rules = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PB2Rules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB1Rules)).BeginInit();
            this.SuspendLayout();
            // 
            // BNext
            // 
            this.BNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BNext.BackColor = System.Drawing.Color.SandyBrown;
            this.BNext.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BNext.Image = ((System.Drawing.Image)(resources.GetObject("BNext.Image")));
            this.BNext.Location = new System.Drawing.Point(1594, 899);
            this.BNext.Name = "BNext";
            this.BNext.Size = new System.Drawing.Size(79, 57);
            this.BNext.TabIndex = 0;
            this.BNext.UseVisualStyleBackColor = false;
            this.BNext.Click += new System.EventHandler(this.BNext_Click);
            // 
            // ExitMainButton
            // 
            this.ExitMainButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ExitMainButton.BackColor = System.Drawing.Color.Chocolate;
            this.ExitMainButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitMainButton.Image = ((System.Drawing.Image)(resources.GetObject("ExitMainButton.Image")));
            this.ExitMainButton.Location = new System.Drawing.Point(946, 899);
            this.ExitMainButton.Name = "ExitMainButton";
            this.ExitMainButton.Size = new System.Drawing.Size(62, 57);
            this.ExitMainButton.TabIndex = 7;
            this.ExitMainButton.UseVisualStyleBackColor = false;
            this.ExitMainButton.Click += new System.EventHandler(this.ExitMainButton_Click);
            // 
            // LNameRules
            // 
            this.LNameRules.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LNameRules.AutoSize = true;
            this.LNameRules.Font = new System.Drawing.Font("Segoe UI Symbol", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNameRules.Location = new System.Drawing.Point(801, 9);
            this.LNameRules.Name = "LNameRules";
            this.LNameRules.Size = new System.Drawing.Size(161, 65);
            this.LNameRules.TabIndex = 8;
            this.LNameRules.Text = "label1";
            // 
            // BBackRules
            // 
            this.BBackRules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BBackRules.BackColor = System.Drawing.Color.SandyBrown;
            this.BBackRules.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBackRules.Image = ((System.Drawing.Image)(resources.GetObject("BBackRules.Image")));
            this.BBackRules.Location = new System.Drawing.Point(224, 899);
            this.BBackRules.Name = "BBackRules";
            this.BBackRules.Size = new System.Drawing.Size(79, 57);
            this.BBackRules.TabIndex = 9;
            this.BBackRules.UseVisualStyleBackColor = false;
            this.BBackRules.Visible = false;
            this.BBackRules.Click += new System.EventHandler(this.BBackRules_Click);
            // 
            // LFirstRule
            // 
            this.LFirstRule.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LFirstRule.AutoSize = true;
            this.LFirstRule.Font = new System.Drawing.Font("Segoe UI Symbol", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFirstRule.Location = new System.Drawing.Point(73, 90);
            this.LFirstRule.Name = "LFirstRule";
            this.LFirstRule.Size = new System.Drawing.Size(111, 45);
            this.LFirstRule.TabIndex = 10;
            this.LFirstRule.Text = "label1";
            // 
            // LSecondRule
            // 
            this.LSecondRule.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LSecondRule.AutoSize = true;
            this.LSecondRule.Font = new System.Drawing.Font("Segoe UI Symbol", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LSecondRule.Location = new System.Drawing.Point(73, 482);
            this.LSecondRule.Name = "LSecondRule";
            this.LSecondRule.Size = new System.Drawing.Size(111, 45);
            this.LSecondRule.TabIndex = 11;
            this.LSecondRule.Text = "label1";
            // 
            // PB2Rules
            // 
            this.PB2Rules.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PB2Rules.Location = new System.Drawing.Point(824, 593);
            this.PB2Rules.Name = "PB2Rules";
            this.PB2Rules.Size = new System.Drawing.Size(300, 270);
            this.PB2Rules.TabIndex = 12;
            this.PB2Rules.TabStop = false;
            // 
            // PB1Rules
            // 
            this.PB1Rules.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PB1Rules.Location = new System.Drawing.Point(812, 160);
            this.PB1Rules.Name = "PB1Rules";
            this.PB1Rules.Size = new System.Drawing.Size(300, 270);
            this.PB1Rules.TabIndex = 13;
            this.PB1Rules.TabStop = false;
            // 
            // LUnderPic1Rules
            // 
            this.LUnderPic1Rules.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LUnderPic1Rules.AutoSize = true;
            this.LUnderPic1Rules.Font = new System.Drawing.Font("Segoe UI Symbol", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LUnderPic1Rules.Location = new System.Drawing.Point(818, 433);
            this.LUnderPic1Rules.Name = "LUnderPic1Rules";
            this.LUnderPic1Rules.Size = new System.Drawing.Size(85, 32);
            this.LUnderPic1Rules.TabIndex = 14;
            this.LUnderPic1Rules.Text = "label1";
            // 
            // LUnderPic2Rules
            // 
            this.LUnderPic2Rules.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LUnderPic2Rules.AutoSize = true;
            this.LUnderPic2Rules.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LUnderPic2Rules.Location = new System.Drawing.Point(819, 866);
            this.LUnderPic2Rules.Name = "LUnderPic2Rules";
            this.LUnderPic2Rules.Size = new System.Drawing.Size(74, 30);
            this.LUnderPic2Rules.TabIndex = 15;
            this.LUnderPic2Rules.Text = "label1";
            // 
            // RulesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(1904, 1061);
            this.Controls.Add(this.LUnderPic2Rules);
            this.Controls.Add(this.LUnderPic1Rules);
            this.Controls.Add(this.PB1Rules);
            this.Controls.Add(this.PB2Rules);
            this.Controls.Add(this.LSecondRule);
            this.Controls.Add(this.LFirstRule);
            this.Controls.Add(this.BBackRules);
            this.Controls.Add(this.LNameRules);
            this.Controls.Add(this.ExitMainButton);
            this.Controls.Add(this.BNext);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RulesForm";
            this.Text = "Rules";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Rules_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PB2Rules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB1Rules)).EndInit();
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
        private System.Windows.Forms.PictureBox PB2Rules;
        private System.Windows.Forms.PictureBox PB1Rules;
        private System.Windows.Forms.Label LUnderPic1Rules;
        private System.Windows.Forms.Label LUnderPic2Rules;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}