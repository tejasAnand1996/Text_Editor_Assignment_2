using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text_Editor_Assignment_2
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
            //centralize the screen
            this.CenterToScreen();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            var userObj = new Users();   
            //validate credentials
            if (userObj.ValidateUser(Username.Text.ToString(), Password.Text.ToString()))
            {
                this.Hide();
                new TextEditor().Show();
            }
        }

        private void RegisterUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new RegisterNewUser().Show();
            this.Hide();
        }
    }
}
