using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_Ha;
using BUS_Ha;

namespace QLQCF
{
    public partial class Login : Form
    {
        public bool loginCheck = false;
        public int auth;

        public Login()
        {
            InitializeComponent();
        }

        Account_BUS account_bus = new Account_BUS();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserName.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            {
                Account_DTO account_dto = new Account_DTO(txtUserName.Text, txtPassword.Text, 0, "", 0, 0, "");
                DataTable tb = account_bus.CheckAccount(account_dto);
                if (tb.Rows.Count > 0)
                {
                    loginCheck = true;
                    auth = tb.Rows[0].Field<int>("auth");
                    MessageBox.Show("Đăng nhập thành công");
                    this.Close();
                }
                else
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu");
            }
            else
            {
                MessageBox.Show("Để đăng nhập bạn cần phải nhập đầy đủ tài khoản và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (!string.IsNullOrEmpty(txtUserName.Text) && !string.IsNullOrEmpty(txtPassword.Text))
                {                   
                    Account_DTO account_dto = new Account_DTO(txtUserName.Text, txtPassword.Text, 0, "", 0, 0, "");
                    DataTable tb = account_bus.CheckAccount(account_dto);
                    if (tb.Rows.Count > 0)
                    {
                        loginCheck = true;
                        auth = tb.Rows[0].Field<int>("auth");
                        MessageBox.Show("Đăng nhập thành công");
                        this.Close();
                    }
                    else
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu");
                }
                else
                {
                    MessageBox.Show("Để đăng nhập bạn cần phải nhập đầy đủ tài khoản và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (!string.IsNullOrEmpty(txtUserName.Text) && !string.IsNullOrEmpty(txtPassword.Text))
                {
                    Account_DTO account_dto = new Account_DTO(txtUserName.Text, txtPassword.Text, 0, "", 0, 0, "");
                    DataTable tb = account_bus.CheckAccount(account_dto);
                    if (tb.Rows.Count > 0)
                    {
                        loginCheck = true;
                        auth = tb.Rows[0].Field<int>("auth");
                        MessageBox.Show("Đăng nhập thành công");
                        this.Close();
                    }
                    else
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu");
                }
                else
                {
                    MessageBox.Show("Để đăng nhập bạn cần phải nhập đầy đủ tài khoản và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
