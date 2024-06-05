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
            ToolTip toolTip1 = new ToolTip();
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            /*Resize += MainMenu_Resize;*/
            /*SizeChanged += MainMenu_SizeChanged;*/
            toolTip1.SetToolTip(InfoButton,"Справка");
            toolTip1.SetToolTip(MenuMainButton, "Настройки и профиль");
            toolTip1.SetToolTip(ExitMainButton, "Выход");
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

        private void OpenNewFormInSameResolution(Form newForm)//открытие нового окна в таком же разрешении
        {
            newForm.Size = this.Size;
            newForm.StartPosition = FormStartPosition.Manual;
            newForm.Location = this.Location;
            newForm.Icon = this.Icon;
            newForm.StartPosition = this.StartPosition;
            newForm.Show();
        }

        private void BGameWithPC_Click(object sender, EventArgs e)
        {
            DifficultySelection difficultySelection = new DifficultySelection();
            difficultySelection.Show();
        }

        private void BRules_Click(object sender, EventArgs e)
        {
            RulesForm rules = new RulesForm();
            OpenNewFormInSameResolution(rules);
        }

        private void BGameWithFriend_Click(object sender, EventArgs e)
        {
            GameWithPC gameWithFriend = new GameWithPC();
            gameWithFriend.SetOppName("Друг");
            OpenNewFormInSameResolution(gameWithFriend);
        }

        private void InfoButton_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            info.Show();
        }

        private void MenuMainButton_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            OpenNewFormInSameResolution(settings);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Experiment exp = new Experiment();
            exp.Show();
        }
    }
}
