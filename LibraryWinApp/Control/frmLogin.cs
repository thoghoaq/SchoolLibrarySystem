using System;
using System.Windows.Forms;
using DataAccess.Repository;

namespace LibrarySystem
{
    public partial class frmLogin : Form
    {
        IUserRepository userRepository = new UserRepository();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

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
                    frmBooks frmBooks = new frmBooks();
                    frmBooks.Show();
                    Form1 form1 = new Form1();
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
