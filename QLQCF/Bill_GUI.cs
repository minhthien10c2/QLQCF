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
    public partial class Bill_GUI : Form
    {
        public Bill_GUI()
        {
            InitializeComponent();
        }

        Product_BUS product_bus = new Product_BUS();
        Category_BUS category_bus = new Category_BUS();
        Bill_BUS bill_bus = new Bill_BUS();
        Bill_Detail_BUS bill_detail_bus = new Bill_Detail_BUS();
        String id;
        double totalPrice = 0;

        private void Bill_GUI_Load(object sender, EventArgs e)
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

            cbProduct.DataSource = product_bus.GetAllProduct();
            cbProduct.DisplayMember = "name";
            cbProduct.ValueMember = "id";

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

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbProduct.DataSource = product_bus.GetProductByIDCategory(cbCategory.SelectedValue.ToString());
            cbProduct.DisplayMember = "name";
            cbProduct.ValueMember = "id";
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cbProduct.Text);
            int count = 0;
            DataTable dtProduct = product_bus.GetProductByID(cbProduct.SelectedValue.ToString());
            double price = dtProduct.Rows[0].Field<double>("price");
            for (int i = 0; i < lbxProduct.Items.Count; i++ )
            {
                if (cbProduct.Text == lbxProduct.Items[i].ToString().Substring(cbProduct.SelectedValue.ToString().Length + 3, cbProduct.Text.Length))
                {
                    MessageBox.Show(price.ToString());
                    count = int.Parse(lbxProduct.Items[i].ToString().Substring(lbxProduct.Items[i].ToString().Length - 1, 1));
                    lbxProduct.Items.RemoveAt(i);
                    break;
                }
            }

            lbxProduct.Items.Add(cbProduct.SelectedValue +" - "+ cbProduct.Text + " - SL: " + (count + 1));
            totalPrice += price;
            txtTotalPrice.Text = totalPrice.ToString();
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            if (lbxProduct.SelectedIndex != -1)
            {
                int count;
                String ID = lbxProduct.SelectedItem.ToString().Substring(0, lbxProduct.SelectedItem.ToString().IndexOf("-") - 1);
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá sản phẩm " + ID + " khỏi list", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    DataTable dtProduct = product_bus.GetProductByID(ID);
                    double price = dtProduct.Rows[0].Field<double>("price");

                    count = int.Parse(lbxProduct.SelectedItem.ToString().Substring(lbxProduct.SelectedItem.ToString().Length - 1, 1));
                    lbxProduct.Items.RemoveAt(lbxProduct.SelectedIndex);
                    totalPrice -= price * count;
                    txtTotalPrice.Text = totalPrice.ToString();
                }
            }
            else
                MessageBox.Show("Vui lòng chọn sản phẩm cần xoá");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID.Text) && !string.IsNullOrEmpty(txtTotalPrice.Text) && lbxProduct.Items.Count > 0)
            {
                if (bill_bus.GetBillByID(txtID.Text).Rows.Count == 0)
                {
                    Bill_DTO bill_dto = new Bill_DTO(txtID.Text, DateTime.Now, DateTime.Now, double.Parse(txtTotalPrice.Text), "MB01");

                    if (bill_bus.AddNewBill(bill_dto))
                    {
                        String IDProduct;
                        int Quantity;
                 
                        for (int i = 0; i < lbxProduct.Items.Count; i++)
                        {
                           IDProduct = lbxProduct.Items[i].ToString().Substring(0, lbxProduct.Items[i].ToString().IndexOf("-") - 1);
                           Quantity = int.Parse(lbxProduct.Items[i].ToString().Substring(lbxProduct.Items[i].ToString().Length - 1, 1));
                           Bill_Detail_DTO bill_detail_dto = new Bill_Detail_DTO(IDProduct, txtID.Text, Quantity);
                           bill_detail_bus.AddNewBill_Detail(bill_detail_dto);
                        }
                        MessageBox.Show("Thêm thành công");
                        dgvProduct.DataSource = product_bus.GetAllProduct();                     
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

    }
}
