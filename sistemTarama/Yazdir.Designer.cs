namespace sistemTarama
{
    partial class Yazdir
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.databaseDataSet = new sistemTarama.databaseDataSet();
            this.bilgisayarOzellikleriBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bilgisayarOzellikleriTableAdapter = new sistemTarama.databaseDataSetTableAdapters.bilgisayarOzellikleriTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bilgisayarOzellikleriBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.bilgisayarOzellikleriBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "sistemTarama.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(984, 461);
            this.reportViewer1.TabIndex = 0;
            // 
            // databaseDataSet
            // 
            this.databaseDataSet.DataSetName = "databaseDataSet";
            this.databaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bilgisayarOzellikleriBindingSource
            // 
            this.bilgisayarOzellikleriBindingSource.DataMember = "bilgisayarOzellikleri";
            this.bilgisayarOzellikleriBindingSource.DataSource = this.databaseDataSet;
            // 
            // bilgisayarOzellikleriTableAdapter
            // 
            this.bilgisayarOzellikleriTableAdapter.ClearBeforeFill = true;
            // 
            // Yazdir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Yazdir";
            this.Text = "Yazdir";
            this.Load += new System.EventHandler(this.Yazdir_Load);
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bilgisayarOzellikleriBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource bilgisayarOzellikleriBindingSource;
        private databaseDataSet databaseDataSet;
        private databaseDataSetTableAdapters.bilgisayarOzellikleriTableAdapter bilgisayarOzellikleriTableAdapter;
    }
}