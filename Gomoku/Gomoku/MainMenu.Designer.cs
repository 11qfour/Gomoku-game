
namespace Gomoku
{
    partial class MainMenu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.LNameOfGame = new System.Windows.Forms.Label();
            this.BGameWithPC = new System.Windows.Forms.Button();
            this.BGameWithFriend = new System.Windows.Forms.Button();
            this.BRules = new System.Windows.Forms.Button();
            this.ExitMainButton = new System.Windows.Forms.Button();
            this.MenuMainButton = new System.Windows.Forms.Button();
            this.InfoButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // LNameOfGame
            // 
            this.LNameOfGame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LNameOfGame.AutoSize = true;
            this.LNameOfGame.Font = new System.Drawing.Font("Segoe UI Symbol", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNameOfGame.Location = new System.Drawing.Point(49, 27);
            this.LNameOfGame.Name = "LNameOfGame";
            this.LNameOfGame.Size = new System.Drawing.Size(720, 65);
            this.LNameOfGame.TabIndex = 0;
            this.LNameOfGame.Text = "Логическая игра \"Гомоку\"";
            // 
            // BGameWithPC
            // 
            this.BGameWithPC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BGameWithPC.BackColor = System.Drawing.Color.Peru;
            this.BGameWithPC.Font = new System.Drawing.Font("Segoe UI Symbol", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGameWithPC.Location = new System.Drawing.Point(78, 133);
            this.BGameWithPC.Name = "BGameWithPC";
            this.BGameWithPC.Size = new System.Drawing.Size(650, 43);
            this.BGameWithPC.TabIndex = 1;
            this.BGameWithPC.Text = "Играть с компьютером";
            this.BGameWithPC.UseVisualStyleBackColor = false;
            this.BGameWithPC.Click += new System.EventHandler(this.BGameWithPC_Click);
            // 
            // BGameWithFriend
            // 
            this.BGameWithFriend.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BGameWithFriend.BackColor = System.Drawing.Color.Peru;
            this.BGameWithFriend.Font = new System.Drawing.Font("Segoe UI Symbol", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGameWithFriend.Location = new System.Drawing.Point(78, 207);
            this.BGameWithFriend.Name = "BGameWithFriend";
            this.BGameWithFriend.Size = new System.Drawing.Size(650, 43);
            this.BGameWithFriend.TabIndex = 2;
            this.BGameWithFriend.Text = "Играть с другом";
            this.BGameWithFriend.UseVisualStyleBackColor = false;
            this.BGameWithFriend.Click += new System.EventHandler(this.BGameWithFriend_Click);
            // 
            // BRules
            // 
            this.BRules.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BRules.BackColor = System.Drawing.Color.Peru;
            this.BRules.Font = new System.Drawing.Font("Segoe UI Symbol", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BRules.Location = new System.Drawing.Point(78, 282);
            this.BRules.Name = "BRules";
            this.BRules.Size = new System.Drawing.Size(650, 43);
            this.BRules.TabIndex = 3;
            this.BRules.Text = "Правила";
            this.BRules.UseVisualStyleBackColor = false;
            this.BRules.Click += new System.EventHandler(this.BRules_Click);
            // 
            // ExitMainButton
            // 
            this.ExitMainButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ExitMainButton.BackColor = System.Drawing.Color.Goldenrod;
            this.ExitMainButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitMainButton.Image = ((System.Drawing.Image)(resources.GetObject("ExitMainButton.Image")));
            this.ExitMainButton.Location = new System.Drawing.Point(354, 362);
            this.ExitMainButton.Name = "ExitMainButton";
            this.ExitMainButton.Size = new System.Drawing.Size(58, 55);
            this.ExitMainButton.TabIndex = 6;
            this.ExitMainButton.UseVisualStyleBackColor = false;
            this.ExitMainButton.Click += new System.EventHandler(this.ExitMainButton_Click);
            // 
            // MenuMainButton
            // 
            this.MenuMainButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MenuMainButton.BackColor = System.Drawing.Color.Goldenrod;
            this.MenuMainButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuMainButton.Image = ((System.Drawing.Image)(resources.GetObject("MenuMainButton.Image")));
            this.MenuMainButton.Location = new System.Drawing.Point(520, 362);
            this.MenuMainButton.Name = "MenuMainButton";
            this.MenuMainButton.Size = new System.Drawing.Size(53, 55);
            this.MenuMainButton.TabIndex = 7;
            this.MenuMainButton.UseVisualStyleBackColor = false;
            this.MenuMainButton.Click += new System.EventHandler(this.MenuMainButton_Click);
            // 
            // InfoButton
            // 
            this.InfoButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.InfoButton.BackColor = System.Drawing.Color.Goldenrod;
            this.InfoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoButton.Image = ((System.Drawing.Image)(resources.GetObject("InfoButton.Image")));
            this.InfoButton.Location = new System.Drawing.Point(188, 362);
            this.InfoButton.Name = "InfoButton";
            this.InfoButton.Size = new System.Drawing.Size(57, 55);
            this.InfoButton.TabIndex = 8;
            this.InfoButton.UseVisualStyleBackColor = false;
            this.InfoButton.Click += new System.EventHandler(this.InfoButton_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 0;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.InfoButton);
            this.Controls.Add(this.MenuMainButton);
            this.Controls.Add(this.ExitMainButton);
            this.Controls.Add(this.BRules);
            this.Controls.Add(this.BGameWithFriend);
            this.Controls.Add(this.BGameWithPC);
            this.Controls.Add(this.LNameOfGame);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenu";
            this.Text = "Логическая игра \"Гомоку\"";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.SizeChanged += new System.EventHandler(this.MainMenu_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LNameOfGame;
        private System.Windows.Forms.Button BGameWithPC;
        private System.Windows.Forms.Button BGameWithFriend;
        private System.Windows.Forms.Button BRules;
        private System.Windows.Forms.Button ExitMainButton;
        private System.Windows.Forms.Button MenuMainButton;
        private System.Windows.Forms.Button InfoButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
    }
}

