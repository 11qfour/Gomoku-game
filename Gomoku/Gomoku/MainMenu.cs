using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomoku
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            /*Resize += MainMenu_Resize;*/
            SizeChanged += MainMenu_SizeChanged;
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void ExitMainButton_Click(object sender, EventArgs e)
        {
            DialogResult resultdialog = MessageBox.Show("Вы уверены что хотите закрыть программу?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultdialog == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void MainMenu_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                float scaleWidth = (float)Width / (float)ClientSize.Width; //коэфициент сохранения ширины
                float scaleHeight = (float)Height / (float)ClientSize.Height;//коэфициент сохранения высоты
                BGameWithPC.Size = new Size((int)(BGameWithPC.Width * scaleWidth), (int)(BGameWithPC.Height * scaleHeight));
                BRules.Size = new Size((int)(BRules.Width * scaleWidth), (int)(BRules.Height * scaleHeight));
                BGameWithFriend.Size = new Size((int)(BGameWithFriend.Width * scaleWidth), (int)(BGameWithFriend.Height * scaleHeight));
                InfoButton.Size = new Size((int)(InfoButton.Width * scaleWidth), (int)(InfoButton.Height * scaleHeight));
                ExitMainButton.Size = new Size((int)(ExitMainButton.Width * scaleWidth), (int)(ExitMainButton.Height * scaleHeight));
            }
        }

        private void OpenNewFormInSameResolution(Form newForm)//открытие нового окна в таком эе разрешении
        {
            newForm.Size = this.Size;
            newForm.StartPosition = FormStartPosition.Manual;
            newForm.Location = this.Location;
            newForm.Show();
        }

        private void BGameWithPC_Click(object sender, EventArgs e)
        {
            GameWithPC gameWithPC = new GameWithPC();
            OpenNewFormInSameResolution(gameWithPC);
        }

        private void BRules_Click(object sender, EventArgs e)
        {
            Rules rules = new Rules();
            OpenNewFormInSameResolution(rules);
        }

        private void BGameWithFriend_Click(object sender, EventArgs e)
        {
            GameWithFriend gameWithFriend = new GameWithFriend();
            OpenNewFormInSameResolution(gameWithFriend);
        }

        private void InfoButton_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            OpenNewFormInSameResolution(info);
        }

        private void MenuMainButton_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            OpenNewFormInSameResolution(settings);
        }
    }
}
