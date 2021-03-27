namespace QLQCF
{
    partial class SalesReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.DataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QLCFDataSet = new QLQCF.QLCFDataSet();
            this.billBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.billTableAdapter = new QLQCF.QLCFDataSetTableAdapters.billTableAdapter();
            this.DataTable1TableAdapter = new QLQCF.QLCFDataSetTableAdapters.DataTable1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLCFDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.billBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DataTable1BindingSource
            // 
            this.DataTable1BindingSource.DataMember = "DataTable1";
            this.DataTable1BindingSource.DataSource = this.QLCFDataSet;
            // 
            // QLCFDataSet
            // 
            this.QLCFDataSet.DataSetName = "QLCFDataSet";
            this.QLCFDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // billBindingSource
            // 
            this.billBindingSource.DataMember = "bill";
            this.billBindingSource.DataSource = this.QLCFDataSet;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.billBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLQCF.SalesReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(629, 284);
            this.reportViewer1.TabIndex = 0;
            // 
            // billTableAdapter
            // 
            this.billTableAdapter.ClearBeforeFill = true;
            // 
            // DataTable1TableAdapter
            // 
            this.DataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // SalesReport
            // 
            this.ClientSize = new System.Drawing.Size(629, 284);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SalesReport";
            this.Load += new System.EventHandler(this.ReportView_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLCFDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.billBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource billBindingSource;
        private QLCFDataSet QLCFDataSet;
        private QLCFDataSetTableAdapters.billTableAdapter billTableAdapter;
        private System.Windows.Forms.BindingSource DataTable1BindingSource;
        private QLCFDataSetTableAdapters.DataTable1TableAdapter DataTable1TableAdapter;
    }
}