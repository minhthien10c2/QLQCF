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
            DataTable tb = bill_bus.GetAllBill();

            dgvBill.DataSource = tb;
            dgvBill.Columns["id"].HeaderText = "Mã hóa đơn";
            dgvBill.Columns["check_in"].HeaderText = "Ngày bán";
            dgvBill.Columns["total_price"].HeaderText = "Tổng tiền";
            dgvBill.Columns["id_table"].Visible = false;
            dgvBill.Columns["name"].HeaderText = "Bàn";

            foreach (DataGridViewColumn c in dgvBill.Columns)
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

            addCBSearch.Rows.Add("Mã hóa đơn", "id");
            addCBSearch.Rows.Add("Bàn", "name");

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
            totalPrice = 0;
            MessageBox.Show(cbProduct.Text);
            int count = 0;
            for (int i = 0; i < lbxProduct.Items.Count; i++ )
            {
                if (cbProduct.Text == lbxProduct.Items[i].ToString().Substring(cbProduct.SelectedValue.ToString().Length + 3, cbProduct.Text.Length))
                {
                    count = int.Parse(lbxProduct.Items[i].ToString().Substring(lbxProduct.Items[i].ToString().Length - 1, 1));
                    lbxProduct.Items.RemoveAt(i);
                    break;
                }
            }

            lbxProduct.Items.Add(cbProduct.SelectedValue +" - "+ cbProduct.Text + " - SL: " + (count + 1));
            
            for (int i = 0; i < lbxProduct.Items.Count; i++)
            {
                
                double priceOneProduct = 0;

                String IDProduct = lbxProduct.Items[i].ToString().Substring(0, lbxProduct.Items[i].ToString().IndexOf("-") - 1);
                DataTable dtProduct = product_bus.GetProductByID(IDProduct);
                double price = dtProduct.Rows[0].Field<double>("price");
                int countPrice = int.Parse(lbxProduct.Items[i].ToString().Substring(lbxProduct.Items[i].ToString().Length - 1, 1));
                priceOneProduct = price * countPrice;

                totalPrice += priceOneProduct;
            }
            txtTotalPrice.Text = totalPrice.ToString();
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            totalPrice = 0;
            if (lbxProduct.SelectedIndex != -1)
            {
                int count;
                String ID = lbxProduct.SelectedItem.ToString().Substring(0, lbxProduct.SelectedItem.ToString().IndexOf("-") - 1);
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá sản phẩm " + ID + " khỏi list", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    count = int.Parse(lbxProduct.SelectedItem.ToString().Substring(lbxProduct.SelectedItem.ToString().Length - 1, 1));
                    lbxProduct.Items.RemoveAt(lbxProduct.SelectedIndex);

                    for (int i = 0; i < lbxProduct.Items.Count; i++)
                    {

                        double priceOneProduct = 0;

                        String IDProduct = lbxProduct.Items[i].ToString().Substring(0, lbxProduct.Items[i].ToString().IndexOf("-") - 1);
                        DataTable dtProduct = product_bus.GetProductByID(IDProduct);
                        double price = dtProduct.Rows[0].Field<double>("price");
                        int countPrice = int.Parse(lbxProduct.Items[i].ToString().Substring(lbxProduct.Items[i].ToString().Length - 1, 1));
                        priceOneProduct = price * countPrice;

                        totalPrice += priceOneProduct;
                    }
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
                    Bill_DTO bill_dto = new Bill_DTO(txtID.Text, DateTime.Now, double.Parse(txtTotalPrice.Text), "MB01");

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
                        dgvBill.DataSource = bill_bus.GetAllBill();              
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

        private void dgvProduct_DoubleClick(object sender, EventArgs e)
        {
            txtID.Text = dgvBill.CurrentRow.Cells[0].Value.ToString();
            txtTotalPrice.Text = dgvBill.CurrentRow.Cells[2].Value.ToString();
            id = dgvBill.CurrentRow.Cells[0].Value.ToString();           

            DataTable tb = bill_detail_bus.GetBill_DetailByID(id);
            if (tb.Rows.Count > 0)
            {
                lbxProduct.Items.Clear();
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    int quantity = tb.Rows[i].Field<int>("quantity");
                    String idProduct = tb.Rows[i].Field<String>("id_product");
                    DataTable tbProduct = product_bus.GetProductByID(idProduct);
                    String nameProduct = tbProduct.Rows[0].Field<String>("name");
                    lbxProduct.Items.Add(idProduct + " - " + nameProduct + " - SL: " + quantity);
                }
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID.Text) && !string.IsNullOrEmpty(txtTotalPrice.Text) && lbxProduct.Items.Count > 0)
            {         
                String idNew = txtID.Text;
                if (idNew == id)
                {
                    Bill_DTO bill_dto = new Bill_DTO(txtID.Text, DateTime.Now, double.Parse(txtTotalPrice.Text), "MB01");

                    if (bill_bus.UpdateBill(bill_dto) && bill_detail_bus.DeleteBill_Detail(id))
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
                        MessageBox.Show("Sửa thành công");
                        dgvBill.DataSource = bill_bus.GetAllBill();
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
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá hóa đơn có mã " + txtID.Text + " không", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (bill_detail_bus.DeleteBill_Detail(txtID.Text))
                    {
                        if (bill_bus.DeleteBill(txtID.Text))
                        {
                            MessageBox.Show("Xoá thành công");
                            dgvBill.DataSource = bill_bus.GetAllBill();
                        }

                        else
                        {
                            MessageBox.Show("Xoá không thành công");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn hóa đơn cần xoá");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(bill_bus.GetAllBill());
            DV.RowFilter = "" + cbSearch.SelectedValue + " like '%" + txtSearch.Text + "%'";
            dgvBill.DataSource = DV;
        }

    }
}
