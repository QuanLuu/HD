using DB_Manage.ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Manage.BLL
{
    public class Import_Manager
    {
        private static Import_Manager instance;

        public static Import_Manager Instance
        {
            get
            {
                if (instance == null) instance = new Import_Manager();
                return Import_Manager.instance;
            }

            private set
            {
                Import_Manager.instance = value;
            }
        }

        private Import_Manager() { }

       

        public DataTable GetHH()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT ID, MA_HANG, TEN_HANG, KHOI_LUONG, GHI_CHU FROM DM_HANG_HOA", new object[] { });
        }

        public DataTable GetAllXeVC()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT BIEN_SO FROM DM_XE_VC_KH UNION SELECT BIEN_SO FROM DM_XE_HUY_DONG", new object[] { });
        }
        public DataTable GetNCC()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM DM_NCC ", new object[] { });
        }

        public DataTable GetKH(string tenkh)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_KHACH_HANG @TEN ", new object[] {tenkh });
        }

        public DataTable GetDGGoc(string mahh)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_DON_GIA_GOC @MA_HH", new object[] {mahh });
        }
        public DataTable DieuchinhgiachoKH(string makh)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_DIEU_CHINH_DG_KH @KH", new object[] { makh });
        }
        public DataTable getXe(string bienso)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_DM_XE_VC @XE", new object[] { bienso });
        }
        public DataTable getXeKH(string bienso)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_XE_KH @BIEN_SO", new object[] { bienso });
        }

        public DataTable getRoMoooc()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM DM_XE_HUY_DONG WHERE GHI_CHU LIKE 'RO_MOOC'", new object[] {  });
        }

        public DataTable getTaiXe()
        {
            return DataProvider.Instance.ExecuteQuery("select distinct TAI_XE from DM_XE_HUY_DONG", new object[] { });
        }
        public DataTable getKHtheoBienSo(string bienso)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_KH_BY_BIEN_SO @BIEN_SO", new object[] { bienso });
        }
        public DataTable getTXtheoBienSo(string bienso)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_TX_BY_BIEN_SO @BIEN_SO", new object[] { bienso });
        }
        public DataTable chuyendoiNCC()
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_DON_GIA_CHUYEN_DOI_NCC", new object[] {  });
        }

        public DataTable GetMasoXuatKho(string ncc, string hh)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_MA_SO_KHO_XUAT @NCC , @HH", new object[] {ncc,hh});
        }

        public DataTable GetMasoNhapKho(string hh)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_MA_SO_KHO_NHAP @HH", new object[] { hh });
        }
        public DataTable getNKHH(DateTime datefrom, DateTime dateto, string ncc, string hh, string kh, string bienso, string taixe)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_NHAT_KY_HH @DATE_FROM , @DATE_TO , @NCC , @HH , @KH , @BIEN_SO , @TX", new object[] { datefrom, dateto, ncc, hh, kh, bienso, taixe });
        }

        public DataTable getDonGiaDieuChinh(DateTime datefrom, string ncc, string hh, string noign, string duongbo, int dieuchinh)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_TINH_TOAN_GIA_DIEU_CHINH @DATE_FROM , @NCC , @HH , @NOI_GN , @DUONG_BO , @DIEU_CHINH", new object[] { datefrom, ncc, hh, noign, duongbo, dieuchinh });
        }
        public DataTable getNhatKyNCC(DateTime datefrom, DateTime dateto, string ncc, string hh)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_NHAT_KY_NCC @DATE_FROM , @DATE_TO , @NCC , @HH", new object[] { datefrom, dateto, ncc, hh });
        }
        public DataTable GetUser( string tendn, string mk)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_GET_USER @NAME , @PASS", new object[] {tendn, mk });
        }
        public DataTable GetKhoLamViecUser(string kho)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_KHO_LAM_VIEC_USER @KHO", new object[] {kho});
        }

        public DataTable dongiatheongay(DateTime date,string ncc, string hh, string kh)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_TINH_DON_GIA_THEO_NGAY @DATE , @NCC , @HH , @KH", new object[] { date, ncc, hh, kh });
        }

        public DataTable gettaikhoandangnhap()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM USER_LOGIN", new object[] {});
        }

        //[SELECT * FROM USER_LOGIN] --

        public DataTable TinhtoanDGDC(DateTime datefrom, string ncc, string hh, string noign, int duongbo, int dieuchinh)
        {          
            return DataProvider.Instance.ExecuteQuery("exec PP_TINH_TOAN_GIA_DIEU_CHINH @DATE_FROM , @NCC , @HH , @NOI_GN , @DUONG_BO , @DIEU_CHINH", new object[] { datefrom, ncc, hh, noign, duongbo, dieuchinh });
           
        }

        public DataTable getnhapkho(DateTime datefrom, DateTime dateto,string ncc, string hh, string maso)
        {
            return DataProvider.Instance.ExecuteQuery("exec PP_UI_GET_NHAT_KY_NHAP_KHO @DATE_FROM , @DATE_TO , @NCC , @HH , @MA_SO", new object[] { datefrom, dateto,ncc, hh, maso});

        }
        public DataTable getxuatkho(DateTime DATE_FROM , DateTime DATE_TO ,string NCC , string KH , string HH , string MA_SO)
        {
            return DataProvider.Instance.ExecuteQuery("exec PP_UI_GET_NHAT_KY_XUAT_KHO @DATE_FROM , @DATE_TO , @NCC , @KH , @HH , @MA_SO", new object[] { DATE_FROM, DATE_TO, NCC, KH, HH, MA_SO });

        }
        //
        public int UpdateNCC(int ACTION, int ID, string ma, string ten, string ghichu)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec PP_UI_UPDATE_NCC @ACTION , @ID , @MA_NCC , @TEN_NCC , @GHI_CHU", new object[] { ACTION, ID, ma, ten, ghichu });
        }

        public int UpdateDMHH(int ACTION, int ID, string ma, string ten, int khoiluong, string ghichu)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec PP_UI_UPDATE_DM_HH @ACTION , @ID , @MA , @TEN , @KL , @GHI_CHU", new object[] { ACTION, ID, ma, ten, khoiluong, ghichu });
        }


        public int UpdateDonGiaChuyenDoiNCC(int ACTION, int ID, string ncc, string nccgoc, string ghichu)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec PP_UI_UPDATE_CHUYEN_DOI_GIA_NCC @ACTION , @ID , @MA_NCC , @MA_NCC_GOC , @GHI_CHU", new object[] { ACTION, ID, ncc, nccgoc, ghichu });
        }
        public int UpdateDMKH(int ACTION, int ID, string KH, string PLKH, string ghichu)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec PP_UI_UPDATE_DM_KH @ACTION , @ID , @KH , @PLKH , @GHI_CHU", new object[] { ACTION, ID, KH, PLKH, ghichu });
        }

        public int UpdateXeVC(int ACTION, int ID, string bienso, string taixe, string ncc, string ghichu)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec PP_UI_UPDATE_DM_XE_VC @ACTION , @ID , @BIEN_SO , @TX , @MA_NCC , @GHI_CHU", new object[] { ACTION, ID, bienso, taixe, ncc , ghichu });
        }
        public int UpdateXeKH(int ACTION, int ID, string bienso, string KH, string ghichu)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec PP_UI_UPDATE_DM_XE_KH @ACTION , @ID , @BIEN_SO , @KH , @GHI_CHU", new object[] { ACTION, ID, bienso, KH, ghichu });
        }
        public int UpdateDGGoc(int ACTION, int ID, DateTime date, string tenhang, string mancc, string noign, int duongbo, int dongia)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec PP_UI_UPDATE_DON_GIA_GOC @ACTION , @ID , @DATE , @TEN_HH , @MA_NCC , @NOI_GN , @DUONG_BO , @DON_GIA", new object[] { ACTION, ID, date, tenhang, mancc, noign, duongbo, dongia });
        }

        public int UpdatedDieuChinhKH(int ACTION, int ID, DateTime datefrom, DateTime dateto, string kh, string mancc, string hh,string noign, int duongbo, int dieuchinh, int dongia)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec PP_UI_UPDATE_DIEU_CHINH_DG_KH @ACTION , @ID , @NGAY_BD , @NGAY_KT , @KH , @NCC , @HH , @NOI_GN , @DUONG_BO , @DIEU_CHINH , @DON_GIA", new object[] { ACTION, ID, datefrom, dateto, kh, mancc, hh, noign, duongbo, dieuchinh, dongia });
        }
        public int UpdatedNKHH(int ACTION, int ID, DateTime ngaybd, string ncc, string hh, string maso, string noinhan, decimal soluong, string tm, string bienso, string kh, string ctr, string thutien, string ghichu, string taixe)
        {
            return DataProvider.Instance.ExecuteNonQuery("PP_UI_UPDATE_NHAT_KY_HANG_HOANG @ACTION , @ID , @NGAY_GD , @NCC , @HH , @MA_SO , @NOI_GN , @SO_LUONG , @TM , @BIEN_SO , @KH , @CTR , @THU_TIEN , @GHI_CHU , @TAI_XE", new object[] { ACTION,  ID,  ngaybd,  ncc,  hh,  maso,  noinhan,  soluong,  tm,  bienso, kh,  ctr,  thutien,  ghichu,  taixe });
        }

        public int UpdatedNhapKho(int ACTION ,int ID ,DateTime DATE ,string HH ,string MA_SO ,int SO_BAO ,string BIEN_SO ,string TX ,string RO_MOC ,string GHI_CHU ,string TEN_DN, string NCC)
        {
            return DataProvider.Instance.ExecuteNonQuery("PP_UI_UPDATE_NHAT_KY_NHAP_KHO @ACTION , @ID , @DATE , @HH , @MA_SO , @SO_BAO , @BIEN_SO , @TX , @RO_MOC , @GHI_CHU , @TEN_DN , @NCC", new object[] { ACTION , ID , DATE , HH , MA_SO , SO_BAO , BIEN_SO , TX , RO_MOC , GHI_CHU , TEN_DN, NCC });
        }

        public int UpdatedXuatKho(int ACTION ,int ID ,string NCC ,DateTime NGAY_XUAT , string HH , string MA_SO ,int SL , string BIEN_SO , string KH , string TX ,int TM ,int TIEN , string GHI_CHU ,int ID_LOGIN)
        {
            return DataProvider.Instance.ExecuteNonQuery("PP_UI_UPDATE_NHAT_KY_XUAT_HANG @ACTION , @ID , @NCC , @NGAY_XUAT , @HH , @MA_SO , @SL , @BIEN_SO , @KH , @TX , @TM , @TIEN , @GHI_CHU , @ID_LOGIN", new object[] { ACTION, ID, NCC, NGAY_XUAT, HH, MA_SO, SL, BIEN_SO, KH, TX, TM, TIEN, GHI_CHU, ID_LOGIN});
        }

        public int UpdateNhatKyNCC(int ACTION ,int ID ,string NCC ,DateTime DATE ,string HH ,string MASO ,string NOI_NHAN ,decimal SO_LUONG ,string BIEN_SO ,string KH ,string TX ,string GHI_CHU ,int ID_LONGIN )
        {
            return DataProvider.Instance.ExecuteNonQuery("PP_UI_UPDATE_NHAT_KY_NCC @ACTION , @ID , @NCC , @DATE , @HH , @MASO , @NOI_NHAN , @SO_LUONG , @BIEN_SO , @KH , @TX , @GHI_CHU , @ID_LONGIN", new object[] { ACTION, ID, NCC, DATE, HH, MASO, NOI_NHAN, SO_LUONG, BIEN_SO, KH, TX, GHI_CHU, ID_LONGIN });
        }

        public int ImportFileExcel(int idncc, string path, int idlogin)
        {
            return DataProvider.Instance.ExecuteNonQuery("EXEC PP_IMPORT_EXCEL @ID_NCC , @FILE_PATH , @ID_LOGIN", new object[] { idncc, path, idlogin });
        }
    }

}
