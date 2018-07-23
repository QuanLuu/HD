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
    public partial class FrmMaSo : Form
    {
        public FrmMaSo()
        {
            InitializeComponent();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (tbmssai.Text != "" && tbmsdung.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc muốn sửa mã số?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
                try
                {
                    int result = Import_Manager.Instance.UpdateMASO(tbmssai.Text, tbmsdung.Text);
                    tbmssai.Text = "";
                    tbmsdung.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (tbmssai.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa mã số: " + tbmssai.Text, "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
                try
                {
                    int result = Import_Manager.Instance.DeleteMASO(tbmssai.Text);
                    tbmssai.Text = "";
                    tbmsdung.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
