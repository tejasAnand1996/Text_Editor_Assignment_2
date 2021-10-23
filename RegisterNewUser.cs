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
    public partial class RegisterNewUser : Form
    {
        public RegisterNewUser()
        {
            InitializeComponent(); 
            this.CenterToScreen();
            userType.DataSource = Enum.GetValues(typeof(UserTypeEnum));
            //userType.Items.Add("View");
            //userType.Items.Add("Edit");
            userType.DropDownStyle = ComboBoxStyle.DropDownList;
            userType.SelectedIndex = userType.FindStringExact("View");
            dob.Format = DateTimePickerFormat.Custom;
            dob.CustomFormat = "dd MM yyyy";
        }

        private void UserType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RegisterUser_Click(object sender, EventArgs e)
        {
            var obj = new Users();
            bool isvalid = true;
            string text = "";
            string content = "";
            string userName = user_name.Text.ToString();
            string password = pass_word.Text.ToString();
            //validate form data
            if (String.IsNullOrEmpty(userName))
            {
                isvalid = false;
                text += "- User Name is invalid!"+ Environment.NewLine;
            }
            if (password.Length < 3)
            {
                isvalid = false;
                text += "- UserName must have more than three characters!" + Environment.NewLine;
            }
            if (obj.CheckUserNameExists(userName)) 
            {
                isvalid = false;
                text += "- User Name ALREADY EXIST, ENTER A NEW ONE!" + Environment.NewLine;
            }

            content += userName + ",";

            if (String.IsNullOrEmpty(password))
            {
                isvalid = false;
                text +=  "- Password is invalid!" + Environment.NewLine;
            }
            if (password.Length<3)
            {
                isvalid = false;
                text += "- Password must have more than three characters!" + Environment.NewLine;
            }


            if (pass_word.Text.ToString() != passwordConfirm.Text.ToString())
            {
                isvalid = false;
                text += "- Passwords do not match!" + Environment.NewLine;
            }
            content +=  pass_word.Text.ToString()+",";

            content += userType.SelectedIndex + ",";
            if (String.IsNullOrEmpty(firstName.Text.ToString()))
            {
                isvalid = false;
                text += "- First Name is invalid!" + Environment.NewLine;
            }
                content += firstName.Text.ToString()+",";
            if (String.IsNullOrEmpty(lastName.Text.ToString()))
            {
                isvalid = false;
                text += "- Last Name is invalid!" + Environment.NewLine;

            }
                content +=  lastName.Text.ToString()+ ",";

            if (dob.Value.Date >= DateTime.Now.Date)
            {
                isvalid = false;
                text += "- D.O.B is invalid!" + Environment.NewLine;
            }
                content += dob.Value.Date.ToString("yyyy/MM/dd") + ",";

            if (isvalid)
            {
                var filePath = "login.txt";
                var existingContent = "";
                //store information
                if (File.Exists(filePath))
                {
                    //read all lines of the file
                    string[] lines = File.ReadAllLines(filePath);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        existingContent += lines[i].ToString() + Environment.NewLine;
                    }
                    existingContent += content;
                    using (StreamWriter sw = File.CreateText(filePath))
                    {
                        sw.WriteLine(existingContent);
                    }

                }
                new LoginPage().Show();
                this.Close();
                return;
            }
            MessageBox.Show(text,"Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            new LoginPage().Show();
            this.Close();
        }
    }
}
