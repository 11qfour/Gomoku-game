
namespace Gomoku
{
    partial class Info
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Info));
            this.RichTBDatasInfo = new System.Windows.Forms.RichTextBox();
            this.ExitMainButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RichTBDatasInfo
            // 
            this.RichTBDatasInfo.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichTBDatasInfo.Location = new System.Drawing.Point(21, 17);
            this.RichTBDatasInfo.Name = "RichTBDatasInfo";
            this.RichTBDatasInfo.Size = new System.Drawing.Size(559, 368);
            this.RichTBDatasInfo.TabIndex = 0;
            this.RichTBDatasInfo.Text = resources.GetString("RichTBDatasInfo.Text");
            // 
            // ExitMainButton
            // 
            this.ExitMainButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ExitMainButton.BackColor = System.Drawing.Color.Chocolate;
            this.ExitMainButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitMainButton.Image = ((System.Drawing.Image)(resources.GetObject("ExitMainButton.Image")));
            this.ExitMainButton.Location = new System.Drawing.Point(264, 391);
            this.ExitMainButton.Name = "ExitMainButton";
            this.ExitMainButton.Size = new System.Drawing.Size(62, 57);
            this.ExitMainButton.TabIndex = 8;
            this.ExitMainButton.UseVisualStyleBackColor = false;
            this.ExitMainButton.Click += new System.EventHandler(this.ExitMainButton_Click);
            // 
            // Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(605, 460);
            this.Controls.Add(this.ExitMainButton);
            this.Controls.Add(this.RichTBDatasInfo);
            this.Name = "Info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Руководство к приложению";
            this.Load += new System.EventHandler(this.Info_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox RichTBDatasInfo;
        private System.Windows.Forms.Button ExitMainButton;
    }
}