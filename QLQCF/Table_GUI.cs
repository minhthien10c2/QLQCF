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
    public partial class Table_GUI : Form
    {
        public Table_GUI()
        {
            InitializeComponent();
        }

        Table_BUS table_bus = new Table_BUS();
        String id;

        private void Table_GUI_Load(object sender, EventArgs e)
        {
            DataTable tb = table_bus.GetAllTable();

            dgvTable.DataSource = tb;
            dgvTable.Columns["id"].HeaderText = "Mã bàn";
            dgvTable.Columns["name"].HeaderText = "Tên bàn";

            foreach (DataGridViewColumn c in dgvTable.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Corobel", 13F, GraphicsUnit.Pixel);
                c.HeaderCell.Style.Font = new Font("Corobel", 10F);
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            DataTable addCBSearch = new DataTable();
            addCBSearch.Columns.Add("DisplayMember");
            addCBSearch.Columns.Add("ValueMember");

            addCBSearch.Rows.Add("Mã bàn", "id");
            addCBSearch.Rows.Add("Tên bàn", "name");

            cbSearch.Items.Clear();
            cbSearch.DataSource = addCBSearch;
            cbSearch.DisplayMember = "DisplayMember";
            cbSearch.ValueMember = "ValueMember";

        }

        private void Clear()
        {
            txtID.Clear();
            txtTableName.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtID.Text) && !string.IsNullOrEmpty(txtTableName.Text))
            {
                if (table_bus.GetTableByID(txtID.Text).Rows.Count == 0)
                {
                    Table_DTO product_dto = new Table_DTO(txtID.Text, txtTableName.Text);

                    if (table_bus.AddNewTable(product_dto))
                    {
                        MessageBox.Show("Thêm thành công");
                        dgvTable.DataSource = table_bus.GetAllTable();
                        Clear();
                    }

                    else
                    {
                        MessageBox.Show("Thêm không thành công");
                    }
                }
                else
                {
                    MessageBox.Show("Mã sản phẩm " + txtID.Text + " đã có trong cơ sở dữ liệu vui lòng chọn mã khác");
                }
            }
            else
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID.Text) && !string.IsNullOrEmpty(txtTableName.Text))
            {
                String idNew = txtID.Text;
                if (idNew == id)
                {
                    Table_DTO product_dto = new Table_DTO(id, txtTableName.Text);

                    if (table_bus.UpdateTable(product_dto))
                    {
                        MessageBox.Show("Sửa thành công");
                        dgvTable.DataSource = table_bus.GetAllTable();
                        Clear();
                    }

                    else
                    {
                        MessageBox.Show("Sừa không thành công");
                    }
                }
                else
                    MessageBox.Show("Không thể thay đổi mã");
            }
            else
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID.Text))
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá sản phẩm có mã " + txtID.Text + " không", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    if (table_bus.DeleteTable(txtID.Text))
                    {
                        MessageBox.Show("Xoá thành công");
                        dgvTable.DataSource = table_bus.GetAllTable();
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
                MessageBox.Show("Hãy chọn sản phẩm cần xoá");
            }
        }

        private void dgvTable_DoubleClick(object sender, EventArgs e)
        {
            txtID.Text = dgvTable.CurrentRow.Cells[0].Value.ToString();
            txtTableName.Text = dgvTable.CurrentRow.Cells[1].Value.ToString();
            id = dgvTable.CurrentRow.Cells[0].Value.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(table_bus.GetAllTable());
            DV.RowFilter = "" + cbSearch.SelectedValue + " like '%" + txtSearch.Text + "%'";
            dgvTable.DataSource = DV;
        }
    }
}
