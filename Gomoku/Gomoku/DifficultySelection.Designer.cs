﻿
namespace Gomoku
{
    partial class DifficultySelection
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
            this.L1DS = new System.Windows.Forms.Label();
            this.BStartDS = new System.Windows.Forms.Button();
            this.L2DS = new System.Windows.Forms.Label();
            this.RBNoTimeDS = new System.Windows.Forms.RadioButton();
            this.RBTimerDS = new System.Windows.Forms.RadioButton();
            this.TBTimerDS = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.L3DS = new System.Windows.Forms.Label();
            this.ChLBDS = new System.Windows.Forms.CheckedListBox();
            this.L4DS = new System.Windows.Forms.Label();
            this.RBBlackDS = new System.Windows.Forms.RadioButton();
            this.RBWhiteDS = new System.Windows.Forms.RadioButton();
            this.GBDS = new System.Windows.Forms.GroupBox();
            this.GBDS.SuspendLayout();
            this.SuspendLayout();
            // 
            // L1DS
            // 
            this.L1DS.AutoSize = true;
            this.L1DS.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L1DS.Location = new System.Drawing.Point(41, 18);
            this.L1DS.Name = "L1DS";
            this.L1DS.Size = new System.Drawing.Size(533, 30);
            this.L1DS.TabIndex = 0;
            this.L1DS.Text = "Сложность игры противника-компьютера";
            // 
            // BStartDS
            // 
            this.BStartDS.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BStartDS.BackColor = System.Drawing.Color.Peru;
            this.BStartDS.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BStartDS.Location = new System.Drawing.Point(238, 362);
            this.BStartDS.Name = "BStartDS";
            this.BStartDS.Size = new System.Drawing.Size(157, 33);
            this.BStartDS.TabIndex = 1;
            this.BStartDS.Text = "Начать игру";
            this.BStartDS.UseVisualStyleBackColor = false;
            this.BStartDS.Click += new System.EventHandler(this.BStartDS_Click);
            // 
            // L2DS
            // 
            this.L2DS.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.L2DS.AutoSize = true;
            this.L2DS.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L2DS.Location = new System.Drawing.Point(56, 178);
            this.L2DS.Name = "L2DS";
            this.L2DS.Size = new System.Drawing.Size(266, 25);
            this.L2DS.TabIndex = 2;
            this.L2DS.Text = "Ограничение по времени";
            // 
            // RBNoTimeDS
            // 
            this.RBNoTimeDS.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RBNoTimeDS.AutoSize = true;
            this.RBNoTimeDS.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBNoTimeDS.Location = new System.Drawing.Point(46, 216);
            this.RBNoTimeDS.Name = "RBNoTimeDS";
            this.RBNoTimeDS.Size = new System.Drawing.Size(276, 25);
            this.RBNoTimeDS.TabIndex = 4;
            this.RBNoTimeDS.TabStop = true;
            this.RBNoTimeDS.Text = "Нет ограничения по времени";
            this.RBNoTimeDS.UseVisualStyleBackColor = true;
            // 
            // RBTimerDS
            // 
            this.RBTimerDS.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RBTimerDS.AutoSize = true;
            this.RBTimerDS.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBTimerDS.Location = new System.Drawing.Point(46, 263);
            this.RBTimerDS.Name = "RBTimerDS";
            this.RBTimerDS.Size = new System.Drawing.Size(307, 25);
            this.RBTimerDS.TabIndex = 5;
            this.RBTimerDS.TabStop = true;
            this.RBTimerDS.Text = "Задать ограничение по времени";
            this.RBTimerDS.UseVisualStyleBackColor = true;
            this.RBTimerDS.CheckedChanged += new System.EventHandler(this.RBTimerDS_CheckedChanged);
            // 
            // TBTimerDS
            // 
            this.TBTimerDS.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.TBTimerDS.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBTimerDS.Location = new System.Drawing.Point(337, 311);
            this.TBTimerDS.Name = "TBTimerDS";
            this.TBTimerDS.Size = new System.Drawing.Size(100, 29);
            this.TBTimerDS.TabIndex = 6;
            this.TBTimerDS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBTimerDS.Visible = false;
            // 
            // L3DS
            // 
            this.L3DS.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.L3DS.AutoSize = true;
            this.L3DS.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L3DS.Location = new System.Drawing.Point(198, 310);
            this.L3DS.Name = "L3DS";
            this.L3DS.Size = new System.Drawing.Size(95, 30);
            this.L3DS.TabIndex = 7;
            this.L3DS.Text = "Время";
            this.L3DS.Visible = false;
            // 
            // ChLBDS
            // 
            this.ChLBDS.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ChLBDS.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChLBDS.FormattingEnabled = true;
            this.ChLBDS.Items.AddRange(new object[] {
            "Простой уровень сложности",
            "Средний уроень сложности",
            "Высокий уровень сложности"});
            this.ChLBDS.Location = new System.Drawing.Point(121, 65);
            this.ChLBDS.Name = "ChLBDS";
            this.ChLBDS.Size = new System.Drawing.Size(366, 94);
            this.ChLBDS.TabIndex = 8;
            this.ChLBDS.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // L4DS
            // 
            this.L4DS.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.L4DS.AutoSize = true;
            this.L4DS.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L4DS.Location = new System.Drawing.Point(399, 178);
            this.L4DS.Name = "L4DS";
            this.L4DS.Size = new System.Drawing.Size(165, 25);
            this.L4DS.TabIndex = 9;
            this.L4DS.Text = "Выбор стороны";
            // 
            // RBBlackDS
            // 
            this.RBBlackDS.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.RBBlackDS.AutoSize = true;
            this.RBBlackDS.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBBlackDS.Location = new System.Drawing.Point(11, 61);
            this.RBBlackDS.Name = "RBBlackDS";
            this.RBBlackDS.Size = new System.Drawing.Size(93, 25);
            this.RBBlackDS.TabIndex = 10;
            this.RBBlackDS.TabStop = true;
            this.RBBlackDS.Text = "Черные";
            this.RBBlackDS.UseVisualStyleBackColor = true;
            // 
            // RBWhiteDS
            // 
            this.RBWhiteDS.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.RBWhiteDS.AutoSize = true;
            this.RBWhiteDS.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBWhiteDS.Location = new System.Drawing.Point(11, 14);
            this.RBWhiteDS.Name = "RBWhiteDS";
            this.RBWhiteDS.Size = new System.Drawing.Size(83, 25);
            this.RBWhiteDS.TabIndex = 11;
            this.RBWhiteDS.TabStop = true;
            this.RBWhiteDS.Text = "Белые";
            this.RBWhiteDS.UseVisualStyleBackColor = true;
            // 
            // GBDS
            // 
            this.GBDS.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.GBDS.Controls.Add(this.RBWhiteDS);
            this.GBDS.Controls.Add(this.RBBlackDS);
            this.GBDS.Location = new System.Drawing.Point(393, 202);
            this.GBDS.Margin = new System.Windows.Forms.Padding(0);
            this.GBDS.Name = "GBDS";
            this.GBDS.Size = new System.Drawing.Size(200, 100);
            this.GBDS.TabIndex = 12;
            this.GBDS.TabStop = false;
            // 
            // DifficultySelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(605, 416);
            this.Controls.Add(this.GBDS);
            this.Controls.Add(this.L4DS);
            this.Controls.Add(this.ChLBDS);
            this.Controls.Add(this.L3DS);
            this.Controls.Add(this.TBTimerDS);
            this.Controls.Add(this.RBTimerDS);
            this.Controls.Add(this.RBNoTimeDS);
            this.Controls.Add(this.L2DS);
            this.Controls.Add(this.BStartDS);
            this.Controls.Add(this.L1DS);
            this.Name = "DifficultySelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор сложности игры противника-компьютера";
            this.Load += new System.EventHandler(this.DifficultySelection_Load);
            this.GBDS.ResumeLayout(false);
            this.GBDS.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label L1DS;
        private System.Windows.Forms.Button BStartDS;
        private System.Windows.Forms.Label L2DS;
        private System.Windows.Forms.RadioButton RBNoTimeDS;
        private System.Windows.Forms.RadioButton RBTimerDS;
        private System.Windows.Forms.TextBox TBTimerDS;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label L3DS;
        private System.Windows.Forms.CheckedListBox ChLBDS;
        private System.Windows.Forms.Label L4DS;
        private System.Windows.Forms.RadioButton RBBlackDS;
        private System.Windows.Forms.RadioButton RBWhiteDS;
        private System.Windows.Forms.GroupBox GBDS;
    }
}