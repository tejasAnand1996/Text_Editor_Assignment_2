using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text_Editor_Assignment_2
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            this.CenterToScreen();
            aboutTextBox.Text = Environment.NewLine + Environment.NewLine + @"               Magic Text Editor Inc." +Environment.NewLine + Environment.NewLine+
                                     "          Version      - 1.0.0.1 " + Environment.NewLine + Environment.NewLine +
                                     "          Developed by - Rahul Nagarkoti";
        }


        private void Login_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
