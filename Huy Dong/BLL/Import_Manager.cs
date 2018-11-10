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


        //DM_HANG_HOA
        public DataTable GetHH()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT ID, MA_HANG, TEN_HANG, KHOI_LUONG, GHI_CHU FROM DM_HANG_HOA", new object[] { });
        }

        public int UpdateDMHH(int ACTION, int ID, string ma, string ten, int khoiluong, string ghichu)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec PP_UI_UPDATE_DM_HH @ACTION , @ID , @MA , @TEN , @KL , @GHI_CHU", new object[] { ACTION, ID, ma, ten, khoiluong, ghichu });
        }
        //public DataTable GetAllXeVC()
        //{
        //    return DataProvider.Instance.ExecuteQuery("SELECT BIEN_SO FROM DM_XE_VC_KH UNION SELECT BIEN_SO FROM DM_XE_HUY_DONG", new object[] { });
        //}
        //DM_NCC
        public DataTable GetNCC()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM DM_NCC ", new object[] { });
        }
        public DataTable GetDanhSachKho()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM DM_NCC WHERE GHI_CHU = 'KHO'", new object[] { });
        }
        public int UpdateNCC(int ACTION, int ID, string ma, string ten, string ghichu)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec PP_UI_UPDATE_NCC @ACTION , @ID , @MA_NCC , @TEN_NCC , @GHI_CHU", new object[] { ACTION, ID, ma, ten, ghichu });
        }
        //DM_Khach_Hang
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
            return DataProvider.Instance.ExecuteQuery("SELECT SUBSTRING(BIEN_SO, CHARINDEX('-', BIEN_SO) + 1, len(BIEN_SO) - CHARINDEX('-', BIEN_SO)) + '-' +  SUBSTRING(BIEN_SO, 1 , CHARINDEX('-', BIEN_SO) - 1) AS BIEN_SO_SHORT, BIEN_SO FROM DM_XE_HUY_DONG WHERE LEN(BIEN_SO)> 0 AND GHI_CHU LIKE 'RO_MOOC'", new object[] {  });
        }

        public DataTable Checkmasonhapkho(string maso)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_CHECK_MA_NHAP_KHO @MASO", new object[] {maso });
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
        public DataTable getNhatKyNCC(DateTime datefrom, DateTime dateto, string ncc, string hh, string kh, string bienso, string taixe)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_NHAT_KY_NCC @DATE_FROM , @DATE_TO , @NCC , @HH , @KH , @BIENSO , @TAIXE", new object[] { datefrom, dateto, ncc, hh, kh, bienso, taixe });
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

        public DataTable getDSKHkoapKM(int idkm)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_DS_KH_KO_AP_KM @ID_KM", new object[] {idkm });
        }

        public DataTable getck1(int nam, int thang)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_CK1 @NAM , @THANG", new object[] { nam, thang });
        }
        public DataTable getck2(string kh)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_CK2 @KH", new object[] { kh });
        }

        public DataTable laytenxetheoduoixe(string bs)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_BIEN_SO_KH_BY_SHORT_BIEN_SO @SHORT_BS", new object[] { bs });
        }

        public DataTable getallxe()
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_ALL_XE_XUAT_KHO", new object[] { });
        }

        public DataTable getxehuydong()
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_XE_HUY_DONG", new object[] { });
        }
        public DataTable gettontheomaso(string ms)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_TON_THEO_MA_SO @MS", new object[] { ms});
        }

        public DataTable taophieuxuat(DateTime date, string ncc, string kh)
        {
            return DataProvider.Instance.ExecuteQuery("PP_TAO_PHIEU_XUAT_TU_DONG @DATE , @NCC , @KH", new object[] { date, ncc, kh });
        }

        public DataTable kiemtranhaplieu(string ncc, string loainhaplieu)
        {
            return DataProvider.Instance.ExecuteQuery("PP_KIEM_TRA_NHAP_LIEU @NCC , @LOAI_DL", new object[] { ncc, loainhaplieu });
        }
        //[PP_NHAP_XUAT_TON] --

        public DataTable TinhtoanDGDC(DateTime datefrom, string ncc, string hh, string noign, int duongbo, int dieuchinh)
        {          
            return DataProvider.Instance.ExecuteQuery("exec PP_TINH_TOAN_GIA_DIEU_CHINH @DATE_FROM , @NCC , @HH , @NOI_GN , @DUONG_BO , @DIEU_CHINH", new object[] { datefrom, ncc, hh, noign, duongbo, dieuchinh });
           
        }

        public DataTable BaoCaoChiTietMatHang(DateTime datefrom, DateTime dateto, string hh, string ncc, string maso, int hhncc)
        {
            return DataProvider.Instance.ExecuteQuery("exec PP_CHI_TIET_MAT_HANG @DATE_FROM , @DATE_TO , @HH , @NCC , @MASO , @HH_NCC", new object[] { datefrom, dateto, hh, ncc, maso, hhncc });
        }

        public DataTable BaoCaoNXT(DateTime datefrom, DateTime dateto, string hh, string ncc, int hhncc)
        {
            return DataProvider.Instance.ExecuteQuery("exec PP_NHAP_XUAT_TON @DATE_FROM , @DATE_TO , @HH , @NCC , @HH_NCC", new object[] { datefrom, dateto, hh, ncc, hhncc });
        }

        //NHAT_KY_KHO
        public DataTable getnhapkho(DateTime datefrom, DateTime dateto,string ncc, string hh, string maso)
        {
            return DataProvider.Instance.ExecuteQuery("exec PP_UI_GET_NHAT_KY_NHAP_KHO @DATE_FROM , @DATE_TO , @NCC , @HH , @MA_SO", new object[] { datefrom, dateto,ncc, hh, maso});

        }
        public int UpdatedNhapKho(int ACTION, int ID, DateTime DATE, string HH, string MA_SO, int SO_BAO, string BIEN_SO, string TX, string RO_MOC, string GHI_CHU, string TEN_DN, string NCC)
        {
            return DataProvider.Instance.ExecuteNonQuery("PP_UI_UPDATE_NHAT_KY_NHAP_KHO @ACTION , @ID , @DATE , @HH , @MA_SO , @SO_BAO , @BIEN_SO , @TX , @RO_MOC , @GHI_CHU , @TEN_DN , @NCC", new object[] { ACTION, ID, DATE, HH, MA_SO, SO_BAO, BIEN_SO, TX, RO_MOC, GHI_CHU, TEN_DN, NCC });
        }
        public DataTable getxuatkho(DateTime DATE_FROM , DateTime DATE_TO ,string NCC , string KH , string HH , string MA_SO, string bienso, string taixe)
        {
            return DataProvider.Instance.ExecuteQuery("exec PP_UI_GET_NHAT_KY_XUAT_KHO @DATE_FROM , @DATE_TO , @NCC , @KH , @HH , @MA_SO , @BIEN_SO , @TAIXE", new object[] { DATE_FROM, DATE_TO, NCC, KH, HH, MA_SO, bienso, taixe });

        }
        public int UpdatedXuatKho(int ACTION, int ID, string NCC, DateTime NGAY_XUAT, string HH, string MA_SO, int SL, string BIEN_SO, string KH, string TX, int TM, int TIEN, string GHI_CHU, int ID_LOGIN, string phieuxuat)
        {
            return DataProvider.Instance.ExecuteNonQuery("PP_UI_UPDATE_NHAT_KY_XUAT_HANG @ACTION , @ID , @NCC , @NGAY_XUAT , @HH , @MA_SO , @SL , @BIEN_SO , @KH , @TX , @TM , @TIEN , @GHI_CHU , @ID_LOGIN , @PX", new object[] { ACTION, ID, NCC, NGAY_XUAT, HH, MA_SO, SL, BIEN_SO, KH, TX, TM, TIEN, GHI_CHU, ID_LOGIN, phieuxuat });
        }
        //

        public DataTable getKMNCC(int nam, int thang)
        {
            return DataProvider.Instance.ExecuteQuery("exec PP_UI_GET_CHUONG_TRINH_KHUYEN_MAI_NCC @YEAR , @MONTH", new object[] { nam, thang });

        }

        public DataTable tonghopSLH(DateTime tungay, DateTime denngay, string ncc, string hh, string kh)
        {
            return DataProvider.Instance.ExecuteQuery("exec PP_TONG_HOP_SO_LIEU_HANG @DATE_FROM , @DATE_TO , @NCC , @HH , @KH", new object[] { tungay, denngay, ncc, hh, kh});

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

        public int UpdateNhatKyNCC(int ACTION ,int ID ,string NCC ,DateTime DATE ,string HH ,string MASO ,string NOI_NHAN ,decimal SO_LUONG ,string BIEN_SO ,string KH ,string TX ,string GHI_CHU ,int ID_LONGIN )
        {
            return DataProvider.Instance.ExecuteNonQuery("PP_UI_UPDATE_NHAT_KY_NCC @ACTION , @ID , @NCC , @DATE , @HH , @MASO , @NOI_NHAN , @SO_LUONG , @BIEN_SO , @KH , @TX , @GHI_CHU , @ID_LONGIN", new object[] { ACTION, ID, NCC, DATE, HH, MASO, NOI_NHAN, SO_LUONG, BIEN_SO, KH, TX, GHI_CHU, ID_LONGIN });
        }

        public int ImportFileExcel(int idncc, string path, int idlogin)
        {
            return DataProvider.Instance.ExecuteNonQuery("EXEC PP_IMPORT_EXCEL @ID_NCC , @FILE_PATH , @ID_LOGIN", new object[] { idncc, path, idlogin });
        }
        
        public int UpdateUserLogin(int action, int id, string ten, string mk, string quyen, string kho)
        {
            return DataProvider.Instance.ExecuteNonQuery("EXEC PP_UI_UPDATE_USER_LOGIN @ACTION , @ID , @TEN , @MK , @QUYEN , @KHO", new object[] { action, id, ten, mk, quyen, kho });
        }

        public int UpdateKMNCC(int action, int id, DateTime ngaybd, DateTime ngaykt, string hanghoa , int giam, string donvi)
        {
            return DataProvider.Instance.ExecuteNonQuery("EXEC PP_UI_UPDATE_CHUONG_TRINH_KHUYEN_MAI_NCC @ACTION , @ID , @NGAY_BD , @NGAY_KT , @HH , @GIAM , @DON_VI", new object[] { action, id, ngaybd, ngaykt, hanghoa, giam, donvi });
        }

        public int UpdateCK1(int action, int id, string diengiai, DateTime ngaybd, DateTime ngaykt, string ncc, string kh, string hanghoa, int giam, string donvi)
        {
            return DataProvider.Instance.ExecuteNonQuery("EXEC PP_UI_UPDATE_CK1 @ACTION , @ID , @DIEN_GIAI , @NGAY_BD , @NGAY_KT , @NCC , @KH , @HH , @GIAM , @DON_VI", new object[] { action, id, diengiai, ngaybd, ngaykt, ncc, kh, hanghoa, giam, donvi });
        }

        public int UpdateCK2(int action, int id, string diengiai, string ghichu, DateTime ngay, string hh, int sl, int tien, string kh, DateTime ngayad)
        {
            return DataProvider.Instance.ExecuteNonQuery("EXEC PP_UI_UPDATE_CK2 @ACTION , @ID , @DIEN_GIAI , @GHI_CHU , @NGAY , @HH , @SL , @TIEN , @KH , @NGAY_AP", new object[] { action, id, diengiai, ghichu, ngay, hh, sl, tien, kh, ngayad });
        }

        //PP_UI_UPDATE_DS_KH_KO_AP_KM
        public int UpdateKMNCC( string query, int idkm)
        {
            return DataProvider.Instance.ExecuteNonQuery("EXEC PP_UI_UPDATE_DS_KH_KO_AP_KM @QUERY , @ID_KM", new object[] { query, idkm});
        }
        public int UpdateMASO(string mssai, string msdung)
        {
            return DataProvider.Instance.ExecuteNonQuery("EXEC PP_UI_UPDATE_MA_SO @MASO_SAI , @MASO_DUNG", new object[] { mssai, msdung });
        }
        //DON_GIA_VAN_CHUYEN_KHACH_HANG

        public DataTable getDonGiaVCKH(string loaihinh)
        {
            return DataProvider.Instance.ExecuteQuery("exec PP_UI_GET_DON_GIA_VAN_CHUYEN_KHACH_HANG @loai_hinh", new object[] { loaihinh });

        }
        public int UpdateDonGiaVCKH(int action, int id, DateTime ngaytinh, string code, string loaihinh, decimal dongia, string ten_user)
        {
            return DataProvider.Instance.ExecuteNonQuery("EXEC PP_UI_UPDATE_DON_GIA_VAN_CHUYEN_KHACH_HANG @ACTICON , @ID , @NGAY , @CODE , @LOAI_HINH , @DON_GIA , @ID_USER", new object[] { action, id, ngaytinh, code, loaihinh, dongia, ten_user });
        }
        //GIA_DIEU_CHINH_KH
        public DataTable getDieuChinhGiaKH(string loaihinh, string kh, string sp)
        {
            return DataProvider.Instance.ExecuteQuery("exec PP_UI_GET_GIA_DIEU_CHINH_KH @loai_hinh , @kh , @sp", new object[] { loaihinh, kh, sp });

        }
        public int UpdateDieuChinhGiaKH(int ACTION ,int ID ,DateTime DATE ,string CODE ,string LOAI_HINH ,string KH ,string SP ,decimal GIA ,string USER)
        {
            return DataProvider.Instance.ExecuteNonQuery("EXEC PP_UI_UPDATE_GIA_DIEU_CHINH_KH @ACTION , @ID , @DATE , @CODE , @LOAI_HINH , @KH , @SP , @GIA , @USER", new object[] { ACTION , ID , DATE , CODE , LOAI_HINH , KH , SP , GIA , USER });
        }

        //DON_GIA_VAN_CHUYEN_KHO
        public DataTable getDonGiaVCKho(string sp)
        {
            return DataProvider.Instance.ExecuteQuery("exec PP_UI_GET_DON_GIA_VAN_CHUYEN_KHO @sp", new object[] { sp });

        }
        public int UpdateDonGiaVCKho(int ACTION ,int ID ,DateTime DATE , string SP , decimal PRICE , string USER)
        {
            return DataProvider.Instance.ExecuteNonQuery("EXEC PP_UI_UPDATE_DON_GIA_VAN_CHUYEN_KHO @ACTION , @ID , @DATE , @SP , @PRICE , @USER", new object[] { ACTION, ID, DATE, SP, PRICE, USER });
        }
        //DON_GIA_DC_THEO_NCC

        public DataTable getDonGiaDCNCC(string sp, string kh, string ncc)
        {
            return DataProvider.Instance.ExecuteQuery("exec PP_UI_GET_DON_GIA_DC_THEO_NCC @kh , @sp , @ncc", new object[] {kh, sp, ncc });

        }
        public int UpdateDonGiaDCNCC(int ACTION, int ID, DateTime DATE, string KH, string SP, string NCC, decimal PRICE, string USER)
        {
            return DataProvider.Instance.ExecuteNonQuery("EXEC PP_UI_UPDATE_DON_GIA_DC_THEO_NCC @ACTION , @ID , @DATE , @KH , @SP , @NCC , @PRICE , @USER", new object[] { ACTION , ID , DATE , KH , SP , NCC , PRICE , USER});
        }
        //
        public int DeleteMASO(string mssai)
        {
            return DataProvider.Instance.ExecuteNonQuery("EXEC PP_UI_DELETE_MA_SO @MASO_SAI", new object[] { mssai});
        }
    }

}
