using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Text_Editor_Assignment_2
{
    public partial class TextEditor : Form
    {
        string filePath = "";
        public TextEditor()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        private void TextEditor_Load(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            var obj = new Users();
            string userType = "";
            //View Only
            if (obj.GetCurrentUserType() == UserTypeEnum.View)
            {
                userType = "(Read-Only Mode)";
                textBox.ReadOnly = true;
                newButton.Enabled = false;
                saveAsButton.Enabled = false;
                saveButton.Enabled = false;
                copyToolStripButton.Enabled = false;
                cutToolStripButton.Enabled = false;
                pasteToolStripButton.Enabled = false;

                copyToolStripMenuItem.Enabled = false;
                cutToolStripMenuItem.Enabled = false;
                pasteToolStripMenuItem.Enabled = false;
                saveToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = false;
                newToolStripMenuItem.Enabled = false;

            }
            //View and Edit
            else
            {
                userType = "(View and Edit Mode)";

                textBox.ReadOnly = false;
                newButton.Enabled = true;
                saveAsButton.Enabled = true;
                saveButton.Enabled = true;
                copyToolStripButton.Enabled = true;
                cutToolStripButton.Enabled = true;
                pasteToolStripButton.Enabled = true;

                copyToolStripMenuItem.Enabled = true;
                cutToolStripMenuItem.Enabled = true;
                pasteToolStripMenuItem.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
                newToolStripMenuItem.Enabled = true;

            }

            userNameLabel.Text = "Username : " + obj.GetCurrentUserName() + "  " + userType;
            for (int i = 1; i <= 20; i++)
            {
                fontSize.Items.Add(i);
            }
            fontSize.Text = fontSize.Font.Size.ToString();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            filePath = "";
            textBox.Clear();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            try
            {
                var file = new OpenFileDialog();
                if (file.ShowDialog() == DialogResult.OK)
                {
                    filePath = file.FileName;
                    textBox.Clear();
                    using (StreamReader sr = new StreamReader(file.FileName))
                    {
                        textBox.Text = sr.ReadToEnd();
                        sr.Close();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot Open selected file, try again!");
            }


        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //saving a new file
            if (String.IsNullOrEmpty(filePath))
            {
                DialogResult saveResult = saveFileDialog1.ShowDialog();
                //saveFileDialog1.FileName = "untitled.txt";
                if (saveResult == DialogResult.OK)
                {
                    filePath = saveFileDialog1.FileName;
                    try
                    {
                        StreamWriter sw = new StreamWriter(filePath);
                        sw.Write(textBox.Text);
                        sw.Close();

                    }
                    catch (IOException)
                    {

                        MessageBox.Show("Error Saving the File!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            //saving to an existing file
            else
            {
                try
                {
                    StreamWriter sw = new StreamWriter(filePath);
                    sw.Write(textBox.Text);
                    sw.Close();

                }
                catch (IOException)
                {
                    MessageBox.Show("Error Saving the File!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void saveAsButton_Click(object sender, EventArgs e)
        {
            //prevent saving an empty file
            if (!String.IsNullOrEmpty(textBox.Text))
            {

                DialogResult saveResult = saveFileDialog1.ShowDialog();
                if (saveResult == DialogResult.OK)
                {
                    filePath = saveFileDialog1.FileName;
                    try
                    {
                        StreamWriter sw = new StreamWriter(filePath);
                        sw.Write(textBox.Text);
                        sw.Close();

                    }
                    catch (IOException)
                    {

                        MessageBox.Show("Error Saving the File!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            else
            {
                MessageBox.Show("ECannot save an empty file!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Cut();
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Copy();
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Paste();
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newButton.PerformClick();
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openButton.PerformClick();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveButton.PerformClick();
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAsButton.PerformClick();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //logout
            var obj = new Users();
            new LoginPage().Show();
            this.Hide();
            obj.Logout();


        }
        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            cutToolStripMenuItem.PerformClick();
        }
        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            copyToolStripMenuItem.PerformClick();
        }
        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            pasteToolStripMenuItem.PerformClick();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }
        private void aboutAbutton_Click(object sender, EventArgs e)
        {
            aboutToolStripMenuItem.PerformClick();
        }
        private void boldButton_Click(object sender, EventArgs e)
        {
            if (textBox.SelectionFont != null)
            {
                Font currentFont = textBox.SelectionFont;
                FontStyle newFont;

                if (textBox.SelectionFont.Bold == true)
                {
                    newFont = FontStyle.Regular;
                }
                else
                {
                    newFont = FontStyle.Bold;
                }

                //set new font style
                textBox.SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size,
                   newFont
                );
            }
        }
        private void italicButton_Click(object sender, EventArgs e)
        {
            if (textBox.SelectionFont != null)
            {
                Font currentFont = textBox.SelectionFont;
                FontStyle newFont;

                if (textBox.SelectionFont.Italic == true)
                {
                    newFont = FontStyle.Regular;
                }
                else
                {
                    newFont = FontStyle.Italic;
                }

                //set new font style
                textBox.SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size,
                   newFont
                );
            }

        }
        private void underlineButton_Click(object sender, EventArgs e)
        {
            if (textBox.SelectionFont != null)
            {
                Font currentFont = textBox.SelectionFont;
                FontStyle newFont;

                if (textBox.SelectionFont.Underline == true)
                {
                    newFont = FontStyle.Regular;
                }
                else
                {
                    newFont = FontStyle.Underline;
                }


                //set new font style
                textBox.SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size,
                   newFont
                );
            }

        }
        private void fontSize_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (textBox.SelectionFont != null)
            {
                Font currentFont = textBox.SelectionFont;
                int newFontSize = int.Parse(fontSize.SelectedItem.ToString());

                //set new font style
                textBox.SelectionFont = new Font(
                   currentFont.FontFamily,
                   newFontSize,
                   currentFont.Style
                );
            }
        }
    }
}
