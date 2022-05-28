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

namespace LibraryWinApp
{
    public partial class frmLogin : Form
    {
        IUserRepository userRepository = new UserRepository();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var userAccount = userRepository.GetUserByEmail(txtEmail.Text);
            if (userAccount != null)
            {
                if (userAccount.Email.Equals(txtEmail.Text) && userAccount.Password.Equals(txtPassword.Text) && userAccount.Role.Equals("Staff") && userAccount.Status.Equals("Active"))
                {
                    this.Hide();
                    frmControl frmControl = new frmControl();
                    frmControl.Show();
                } else
                {
                    string message = "You don't have admit to access this file!!";
                    string title = "Login Failed";
                    MessageBox.Show(message, title);
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
