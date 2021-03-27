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
    public partial class Account_GUI : Form
    {
        Account_BUS account_bus = new Account_BUS();
        String id;

        public Account_GUI()
        {
            InitializeComponent();
        }

        private void Account_GUI_Load(object sender, EventArgs e)
        {
            DataTable tb = account_bus.GetAllAccount();

            dgvAccount.DataSource = tb;
            dgvAccount.Columns["user_name"].HeaderText = "Tài khoản";
            dgvAccount.Columns["password"].Visible = false;
            dgvAccount.Columns["name"].HeaderText = "Họ tên";
            dgvAccount.Columns["auth"].HeaderText = "Quyền";
            dgvAccount.Columns["gender"].HeaderText = "Gới tính";
            dgvAccount.Columns["phone"].HeaderText = "Điện thoại";
            dgvAccount.Columns["address"].HeaderText = "Địa chỉ";

            foreach (DataGridViewColumn c in dgvAccount.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Corobel", 13F, GraphicsUnit.Pixel);
                c.HeaderCell.Style.Font = new Font("Corobel", 10F);
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            DataTable addCBAuth = new DataTable();
            addCBAuth.Columns.Add("DisplayMember");
            addCBAuth.Columns.Add("ValueMember");

            addCBAuth.Rows.Add("Nhân viên", "Nhân viên");
            addCBAuth.Rows.Add("Admin", "Admin");

            cbAuth.Items.Clear();
            cbAuth.DataSource = addCBAuth;
            cbAuth.DisplayMember = "DisplayMember";
            cbAuth.ValueMember = "ValueMember";

            DataTable addCBGender = new DataTable();
            addCBGender.Columns.Add("DisplayMember");
            addCBGender.Columns.Add("ValueMember");

            addCBGender.Rows.Add("Nam", "Nam");
            addCBGender.Rows.Add("Nữ", "Nữ");
            addCBGender.Rows.Add("Khác", "Khác");

            cbGender.Items.Clear();
            cbGender.DataSource = addCBGender;
            cbGender.DisplayMember = "DisplayMember";
            cbGender.ValueMember = "ValueMember";

            DataTable addCBSearch = new DataTable();
            addCBSearch.Columns.Add("DisplayMember");
            addCBSearch.Columns.Add("ValueMember");

            addCBSearch.Rows.Add("Tài khoản", "user_name");
            addCBSearch.Rows.Add("Địa chỉ", "address");
            addCBSearch.Rows.Add("Họ tên", "name");
            addCBSearch.Rows.Add("Giới tính", "gender");
            
            cbSearch.Items.Clear();
            cbSearch.DataSource = addCBSearch;
            cbSearch.DisplayMember = "DisplayMember";
            cbSearch.ValueMember = "ValueMember";
        }

        private void Clear()
        {
            txtUserName.Clear();
            txtPassword.Clear();
            txtName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            cbAuth.SelectedIndex = 0;
            cbGender.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtUserName.Text) && !string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtPhone.Text) && !string.IsNullOrEmpty(txtAddress.Text))
            {
                if (account_bus.GetAccountByUserName(txtUserName.Text).Rows.Count == 0)
                {
                    Account_DTO account_dto = new Account_DTO(txtUserName.Text, txtUserName.Text, cbAuth.SelectedValue.ToString(), txtName.Text, cbGender.SelectedValue.ToString(), int.Parse(txtPhone.Text), txtAddress.Text);

                    if (account_bus.AddNewAccount(account_dto))
                    {
                        MessageBox.Show("Thêm thành công");
                        dgvAccount.DataSource = account_bus.GetAllAccount();
                        Clear();
                    }

                    else
                    {
                        MessageBox.Show("Thêm không thành công");
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản " + txtUserName.Text + " đã có trong cơ sở dữ liệu vui lòng chọn tài khoản khác");
                }
            }
            else
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserName.Text) && !string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtPhone.Text) && !string.IsNullOrEmpty(txtAddress.Text))
            {
                String idNew = txtUserName.Text;
                if (idNew == id)
                {
                    Account_DTO account_dto = new Account_DTO(txtUserName.Text, "", cbAuth.SelectedValue.ToString(), txtName.Text, cbGender.SelectedValue.ToString(), int.Parse(txtPhone.Text), txtAddress.Text);

                    if (account_bus.UpdateAccount(account_dto))
                    {
                        MessageBox.Show("Sửa thành công");
                        dgvAccount.DataSource = account_bus.GetAllAccount();
                        Clear();
                    }

                    else
                    {
                        MessageBox.Show("Sừa không thành công");
                    }
                }
                else
                    MessageBox.Show("Không thể thay đổi tài khoản");
            }
            else
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserName.Text))
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá nhân viên có mã " + txtUserName.Text + " không", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    if (account_bus.DeleteAccount(txtUserName.Text))
                    {
                        MessageBox.Show("Xoá thành công");
                        dgvAccount.DataSource = account_bus.GetAllAccount();
                        Clear();
                    }

                    else
                    {
                        MessageBox.Show("Xoá không thành công");
                    }
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn tài khoản cần xoá");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(account_bus.GetAllAccount());
            DV.RowFilter = "" + cbSearch.SelectedValue + " like '%" + txtSearch.Text + "%'";
            dgvAccount.DataSource = DV;
        }

        private void dgvAccount_DoubleClick(object sender, EventArgs e)
        {
            txtUserName.Text = dgvAccount.CurrentRow.Cells[0].Value.ToString();
            cbAuth.Text = dgvAccount.CurrentRow.Cells[2].Value.ToString();
            txtName.Text = dgvAccount.CurrentRow.Cells[3].Value.ToString();
            cbGender.Text = dgvAccount.CurrentRow.Cells[4].Value.ToString();
            txtPhone.Text = dgvAccount.CurrentRow.Cells[5].Value.ToString();
            txtAddress.Text = dgvAccount.CurrentRow.Cells[6].Value.ToString();
            id = dgvAccount.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserName.Text))
            {
                if (MessageBox.Show("Bạn có chắc chắn reset mật khẩu mặc định cho tài khoản " + txtUserName.Text + " không", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Account_DTO account_dto = new Account_DTO(txtUserName.Text, txtUserName.Text, "", "", "", 0, "");

                    if (account_bus.ChangePassword(account_dto))
                    {
                        MessageBox.Show("Cập nhật thành công");
                        dgvAccount.DataSource = account_bus.GetAllAccount();
                        Clear();
                    }

                    else
                    {
                        MessageBox.Show("Cập nhật không thành công");
                    }
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn danh mục cần cập nhật");
            }
        }

        private void txtPhone_Enter(object sender, EventArgs e)
        {
            if (txtPhone.Text == "Chỉ nhập số")
            {
                txtPhone.Clear();
                txtPhone.ForeColor = Color.Black;
            }
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                txtPhone.Text = "Chỉ nhập số";
                txtPhone.ForeColor = Color.Gray;
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
