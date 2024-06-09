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
    public partial class Info : Form
    {
        public Info()
        {
            InitializeComponent();
        }

        private void ExitMainButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Info_Load(object sender, EventArgs e)
        {
            RichTBDatasInfo.ReadOnly = true;
            RichTBDatasInfo.ScrollBars = RichTextBoxScrollBars.Both;
            RichTBDatasInfo.SelectionStart = 0;
            RichTBDatasInfo.SelectionLength = 0;
        }
    }
}
