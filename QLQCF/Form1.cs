﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQCF
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        Login login;
        Bill_GUI bill_gui;
        Category_GUI category_gui;
        Product_GUI product_gui;
        Table_GUI table_gui;

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            login = new Login();
            login.ShowDialog();

            if (login.loginCheck == true)
            {
                quảnLýToolStripMenuItem.Enabled = true;
                đăngNhậpToolStripMenuItem.Enabled = false;
                đăngXuấtToolStripMenuItem.Enabled = true;
            }

            if (login.auth == 0)
            {
                quảnLýSảnPhẩmToolStripMenuItem.Enabled = false;
                quảnLýDanhMụcToolStripMenuItem.Enabled = false;
                quảnLýBànToolStripMenuItem.Enabled = false;
            }
            else
            {
                quảnLýSảnPhẩmToolStripMenuItem.Enabled = true;
                quảnLýDanhMụcToolStripMenuItem.Enabled = true;
                quảnLýBànToolStripMenuItem.Enabled = true;
                thốngKêToolStripMenuItem.Enabled = true;
            }
        }

        private void OpenChildForm(Form childform, object btnSender)
        {
            childform.Refresh();
            childform.TopLevel = false;
            childform.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(childform);
            childform.BringToFront();
            childform.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            quảnLýToolStripMenuItem.Enabled = false;
            đăngXuấtToolStripMenuItem.Enabled = false;
            tàiKhoảnToolStripMenuItem.Enabled = false;
            thốngKêToolStripMenuItem.Enabled = false;
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            quảnLýToolStripMenuItem.Enabled = false;
            đăngXuấtToolStripMenuItem.Enabled = false;
            tàiKhoảnToolStripMenuItem.Enabled = false;
            thốngKêToolStripMenuItem.Enabled = false;
            đăngNhậpToolStripMenuItem.Enabled = true;
        }

        private void quảnLýBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bill_gui = new Bill_GUI();
            panel1.Controls.Clear();
            OpenChildForm(bill_gui, sender);
        }

        private void quảnLýSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            product_gui = new Product_GUI();
            panel1.Controls.Clear();
            OpenChildForm(product_gui, sender);
        }

        private void quảnLýDanhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            category_gui = new Category_GUI();
            panel1.Controls.Clear();
            OpenChildForm(category_gui, sender);
        }

        private void quảnLýBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            table_gui = new Table_GUI();
            panel1.Controls.Clear();
            OpenChildForm(table_gui, sender);
        }
    }
}
