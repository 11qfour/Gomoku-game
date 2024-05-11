
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
            this.SuspendLayout();
            // 
            // L1DS
            // 
            this.L1DS.AutoSize = true;
            this.L1DS.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L1DS.Location = new System.Drawing.Point(41, 9);
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
            this.BStartDS.Location = new System.Drawing.Point(219, 361);
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
            this.L2DS.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L2DS.Location = new System.Drawing.Point(148, 182);
            this.L2DS.Name = "L2DS";
            this.L2DS.Size = new System.Drawing.Size(330, 30);
            this.L2DS.TabIndex = 2;
            this.L2DS.Text = "Ограничение по времени";
            // 
            // RBNoTimeDS
            // 
            this.RBNoTimeDS.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RBNoTimeDS.AutoSize = true;
            this.RBNoTimeDS.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBNoTimeDS.Location = new System.Drawing.Point(171, 234);
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
            this.RBTimerDS.Location = new System.Drawing.Point(171, 265);
            this.RBTimerDS.Name = "RBTimerDS";
            this.RBTimerDS.Size = new System.Drawing.Size(307, 25);
            this.RBTimerDS.TabIndex = 5;
            this.RBTimerDS.TabStop = true;
            this.RBTimerDS.Text = "Задать ограничение по времени";
            this.RBTimerDS.UseVisualStyleBackColor = true;
            this.RBTimerDS.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // TBTimerDS
            // 
            this.TBTimerDS.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.TBTimerDS.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBTimerDS.Location = new System.Drawing.Point(347, 316);
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
            this.L3DS.Location = new System.Drawing.Point(166, 312);
            this.L3DS.Name = "L3DS";
            this.L3DS.Size = new System.Drawing.Size(95, 30);
            this.L3DS.TabIndex = 7;
            this.L3DS.Text = "Время";
            // 
            // ChLBDS
            // 
            this.ChLBDS.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ChLBDS.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChLBDS.FormattingEnabled = true;
            this.ChLBDS.Items.AddRange(new object[] {
            "Простой уровень сложности",
            "Средний урвоень сложности",
            "Высокий уровень сложности"});
            this.ChLBDS.Location = new System.Drawing.Point(103, 63);
            this.ChLBDS.Name = "ChLBDS";
            this.ChLBDS.Size = new System.Drawing.Size(403, 94);
            this.ChLBDS.TabIndex = 8;
            this.ChLBDS.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // DifficultySelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(605, 416);
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
    }
}