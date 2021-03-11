using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace sistemTarama
{
    public partial class Yazdir : Form
    {
        public Yazdir()
        {
            InitializeComponent();
        }

        private void Yazdir_Load(object sender, EventArgs e)
        {
            OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=database.accdb");
            baglan.Open();
            OleDbDataAdapter komut = new OleDbDataAdapter("select * from bilgisayarOzellikleri", baglan);
            DataSet ds = new DataSet();
            komut.Fill(ds, "bilgisayarOzellikleri");

            bilgisayarOzellikleriBindingSource.DataSource = ds;

            // TODO: This line of code loads data into the 'databaseDataSet.bilgisayarOzellikleri' table. You can move, or remove it, as needed.
            //this.bilgisayarOzellikleriTableAdapter.Fill(this.databaseDataSet.bilgisayarOzellikleri);

            this.reportViewer1.RefreshReport();
        }
    }
}
