
namespace Gomoku
{
    partial class Settings
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
            this.LMainSett = new System.Windows.Forms.Label();
            this.TBNameSett = new System.Windows.Forms.TextBox();
            this.PagesSett = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.LSett2 = new System.Windows.Forms.Label();
            this.TBRapidSett = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.LSett1 = new System.Windows.Forms.Label();
            this.BChngeNameSett = new System.Windows.Forms.Button();
            this.BReloadingForm = new System.Windows.Forms.Button();
            this.BChangeGamerSett = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.PagesSett.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LMainSett
            // 
            this.LMainSett.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LMainSett.AutoSize = true;
            this.LMainSett.Font = new System.Drawing.Font("Segoe UI Symbol", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LMainSett.Location = new System.Drawing.Point(241, 3);
            this.LMainSett.Name = "LMainSett";
            this.LMainSett.Size = new System.Drawing.Size(335, 47);
            this.LMainSett.TabIndex = 0;
            this.LMainSett.Text = "Профиль игрока";
            // 
            // TBNameSett
            // 
            this.TBNameSett.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TBNameSett.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBNameSett.Location = new System.Drawing.Point(40, 69);
            this.TBNameSett.Name = "TBNameSett";
            this.TBNameSett.Size = new System.Drawing.Size(174, 33);
            this.TBNameSett.TabIndex = 2;
            // 
            // PagesSett
            // 
            this.PagesSett.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PagesSett.Controls.Add(this.tabPage1);
            this.PagesSett.Controls.Add(this.tabPage2);
            this.PagesSett.Location = new System.Drawing.Point(0, 0);
            this.PagesSett.Name = "PagesSett";
            this.PagesSett.SelectedIndex = 0;
            this.PagesSett.Size = new System.Drawing.Size(800, 450);
            this.PagesSett.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Moccasin;
            this.tabPage1.Controls.Add(this.LSett2);
            this.tabPage1.Controls.Add(this.TBRapidSett);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Controls.Add(this.LSett1);
            this.tabPage1.Controls.Add(this.BChngeNameSett);
            this.tabPage1.Controls.Add(this.BReloadingForm);
            this.tabPage1.Controls.Add(this.BChangeGamerSett);
            this.tabPage1.Controls.Add(this.TBNameSett);
            this.tabPage1.Controls.Add(this.LMainSett);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "1";
            // 
            // LSett2
            // 
            this.LSett2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LSett2.AutoSize = true;
            this.LSett2.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LSett2.Location = new System.Drawing.Point(295, 175);
            this.LSett2.Name = "LSett2";
            this.LSett2.Size = new System.Drawing.Size(155, 25);
            this.LSett2.TabIndex = 10;
            this.LSett2.Text = "Лучшие матчи:";
            // 
            // TBRapidSett
            // 
            this.TBRapidSett.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TBRapidSett.Enabled = false;
            this.TBRapidSett.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBRapidSett.Location = new System.Drawing.Point(327, 121);
            this.TBRapidSett.Name = "TBRapidSett";
            this.TBRapidSett.Size = new System.Drawing.Size(113, 33);
            this.TBRapidSett.TabIndex = 9;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressBar1.Location = new System.Drawing.Point(568, 121);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(155, 28);
            this.progressBar1.TabIndex = 8;
            // 
            // LSett1
            // 
            this.LSett1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LSett1.AutoSize = true;
            this.LSett1.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LSett1.Location = new System.Drawing.Point(131, 124);
            this.LSett1.Name = "LSett1";
            this.LSett1.Size = new System.Drawing.Size(94, 25);
            this.LSett1.TabIndex = 7;
            this.LSett1.Text = "Рейтинг";
            // 
            // BChngeNameSett
            // 
            this.BChngeNameSett.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BChngeNameSett.BackColor = System.Drawing.Color.Peru;
            this.BChngeNameSett.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BChngeNameSett.Location = new System.Drawing.Point(233, 70);
            this.BChngeNameSett.Name = "BChngeNameSett";
            this.BChngeNameSett.Size = new System.Drawing.Size(270, 32);
            this.BChngeNameSett.TabIndex = 6;
            this.BChngeNameSett.Text = "Изменить имя";
            this.BChngeNameSett.UseVisualStyleBackColor = false;
            // 
            // BReloadingForm
            // 
            this.BReloadingForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BReloadingForm.BackColor = System.Drawing.Color.Peru;
            this.BReloadingForm.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BReloadingForm.Location = new System.Drawing.Point(514, 70);
            this.BReloadingForm.Name = "BReloadingForm";
            this.BReloadingForm.Size = new System.Drawing.Size(270, 32);
            this.BReloadingForm.TabIndex = 5;
            this.BReloadingForm.Text = "Обновить данные";
            this.BReloadingForm.UseVisualStyleBackColor = false;
            // 
            // BChangeGamerSett
            // 
            this.BChangeGamerSett.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BChangeGamerSett.BackColor = System.Drawing.Color.Peru;
            this.BChangeGamerSett.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BChangeGamerSett.Location = new System.Drawing.Point(233, 372);
            this.BChangeGamerSett.Name = "BChangeGamerSett";
            this.BChangeGamerSett.Size = new System.Drawing.Size(310, 32);
            this.BChangeGamerSett.TabIndex = 3;
            this.BChangeGamerSett.Text = "Сменить пользователя";
            this.BChangeGamerSett.UseVisualStyleBackColor = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Moccasin;
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(307, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Лучшие матчи:";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PagesSett);
            this.Name = "Settings";
            this.Text = "Settings";
            this.PagesSett.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LMainSett;
        private System.Windows.Forms.TextBox TBNameSett;
        private System.Windows.Forms.TabControl PagesSett;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button BChangeGamerSett;
        private System.Windows.Forms.Button BReloadingForm;
        private System.Windows.Forms.Label LSett1;
        private System.Windows.Forms.Button BChngeNameSett;
        private System.Windows.Forms.Label LSett2;
        private System.Windows.Forms.TextBox TBRapidSett;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
    }
}