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
    public partial class ChangePassword_GUI : Form
    {
        public String account;
        public ChangePassword_GUI()
        {
            InitializeComponent();
        }
        
        private void ChangePassword_GUI_Load(object sender, EventArgs e)
        {

        }

        Account_BUS account_bus = new Account_BUS();

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Text) && !string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                if (txtPassword.Text == txtConfirmPassword.Text)
                {
                    Account_DTO account_dto = new Account_DTO(account, txtConfirmPassword.Text, "", "", "", 0, "");
                    if (account_bus.ChangePassword(account_dto))
                    {
                        MessageBox.Show("Sửa thành công");
                        txtConfirmPassword.Clear();
                        txtPassword.Clear();
                    }

                    else
                    {
                        MessageBox.Show("Sừa không thành công");
                    }
                }
                else
                {
                    MessageBox.Show("Xác nhận mật khẩu sai, vui lòng nhập lại");
                }
            }
            else
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin!");
            }
        }
    }
}
