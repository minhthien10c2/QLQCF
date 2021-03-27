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
    public partial class Product_GUI : Form
    {
        public Product_GUI()
        {
            InitializeComponent();
        }

        Product_BUS product_bus = new Product_BUS();
        Category_BUS category_bus = new Category_BUS();
        String id;
        private void Product_GUI_Load(object sender, EventArgs e)
        {
            DataTable tb = product_bus.GetAllProduct();
            
            dgvProduct.DataSource = tb;
            dgvProduct.Columns["id"].HeaderText = "Mã sản phẩm";
            dgvProduct.Columns["name"].HeaderText = "Tên sản phẩm";
            dgvProduct.Columns["price"].HeaderText = "Giá bán";
            dgvProduct.Columns["id_category"].Visible = false;
            dgvProduct.Columns["category_name"].HeaderText = "Danh mục";

            foreach (DataGridViewColumn c in dgvProduct.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Corobel", 13F, GraphicsUnit.Pixel);
                c.HeaderCell.Style.Font = new Font("Corobel", 10F);
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            cbCategory.DataSource = category_bus.GetAllCategory();
            cbCategory.DisplayMember = "name";
            cbCategory.ValueMember = "id";

            DataTable addCBSearch = new DataTable();
            addCBSearch.Columns.Add("DisplayMember");
            addCBSearch.Columns.Add("ValueMember");

            addCBSearch.Rows.Add("Mã sản phẩm", "id");
            addCBSearch.Rows.Add("Tên sản phẩm", "name");
            addCBSearch.Rows.Add("Danh mục", "category_name");

            cbSearch.Items.Clear();
            cbSearch.DataSource = addCBSearch;
            cbSearch.DisplayMember = "DisplayMember";
            cbSearch.ValueMember = "ValueMember";

        }

        private void Clear()
        {
            txtID.Clear();
            txtPrice.Clear();
            txtProductName.Clear();
            cbCategory.SelectedItem = 1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtID.Text) && !string.IsNullOrEmpty(txtProductName.Text) && !string.IsNullOrEmpty(txtPrice.Text))
            {
                if (product_bus.GetProductByID(txtID.Text).Rows.Count == 0)
                {
                    Product_DTO product_dto = new Product_DTO(txtID.Text, txtProductName.Text, float.Parse(txtPrice.Text), cbCategory.SelectedValue.ToString());

                    if (product_bus.AddNewProduct(product_dto))
                    {
                        MessageBox.Show("Thêm thành công");
                        dgvProduct.DataSource = product_bus.GetAllProduct();
                        Clear();
                    }

                    else
                    {
                        MessageBox.Show("Thêm không thành công");
                    }
                }
                else
                {
                    MessageBox.Show("Mã sản phẩm "+txtID.Text+" đã có trong cơ sở dữ liệu vui lòng chọn mã khác");
                }
            }
            else
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID.Text) && !string.IsNullOrEmpty(txtProductName.Text) && !string.IsNullOrEmpty(txtPrice.Text))
            {
                String idNew = txtID.Text;
                if (idNew == id)
                {
                    Product_DTO product_dto = new Product_DTO(id, txtProductName.Text, float.Parse(txtPrice.Text), cbCategory.SelectedValue.ToString());

                    if (product_bus.UpdateProduct(product_dto))
                    {
                        MessageBox.Show("Sửa thành công");
                        dgvProduct.DataSource = product_bus.GetAllProduct();
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

                    if (product_bus.DeleteProduct(txtID.Text))
                    {
                        MessageBox.Show("Xoá thành công");
                        dgvProduct.DataSource = product_bus.GetAllProduct();
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

        private void dgvProduct_DoubleClick(object sender, EventArgs e)
        {
            txtID.Text = dgvProduct.CurrentRow.Cells[0].Value.ToString();
            txtProductName.Text = dgvProduct.CurrentRow.Cells[1].Value.ToString();
            txtPrice.Text = dgvProduct.CurrentRow.Cells[2].Value.ToString();
            cbCategory.Text = dgvProduct.CurrentRow.Cells[4].Value.ToString();
            id = dgvProduct.CurrentRow.Cells[0].Value.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(product_bus.GetAllProduct());
            DV.RowFilter = "" + cbSearch.SelectedValue + " like '%" + txtSearch.Text + "%'";
            dgvProduct.DataSource = DV;
        }

        private void txtPrice_Enter(object sender, EventArgs e)
        {
            if (txtPrice.Text == "Chỉ nhập số")
            {
                txtPrice.Clear();
                txtPrice.ForeColor = Color.Black;
            }
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                txtPrice.Text = "Chỉ nhập số";
                txtPrice.ForeColor = Color.Gray;
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
