using DB_Manage.BLL;
using DevComponents.DotNetBar;
using QLHH_CN_HD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Manage
{
    public partial class FrmMain : DevComponents.DotNetBar.Office2007RibbonForm
    {
        int Action = 0;
        public string tendn;
        public int id_user;
        public string kholamviec;
        public string quyentruycap ="";
        public string kiemtra = "Xuat Kho";
        public FrmMain()
        {
            InitializeComponent();
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["FrmDangNhap"];
            ribNhapXuatKho.Select();
            tabControlMain.SelectedTabIndex = 5;
            checkedListBoxQuyenTruyCap.Items.Clear();
            datagridviewspeed();
            //GetKhoTheoUser();
            getHH();
            getNCC();
            getKH();
            gettaixe();
            getXeVC();
            getAllXeVC();
            getXeKH();
            getromooc();
            getChuyenDoiNCC();
            dtpNgayKTNKHH.Value = DateTime.Now;
            dtpNgayBDNKHH.Value = DateTime.Now.AddDays(-7);
            dtpKTXuatKho.Value = DateTime.Now;
            dtpBDXuatKho.Value = DateTime.Now.AddDays(-7);
            dtpKTNhapKhoFilter.Value = DateTime.Now;
            dtpBDNhapKhoFilter.Value = DateTime.Now.AddDays(-7);
            //getnhapkho();
            //getNKHH();
            //getNhatKyNCC();
            //getxuatkho();
            //SetDropDown(this.panelXuatKho);
            //SetDropDown(this.panelNhapKho);
            //SetDropDown(this.panelNKNCC);
  
            GetDSKho();
            getdongiavckh();
            getDCGiaKH();
            getDGVCKho();
            getDonGiaDCNCC();
            tbNamCk1.Text = DateTime.Now.Year.ToString();
            tbThangCK1.Text = DateTime.Now.Month.ToString();
            dtpNGayBDTongHopSLH.Value = DateTime.Now;
            dtpNgayKTTongHopSLH.Value = DateTime.Now.AddDays(7);
        }
        void getDGVCKho()
        {
            DataTable data = Import_Manager.Instance.getDonGiaVCKho(tbspDGVCKho.Text);
            dtgDGVCKho.DataSource = data;
        }

        void getDonGiaDCNCC()
        {
            DataTable data = Import_Manager.Instance.getDonGiaDCNCC(tbkhDGDCNCC.Text, tbSPDGDCNCC.Text, tbNCCDGDCNCC.Text);
            dtgDGDCNCC.DataSource = data;
        }

        void datagridviewspeed()
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dtgNKNCC, new object[] { true });

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dtgTongHopSLH, new object[] { true });

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dtgdongiangay, new object[] { true });

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dtgNhapKho, new object[] { true });

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dtgXuatKho, new object[] { true });

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dtgKH, new object[] { true });

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dtgXeKH, new object[] { true });

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dtgDCGiaKH, new object[] { true });
        }
      void getHH()
        {
            DataTable data = Import_Manager.Instance.GetHH();
            dtgHangHoa.DataSource = data;
            cbTenHangDGGoc.DisplayMember = "TEN_HANG";
            cbTenHangDGGoc.DataSource = data;
           
            cbHHNKHH.BindingContext = new BindingContext();
            cbHHNKHH.DisplayMember = "TEN_HANG";
            cbHHNKHH.DataSource = data;
            cbhhNhapKho.BindingContext = new BindingContext();
            cbhhNhapKho.DisplayMember = "TEN_HANG";
            cbhhNhapKho.DataSource = data;
            cbHHNKNCC.BindingContext = new BindingContext();
            cbHHNKNCC.DisplayMember = "TEN_HANG";
            cbHHNKNCC.DataSource = data;
            cbHHXuatKho.BindingContext = new BindingContext();
            cbHHXuatKho.DisplayMember = "TEN_HANG";
            cbHHXuatKho.DataSource = data;
           

            cbHHCK1.BindingContext = new BindingContext();
            cbHHCK1.DisplayMember = "TEN_HANG";
            cbHHCK1.DataSource = data;
            cbHHCK2.BindingContext = new BindingContext();
            cbHHCK2.DisplayMember = "TEN_HANG";
            cbHHCK2.DataSource = data;

            cbSPDCGiaKH.BindingContext = new BindingContext();
            cbSPDCGiaKH.DisplayMember = "TEN_HANG";
            cbSPDCGiaKH.DataSource = data;

            cbSpDGVCKho.BindingContext = new BindingContext();
            cbSpDGVCKho.DisplayMember = "TEN_HANG";
            cbSpDGVCKho.DataSource = data;

            cbSPDGDCNCC.BindingContext = new BindingContext();
            cbSPDGDCNCC.DisplayMember = "TEN_HANG";
            cbSPDGDCNCC.DataSource = data;
        }

        void PopulateStringGrid(DataGridView aGrid, DataTable data)
        {
            aGrid.RowCount = 2;
            aGrid.ColumnCount = data.Columns.Count;
           
            for (int i = 0;i< data.Rows.Count; i++)
            {
                for(int j = 0; j< data.Columns.Count; j++)
                {
                    aGrid.Rows[i+1].Cells[j].Value = data.Rows[i][j].ToString(); 
                }
                aGrid.RowCount += 1;
            }

        }
       void getdongiagoc(string mahh)
        {
            DataTable data = Import_Manager.Instance.GetDGGoc(mahh);
            dtgDGGoc.DataSource = data;
        }
        void getNKHH()
        {
            DataTable data = Import_Manager.Instance.getNKHH(dtpNgayBDNKHH.Value, dtpNgayKTNKHH.Value, tbNCCNKHH.Text, tbTenHangNKHH.Text, tbKHFilterNKHH.Text, tbBienSoFilerNKHH.Text, tbTaiXeFilerNKHH.Text);
            dtgSLH.DataSource = data;
        }
        void getNhatKyNCC()
        {
            DataTable data = Import_Manager.Instance.getNhatKyNCC(dtpBDLayHangNCC.Value, dtpKTLayHangNCC.Value, tbNCCNKNCC.Text, tbHHNKNCCFilter.Text, tbKHNKNCCFilter.Text, tbbiensonhatkynccfilter.Text, tbtaixenknccfilter.Text);
            dtgNKNCC.DataSource = data;
        }
        void getXeVC()
        {
            DataTable data = Import_Manager.Instance.getXe(tbBienSoFilter.Text);
            dtgXeVC.DataSource = data;
            //cbBienSoNhapKho.DisplayMember = "BIEN_SO";
            //cbBienSoNhapKho.DataSource = data;  
        }

        void getMaSoXuatKho()
        {
            cbMaSoXuatKho.Text = "";
            DataTable data = Import_Manager.Instance.GetMasoXuatKho(cbNCCXuatKho.Text, cbHHXuatKho.Text);
            cbMaSoXuatKho.DisplayMember = "MA_SO";
            cbMaSoXuatKho.DataSource = data;
        }
        void getck1()
        {
            if (tbNamCk1.Text != "" && tbThangCK1.Text != "")
            {
                DataTable data = Import_Manager.Instance.getck1(Int32.Parse(tbNamCk1.Text), Int32.Parse(tbThangCK1.Text));
                dtgCK1.DataSource = data;
            }
        }
        void getck2()
        {       
                DataTable data = Import_Manager.Instance.getck2(tbKHCK2.Text);
                dtgCK2.DataSource = data;
        }

      
        void GetDSKho()
        {
            DataTable data = Import_Manager.Instance.GetDanhSachKho();
            for(int i = 0; i < data.Rows.Count; i ++)
            {
                checkedListBoxKhoNhapLieu.Items.Add(data.Rows[i][1]);
            }
          
        }

        void tonghopSLH()
        {
            DataTable data = Import_Manager.Instance.tonghopSLH(dtpNGayBDTongHopSLH.Value, dtpNgayKTTongHopSLH.Value, tbNCCTongHopSLHFilter.Text, tbHHTongHopSLHFilter.Text, tbKHTongHopSLH.Text);
            dtgTongHopSLH.DataSource = data;
        }
        public void GetKhoTheoUser()
        {
            DataTable data = Import_Manager.Instance.GetKhoLamViecUser(kholamviec);
            cbNCCNhapKho.DisplayMember = "MA_NCC";
            cbNCCNhapKho.DataSource = data;
            cbNCCXuatKho.BindingContext = new BindingContext();
            cbNCCXuatKho.DisplayMember = "MA_NCC";
            cbNCCXuatKho.DataSource = data;
            cbNCCDonGiaNgay.BindingContext = new BindingContext();
            cbNCCDonGiaNgay.DisplayMember = "MA_NCC";
            cbNCCDonGiaNgay.DataSource = data;

            cbNCCDGDCNCC.BindingContext = new BindingContext();
            cbNCCDGDCNCC.DisplayMember = "MA_NCC";
            cbNCCDGDCNCC.DataSource = data;

        }

        void getMaSoNhapKho()
        {
            DataTable data = Import_Manager.Instance.GetMasoNhapKho(cbhhNhapKho.Text);
            cbMaSoNhapKho.DisplayMember = "MA_SO";
            cbMaSoNhapKho.DataSource = data;
        }
        void getAllXeVC()
        {
            DataTable data = Import_Manager.Instance.getallxe();
            cbBienSoNKNCC.DisplayMember = "BIEN_SO";
            cbBienSoNKNCC.DataSource = data;
            cbBienSoXuatKho.BindingContext = new BindingContext();
            cbBienSoXuatKho.DisplayMember = "BIEN_SO_SHORT";
            cbBienSoXuatKho.ValueMember = "BIEN_SO";
            cbBienSoXuatKho.DataSource = data;
            DataTable xehuydong = Import_Manager.Instance.getxehuydong();
            cbBienSoNhapKho.DisplayMember = "BIEN_SO_SHORT";
            cbBienSoNhapKho.ValueMember = "BIEN_SO";
            cbBienSoNhapKho.DataSource = xehuydong;
        }
        void gettaixe()
        {
            DataTable data = Import_Manager.Instance.getTaiXe();
            cbTaiXeNhapKho.DisplayMember = "TAI_XE";
            cbTaiXeNhapKho.DataSource = data;
            cbTaiXeXuatKho.BindingContext = new BindingContext();
            cbTaiXeXuatKho.DisplayMember = "TAI_XE";
            cbTaiXeXuatKho.DataSource = data;
            cbTaiXeNKNCC.BindingContext = new BindingContext();
            cbTaiXeNKNCC.DisplayMember = "TAI_XE";
            cbTaiXeNKNCC.DataSource = data;
        }
        void getromooc()
        {
            DataTable data = Import_Manager.Instance.getRoMoooc();
            cbRoMocNhapKho.DisplayMember = "BIEN_SO_SHORT";
            cbRoMocNhapKho.ValueMember = "BIEN_SO";
            cbRoMocNhapKho.DataSource = data;
        }

        void getXeKH()
        {
            DataTable data = Import_Manager.Instance.getXeKH(tbBiensoXeKHFilter.Text);
            dtgXeKH.DataSource = data;
            //cbBienSoXuatKho.DisplayMember = "BIEN_SO";
            //cbBienSoXuatKho.DataSource = data;       
            //PopulateStringGrid(dtgXeKH, data);

        }
        public int gettontheomaso(string ms)
        {
            try
            {
                DataTable data = Import_Manager.Instance.gettontheomaso(ms);
                if (data.Rows.Count > 0)
                {
                    return Int32.Parse(data.Rows[0][0].ToString());
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }

        public string taophieuxuat()
        {
            try
            {
                DataTable data = Import_Manager.Instance.taophieuxuat(dtpNgayXuatKho.Value, cbNCCXuatKho.Text, cbKHXuatKho.Text);
                return data.Rows[0][0].ToString();
            }
            catch
            { return ""; }
        }
        
        public string getKHtheoBienSo(string bienso)
        {
            DataTable data = Import_Manager.Instance.getKHtheoBienSo(bienso);
            if(data.Rows.Count > 0)
            {
                return data.Rows[0][0].ToString();
            }
            else
            {
                return "HD";
            }
        }

        public string getbiensotheoduoixe(string bienso)
        {
            DataTable data = Import_Manager.Instance.laytenxetheoduoixe(bienso);
            if (data.Rows.Count > 0)
            {
                return data.Rows[0][0].ToString();
            }
            else
            {
                return "";
            }
        }
        public string getTXtheoBienSo(string bienso)
        {
            DataTable data = Import_Manager.Instance.getTXtheoBienSo(bienso);
            if (data.Rows.Count > 0)
            {
                return data.Rows[0][0].ToString();
            }
            else
            {
                return "";
            }
        }
        public void getnhapkho()
        {
            DataTable data = Import_Manager.Instance.getnhapkho(dtpBDNhapKhoFilter.Value, dtpKTNhapKhoFilter.Value,cbNCCNhapKho.Text, tbHHNhapKhoFilter.Text, tbMaSoNhapKhoFilter.Text);
            dtgNhapKho.DataSource = data;
        }
        void getdongiangay()
        {
            DataTable data = Import_Manager.Instance.dongiatheongay(dtpDonGiaNGay.Value, cbNCCDonGiaNgay.Text, tbHHDonGiaNgay.Text, tbKHDonGiaNgay.Text);
            dtgdongiangay.DataSource = data;
        }
        public int getdongiaxuatkho()
        {
            DataTable data = Import_Manager.Instance.dongiatheongay(dtpNgayXuatKho.Value, cbNCCXuatKho.Text, cbHHXuatKho.Text, cbKHXuatKho.Text);
            if (data.Rows.Count > 0)
            {
                return Int32.Parse(data.Rows[0][6].ToString());
            }
            else
            {
                return 0;
            }
        }
        
        public void ribbon()
        {
            foreach (BaseItem item in ribconManage.Items)
            {
                RibbonTabItem ribbonTab = item as RibbonTabItem;
                if (ribbonTab != null)
                {
                    RibbonPanel panel = ribbonTab.Panel;

                    foreach (Control panelControl in panel.Controls)
                    {
                        RibbonBar ribbonBar = panelControl as RibbonBar;

                        if (ribbonBar != null)
                        {
                            foreach (BaseItem ribbonBarItem in ribbonBar.Items)
                            {
                                if (ribbonBarItem.Tag != null)
                                {
                                    ribbonBarItem.Enabled = false;
                                    checkedListBoxQuyenTruyCap.Items.Add(ribbonBarItem.Tag.ToString());
                                    if (quyentruycap.Contains(ribbonBarItem.Tag.ToString() + ",") && quyentruycap != null) ribbonBarItem.Enabled = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        void getxuatkho()
        {
            DataTable data = Import_Manager.Instance.getxuatkho(dtpBDXuatKho.Value, dtpKTXuatKho.Value, cbNCCXuatKho.Text, tbKHXuatKhoFilter.Text, tbHHXuatKhoFilter.Text, tbMaSoXuatKhoFilter.Text, tbbiensoxuatkhofilter.Text, tbtxxuatkhofilter.Text);
            dtgXuatKho.DataSource = data;
        }
        void gettaikhoandangnhap()
        {
            DataTable data = Import_Manager.Instance.gettaikhoandangnhap();
            dtgTaiKhoanDN.DataSource = data;
        }
       
        void getNCC()
        {
            DataTable data = Import_Manager.Instance.GetNCC();
            dtgNCC.DataSource = data;
            cbNCCDGGoc.DisplayMember = "MA_NCC";
            cbNCCDGGoc.DataSource = data;

            cbNCCChuyenDoi.BindingContext = new BindingContext();
            cbNCCChuyenDoi.DisplayMember = "MA_NCC";
            cbNCCChuyenDoi.DataSource = data;
            cbNCCGoc.BindingContext = new BindingContext();
            cbNCCGoc.DisplayMember = "MA_NCC";
            cbNCCGoc.DataSource = data;
            cbNCCXeVC.BindingContext = new BindingContext();
            cbNCCXeVC.DisplayMember = "MA_NCC";
            cbNCCXeVC.DataSource = data;
            cbNCCNKHH.BindingContext = new BindingContext();
            cbNCCNKHH.DisplayMember = "MA_NCC";
            cbNCCNKHH.DataSource = data;

            cbNCCNKNCC.BindingContext = new BindingContext();
            cbNCCNKNCC.DisplayMember = "MA_NCC";
            cbNCCNKNCC.DataSource = data;
            cbNCCCK1.BindingContext = new BindingContext();
            cbNCCCK1.DisplayMember = "MA_NCC";
            cbNCCCK1.DataSource = data;
        }
        void getChuyenDoiNCC()
        {
            DataTable data = Import_Manager.Instance.chuyendoiNCC();
            dtgChuyenDoiNCC.DataSource = data;
        }

      void getKH()
        {
            DataTable data = Import_Manager.Instance.GetKH(tbKHFilter.Text);
            dtgKH.DataSource = data;
            cbKHNKHH.BindingContext = new BindingContext();
            cbKHNKHH.DisplayMember = "KHACH_HANG";
            cbKHNKHH.DataSource = data;
            cbKHXeKH.BindingContext = new BindingContext();
            cbKHXeKH.DisplayMember = "KHACH_HANG";
            cbKHXeKH.DataSource = data;
            cbKHNKNCC.BindingContext = new BindingContext();
            cbKHNKNCC.DisplayMember = "KHACH_HANG";
            cbKHNKNCC.DataSource = data;
            cbKHXuatKho.BindingContext = new BindingContext();
            cbKHXuatKho.DisplayMember = "KHACH_HANG";
            cbKHXuatKho.DataSource = data;
            cbKHCK1.BindingContext = new BindingContext();
            cbKHCK1.DisplayMember = "KHACH_HANG";
            cbKHCK1.DataSource = data;
            cbKHCK2.BindingContext = new BindingContext();
            cbKHCK2.DisplayMember = "KHACH_HANG";
            cbKHCK2.DataSource = data;

            cbKHDCGiaKH.BindingContext = new BindingContext();
            cbKHDCGiaKH.DisplayMember = "KHACH_HANG";
            cbKHDCGiaKH.DataSource = data;

            cbKHDGDCNCC.BindingContext = new BindingContext();
            cbKHDGDCNCC.DisplayMember = "KHACH_HANG";
            cbKHDGDCNCC.DataSource = data;
        }
        private void dtgHangHoa_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgHangHoa.CurrentRow != null)
            {
                getdongiagoc(dtgHangHoa.CurrentRow.Cells[1].Value.ToString());
                tbMaHH.Text = dtgHangHoa.CurrentRow.Cells[1].Value.ToString();
                tbTenHH.Text = dtgHangHoa.CurrentRow.Cells[2].Value.ToString();
                numKLHH.Text = dtgHangHoa.CurrentRow.Cells[3].Value.ToString();
                tbGhiChuHH.Text = dtgHangHoa.CurrentRow.Cells[4].Value.ToString();
            }
        }

       

        private void btnNewDGGoc_Click(object sender, EventArgs e)
        {
            if (Action != 0) MessageBox.Show("Bạn chưa lưu dữ liệu");
            Action = 1;
            panelDGGoc.Visible = true;
        }

        private void dtgDGGoc_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgDGGoc.CurrentRow != null )
            {
                dtpDGGoc.Value = DateTime.Parse(dtgDGGoc.CurrentRow.Cells[1].Value.ToString());      
                cbNCCDGGoc.Text = dtgDGGoc.CurrentRow.Cells[4].Value.ToString();
                tbNoiGNDGGoc.Text = dtgDGGoc.CurrentRow.Cells[5].Value.ToString();
                chbDuongboDGGoc.Checked = Boolean.Parse(dtgDGGoc.CurrentRow.Cells[6].Value.ToString());
                numDGGoc.Text = dtgDGGoc.CurrentRow.Cells[7].Value.ToString();
            }
        }

        private void btnSaveHH_Click(object sender, EventArgs e)
        {
            int idHH = 0;
            int currow = 0;
            if (Action == 2)
                { currow = dtgHangHoa.CurrentRow.Index; }
            else if (Action == 1)
                { currow = dtgHangHoa.Rows.Count - 1; }
            else
                { currow = 0; }
            if (dtgHangHoa.Rows.Count > 1 && dtgHangHoa.CurrentRow.Cells[0].Value.ToString() != "") idHH = (int)dtgHangHoa.CurrentRow.Cells[0].Value;

            try
            {       
                int results = Import_Manager.Instance.UpdateDMHH(Action, idHH, tbMaHH.Text, tbTenHH.Text, (int)numKLHH.Value, tbGhiChuHH.Text);

                getHH();
                if (dtgHangHoa.Rows.Count > 2) dtgHangHoa.CurrentCell = dtgHangHoa.Rows[dtgHangHoa.Rows.Count - 2].Cells[0];
                dtgHangHoa.CurrentCell = dtgHangHoa.Rows[currow].Cells[0];
                if (Action == 1)
                {
                    Action = 0;
                    btnNewHH_Click(btnNewHH, e);
                }
                else
                {
                    Action = 0;
                    Button curBut = sender as Button;
                    EnableControlDataEntry(curBut.Parent);
                    panelHH.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void EnableControlDataEntry(Control col)
        {
            if (Action != 0)
            {
                foreach (Control c in col.Controls)
                {
                    if (c.Tag != null)
                    {
                        if (c.Tag.ToString() == "New") c.Enabled = false;
                        if (c.Tag.ToString() == "Edit") c.Enabled = false;
                        if (c.Tag.ToString() == "Delete") c.Enabled = false;
                        if (c.Tag.ToString() == "Save") c.Enabled = true;
                        if (c.Tag.ToString() == "Cancel") c.Enabled = true;
                    }
                }
            }
            else
            {
                foreach (Control c in col.Controls)
                {
                    if (c.Tag != null)
                    {
                        if (c.Tag.ToString() == "New") c.Enabled = true;
                        if (c.Tag.ToString() == "Edit") c.Enabled = true;
                        if (c.Tag.ToString() == "Delete") c.Enabled = true;
                        if (c.Tag.ToString() == "Save") c.Enabled = false;
                        if (c.Tag.ToString() == "Cancel") c.Enabled = false;
                    }
                }
            }
        }

        private void btnNewHH_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            tbMaHH.Text = "";
            tbTenHH.Text = "";
            tbGhiChuHH.Text = "";
            Action = 1;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelHH.Visible = true;
        }

        private void btnCancelHH_Click(object sender, EventArgs e)
        {
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelHH.Visible = false;
        }

        private void btnDeleteHH_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            Action = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                Action = 0;
                return;
            }
            try
            {
                int results = Import_Manager.Instance.UpdateDMHH(Action, (int)dtgHangHoa.CurrentRow.Cells[0].Value, tbMaHH.Text, tbTenHH.Text, (int)numKLHH.Value, tbGhiChuHH.Text);
                getHH();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
        }

        private void btnEditHH_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }          
            Action = 2;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelHH.Visible = true;
        }

        private void btnNewDGGoc_Click_1(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            dtpDGGoc.Value = DateTime.Now;
            Action = 1;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelDGGoc.Visible = true;
        }

        private void btnSaveDGGoc_Click(object sender, EventArgs e)
        {
            int id = 0;
            int currow = 0;
            if (Action == 2)
                { currow = dtgDGGoc.CurrentRow.Index; }
            else if (Action == 1)
                { currow = dtgDGGoc.Rows.Count - 1; }
            else
                { currow = 0; }
            int duongbo = 0;
            if (chbDuongboDGGoc.Checked) duongbo = 1;
            if (dtgDGGoc.Rows.Count > 1 && dtgDGGoc.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgDGGoc.CurrentRow.Cells[0].Value;
            try
            {
                int results = Import_Manager.Instance.UpdateDGGoc(Action, id, dtpDGGoc.Value, cbTenHangDGGoc.Text, cbNCCDGGoc.Text, tbNoiGNDGGoc.Text, duongbo, (int)numDGGoc.Value);

                getdongiagoc(dtgHangHoa.CurrentRow.Cells[1].Value.ToString());
                if (dtgDGGoc.Rows.Count > 2) dtgDGGoc.CurrentCell = dtgDGGoc.Rows[dtgDGGoc.Rows.Count - 2].Cells[0];
                Action = 0;
                Button curBut = sender as Button;
                EnableControlDataEntry(curBut.Parent);
                panelDGGoc.Visible = false;
                dtgDGGoc.CurrentCell = dtgDGGoc.Rows[currow].Cells[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteDGGoc_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            Action = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                Action = 0;
                return;
            }
            try
            {
                int results = Import_Manager.Instance.UpdateDGGoc(Action, (int)dtgDGGoc.CurrentRow.Cells[0].Value, dtpDGGoc.Value, cbTenHangDGGoc.Text, cbNCCDGGoc.Text, tbNoiGNDGGoc.Text, 1, (int)numDGGoc.Value);
                getdongiagoc(dtgHangHoa.CurrentRow.Cells[1].Value.ToString());
                if (Action == 1)
                {
                    Action = 0;
                    btnNewDGGoc_Click(btnNewDGGoc, e);
                }
                else
                {
                    Action = 0;
                    Button curBut = sender as Button;
                    EnableControlDataEntry(curBut.Parent);
                    panelDGGoc.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnEditDGGoc_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            dtpDGGoc.Value = DateTime.Now;
            tbNoiGNDGGoc.Text = "";
            numDGGoc.Value = 0;
            chbDuongboDGGoc.Checked = true;
            Action = 2;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelDGGoc.Visible = true;
        }

        private void btnCancelDGGoc_Click(object sender, EventArgs e)
        {
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelDGGoc.Visible = false;
        }

        private void btnrbHangHoa_Click(object sender, EventArgs e)
        {
            tabControlMain.SelectedTabIndex = 0;
        }
      

        private void btnrbKH_Click(object sender, EventArgs e)
        {
            tabControlMain.SelectedTabIndex = 1;
        }

        private void btnNewKH_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            tbKH.Text = "";
            tbPLKH.Text = "";
            tbGhiChuKH.Text = "";
            Action = 1;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelKH.Visible = true;
        }

        private void btneditkh_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            Action = 2;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelKH.Visible = true;
        }

        private void btncancelkh_Click(object sender, EventArgs e)
        {
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelKH.Visible = false;
        }

        private void tbKHFilter_OnValueChanged(object sender, EventArgs e)
        {
            getKH();
        }

        private void dtgKH_SelectionChanged(object sender, EventArgs e)
        {
            if(dtgKH.CurrentRow != null)
            {
                tbKH.Text = dtgKH.CurrentRow.Cells[1].Value.ToString();
                tbPLKH.Text = dtgKH.CurrentRow.Cells[2].Value.ToString();
                tbGhiChuKH.Text = dtgKH.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void tabControlMain_SelectedTabChanging(object sender, TabStripTabChangingEventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu, vui lòng chọn Save hoặc Cancel");
                e.Cancel = true;
            }
        }

        private void btnsavekh_Click(object sender, EventArgs e)
        {
            int id = 0;
            int currow = 0;
            if (Action == 2)
                { currow = dtgKH.CurrentRow.Index; }
            else if (Action == 1)
                { currow = dtgKH.Rows.Count - 1; }
            else
                { currow = 0; }
            if (dtgKH.Rows.Count > 1 && dtgKH.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgKH.CurrentRow.Cells[0].Value;
            try
            {
               int results = Import_Manager.Instance.UpdateDMKH(Action, id, tbKH.Text, tbPLKH.Text, tbGhiChuKH.Text);

                getKH();
                if (dtgKH.Rows.Count > 2) dtgKH.CurrentCell = dtgKH.Rows[dtgKH.Rows.Count - 2].Cells[0];
                dtgKH.CurrentCell = dtgKH.Rows[currow].Cells[0];
                if (Action == 1)
                {
                    Action = 0;
                    btnNewKH_Click(btnNewKH, e);
                }
                else
                {
                    Action = 0;
                    Button curBut = sender as Button;
                    EnableControlDataEntry(curBut.Parent);
                    panelKH.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btndeletekh_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            Action = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                Action = 0;
                return;
            }
            try
            {
                int results = Import_Manager.Instance.UpdateDMKH(Action, (int)dtgKH.CurrentRow.Cells[0].Value, tbKH.Text, tbPLKH.Text, tbGhiChuKH.Text);
                getKH();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
        }


        private void btnrbNCC_Click(object sender, EventArgs e)
        {
            tabControlMain.SelectedTabIndex = 2;
        }


        private void dtgDieuChinhGiaKH_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void btnnewncc_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            tbMaNCC.Text = "";
            tbTenNCC.Text = "";
            tbGhiChuNCC.Text = "";
            Action = 1;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelNCC.Visible = true;
        }

        private void btneditncc_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
          
            Action = 2;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelNCC.Visible = true;
        }

        private void btncancelncc_Click(object sender, EventArgs e)
        {
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelNCC.Visible = false;
        }

        private void btnsavencc_Click(object sender, EventArgs e)
        {
            int id = 0;
            int currow = 0;
            if (Action == 2)
                { currow = dtgNCC.CurrentRow.Index; }
            else if (Action == 1)
                { currow = dtgNCC.Rows.Count - 1; }
            else
                { currow = 0; }
            if (dtgNCC.Rows.Count > 1 && dtgNCC.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgNCC.CurrentRow.Cells[0].Value;
            try
            {
                int results = Import_Manager.Instance.UpdateNCC(Action, id, tbMaNCC.Text, tbTenNCC.Text, tbGhiChuNCC.Text);

                getNCC();
                if (dtgNCC.Rows.Count > 2) dtgNCC.CurrentCell = dtgNCC.Rows[dtgNCC.Rows.Count - 2].Cells[0];
                
                dtgNCC.CurrentCell = dtgNCC.Rows[currow].Cells[0];
                if (Action == 1)
                {
                    Action = 0;
                    btnnewncc_Click(btnnewncc, e);
                }
                else
                {
                    Action = 0;
                    Button curBut = sender as Button;
                    EnableControlDataEntry(curBut.Parent);
                    panelNCC.Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btndeletencc_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            Action = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                Action = 0;
                return;
            }
            try
            {
                int results = Import_Manager.Instance.UpdateNCC(Action, (int)dtgNCC.CurrentRow.Cells[0].Value, tbMaNCC.Text, tbTenNCC.Text, tbGhiChuNCC.Text);
                getNCC();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
        }

        private void dtgNCC_SelectionChanged(object sender, EventArgs e)
        {
            if(dtgNCC.CurrentRow != null)
            {
                tbMaNCC.Text = dtgNCC.CurrentRow.Cells[1].Value.ToString();
                tbTenNCC.Text = dtgNCC.CurrentRow.Cells[2].Value.ToString();
                tbGhiChuNCC.Text  = dtgNCC.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void btnnewdongiancc_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
           
            Action = 1;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelChuyenDoiNCC.Visible = true;
        }

        private void btneditdongiancc_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            Action = 2;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelChuyenDoiNCC.Visible = true;
        }

        private void btncanceldongianncc_Click(object sender, EventArgs e)
        {
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelChuyenDoiNCC.Visible = false;
        }

        private void btnsavedongiancc_Click(object sender, EventArgs e)
        {
            int id = 0;
            int currow = 0;
            if (Action == 2)
             { currow = dtgChuyenDoiNCC.CurrentRow.Index; }
            else if (Action == 1)
                { currow = dtgChuyenDoiNCC.Rows.Count - 1; }
            else
                { currow = 0; }
            if (dtgChuyenDoiNCC.Rows.Count > 1 && dtgChuyenDoiNCC.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgChuyenDoiNCC.CurrentRow.Cells[0].Value;
            try
            {
                int results = Import_Manager.Instance.UpdateDonGiaChuyenDoiNCC(Action, id, cbNCCChuyenDoi.Text, cbNCCGoc.Text, tbGhiChuChuyenDoiNCC.Text);

                getChuyenDoiNCC();
                if (dtgChuyenDoiNCC.Rows.Count > 2) dtgChuyenDoiNCC.CurrentCell = dtgChuyenDoiNCC.Rows[dtgChuyenDoiNCC.Rows.Count - 2].Cells[0];
                dtgChuyenDoiNCC.CurrentCell = dtgChuyenDoiNCC.Rows[currow].Cells[0];
                if (Action == 1)
                {
                    Action = 0;
                    btnnewdongiancc_Click(btnnewdongiancc, e);
                }
                else
                {
                    Action = 0;
                    Button curBut = sender as Button;
                    EnableControlDataEntry(curBut.Parent);
                    panelChuyenDoiNCC.Visible = false;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btndeletedongiancc_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            Action = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                Action = 0;
                return;
            }
            try
            {
                int results = Import_Manager.Instance.UpdateDonGiaChuyenDoiNCC(Action, (int)dtgChuyenDoiNCC.CurrentRow.Cells[0].Value, cbNCCChuyenDoi.Text, cbNCCGoc.Text, tbGhiChuChuyenDoiNCC.Text);
                getChuyenDoiNCC();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
        }

        private void btnrbXevc_Click(object sender, EventArgs e)
        {
            tabControlMain.SelectedTabIndex = 3;
        }

        private void btnnewxevc_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            tbBienSoXe.Text = "";
            tbTaiXe.Text = "";
            tbGhiChuXevc.Text = "";
            cbNCCXeVC.Text = "HDVC";
            Action = 1;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelXeVC.Visible = true;
        }

        private void btneditxevc_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
           
            Action = 2;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelXeVC.Visible = true;
        }

        private void btncancelxevc_Click(object sender, EventArgs e)
        {
            
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelXeVC.Visible = false;
        }

        private void btnsavexevc_Click(object sender, EventArgs e)
        {
            int id = 0;
            int currow = 0;
            if (Action == 2)
            { currow = dtgXeVC.CurrentRow.Index; }
            else if (Action == 1)
            { currow = dtgXeVC.Rows.Count - 1; }
            else
            { currow = 0; }
            
            if (dtgXeVC.Rows.Count > 1 && dtgXeVC.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgXeVC.CurrentRow.Cells[0].Value;
            try
            {
                int results = Import_Manager.Instance.UpdateXeVC(Action, id, tbBienSoXe.Text, tbTaiXe.Text, cbNCCXeVC.Text, tbGhiChuXevc.Text);

                getXeVC();
                if (dtgXeVC.Rows.Count > 2) dtgXeVC.CurrentCell = dtgXeVC.Rows[dtgXeVC.Rows.Count - 2].Cells[0];
               
                dtgXeVC.CurrentCell = dtgXeVC.Rows[currow].Cells[0];
                if (Action == 1)
                {
                    Action = 0;
                    btnnewxevc_Click(btnnewxevc, e);
                }
                else
                {
                    Action = 0;
                    Button curBut = sender as Button;
                    EnableControlDataEntry(curBut.Parent);
                    panelXeVC.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btndeletexevc_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            Action = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                Action = 0;
                return;
            }
            try
            {
                int results = Import_Manager.Instance.UpdateXeVC(Action, (int)dtgXeVC.CurrentRow.Cells[0].Value, tbBienSoXe.Text, tbTaiXe.Text, cbNCCXeVC.Text, tbGhiChuXevc.Text);
                getXeVC();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
        }

        private void dtgXeVC_SelectionChanged(object sender, EventArgs e)
        {
            if(dtgXeVC.CurrentRow != null)
            {
                tbBienSoXe.Text = dtgXeVC.CurrentRow.Cells[1].Value.ToString();
                tbTaiXe.Text = dtgXeVC.CurrentRow.Cells[2].Value.ToString();
                cbNCCXeVC.Text = dtgXeVC.CurrentRow.Cells[3].Value.ToString();
                tbGhiChuXevc.Text = dtgXeVC.CurrentRow.Cells[4].Value.ToString();
            }
        }

        private void dtgChuyenDoiNCC_SelectionChanged(object sender, EventArgs e)
        {
            if(dtgChuyenDoiNCC.CurrentRow != null)
            {
                cbNCCChuyenDoi.Text = dtgChuyenDoiNCC.CurrentRow.Cells[1].Value.ToString();
                cbNCCGoc.Text = dtgChuyenDoiNCC.CurrentRow.Cells[2].Value.ToString();
                tbGhiChuChuyenDoiNCC.Text = dtgChuyenDoiNCC.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void buttonItemNKHH_Click(object sender, EventArgs e)
        {
            tabControlMain.SelectedTabIndex = 7;
            dtpDonGiaNGay.Value = DateTime.Now;
            //getdongiangay();
        }

        private void tbKHFilterNKHH_TextChanged(object sender, EventArgs e)
        {
            getNKHH();
        }

        private void tbBienSoFilerNKHH_TextChanged(object sender, EventArgs e)
        {
            getNKHH();
        }

        private void tbTenHangNKHH_TextChanged(object sender, EventArgs e)
        {
            getNKHH();
        }

        private void tbNCCNKHH_TextChanged(object sender, EventArgs e)
        {
            getNKHH();
        }

        private void tbTaiXeFilerNKHH_TextChanged(object sender, EventArgs e)
        {
            getNKHH();
        }

        private void dtpNgayBDNKHH_ValueChanged(object sender, EventArgs e)
        {
            getNKHH();
        }

        private void dtpNgayKTNKHH_ValueChanged(object sender, EventArgs e)
        {
            getNKHH();
        }

        private void btnnewnkhh_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            dtpNgayGNNKHH.Value = DateTime.Now;
            tbBienSoNKHH.Text = "";
            tbTaiXeNKHH.Text = "";
            tbGhiChuNKHH.Text = "";
            tbMaso.Text = "";
            numSoLuongNKHH.Value = 0;
            tbTM.Text = "";
            tbCRT.Text = "";
            tbThuTienNKHH.Text = "";
            Action = 1;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelNKHH.Visible = true;
        }

        private void btneditnkhh_Click(object sender, EventArgs e)
        {

            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
           
            Action = 2;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelNKHH.Visible = true;
        }

        private void btncancelnkhh_Click(object sender, EventArgs e)
        {
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelNKHH.Visible = false;
        }

        private void btnsavenkhh_Click(object sender, EventArgs e)
        {
            
            int id = 0;
            int currow = 0;
            if (Action == 2)
            { currow = dtgSLH.CurrentRow.Index; }
            else if (Action == 1)
            { currow = dtgSLH.Rows.Count - 1; }
            else
            { currow = 0; }

            if (dtgSLH.Rows.Count > 1 && dtgSLH.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgSLH.CurrentRow.Cells[0].Value;
            try
            {
                int results = Import_Manager.Instance.UpdatedNKHH(Action, id, dtpNgayGNNKHH.Value, cbNCCNKHH.Text, cbHHNKHH.Text, tbMaso.Text, tbNoiGNNKHH.Text, decimal.Parse(numSoLuongNKHH.Value.ToString()), tbTM.Text, tbBienSoNKHH.Text, cbKHNKHH.Text, tbCRT.Text, tbThuTienNKHH.Text, tbGhiChuNKHH.Text, tbTaiXeNKHH.Text);

                getNKHH();
               
                dtgSLH.CurrentCell = dtgSLH.Rows[currow].Cells[0];
                if (Action == 1)
                {
                    Action = 0;
                    btnnewnkhh_Click(btnnewnkhh, e);
                }
                else
                {
                    Action = 0;
                    Button curBut = sender as Button;
                    EnableControlDataEntry(curBut.Parent);
                    panelNKHH.Visible = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

        private void btndeletenkhh_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            Action = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                Action = 0;
                return;
            }
            try
            {
                int results = Import_Manager.Instance.UpdatedNKHH(Action, (int)dtgSLH.CurrentRow.Cells[0].Value, dtpNgayGNNKHH.Value, cbNCCNKHH.Text, cbHHNKHH.Text, tbMaso.Text, tbNoiGNNKHH.Text, decimal.Parse(numSoLuongNKHH.Value.ToString()), tbTM.Text, tbBienSoNKHH.Text, cbKHNKHH.Text, tbCRT.Text, tbThuTienNKHH.Text, tbGhiChuNKHH.Text, tbTaiXeNKHH.Text);
                getNKHH();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
        }

        private void dtgSLH_SelectionChanged(object sender, EventArgs e)
        {
            if(dtgSLH.CurrentRow != null && Action != 1)
            {
                dtpNgayBDNKHH.Value = DateTime.Parse(dtgSLH.CurrentRow.Cells[1].Value.ToString());
                cbNCCNKHH.Text = dtgSLH.CurrentRow.Cells[2].Value.ToString();
                cbHHNKHH.Text = dtgSLH.CurrentRow.Cells[3].Value.ToString();
                tbMaso.Text = dtgSLH.CurrentRow.Cells[4].Value.ToString();
                tbNoiGNNKHH.Text = dtgSLH.CurrentRow.Cells[5].Value.ToString();
                numSoLuongNKHH.Value = decimal.Parse(dtgSLH.CurrentRow.Cells[6].Value.ToString());
                tbTM.Text = dtgSLH.CurrentRow.Cells[7].Value.ToString();
                tbBienSoNKHH.Text = dtgSLH.CurrentRow.Cells[8].Value.ToString();
                cbKHNKHH.Text = dtgSLH.CurrentRow.Cells[9].Value.ToString();
                tbCRT.Text = dtgSLH.CurrentRow.Cells[10].Value.ToString();
                tbThuTienNKHH.Text = dtgSLH.CurrentRow.Cells[11].Value.ToString();
                tbGhiChuNKHH.Text = dtgSLH.CurrentRow.Cells[12].Value.ToString();
                tbTaiXeNKHH.Text = dtgSLH.CurrentRow.Cells[13].Value.ToString();
            }
        }

        private void buttonItemNHapXuaKho_Click(object sender, EventArgs e)
        {
            getnhapkho();
            getxuatkho();
            //GetKhoTheoUser();
            tabControlMain.SelectedTabIndex = 5;
            getMaSoNhapKho();
        }

        private void dtpBDNhapKhoFilter_ValueChanged(object sender, EventArgs e)
        {
            getnhapkho();
        }

        private void dtpKTNhapKhoFilter_ValueChanged(object sender, EventArgs e)
        {
            getnhapkho();
        }

        private void tbHHNhapKhoFilter_TextChanged(object sender, EventArgs e)
        {
            getnhapkho();
        }

        private void tbMaSoNhapKhoFilter_TextChanged(object sender, EventArgs e)
        {
            getnhapkho();
        }

        private void btnnewnhapkho_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }          
            tbGhiChuNhapKho.Text = "";

            Action = 1;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelNhapKho.Visible = true;
            dtpNhapKho.Value = DateTime.Now;
            dtpNhapKho.Select();
        }

        private void btneditnhapkho_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            Action = 2;
            if (dtgNhapKho.CurrentRow != null && dtgNhapKho.CurrentRow.Cells[0].Value.ToString() != "" && Action != 1)
            {
                if (Action != 0) cbNCCNhapKho.Text = dtgNhapKho.CurrentRow.Cells[1].Value.ToString();
                dtpNhapKho.Value = DateTime.Parse(dtgNhapKho.CurrentRow.Cells[2].Value.ToString());
                cbhhNhapKho.Text = dtgNhapKho.CurrentRow.Cells[3].Value.ToString();
                cbMaSoNhapKho.Text = dtgNhapKho.CurrentRow.Cells[4].Value.ToString();
                numSoBaoNhapKho.Text = dtgNhapKho.CurrentRow.Cells[5].Value.ToString();
                cbBienSoNhapKho.Text = dtgNhapKho.CurrentRow.Cells[6].Value.ToString();
                cbTaiXeNhapKho.Text = dtgNhapKho.CurrentRow.Cells[7].Value.ToString();
                cbRoMocNhapKho.Text = dtgNhapKho.CurrentRow.Cells[8].Value.ToString();
                tbGhiChuNhapKho.Text = dtgNhapKho.CurrentRow.Cells[9].Value.ToString();
            }
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelNhapKho.Visible = true;
        }

        private void btncancelnhapkho_Click(object sender, EventArgs e)
        {
          
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelNhapKho.Visible = false;
        }

        private void btnsavenhapkho_Click(object sender, EventArgs e)
        {
            
            int id = 0;
            int currow = 0;
            if (Action == 2)
            { currow = dtgNhapKho.CurrentRow.Index; }
            else if (Action == 1)
            { currow = dtgNhapKho.Rows.Count - 1; }
            else
            { currow = 0; }
            string bienso = cbBienSoNhapKho.Text;
            string romooc = cbRoMocNhapKho.Text;
            if (cbBienSoNhapKho.SelectedValue != null) bienso = cbBienSoNhapKho.SelectedValue.ToString();
            if (cbRoMocNhapKho.SelectedValue != null) romooc = cbRoMocNhapKho.SelectedValue.ToString();
            if (dtgNhapKho.Rows.Count > 1 && dtgNhapKho.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgNhapKho.CurrentRow.Cells[0].Value;
            try
            {
                DataTable checkmaso = Import_Manager.Instance.Checkmasonhapkho(cbMaSoNhapKho.Text);
                if(Int32.Parse(checkmaso.Rows[0][0].ToString()) > 0)
                {
                    MessageBox.Show("Trùng mã số, vui lòng kiểm tra lại");
                    return;
                }

                int results = Import_Manager.Instance.UpdatedNhapKho(Action, id, dtpNhapKho.Value, cbhhNhapKho.Text, cbMaSoNhapKho.Text, (int)numSoBaoNhapKho.Value, bienso, cbTaiXeNhapKho.Text, romooc, tbGhiChuNhapKho.Text, tendn, cbNCCNhapKho.Text);

                getnhapkho();
                
                dtgNhapKho.CurrentCell = dtgNhapKho.Rows[currow].Cells[0];
                if (Action == 1)
                {
                    Action = 0;
                    btnnewnhapkho_Click(btnnewnhapkho, e);
                }
                else
                {
                    Action = 0;
                    Button curBut = sender as Button;
                    EnableControlDataEntry(curBut.Parent);
                    panelNhapKho.Visible = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btndeletenhapkho_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            Action = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                Action = 0;
                return;
            }
            try
            {
                int results = Import_Manager.Instance.UpdatedNhapKho(Action, (int)dtgNhapKho.CurrentRow.Cells[0].Value, dtpNhapKho.Value, cbhhNhapKho.Text, cbMaSoNhapKho.Text, (int)numSoBaoNhapKho.Value, cbBienSoNhapKho.Text, cbTaiXeNhapKho.Text, cbRoMocNhapKho.Text, tbGhiChuNhapKho.Text, "admin", cbNCCNhapKho.Text);
                getnhapkho();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
        }

        private void tbBiensoXeKHFilter_OnValueChanged(object sender, EventArgs e)
        {
            getXeKH();
        }

        private void btnsavexekh_Click(object sender, EventArgs e)
        {
            int id = 0;
            int currow = 0;
            if (Action == 2)
            { currow = dtgXeKH.CurrentRow.Index; }
            else if (Action == 1)
            { currow = dtgXeKH.Rows.Count - 1; }
            else
            { currow = 0; }

            if (dtgXeKH.Rows.Count > 1 && dtgXeKH.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgXeKH.CurrentRow.Cells[0].Value;
            try
            {
                int results = Import_Manager.Instance.UpdateXeKH(Action, id, tbbiensoXeKH.Text, cbKHXeKH.Text, tbGhiChuXeKH.Text);

                getXeKH();
                if (dtgXeKH.Rows.Count > 2) dtgXeKH.CurrentCell = dtgXeKH.Rows[dtgXeKH.Rows.Count - 2].Cells[0];
               
                dtgXeKH.CurrentCell = dtgXeKH.Rows[currow].Cells[0];
                if (Action == 1)
                {
                    Action = 0;
                    btnnewxekh_Click(btnnewxekh, e);
                }
                else
                {
                    Action = 0;
                    Button curBut = sender as Button;
                    EnableControlDataEntry(curBut.Parent);
                    panelXeKH.Visible = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btndeletexekh_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            Action = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                Action = 0;
                return;
            }
            try
            {
                int results = Import_Manager.Instance.UpdateXeKH(Action, (int)dtgXeKH.CurrentRow.Cells[0].Value, tbbiensoXeKH.Text, cbKHXeKH.Text, tbGhiChuXeKH.Text);
                getXeKH();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
        }

        private void btnnewxekh_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            tbbiensoXeKH.Text = "";
            
            tbGhiChuXeKH.Text = "";
          
            Action = 1;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelXeKH.Visible = true;
        }

        private void btneditxekh_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
           
            Action = 2;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelXeKH.Visible = true;
        }

        private void btncancelxekh_Click(object sender, EventArgs e)
        {
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelXeKH.Visible = false;
        }

        private void dtgXeKH_SelectionChanged(object sender, EventArgs e)
        {
            if(dtgXeKH.CurrentRow != null)
            {
                tbbiensoXeKH.Text = dtgXeKH.CurrentRow.Cells[1].Value.ToString();
                cbKHXeKH.Text = dtgXeKH.CurrentRow.Cells[2].Value.ToString();
                tbGhiChuXeKH.Text = dtgXeKH.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void cbBienSoNhapKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Action==1) cbTaiXeNhapKho.Text = getTXtheoBienSo(cbBienSoNhapKho.SelectedValue.ToString());
        }

        private void cbBienSoXuatKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Action == 1)
            {
                cbKHXuatKho.Text = getKHtheoBienSo(cbBienSoXuatKho.SelectedValue.ToString());
                cbTaiXeXuatKho.Text = getTXtheoBienSo(cbBienSoXuatKho.SelectedValue.ToString());
            }
        }

        private void dtpBDLayHangNCC_ValueChanged(object sender, EventArgs e)
        {
            getNhatKyNCC();
        }

        private void dtpKTLayHangNCC_ValueChanged(object sender, EventArgs e)
        {
            getNhatKyNCC();
        }

        private void tbTenHangNKNCC_TextChanged(object sender, EventArgs e)
        {
            getNhatKyNCC();
        }

        private void tbMasoNKNCCFilter_TextChanged(object sender, EventArgs e)
        {
            getNhatKyNCC();
        }

        private void tbBienSoFilter_OnValueChanged(object sender, EventArgs e)
        {
            getXeVC();
        }

        private void buttonItemNKNCC_Click(object sender, EventArgs e)
        {
            getNhatKyNCC();
            tabControlMain.SelectedTabIndex = 6;
        }

        private void btnnewnkncc_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            tbMaSoNKNCC.Text = "";
            numSoLuongNKNCC.Value = 0;
            cbBienSoNKNCC.Text = "";
            cbKHNKNCC.Text = "";
            cbTaiXeNKNCC.Text = "";
            tbGhichuNKNCC.Text = "";
            dtpNgayNhanNKNCC.Value = DateTime.Now;
            dtpNgayNhanNKNCC.Select();
            Action = 1;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelNKNCC.Visible = true;
        }

        private void btneditnkncc_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            
            Action = 2;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelNKNCC.Visible = true;
        }

        private void btncancelnkncc_Click(object sender, EventArgs e)
        {
           
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelNKNCC.Visible = false;
        }

        private void btnsavenkncc_Click(object sender, EventArgs e)
        {
            
            int id = 0;
            int currow = 0;
            if (Action == 2)
            { currow = dtgNKNCC.CurrentRow.Index; }
            else if (Action == 1)
            { currow = dtgNKNCC.Rows.Count - 1; }
            else
            { currow = 0; }

            if (dtgNKNCC.Rows.Count > 1 && dtgNKNCC.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgNKNCC.CurrentRow.Cells[0].Value;
            try
            {
                int results = Import_Manager.Instance.UpdateNhatKyNCC(Action, id, cbNCCNKNCC.Text, dtpNgayNhanNKNCC.Value, cbHHNKNCC.Text, tbMaSoNKNCC.Text, tbNoiNhanNKNCC.Text,decimal.Parse(numSoLuongNKNCC.Value.ToString()),cbBienSoNKNCC.Text, cbKHNKNCC.Text, cbTaiXeNKNCC.Text, tbGhichuNKNCC.Text, id_user);

                getNhatKyNCC();
               
                dtgNKNCC.CurrentCell = dtgNKNCC.Rows[currow].Cells[0];
                if (Action == 1)
                {
                    Action = 0;
                    btnnewnkncc_Click(btnnewnkncc, e);
                }
                else
                {
                    Action = 0;
                    Button curBut = sender as Button;
                    EnableControlDataEntry(curBut.Parent);
                    panelNKNCC.Visible = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btndeletenkncc_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            Action = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                Action = 0;
                return;
            }
            try
            {
                int results = Import_Manager.Instance.UpdateNhatKyNCC(Action, Int32.Parse(dtgNKNCC.CurrentRow.Cells[0].Value.ToString()), cbNCCNKNCC.Text, dtpNgayNhanNKNCC.Value, cbHHNKNCC.Text, tbMaSoNKNCC.Text, tbNoiNhanNKNCC.Text, decimal.Parse(numSoLuongNKNCC.Value.ToString()), cbBienSoNKNCC.Text, cbKHNKNCC.Text, cbTaiXeNKNCC.Text, tbGhichuNKNCC.Text, 1);
                getNhatKyNCC();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
        }

        private void btnnewxuatkho_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            //cbMaSoXuatKho.Text = "";
            
            //cbKHXuatKho.Text = "";
            cbTaiXeXuatKho.Text = "";
            chbTienMatXuatKho.Checked = false;
            tbGhiChuXuatKho.Text = "";
            Action = 1;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelXuatKho.Visible = true;
            getMaSoXuatKho();
            dtpNgayXuatKho.Value = DateTime.Now;
            dtpNgayXuatKho.Select();
            TbPhieuXuat.Text = taophieuxuat();
            cbBienSoXuatKho.Text = "54-";
        }

        private void dtpBDXuatKho_ValueChanged(object sender, EventArgs e)
        {
            getxuatkho();
        }

        private void dtpKTXuatKho_ValueChanged(object sender, EventArgs e)
        {
            getxuatkho();
        }

        private void tbKHXuatKhoFilter_TextChanged(object sender, EventArgs e)
        {
            getxuatkho();
        }

        private void tbHHXuatKhoFilter_TextChanged(object sender, EventArgs e)
        {
            getxuatkho();
        }

        private void tbMaSoXuatKhoFilter_TextChanged(object sender, EventArgs e)
        {
            getxuatkho();
            getMaSoXuatKho();
        }

        private void cbNCCXuatKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            getxuatkho();
        }

        private void cbNCCNhapKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            getnhapkho();
            
        }

        private void btneditxuatkho_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            if (dtgXuatKho.CurrentRow != null && dtgXuatKho.CurrentRow.Cells[0].Value.ToString() != "" && Action != 1)
            {

                if (Action != 0) cbNCCXuatKho.Text = dtgXuatKho.CurrentRow.Cells[1].Value.ToString();
                dtpNgayXuatKho.Value = DateTime.Parse(dtgXuatKho.CurrentRow.Cells[2].Value.ToString());
                cbHHXuatKho.Text = dtgXuatKho.CurrentRow.Cells[3].Value.ToString();
                TbPhieuXuat.Text = dtgXuatKho.CurrentRow.Cells[4].Value.ToString(); ;
                cbMaSoXuatKho.Text = dtgXuatKho.CurrentRow.Cells[5].Value.ToString();
                numSoBaoXuatKho.Text = dtgXuatKho.CurrentRow.Cells[6].Value.ToString();
                cbBienSoXuatKho.Text = dtgXuatKho.CurrentRow.Cells[7].Value.ToString();
                cbKHXuatKho.Text = dtgXuatKho.CurrentRow.Cells[8].Value.ToString();
                cbTaiXeXuatKho.Text = dtgXuatKho.CurrentRow.Cells[9].Value.ToString();
                chbTienMatXuatKho.Checked = bool.Parse(dtgXuatKho.CurrentRow.Cells[10].Value.ToString());
                numTienMatXuatKho.Text = dtgXuatKho.CurrentRow.Cells[11].Value.ToString();
                tbGhiChuXuatKho.Text = dtgXuatKho.CurrentRow.Cells[12].Value.ToString();
            }
            Action = 2;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelXuatKho.Visible = true;
        }

        private void btncancelxuatkho_Click(object sender, EventArgs e)
        {
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelXuatKho.Visible = false;
        }

        private void btnsavexuatkho_Click(object sender, EventArgs e)
        {
            int tienmat = 0;
            if (chbTienMatXuatKho.Checked) tienmat = 1;
            int id = 0;
            int currow = 0;
            if (Action == 2)
            { currow = dtgXuatKho.CurrentRow.Index; }
            else if (Action == 1)
            { currow = dtgXuatKho.Rows.Count - 1; }
            else
            { currow = 0; }
            string bienso = cbBienSoXuatKho.Text;
            if (cbBienSoXuatKho.SelectedValue != null ) bienso = cbBienSoXuatKho.SelectedValue.ToString();
            if (dtgXuatKho.Rows.Count > 1 && dtgXuatKho.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgXuatKho.CurrentRow.Cells[0].Value;
            try
            {
                int results = Import_Manager.Instance.UpdatedXuatKho(Action, id, cbNCCXuatKho.Text, dtpNgayXuatKho.Value, cbHHXuatKho.Text, cbMaSoXuatKho.Text, (int)numSoBaoXuatKho.Value, bienso, cbKHXuatKho.Text, cbTaiXeXuatKho.Text, tienmat, (int)numTienMatXuatKho.Value, tbGhiChuXuatKho.Text, id_user, TbPhieuXuat.Text);

                getxuatkho();
                
                dtgXuatKho.CurrentCell = dtgXuatKho.Rows[currow].Cells[0];
                if (Action == 1)
                {
                    Action = 0;
                    btnnewxuatkho_Click(btnnewxuatkho, e);
                }
                else
                {
                    Action = 0;
                    Button curBut = sender as Button;
                    EnableControlDataEntry(curBut.Parent);
                    panelXuatKho.Visible = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btndeletexuatkho_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            Action = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                Action = 0;
                return;
            }
            try
            {
                int results = Import_Manager.Instance.UpdatedXuatKho(Action, (int)dtgXuatKho.CurrentRow.Cells[0].Value, cbNCCXuatKho.Text, dtpNgayXuatKho.Value, cbHHXuatKho.Text, cbMaSoXuatKho.Text, (int)numSoBaoXuatKho.Value, cbBienSoXuatKho.Text, cbKHXuatKho.Text, cbTaiXeXuatKho.Text, 0, (int)numTienMatXuatKho.Value, tbGhiChuXuatKho.Text, 1, TbPhieuXuat.Text);
                getxuatkho();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
        }

        private void dtgNhapKho_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        private void dtgXuatKho_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        void SetDropDown(Control col)
        {
            foreach (Control c in col.Controls)
            {
                if (c.GetType().Name == "ComboBox")                    
                {
                    c.Enter += combobox_dropdown;
                    c.Click += combobox_dropdown;
                }  
            }
        }
       

        private void combobox_dropdown(object sender, EventArgs e)
        {
            ComboBox curBox = sender as ComboBox;
            curBox.DroppedDown = true;
        }

        private void dtgNKNCC_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgNKNCC.CurrentRow != null && dtgNKNCC.CurrentRow.Cells[0].Value.ToString() != "" && Action != 1)
            {
                cbNCCNKNCC.Text = dtgNKNCC.CurrentRow.Cells[1].Value.ToString();
                dtpNgayNhanNKNCC.Value = DateTime.Parse(dtgNKNCC.CurrentRow.Cells[2].Value.ToString());
                cbHHNKNCC.Text = dtgNKNCC.CurrentRow.Cells[3].Value.ToString();
                tbMaSoNKNCC.Text = dtgNKNCC.CurrentRow.Cells[4].Value.ToString();
                tbNoiNhanNKNCC.Text = dtgNKNCC.CurrentRow.Cells[5].Value.ToString();
                numSoLuongNKNCC.Text = dtgNKNCC.CurrentRow.Cells[6].Value.ToString();
                cbBienSoNKNCC.Text = dtgNKNCC.CurrentRow.Cells[7].Value.ToString();
                cbKHNKNCC.Text = dtgNKNCC.CurrentRow.Cells[8].Value.ToString();
                cbTaiXeNKNCC.Text = dtgNKNCC.CurrentRow.Cells[9].Value.ToString();
                tbGhichuNKNCC.Text = dtgNKNCC.CurrentRow.Cells[10].Value.ToString();
            }
        }

        private void cbhhNhapKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            getMaSoNhapKho();
        }

        private void buttonItemImportDLNCC_Click(object sender, EventArgs e)
        {
            Import_File importfile = new Import_File();
            importfile.ShowDialog();
            //chithisx.ShowInTaskbar = true;
            importfile.FormClosing += main_close;
        }
        private void main_close(object sender, FormClosingEventArgs e)
        {
            getNhatKyNCC();
        }

        private void panelHH_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbBienSoNKNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Action == 1)
            {
                cbKHNKNCC.Text = getKHtheoBienSo(cbBienSoNKNCC.Text);
                cbTaiXeNKNCC.Text = getTXtheoBienSo(cbBienSoNKNCC.Text);
            }
        }

        private void dtpDonGiaNGay_ValueChanged(object sender, EventArgs e)
        {
            getdongiangay();
        }

        private void cbNCCDonGiaNgay_SelectedIndexChanged(object sender, EventArgs e)
        {
            getdongiangay();
        }

        private void tbHHDonGiaNgay_TextChanged(object sender, EventArgs e)
        {
            getdongiangay();
        }

        private void tbKHDonGiaNgay_TextChanged(object sender, EventArgs e)
        {
            getdongiangay();
        }

        private void cbHHXuatKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            getMaSoXuatKho();
        }

        private void buttonItemUser_Click(object sender, EventArgs e)
        {
            gettaikhoandangnhap();
            tabControlMain.SelectedTabIndex = 8;
        }

        private void btnnewuser_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            tbtenDN.Text = "";
            tbMatKhau.Text = "";
            Action = 1;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelUser.Visible = true;
        }

        private void btnedituser_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            
            Action = 2;
            tbtenDN.Text = dtgTaiKhoanDN.CurrentRow.Cells[1].Value.ToString();
            tbMatKhau.Text = dtgTaiKhoanDN.CurrentRow.Cells[2].Value.ToString();
            string quyen = dtgTaiKhoanDN.CurrentRow.Cells[3].Value.ToString();
            string kho = dtgTaiKhoanDN.CurrentRow.Cells[4].Value.ToString();
            for(int i = 0; i <checkedListBoxQuyenTruyCap.Items.Count; i++)
            {
                checkedListBoxQuyenTruyCap.SetItemChecked(i, false);
                if (quyen.Contains(checkedListBoxQuyenTruyCap.Items[i].ToString() + ",") && checkedListBoxQuyenTruyCap.Items[i].ToString() != "") checkedListBoxQuyenTruyCap.SetItemChecked(i, true);
            }
            for (int i = 0; i < checkedListBoxKhoNhapLieu.Items.Count; i++)
            {
                checkedListBoxKhoNhapLieu.SetItemChecked(i, false);
                if (kho.Contains(checkedListBoxKhoNhapLieu.Items[i].ToString() + ",")) checkedListBoxKhoNhapLieu.SetItemChecked(i, true);
            }
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelUser.Visible = true;

        }

        private void btncanceluser_Click(object sender, EventArgs e)
        {
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelUser.Visible = false;
        }

        private void btnsaveuser_Click(object sender, EventArgs e)
        {
            
            int id = 0;
            int currow = 0;
            if (Action == 2)
            { currow = dtgTaiKhoanDN.CurrentRow.Index; }
            else if (Action == 1)
            { currow = dtgTaiKhoanDN.Rows.Count - 1; }
            else
            { currow = 0; }

            if (dtgTaiKhoanDN.Rows.Count > 1 && dtgTaiKhoanDN.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgTaiKhoanDN.CurrentRow.Cells[0].Value;
            try
            {
                string quyen ="";
                string kho = "";
                for (int i=0; i<checkedListBoxQuyenTruyCap.Items.Count; i ++)
                {
                    if(checkedListBoxQuyenTruyCap.GetItemChecked(i)) quyen += checkedListBoxQuyenTruyCap.Items[i].ToString() + ", ";
                }
                for (int i = 0; i < checkedListBoxKhoNhapLieu.Items.Count; i++)
                {
                    if (checkedListBoxKhoNhapLieu.GetItemChecked(i)) kho += checkedListBoxKhoNhapLieu.Items[i].ToString() + ", ";
                }
                int results = Import_Manager.Instance.UpdateUserLogin(Action, id, tbtenDN.Text, tbMatKhau.Text, quyen, kho);
                gettaikhoandangnhap();
                dtgTaiKhoanDN.CurrentCell = dtgTaiKhoanDN.Rows[currow].Cells[0];
                if (Action == 1)
                {
                    Action = 0;
                    btnnewuser_Click(btnnewuser, e);
                }
                else
                {
                    Action = 0;
                    Button curBut = sender as Button;
                    EnableControlDataEntry(curBut.Parent);
                    panelUser.Visible = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btndeleteuser_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            Action = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                Action = 0;
                return;
            }
            try
            {
                int results = Import_Manager.Instance.UpdateUserLogin(Action, (int)dtgTaiKhoanDN.CurrentRow.Cells[0].Value, tbtenDN.Text, tbMatKhau.Text, checkedListBoxQuyenTruyCap.Text, checkedListBoxKhoNhapLieu.Text);
                gettaikhoandangnhap();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
        }

       

        private void buttonItemKM_Click(object sender, EventArgs e)
        {
            //getKMNCC();
            tabControlMain.SelectedTabIndex = 9;
        }

        

       

        

        private void numGiamKM_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

       
        private void btnnewck1_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            dtpNgayBDCK1.Value = DateTime.Now;
            dtpNgayKTCK1.Value = DateTime.Now.AddDays(10);
            tbDiengiaiCK1.Text = "";
            numCK1.Text = "";
            Action = 1;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelCK1.Visible = true;
        }

        private void btneditck1_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            if(dtgCK1.CurrentRow != null && dtgCK1.CurrentRow.Cells[1].Value.ToString() != "")
            {
                tbDiengiaiCK1.Text = dtgCK1.CurrentRow.Cells[1].Value.ToString();
                dtpNgayBDCK1.Value = DateTime.Parse(dtgCK1.CurrentRow.Cells[2].Value.ToString());
                dtpNgayKTCK1.Value = DateTime.Parse(dtgCK1.CurrentRow.Cells[3].Value.ToString());
                cbNCCCK1.Text = dtgCK1.CurrentRow.Cells[4].Value.ToString();
                cbKHCK1.Text = dtgCK1.CurrentRow.Cells[5].Value.ToString();
                cbHHCK1.Text = dtgCK1.CurrentRow.Cells[6].Value.ToString();
                numCK1.Value = Int32.Parse(dtgCK1.CurrentRow.Cells[7].Value.ToString());
                cbDonViCK1.Text = dtgCK1.CurrentRow.Cells[8].Value.ToString();

            }
            
            Action = 2;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelCK1.Visible = true;
        }

        private void btncancelck1_Click(object sender, EventArgs e)
        {
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelCK1.Visible = false;
        }

        private void btnsaveck1_Click(object sender, EventArgs e)
        {

            int id = 0;
            int currow = 0;
            if (Action == 2)
            { currow = dtgCK1.CurrentRow.Index; }
            else if (Action == 1)
            { currow = dtgCK1.Rows.Count - 1; }
            else
            { currow = 0; }

            if (dtgCK1.Rows.Count > 1 && dtgCK1.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgCK1.CurrentRow.Cells[0].Value;
            try
            {
                int results = Import_Manager.Instance.UpdateCK1(Action, id, tbDiengiaiCK1.Text, dtpNgayBDCK1.Value, dtpNgayKTCK1.Value, cbNCCCK1.Text, cbKHCK1.Text, cbHHCK1.Text, Int32.Parse(numCK1.Value.ToString()), cbDonViCK1.Text);

                getck1();

                dtgCK1.CurrentCell = dtgCK1.Rows[currow].Cells[0];
                if (Action == 1)
                {
                    Action = 0;
                    btnnewck1_Click(btnnewck1, e);
                }
                else
                {
                    Action = 0;
                    Button curBut = sender as Button;
                    EnableControlDataEntry(curBut.Parent);
                    panelCK1.Visible = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbNamCk1_TextChanged(object sender, EventArgs e)
        {
            getck1();
        }

        private void panel42_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbThangCK1_TextChanged(object sender, EventArgs e)
        {
            getck1();
        }

        private void btndeleteck1_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            Action = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                Action = 0;
                return;
            }
            try
            {
                int results = Import_Manager.Instance.UpdateCK1(Action,  Int32.Parse(dtgCK1.CurrentRow.Cells[0].Value.ToString()), tbDiengiaiCK1.Text, dtpNgayBDCK1.Value, dtpNgayKTCK1.Value, cbNCCCK1.Text, cbKHCK1.Text, cbHHCK1.Text, Int32.Parse(numCK1.Value.ToString()), cbDonViCK1.Text);
                getck1();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
        }

     

        private void numCK1_ValueChanged(object sender, EventArgs e)
        {
            if (numCK1.Value > 100)
            {
                cbDonViCK1.Text = "VND";
            }
            else { cbDonViCK1.Text = "Bao"; }
        }

        private void numCK1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void buttonItemCK1_Click(object sender, EventArgs e)
        {
            getck1();
            tabControlMain.SelectedTabIndex = 10;
        }

        private void numCK1_KeyUp(object sender, KeyEventArgs e)
        {
            if (numCK1.Value > 100)
            {
                cbDonViCK1.Text = "VND";
            }
            else { cbDonViCK1.Text = "Bao"; }
        }

      

        private void tbKHCK2_TextChanged(object sender, EventArgs e)
        {
            getck2();
        }

        private void btnnewck2_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            dtpNgayCK2.Value = DateTime.Now;
            dtpNgayADCK2.Value = DateTime.Now;
            tbDienGiaiCK2.Text = "";
            tbGhiChuCK2.Text = "";
            numSLCK2.Text = "";
            numTienCK2.Text = "";
            Action = 1;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelCK2.Visible = true;
        }

        private void btneditck2_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            if (dtgCK2.CurrentRow != null && dtgCK2.CurrentRow.Cells[1].Value.ToString() != "")
            {
                tbDienGiaiCK2.Text = dtgCK2.CurrentRow.Cells[1].Value.ToString();
                tbGhiChuCK2.Text = dtgCK2.CurrentRow.Cells[2].Value.ToString();
                dtpNgayCK2.Value = DateTime.Parse(dtgCK2.CurrentRow.Cells[3].Value.ToString());
                cbHHCK2.Text = dtgCK2.CurrentRow.Cells[4].Value.ToString();
                numSLCK2.Value = Int32.Parse(dtgCK2.CurrentRow.Cells[5].Value.ToString());
                numTienCK2.Value = Int32.Parse(dtgCK2.CurrentRow.Cells[6].Value.ToString());
                cbKHCK2.Text = dtgCK2.CurrentRow.Cells[7].Value.ToString();
                dtpNgayADCK2.Value = DateTime.Parse(dtgCK2.CurrentRow.Cells[8].Value.ToString());
            }

            Action = 2;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelCK2.Visible = true;
        }

        private void btncancelck2_Click(object sender, EventArgs e)
        {
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelCK2.Visible = false;
        }

        private void btnsaveck2_Click(object sender, EventArgs e)
        {

            int id = 0;
            int currow = 0;
            if (Action == 2)
            { currow = dtgCK2.CurrentRow.Index; }
            else if (Action == 1)
            { currow = dtgCK2.Rows.Count - 1; }
            else
            { currow = 0; }

            if (dtgCK2.Rows.Count > 1 && dtgCK2.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgCK2.CurrentRow.Cells[0].Value;
            try
            {
                int results = Import_Manager.Instance.UpdateCK2(Action, id, tbDienGiaiCK2.Text, tbGhiChuCK2.Text, dtpNgayCK2.Value, cbHHCK2.Text, Int32.Parse(numSLCK2.Value.ToString()), Int32.Parse(numTienCK2.Value.ToString()), cbKHCK2.Text, dtpNgayADCK2.Value);

                getck2();

                dtgCK2.CurrentCell = dtgCK2.Rows[currow].Cells[0];
                if (Action == 1)
                {
                    Action = 0;
                    btnnewck2_Click(btnnewck2, e);
                }
                else
                {
                    Action = 0;
                    Button curBut = sender as Button;
                    EnableControlDataEntry(curBut.Parent);
                    panelCK2.Visible = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btndeleteck2_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            Action = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                Action = 0;
                return;
            }
            try
            {
                int results = Import_Manager.Instance.UpdateCK2(Action, Int32.Parse(dtgCK2.CurrentRow.Cells[0].Value.ToString()), tbDienGiaiCK2.Text, tbGhiChuCK2.Text, dtpNgayCK2.Value, cbHHCK2.Text, Int32.Parse(numSLCK2.Value.ToString()), Int32.Parse(numTienCK2.Value.ToString()), cbKHCK2.Text, dtpNgayADCK2.Value);
                getck2();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            getck2();
            tabControlMain.SelectedTabIndex = 11;
        }

        private void dtpNGayBDTongHopSLH_ValueChanged(object sender, EventArgs e)
        {
            tonghopSLH();
        }

        private void dtpNgayKTTongHopSLH_ValueChanged(object sender, EventArgs e)
        {
            tonghopSLH();
        }

        private void tbNCCTongHopSLHFilter_TextChanged(object sender, EventArgs e)
        {
            tonghopSLH();
        }

        private void tbHHTongHopSLHFilter_TextChanged(object sender, EventArgs e)
        {
            tonghopSLH();
        }

        private void tbKHTongHopSLH_TextChanged(object sender, EventArgs e)
        {
            tonghopSLH();
        }

        private void buttonItemSLH_Click(object sender, EventArgs e)
        {
            
            tabControlMain.SelectedTabIndex = 12;
        }

        private void cbMaSoXuatKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelTonXuatKho.Text = "Tồn: " + gettontheomaso(cbMaSoXuatKho.Text).ToString();
        }

        private void chbTienMatXuatKho_CheckedChanged(object sender, EventArgs e)
        {
            if(chbTienMatXuatKho.Checked)
            {
                numTienMatXuatKho.Enabled = true;
                numTienMatXuatKho.Value = getdongiaxuatkho() * numSoBaoXuatKho.Value;
            }
            else
            {
                numTienMatXuatKho.Enabled = false;
            }
        }

        private void cbKHXuatKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Action == 1) TbPhieuXuat.Text = taophieuxuat();
        }

        private void btnKiemTraXuatKho_Click(object sender, EventArgs e)
        {
            kiemtra = "Xuat Kho";
            FrmCheck f = new FrmCheck();
            f.KiemTraDL(cbNCCXuatKho.Text,kiemtra);
            f.ShowDialog();
        }

        private void btnKiemTraNCC_Click(object sender, EventArgs e)
        {
            kiemtra = "NCC";
            FrmCheck f = new FrmCheck();
            f.KiemTraDL("", kiemtra);
            f.ShowDialog();
        }

        private void dtpNgayXuatKho_ValueChanged(object sender, EventArgs e)
        {
            if (Action == 1) TbPhieuXuat.Text = taophieuxuat();
        }

        private void buttonItemMaSo_Click(object sender, EventArgs e)
        {
            FrmMaSo f = new FrmMaSo();
            f.ShowDialog();
            f.FormClosing += formmaso_close;
        }
        private void formmaso_close(object sender, FormClosingEventArgs e)
        {
            getnhapkho();
            getxuatkho();
        }

        private void tbbiensoxuatkhofilter_TextChanged(object sender, EventArgs e)
        {
            getxuatkho();
        }

        private void panel26_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbtxxuatkhofilter_TextChanged(object sender, EventArgs e)
        {
            getxuatkho();
        }

        private void buttonItemNXT_Click(object sender, EventArgs e)
        {
            tabControlMain.SelectedTabIndex = 13;
            dtpfromNXT.Value = DateTime.Now.AddDays(-7);
            dtptoNXT.Value = DateTime.Now;
        }
        void getnxt()
        {
            int nxtkho = 0;
            if (chbHHNCCNXT.Checked) nxtkho = 1;
            DataTable data = Import_Manager.Instance.BaoCaoNXT(dtpfromNXT.Value, dtptoNXT.Value, tbHHNXT.Text, tbNCCNXT.Text, nxtkho);
            dtgNXT.DataSource = data;
        }
        void chitietmathang()
        {
            int ctmh = 0;
            if (chbCTMH.Checked) ctmh = 1;
            DataTable data = Import_Manager.Instance.BaoCaoChiTietMatHang(dtpfromchitietmh.Value, dtptochitietmh.Value, tbHHCTMH.Text, tbNCCCCTMH.Text, tbMSCTMH.Text ,ctmh);
            dtgChiTietMH.DataSource = data;
        }

        private void dtpfromNXT_ValueChanged(object sender, EventArgs e)
        {
            getnxt();
        }

        private void dtptoNXT_ValueChanged(object sender, EventArgs e)
        {
            getnxt();
        }

        private void tbHHNXT_TextChanged(object sender, EventArgs e)
        {
            getnxt();
        }

        private void tbNCCNXT_TextChanged(object sender, EventArgs e)
        {
            getnxt();
        }

        private void chbHHNCCNXT_CheckedChanged(object sender, EventArgs e)
        {
            if(chbHHNCCNXT.Checked)
            {
                tbNCCNXT.Visible = true;
                labelNCCNXT.Visible = true;
            }
            else
            {
                tbNCCNXT.Visible = false;
                labelNCCNXT.Visible = false;
            }
            getnxt();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            getNhatKyNCC();
        }

        private void tbKHNKNCCFilter_TextChanged(object sender, EventArgs e)
        {
            getNhatKyNCC();
        }

        private void tbtaixenknccfilter_TextChanged(object sender, EventArgs e)
        {
            getNhatKyNCC();
        }

        private void buttonItemCTMH_Click(object sender, EventArgs e)
        {
            tabControlMain.SelectedTabIndex = 14;
            dtpfromchitietmh.Value = DateTime.Now.AddDays(-7);
            dtptochitietmh.Value = DateTime.Now;
        }

        private void dtpfromchitietmh_ValueChanged(object sender, EventArgs e)
        {
            chitietmathang();
        }

        private void dtptochitietmh_ValueChanged(object sender, EventArgs e)
        {
            chitietmathang();
        }

        private void tbHHCTMH_TextChanged(object sender, EventArgs e)
        {
            chitietmathang();
        }

        private void tbMSCTMH_TextChanged(object sender, EventArgs e)
        {
            chitietmathang();
        }

        private void tbNCCCCTMH_TextChanged(object sender, EventArgs e)
        {
            chitietmathang();
        }

        private void chbCTMH_CheckedChanged(object sender, EventArgs e)
        {
            if (chbCTMH.Checked)
            {
                tbNCCCCTMH.Visible = true;
                labelCTMH.Visible = true;
            }
            else
            {
                tbNCCCCTMH.Visible = false;
                labelCTMH.Visible = false;
            }
            chitietmathang();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            Action = 1;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelDonGiaVCKH.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            if (dtgDonGiaVCKH.CurrentRow != null && dtgDonGiaVCKH.CurrentRow.Cells[1].Value.ToString() != "")
            {
                dtpDonGiaVCKH.Value = DateTime.Parse(dtgDonGiaVCKH.CurrentRow.Cells[1].Value.ToString());
                cbLoaiHinhVCKH.Text = dtgDonGiaVCKH.CurrentRow.Cells[3].Value.ToString();
                numDonGiaVCKH.Text = dtgDonGiaVCKH.CurrentRow.Cells[4].Value.ToString();
            }

            Action = 2;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelDonGiaVCKH.Visible = true;
        }
        void getdongiavckh()
        {
            DataTable data = Import_Manager.Instance.getDonGiaVCKH(tbloaihinhdongiavckh.Text);
            dtgDonGiaVCKH.DataSource = data;
        }

        private void tbloaihinhdongiavckh_TextChanged(object sender, EventArgs e)
        {
            getdongiavckh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            Action = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                Action = 0;
                return;
            }
            try
            {
                int results = Import_Manager.Instance.UpdateDonGiaVCKH(Action, Int32.Parse(dtgDonGiaVCKH.CurrentRow.Cells[0].Value.ToString()), dtpDonGiaVCKH.Value, "", "", 0, tendn);
                getdongiavckh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            int id = 0;
            int currow = 0;
            string code = "";
            if (Action == 2)
            { currow = dtgDonGiaVCKH.CurrentRow.Index; }
            else if (Action == 1)
            { currow = dtgDonGiaVCKH.Rows.Count - 1; }
            else
            { currow = 0; }

            if (dtgDonGiaVCKH.Rows.Count > 1 && dtgDonGiaVCKH.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgDonGiaVCKH.CurrentRow.Cells[0].Value;
            try
            {
                if (cbLoaiHinhVCKH.Text.Contains("NCC"))
                    code = "NCC";
                else
                    code = "KHO";

                int results = Import_Manager.Instance.UpdateDonGiaVCKH(Action, id, dtpDonGiaVCKH.Value, code, cbLoaiHinhVCKH.Text, numDonGiaVCKH.Value, tendn);

                getdongiavckh();

                dtgDonGiaVCKH.CurrentCell = dtgDonGiaVCKH.Rows[currow].Cells[0];
                if (Action == 1)
                {
                    Action = 0;
                    button6_Click(button6, e);
                }
                else
                {
                    Action = 0;
                    Button curBut = sender as Button;
                    EnableControlDataEntry(curBut.Parent);
                    panelDonGiaVCKH.Visible = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelDonGiaVCKH.Visible = false;
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            tabControlMain.SelectedTabIndex = 9;
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            tabControlMain.SelectedTabIndex = 15;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            numGiaDCKH.Value = 0;
            cbLoaiHinhVCKH.Text = "";
            cbKHDCGiaKH.Text = "";
            Action = 1;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelDCGIaKH.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            if (dtgDCGiaKH.CurrentRow != null && dtgDCGiaKH.CurrentRow.Cells[1].Value.ToString() != "")
            {
                dtpNGayDieuChinhGiaKH.Value = DateTime.Parse(dtgDCGiaKH.CurrentRow.Cells[1].Value.ToString());
                cbLoaiHinhDCGiaKH.Text = dtgDCGiaKH.CurrentRow.Cells[3].Value.ToString();
                cbKHDCGiaKH.Text = dtgDCGiaKH.CurrentRow.Cells[4].Value.ToString();
                cbSPDCGiaKH.Text = dtgDCGiaKH.CurrentRow.Cells[5].Value.ToString();
                numGiaDCKH.Text = dtgDCGiaKH.CurrentRow.Cells[6].Value.ToString();
            }

            Action = 2;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelDCGIaKH.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            Action = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                Action = 0;
                return;
            }
            try
            {
                int results = Import_Manager.Instance.UpdateDieuChinhGiaKH(Action, Int32.Parse(dtgDCGiaKH.CurrentRow.Cells[0].Value.ToString()), DateTime.Now, "", "", "", "", 0, tendn);
                getDCGiaKH();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
        }
        void getDCGiaKH()
        {
            DataTable data = Import_Manager.Instance.getDieuChinhGiaKH(tbloaihinhgiadckh.Text, tbkhdieuchinhgiakh.Text, tbspdieuchinhgiakh.Text);
            dtgDCGiaKH.DataSource = data;
        }

        private void tbloaihinhgiadckh_TextChanged(object sender, EventArgs e)
        {
            getDCGiaKH();
        }

        private void tbkhdieuchinhgiakh_TextChanged(object sender, EventArgs e)
        {
            getDCGiaKH();
        }

        private void tbspdieuchinhgiakh_TextChanged(object sender, EventArgs e)
        {
            getDCGiaKH();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            int id = 0;
            int currow = 0;
            string code = "";
            if (cbLoaiHinhDCGiaKH.Text == "KH mua tại NCC")
                code = "KH_NCC";
            else if (cbLoaiHinhDCGiaKH.Text == "KH mua tại Kho")
                code = "KH_KHO";
            else if (cbLoaiHinhDCGiaKH.Text == "VC từ NCC tới KH")
                code = "VC_NCC";
            else if (cbLoaiHinhDCGiaKH.Text == "VC từ Kho tới KH")
                code = "VC_KHO";
            else
                code = "";

            if (Action == 2)
            { currow = dtgDCGiaKH.CurrentRow.Index; }
            else if (Action == 1)
            { currow = dtgDCGiaKH.Rows.Count - 1; }
            else
            { currow = 0; }

            if (dtgDCGiaKH.Rows.Count > 1 && dtgDCGiaKH.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgDCGiaKH.CurrentRow.Cells[0].Value;
            try
            {
                int results = Import_Manager.Instance.UpdateDieuChinhGiaKH(Action, id, dtpNGayDieuChinhGiaKH.Value, code, cbLoaiHinhDCGiaKH.Text, cbKHDCGiaKH.Text, cbSPDCGiaKH.Text, numGiaDCKH.Value, tendn);

                getDCGiaKH();

                dtgDCGiaKH.CurrentCell = dtgDCGiaKH.Rows[currow].Cells[0];
                if (Action == 1)
                {
                    Action = 0;
                    button10_Click(button10, e);
                }
                else
                {
                    Action = 0;
                    Button curBut = sender as Button;
                    EnableControlDataEntry(curBut.Parent);
                    panelDCGIaKH.Visible = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelDCGIaKH.Visible = false;
        }

        private void tabControlMain_Click(object sender, EventArgs e)
        {

        }

        private void tbspDGVCKho_TextChanged(object sender, EventArgs e)
        {
            getDGVCKho();
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            tabControlMain.SelectedTabIndex = 16;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            cbSpDGVCKho.Text = "";
            numDGVCKho.Value = 0;
            Action = 1;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelDGVCKho.Visible = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            } 
            if (dtgDGVCKho.CurrentRow != null && dtgDGVCKho.CurrentRow.Cells[0].Value.ToString() != "")
            {
                dtpNgayDGVCKho.Value = DateTime.Parse(dtgDGVCKho.CurrentRow.Cells[1].Value.ToString());
                cbSpDGVCKho.Text = dtgDGVCKho.CurrentRow.Cells[2].Value.ToString();
                numDGVCKho.Text = dtgDGVCKho.CurrentRow.Cells[3].Value.ToString();
            }

            Action = 2;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelDGVCKho.Visible = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            Action = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                Action = 0;
                return;
            }
            try
            {
                int results = Import_Manager.Instance.UpdateDonGiaVCKho(Action, Int32.Parse(dtgDGVCKho.CurrentRow.Cells[0].Value.ToString()), DateTime.Now, "", 0, "");
                    getDGVCKho();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            
            int id = 0;
            int currow = 0;
           
            if (Action == 2)
            { currow = dtgDGVCKho.CurrentRow.Index; }
            else if (Action == 1)
            { currow = dtgDGVCKho.Rows.Count - 1; }
            else
            { currow = 0; }

            if (dtgDGVCKho.Rows.Count > 1 && dtgDGVCKho.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgDGVCKho.CurrentRow.Cells[0].Value;
            try
            {
                int results = Import_Manager.Instance.UpdateDonGiaVCKho(Action, id, dtpNgayDGVCKho.Value, cbSpDGVCKho.Text, numDGVCKho.Value, tendn);

                getDGVCKho();

                dtgDGVCKho.CurrentCell = dtgDGVCKho.Rows[currow].Cells[0];
                if (Action == 1)
                {
                    Action = 0;
                    button15_Click(button15, e);
                }
                else
                {
                    Action = 0;
                    Button curBut = sender as Button;
                    EnableControlDataEntry(curBut.Parent);
                    panelDGVCKho.Visible = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelDGVCKho.Visible = false;
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            tabControlMain.SelectedTabIndex = 17;
        }

        private void tbkhDGDCNCC_TextChanged(object sender, EventArgs e)
        {
            getDonGiaDCNCC();
        }

        private void tbSPDGDCNCC_TextChanged(object sender, EventArgs e)
        {
            getDonGiaDCNCC();
        }

        private void tbNCCDGDCNCC_TextChanged(object sender, EventArgs e)
        {
            getDonGiaDCNCC();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            cbKHDGDCNCC.Text = "";
            numDGDCNCC.Value = 0;
            cbNCCDGDCNCC.Text = "";
            Action = 1;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelDGDCNCC.Visible = true;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            if (dtgDGDCNCC.CurrentRow != null && dtgDGDCNCC.CurrentRow.Cells[0].Value.ToString() != "")
            {
                dtpNgayDGDCNCC.Value = DateTime.Parse(dtgDGDCNCC.CurrentRow.Cells[1].Value.ToString());
                cbKHDGDCNCC.Text = dtgDGDCNCC.CurrentRow.Cells[2].Value.ToString();
                cbSPDGDCNCC.Text = dtgDGDCNCC.CurrentRow.Cells[3].Value.ToString();
                cbNCCDGDCNCC.Text = dtgDGDCNCC.CurrentRow.Cells[4].Value.ToString();
                numDGVCKho.Text = dtgDGDCNCC.CurrentRow.Cells[5].Value.ToString();
            }

            Action = 2;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelDGDCNCC.Visible = true;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            Action = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                Action = 0;
                return;
            }
            try
            {
                int results = Import_Manager.Instance.UpdateDonGiaDCNCC(Action, Int32.Parse(dtgDGDCNCC.CurrentRow.Cells[0].Value.ToString()), DateTime.Now, "", "", "", 0, "");
                getDonGiaDCNCC();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            
            int id = 0;
            int currow = 0;
            if (Action == 2)
            { currow = dtgDGDCNCC.CurrentRow.Index; }
            else if (Action == 1)
            { currow = dtgDGDCNCC.Rows.Count - 1; }
            else
            { currow = 0; }

            if (dtgDGDCNCC.Rows.Count > 1 && dtgDGDCNCC.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgDGDCNCC.CurrentRow.Cells[0].Value;
            try
            {
                int results = Import_Manager.Instance.UpdateDonGiaDCNCC(Action, id, dtpNGayDieuChinhGiaKH.Value, cbKHDGDCNCC.Text, cbSPDGDCNCC.Text, cbNCCDGDCNCC.Text, numDGDCNCC.Value, tendn);

                getDonGiaDCNCC();

                dtgDGDCNCC.CurrentCell = dtgDGDCNCC.Rows[currow].Cells[0];
                if (Action == 1)
                {
                    Action = 0;
                    button20_Click(button20, e);
                }
                else
                {
                    Action = 0;
                    Button curBut = sender as Button;
                    EnableControlDataEntry(curBut.Parent);
                    panelDGDCNCC.Visible = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelDGDCNCC.Visible = false;
        }
    }
}
