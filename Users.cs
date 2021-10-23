using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text_Editor_Assignment_2
{
    public class Users
    {
        //Current user tracking
        private static string CurrentUserName = "";
        private static UserTypeEnum? CurrentUserType = UserTypeEnum.View;
        private static int LoginCount = 0;
        private static DateTime LastLogin = DateTime.Now;
        //
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public int UserType { get; set; }
        public List<Users> GetUsers()
        {
            var userList = new List<Users>();
            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader("login.txt");
            //Read the first line of text
            var text = sr.ReadLine();
            //check until to reach eof
            while (text != null)
            {
                //compare userName and password
                var line = text.Split(',');
                var user = new Users
                {
                    UserName = line[0],
                    Password = line[1],
                    UserType = int.Parse(line[2]),
                    FirstName = line[3],
                    LastName = line[4],
                    DOB = line[5],

                };
                //add the user to the list
                userList.Add(user);
                //Read the next line
                text = sr.ReadLine();
            }
            sr.Close();

            return userList;
        }
        public bool ValidateUser(string userName, string password)
        {
            //check failed attempt count and time limit
            if (userName == Users.CurrentUserName && Users.LoginCount > 2 && Users.LastLogin.AddMinutes(1) > DateTime.Now)
            {
                Users.CurrentUserName = userName;
                Users.LoginCount++;
                MessageBox.Show("Invalid Credentials! Too many Login attempts. Try again in 30 minutes", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            var userList = GetUsers();
            //Get the matching user
            var user = userList.Where(x => x.UserName == userName).FirstOrDefault();
            CurrentUserName = user?.UserName;
            //user does not exist
            if (user == null || user?.Password != password)
            {
                Users.LoginCount++;
                MessageBox.Show("Invalid Credentials! Enter again", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            CurrentUserType = (UserTypeEnum)user.UserType;
            Users.LoginCount = 0;
            return true;
        }
        public bool CheckUserNameExists(string userName)
        {
            var userList = GetUsers();
            var list = userList.Where(x => x.UserName == userName).ToList();
            //username already exists
            if (list.Count > 0)
            {
                return true;
            }
            return false;

        }
        public void Logout() 
        {
            CurrentUserName = "";
            CurrentUserType = null;
        }
        public string GetCurrentUserName() 
        {
            return CurrentUserName;
        }
        public UserTypeEnum GetCurrentUserType()
        {
            return CurrentUserType?? UserTypeEnum.View;
        }

    }
}
