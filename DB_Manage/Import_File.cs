using DB_Manage.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLHH_CN_HD
{
    public partial class Import_File : Form
    {
        int id_ncc = 0;
        public Import_File()
        {
            InitializeComponent();
            
            DataTable data = Import_Manager.Instance.GetNCC();
            cbNCC.DisplayMember = "MA_NCC";
            cbNCC.ValueMember = "ID";
            cbNCC.DataSource = data;
        }

        private void chbTonghop_CheckedChanged(object sender, EventArgs e)
        {
            cbNCC.Enabled = true;
            if (chbTonghop.Checked)
            {
                cbNCC.Enabled = false;
                id_ncc = 9999;
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if(tbpath.Text == "")
            {
                MessageBox.Show("Vui lòng chọn file lấy dữ liệu");
                return;
            }
            id_ncc = (int)cbNCC.SelectedValue;
            int results = Import_Manager.Instance.ImportFileExcel(id_ncc, tbpath.Text, 1);  
            MessageBox.Show("Đã lấy dữ liệu xong");
        }

        private void tbpath_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbpath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Cursor Files|*.xls*";
            openFileDialog1.Title = "Select a Excel File";
  
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbpath.Text = openFileDialog1.FileName;
            }
        }
    }
}
