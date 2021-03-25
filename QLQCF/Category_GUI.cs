﻿using System;
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
    public partial class Category_GUI : Form
    {
        public Category_GUI()
        {
            InitializeComponent();
        }

        Category_BUS category_bus = new Category_BUS();
        String id;

        private void Category_GUI_Load(object sender, EventArgs e)
        {
            DataTable tb = category_bus.GetAllCategory();

            dgvCategory.DataSource = tb;
            dgvCategory.Columns["id"].HeaderText = "Mã danh mục";
            dgvCategory.Columns["name"].HeaderText = "Tên danh mục";    

            foreach (DataGridViewColumn c in dgvCategory.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Corobel", 13F, GraphicsUnit.Pixel);
                c.HeaderCell.Style.Font = new Font("Corobel", 10F);
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            DataTable addCBSearch = new DataTable();
            addCBSearch.Columns.Add("DisplayMember");
            addCBSearch.Columns.Add("ValueMember");

            addCBSearch.Rows.Add("Mã danh mục", "id");
            addCBSearch.Rows.Add("Tên danh mục", "name");

            cbSearch.Items.Clear();
            cbSearch.DataSource = addCBSearch;
            cbSearch.DisplayMember = "DisplayMember";
            cbSearch.ValueMember = "ValueMember";
        }

        private void Clear()
        {
            txtID.Clear();
            txtCategoryName.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtID.Text) && !string.IsNullOrEmpty(txtCategoryName.Text))
            {
                if (category_bus.GetCategoryByID(txtID.Text).Rows.Count == 0)
                {
                    Category_DTO category_dto = new Category_DTO(txtID.Text, txtCategoryName.Text);

                    if (category_bus.AddNewCategory(category_dto))
                    {
                        MessageBox.Show("Thêm thành công");
                        dgvCategory.DataSource = category_bus.GetAllCategory();
                        Clear();
                    }

                    else
                    {
                        MessageBox.Show("Thêm không thành công");
                    }
                }
                else
                {
                    MessageBox.Show("Mã danh mục " + txtID.Text + " đã có trong cơ sở dữ liệu vui lòng chọn mã khác");
                }
            }
            else
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID.Text) && !string.IsNullOrEmpty(txtCategoryName.Text))
            {
                String idNew = txtID.Text;
                if (idNew == id)
                {
                    Category_DTO category_dto = new Category_DTO(id, txtCategoryName.Text);

                    if (category_bus.UpdateCategory(category_dto))
                    {
                        MessageBox.Show("Sửa thành công");
                        dgvCategory.DataSource = category_bus.GetAllCategory();
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
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá danh mục có mã " + txtID.Text + " không", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    if (category_bus.DeleteCategory(txtID.Text))
                    {
                        MessageBox.Show("Xoá thành công");
                        dgvCategory.DataSource = category_bus.GetAllCategory();
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
                MessageBox.Show("Hãy chọn danh mục cần xoá");
            }
        }

        private void dgvCategory_DoubleClick(object sender, EventArgs e)
        {
            txtID.Text = dgvCategory.CurrentRow.Cells[0].Value.ToString();
            txtCategoryName.Text = dgvCategory.CurrentRow.Cells[1].Value.ToString();
            id = dgvCategory.CurrentRow.Cells[0].Value.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(category_bus.GetAllCategory());
            DV.RowFilter = "" + cbSearch.SelectedValue + " like '%" + txtSearch.Text + "%'";
            dgvCategory.DataSource = DV;
        }
    }
}
