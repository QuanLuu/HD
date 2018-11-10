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
    public partial class FrmCheck : Form
    {
     
        public FrmCheck()
        {
            InitializeComponent();
        }

        public void KiemTraDL(string ncc, string loaidl)
        {
            DataTable data = Import_Manager.Instance.kiemtranhaplieu(ncc, loaidl);
            dtgKiemTra.DataSource = data;
        }
    }
}
