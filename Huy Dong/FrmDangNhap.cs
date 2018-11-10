using DB_Manage;
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
    public partial class FrmDangNhap : Form
    {
 
        FrmMain f;
        public FrmDangNhap()
        {
            InitializeComponent();
           
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (tbmk.Text == "") return;
            try
            {
                DataTable data = Import_Manager.Instance.GetUser(tbten.Text, tbmk.Text);
                int kqcheck = data.Rows.Count;
                if (kqcheck > 0)
                {
                    f.tendn = tbten.Text;
                    f.id_user = Int32.Parse(data.Rows[0][0].ToString());
                    f.kholamviec = data.Rows[0][4].ToString();
                    f.quyentruycap = data.Rows[0][3].ToString();
                    f.GetKhoTheoUser();
                    f.ribbon();
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Không đúng mật khẩu");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           
        }
        private void main_close(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void tbmk_Enter(object sender, EventArgs e)
        {
           
        }

        private void tbmk_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return) btnDangNhap_Click(btnDangNhap, e);
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            f = new FrmMain();
            f.ShowInTaskbar = true;
            f.FormClosing += main_close;
        }
    }
}
