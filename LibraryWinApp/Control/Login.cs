using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryWinApp.Control
{
    public partial class Login : Form
    {
        IUserRepository userRepository = new UserRepository();
        public Login()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            var userAccount = userRepository.GetUserByEmail(txtEmail.Text);
            //Got email and password
            //Compare to database
            if (userAccount != null)
            {
                if (userAccount.Email.Equals(txtEmail.Text) && userAccount.Password.Equals(txtPassword.Text))
                {
                    this.Hide();
                    frmControl frmControl = new frmControl();
                    frmControl.Show();
                }
            }
            else
            {
                string message = "You don't have admit to access this file!";
                string title = "Login Failed";
                MessageBox.Show(message, title);

            }
        }
    }
}
