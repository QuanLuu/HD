using DB_Manage.BLL;
using DevComponents.DotNetBar;
using QLHH_CN_HD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Manage
{
    public partial class FrmMain : DevComponents.DotNetBar.Office2007RibbonForm
    {
        int Action = 0;
        public FrmMain()
        {
            InitializeComponent();
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
            getnhapkho();
            getNKHH();
            getNhatKyNCC();
            getxuatkho();
            SetDropDown(this.panelXuatKho);
            SetDropDown(this.panelNhapKho);
            SetDropDown(this.panelNKNCC);
        }
      void getHH()
        {
            DataTable data = Import_Manager.Instance.GetHH();
            dtgHangHoa.DataSource = data;
            cbTenHangDGGoc.DisplayMember = "TEN_HANG";
            cbTenHangDGGoc.DataSource = data;
            cbHHDC.DisplayMember = "TEN_HANG";
            cbHHDC.DataSource = data;
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
            DataTable data = Import_Manager.Instance.getNhatKyNCC(dtpBDLayHangNCC.Value, dtpKTLayHangNCC.Value, tbNCCNKNCC.Text, tbHHNKNCCFilter.Text);
            dtgNKNCC.DataSource = data;
        }
        void getXeVC()
        {
            DataTable data = Import_Manager.Instance.getXe(tbBienSoFilter.Text);
            dtgXeVC.DataSource = data;
            cbBienSoNhapKho.DisplayMember = "BIEN_SO";
            cbBienSoNhapKho.DataSource = data;  
        }

        void getMaSoXuatKho()
        {
            DataTable data = Import_Manager.Instance.GetMasoXuatKho(cbNCCXuatKho.Text);
            cbMaSoXuatKho.DisplayMember = "MA_SO";
            cbMaSoXuatKho.DataSource = data;
        }

        void getMaSoNhapKho()
        {
            DataTable data = Import_Manager.Instance.GetMasoNhapKho(cbhhNhapKho.Text);
            cbMaSoNhapKho.DisplayMember = "MA_SO";
            cbMaSoNhapKho.DataSource = data;
        }
        void getAllXeVC()
        {
            DataTable data = Import_Manager.Instance.GetAllXeVC();
            cbBienSoNKNCC.DisplayMember = "BIEN_SO";
            cbBienSoNKNCC.DataSource = data;
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
            cbRoMocNhapKho.DisplayMember = "BIEN_SO";
            cbRoMocNhapKho.DataSource = data;
        }

        void getXeKH()
        {
            DataTable data = Import_Manager.Instance.getXeKH(tbBiensoXeKHFilter.Text);
            dtgXeKH.DataSource = data;
            cbBienSoXuatKho.DisplayMember = "BIEN_SO";
            cbBienSoXuatKho.DataSource = data;       
            //PopulateStringGrid(dtgXeKH, data);

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
        void getnhapkho()
        {
            DataTable data = Import_Manager.Instance.getnhapkho(dtpBDNhapKhoFilter.Value, dtpKTNhapKhoFilter.Value,cbNCCNhapKho.Text, tbHHNhapKhoFilter.Text, tbMaSoNhapKhoFilter.Text);
            dtgNhapKho.DataSource = data;
        }

        void getxuatkho()
        {
            DataTable data = Import_Manager.Instance.getxuatkho(dtpBDXuatKho.Value, dtpKTXuatKho.Value, cbNCCXuatKho.Text, tbKHXuatKhoFilter.Text, tbHHXuatKhoFilter.Text, tbMaSoXuatKhoFilter.Text);
            dtgXuatKho.DataSource = data;
        }
        public int dongiadieuchinh()
        {
            int duongbo = 0;
            if (chbDuongBoDC.Checked) duongbo = 1;
            DataTable data = Import_Manager.Instance.TinhtoanDGDC(dtpNgayBĐC.Value, cbNCCDC.Text, cbHHDC.Text, tbNoiGNDC.Text, duongbo, (int)numDC.Value);
            if (data.Rows.Count > 0)
            {
               
                return Int32.Parse(data.Rows[0][1].ToString());
            }
            else
            {
                return 0;
            }
             
        } 
        void getNCC()
        {
            DataTable data = Import_Manager.Instance.GetNCC();
            dtgNCC.DataSource = data;
            cbNCCDGGoc.DisplayMember = "MA_NCC";
            cbNCCDGGoc.DataSource = data;
            cbNCCDC.BindingContext = new BindingContext();
            cbNCCDC.DisplayMember = "MA_NCC";
            cbNCCDC.DataSource = data;
            
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

            cbNCCNhapKho.BindingContext = new BindingContext();
            cbNCCNhapKho.DisplayMember = "MA_NCC";
            cbNCCNhapKho.DataSource = data;
            cbNCCXuatKho.BindingContext = new BindingContext();
            cbNCCXuatKho.DisplayMember = "MA_NCC";
            cbNCCXuatKho.DataSource = data;
            cbNCCNKNCC.BindingContext = new BindingContext();
            cbNCCNKNCC.DisplayMember = "MA_NCC";
            cbNCCNKNCC.DataSource = data;

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
            cbKHDC.DisplayMember = "KHACH_HANG";
            cbKHDC.DataSource = data;
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
        }
        void getDieuChinhGia(string kh)
        {
            DataTable data = Import_Manager.Instance.DieuchinhgiachoKH(kh);
            dtgDieuChinhGiaKH.DataSource = data;
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
                Action = 0;
                Button curBut = sender as Button;
                EnableControlDataEntry(curBut.Parent);
                panelHH.Visible = false;
                dtgHangHoa.CurrentCell = dtgHangHoa.Rows[currow].Cells[0];
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
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
                getDieuChinhGia(dtgKH.CurrentRow.Cells[1].Value.ToString());
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

        private void btnNewDC_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }
            dtpNgayBĐC.Value = DateTime.Now;
            dtpNgayKTDC.Value = DateTime.Now.AddDays(10);
            tbNoiGNDC.Text = "";
            chbDuongBoDC.Checked = true;
            numDC.Value = 0;
            numGiaDC.Value = 0;
            Action = 1;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelDieuChinhGia.Visible = true;
        }

        private void btnEditDC_Click(object sender, EventArgs e)
        {
            if (Action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu");
                return;
            }

            Action = 2;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelDieuChinhGia.Visible = true;
        }

        private void btnCancelDC_Click(object sender, EventArgs e)
        {

            Action = 0;
            Button curBut = sender as Button;
            EnableControlDataEntry(curBut.Parent);
            panelDieuChinhGia.Visible = false;
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
                Action = 0;
                Button curBut = sender as Button;
                EnableControlDataEntry(curBut.Parent);
                panelKH.Visible = false;
                dtgKH.CurrentCell = dtgKH.Rows[currow].Cells[0];
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

        private void btnSaveDC_Click(object sender, EventArgs e)
        {

            int id = 0;
            int currow = 0;
            if (Action == 2)
                { currow = dtgDieuChinhGiaKH.CurrentRow.Index; }
            else if (Action == 1)
                { currow = dtgDieuChinhGiaKH.Rows.Count - 1; }
            else
                { currow = 0; }
            int duongbo = 0;
            if (chbDuongBoDC.Checked) duongbo = 1;
            if (dtgDieuChinhGiaKH.Rows.Count > 1 && dtgDieuChinhGiaKH.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgDieuChinhGiaKH.CurrentRow.Cells[0].Value;
            try
            {
                int results = Import_Manager.Instance.UpdatedDieuChinhKH(Action, id, dtpNgayBĐC.Value, dtpNgayKTDC.Value, cbKHDC.Text, cbNCCDC.Text, cbHHDC.Text, tbNoiGNDC.Text, duongbo, (int)numDC.Value, (int)numGiaDC.Value);

                getDieuChinhGia(dtgKH.CurrentRow.Cells[1].Value.ToString());
                if (dtgDieuChinhGiaKH.Rows.Count > 2) dtgDieuChinhGiaKH.CurrentCell = dtgDieuChinhGiaKH.Rows[dtgDieuChinhGiaKH.Rows.Count - 2].Cells[0];
                Action = 0;
                Button curBut = sender as Button;
                EnableControlDataEntry(curBut.Parent);
                panelDieuChinhGia.Visible = false;
                dtgDieuChinhGiaKH.CurrentCell = dtgDieuChinhGiaKH.Rows[currow].Cells[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteDC_Click(object sender, EventArgs e)
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
                int results = Import_Manager.Instance.UpdatedDieuChinhKH(Action, (int)dtgDieuChinhGiaKH.CurrentRow.Cells[0].Value, dtpNgayBĐC.Value, dtpNgayKTDC.Value, cbKHDC.Text, cbNCCDC.Text, cbHHDC.Text, tbNoiGNDC.Text, 1, (int)numDC.Value, (int)numGiaDC.Value);
                getDieuChinhGia(dtgKH.CurrentRow.Cells[1].Value.ToString()); ;
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
            if(dtgDieuChinhGiaKH.CurrentRow != null)
            {
                dtpNgayBĐC.Value = DateTime.Parse(dtgDieuChinhGiaKH.CurrentRow.Cells[1].Value.ToString());
                dtpNgayKTDC.Value = DateTime.Parse(dtgDieuChinhGiaKH.CurrentRow.Cells[2].Value.ToString());
                cbNCCDC.Text = dtgDieuChinhGiaKH.CurrentRow.Cells[4].Value.ToString();
                cbHHDC.Text = dtgDieuChinhGiaKH.CurrentRow.Cells[5].Value.ToString();
                tbNoiGNDC.Text = dtgDieuChinhGiaKH.CurrentRow.Cells[6].Value.ToString();
                chbDuongBoDC.Checked = Boolean.Parse(dtgDieuChinhGiaKH.CurrentRow.Cells[7].Value.ToString());
                numDC.Text = dtgDieuChinhGiaKH.CurrentRow.Cells[8].Value.ToString();
                numGiaDC.Text = dtgDieuChinhGiaKH.CurrentRow.Cells[9].Value.ToString();
            }
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
                Action = 0;
                Button curBut = sender as Button;
                EnableControlDataEntry(curBut.Parent);
                panelNCC.Visible = false;
                dtgNCC.CurrentCell = dtgNCC.Rows[currow].Cells[0];
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
                Action = 0;
                Button curBut = sender as Button;
                EnableControlDataEntry(curBut.Parent);
                panelChuyenDoiNCC.Visible = false;
                dtgChuyenDoiNCC.CurrentCell = dtgChuyenDoiNCC.Rows[currow].Cells[0];
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
                Action = 0;
                Button curBut = sender as Button;
                EnableControlDataEntry(curBut.Parent);
                panelXeVC.Visible = false;
                dtgXeVC.CurrentCell = dtgXeVC.Rows[currow].Cells[0];
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
            tabControlMain.SelectedTabIndex = 4;
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
                Action = 0;
                Button curBut = sender as Button;
                EnableControlDataEntry(curBut.Parent);
                panelNKHH.Visible = false;
                dtgSLH.CurrentCell = dtgSLH.Rows[currow].Cells[0];
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
            if(dtgSLH.CurrentRow != null)
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

        private void numDC_ValueChanged(object sender, EventArgs e)
        {
            if (Action == 1 || Action == 2)
            {
                
                numGiaDC.Value = dongiadieuchinh();
            }
        }

        private void numDC_KeyUp(object sender, KeyEventArgs e)
        {
            if (Action == 1 || Action == 2)
            {
               
                numGiaDC.Value = dongiadieuchinh();
            }
        }

        private void cbHHDC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Action == 1 || Action == 2)
            {
                numGiaDC.Value = dongiadieuchinh();
            }
        }

        private void cbNCCDC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Action == 1 || Action == 2)
            {

                numGiaDC.Value = dongiadieuchinh();
            }
        }

        private void tbNoiGNDC_OnValueChanged(object sender, EventArgs e)
        {
            if (Action == 1 || Action == 2)
            {

                numGiaDC.Value = dongiadieuchinh();
            }
        }

        private void chbDuongBoDC_OnChange(object sender, EventArgs e)
        {
            if (Action == 1 || Action == 2)
            {

                numGiaDC.Value = dongiadieuchinh();
            }
        }

        private void dtpNgayBĐC_ValueChanged(object sender, EventArgs e)
        {
            if (Action == 1 || Action == 2)
            {

                numGiaDC.Value = dongiadieuchinh();
            }
        }

        private void buttonItemNHapXuaKho_Click(object sender, EventArgs e)
        {
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

            if (dtgNhapKho.Rows.Count > 1 && dtgNhapKho.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgNhapKho.CurrentRow.Cells[0].Value;
            try
            {
                int results = Import_Manager.Instance.UpdatedNhapKho(Action, id, dtpNhapKho.Value, cbhhNhapKho.Text, cbMaSoNhapKho.Text, (int)numSoBaoNhapKho.Value, cbBienSoNhapKho.Text, cbTaiXeNhapKho.Text, cbRoMocNhapKho.Text, tbGhiChuNhapKho.Text, "admin", cbNCCNhapKho.Text);

                getnhapkho();
                Action = 0;
                Button curBut = sender as Button;
                EnableControlDataEntry(curBut.Parent);
                panelNhapKho.Visible = false;
                dtgNhapKho.CurrentCell = dtgNhapKho.Rows[currow].Cells[0];
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
                Action = 0;
                Button curBut = sender as Button;
                EnableControlDataEntry(curBut.Parent);
                panelXeKH.Visible = false;
                dtgXeKH.CurrentCell = dtgXeKH.Rows[currow].Cells[0];
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
            cbTaiXeNhapKho.Text = getTXtheoBienSo(cbBienSoNhapKho.Text);
        }

        private void cbBienSoXuatKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Action == 1)
            {
                cbTaiXeXuatKho.Text = getKHtheoBienSo(cbBienSoXuatKho.Text);
                cbKHXuatKho.Text = getTXtheoBienSo(cbBienSoXuatKho.Text);
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
                int results = Import_Manager.Instance.UpdateNhatKyNCC(Action, id, cbNCCNKNCC.Text, dtpNgayNhanNKNCC.Value, cbHHNKNCC.Text, tbMaSoNKNCC.Text, tbNoiNhanNKNCC.Text,decimal.Parse(numSoLuongNKNCC.Value.ToString()),cbBienSoNKNCC.Text, cbKHNKNCC.Text, cbTaiXeNKNCC.Text, tbGhichuNKNCC.Text, 1);

                getNhatKyNCC();
                Action = 0;
                Button curBut = sender as Button;
                EnableControlDataEntry(curBut.Parent);
                panelNKNCC.Visible = false;
                dtgNKNCC.CurrentCell = dtgNKNCC.Rows[currow].Cells[0];
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
            cbMaSoXuatKho.Text = "";
            cbBienSoXuatKho.Text = "54-";
            cbKHXuatKho.Text = "";
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

            if (dtgXuatKho.Rows.Count > 1 && dtgXuatKho.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgXuatKho.CurrentRow.Cells[0].Value;
            try
            {
                int results = Import_Manager.Instance.UpdatedXuatKho(Action, id, cbNCCXuatKho.Text, dtpNgayXuatKho.Value, cbHHXuatKho.Text, cbMaSoXuatKho.Text, (int)numSoBaoXuatKho.Value, cbBienSoXuatKho.Text, cbKHXuatKho.Text, cbTaiXeXuatKho.Text, tienmat, (int)numTienMatXuatKho.Value, tbGhiChuXuatKho.Text,1);

                getxuatkho();
                Action = 0;
                Button curBut = sender as Button;
                EnableControlDataEntry(curBut.Parent);
                panelXuatKho.Visible = false;
                dtgXuatKho.CurrentCell = dtgXuatKho.Rows[currow].Cells[0];
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
                int results = Import_Manager.Instance.UpdatedXuatKho(Action, (int)dtgXuatKho.CurrentRow.Cells[0].Value, cbNCCXuatKho.Text, dtpNgayXuatKho.Value, cbHHXuatKho.Text, cbMaSoXuatKho.Text, (int)numSoBaoXuatKho.Value, cbBienSoXuatKho.Text, cbKHXuatKho.Text, cbTaiXeXuatKho.Text, 0, (int)numTienMatXuatKho.Value, tbGhiChuXuatKho.Text, 1);
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
            if (dtgNhapKho.CurrentRow != null && dtgNhapKho.CurrentRow.Cells[0].Value.ToString() != "")
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
        }

        private void dtgXuatKho_SelectionChanged(object sender, EventArgs e)
        {
            if(dtgXuatKho.CurrentRow != null && dtgXuatKho.CurrentRow.Cells[0].Value.ToString() != "")
            {
                              
                if(Action != 0) cbNCCXuatKho.Text = dtgXuatKho.CurrentRow.Cells[1].Value.ToString();
                dtpNgayXuatKho.Value = DateTime.Parse(dtgXuatKho.CurrentRow.Cells[2].Value.ToString());
                cbHHXuatKho.Text = dtgXuatKho.CurrentRow.Cells[3].Value.ToString();
                cbMaSoXuatKho.Text = dtgXuatKho.CurrentRow.Cells[4].Value.ToString();
                numSoBaoXuatKho.Text = dtgXuatKho.CurrentRow.Cells[5].Value.ToString();
                cbBienSoXuatKho.Text = dtgXuatKho.CurrentRow.Cells[6].Value.ToString();
                cbKHXuatKho.Text = dtgXuatKho.CurrentRow.Cells[7].Value.ToString();
                cbTaiXeXuatKho.Text = dtgXuatKho.CurrentRow.Cells[8].Value.ToString();
                chbTienMatXuatKho.Checked = bool.Parse(dtgXuatKho.CurrentRow.Cells[9].Value.ToString());
                numTienMatXuatKho.Text = dtgXuatKho.CurrentRow.Cells[10].Value.ToString();
                tbGhiChuXuatKho.Text = dtgXuatKho.CurrentRow.Cells[11].Value.ToString();
            }
        }

        void SetDropDown(Control col)
        {
            foreach (Control c in col.Controls)
            {
                if (c.GetType().Name == "ComboBox")                    
                {
                    c.Enter += combobox_dropdown;
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
            if (dtgNKNCC.CurrentRow != null && dtgNKNCC.CurrentRow.Cells[0].Value.ToString() != "")
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
    }
}
