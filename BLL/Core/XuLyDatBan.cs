using BLL.Core;
using BLL.DB;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class XuLyDatBan:BaseXuLy
    {
        public string trangThaiChuaNhan = "Chưa Nhận";
        public string trangThaiDaHuy = "Đã Hủy";
        public string trangThaiDaNhan = "Đã Nhận";
        public string[] listTrangThai = { "Chưa Nhận", "Đã Hủy", "Đã Nhận" };
        XuLyBan xuLyBan = new XuLyBan();
        XuLyTrangThaiBan xuLyTrangThaiBan = new XuLyTrangThaiBan();
        public bool KT_TonTai(string maDB) 
        {
            DatBan db = ctx.DatBans.FirstOrDefault(v => v.maDatBan.Trim().Equals(maDB.Trim()));
            if(db == null)
            {
                return false;
            }
            return true;
        }
        public int themDatBan(DatBan datban)
        {
            try
            {
                bool checkKT = KT_TonTai(datban.maDatBan);
                bool checkTrangThai = xuLyBan.checkBanTrong(datban.MaBan);
                if (checkKT == true || checkTrangThai==false) { return 0; }
                ctx.DatBans.InsertOnSubmit(datban);
                ctx.SubmitChanges();
                //cập nhật bàn đó đã đặt
                xuLyBan.capNhatTrangThaiBan(datban.MaBan, xuLyTrangThaiBan.maTrangThaiBanDaDat);
                return 1;
            }
            catch { return 0; }
        }
        public int capNhatTrangThai (string maDB, string trangthai, string maban )
        {
            try
            {
                DatBan db = ctx.DatBans.FirstOrDefault(v => v.maDatBan.Trim().Equals(maDB));
                if (db == null) { return 0; }
                db.TrangThai = trangthai;
                if (trangthai.Trim().Equals(trangThaiDaHuy.Trim()))
                {
                    xuLyBan.capNhatTrangThaiBan(maban, xuLyTrangThaiBan.maTrangThaiBanTrong);
                }
                ctx.SubmitChanges();
                return 1;
            }
            catch { return 0; }
        }
        public List<DatBan> getAll()
        {
            try
            {
                ctx.Refresh(RefreshMode.OverwriteCurrentValues, ctx.DatBans);
                List<DatBan> listDB = new List<DatBan>();
                listDB = ctx.DatBans.ToList();
                return listDB;
            }
            catch { return null; }
        }
        public List<DatBan> getBySDT(string sdt)
        {
            try
            {
                List<DatBan> listDB = new List<DatBan>();
                listDB = ctx.DatBans.Where(v => v.SoDienThoai.Trim().Equals(sdt.Trim())).ToList();
                return listDB;
            }
            catch { return null; }
        }
    }
}
