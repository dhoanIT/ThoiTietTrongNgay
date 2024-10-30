using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using De2API.Models;

namespace De2API.Controllers
{
    public class ThoiTietTrongNgayController : ApiController
    {
        DBTTEntities db = new DBTTEntities();
        [HttpGet]
        public List<ThoiTietTrongNgay> ThongTinThoiTiet()
        {
            return db.ThoiTietTrongNgays.ToList();
        }
        [HttpPost]
        public bool Them(DateTime gio, string maKV, decimal nhietdo, decimal doam)
        {
            ThoiTietTrongNgay tttn = db.ThoiTietTrongNgays.FirstOrDefault(x => x.MaKhuVuc == maKV);
            if (tttn == null) 
            { 
                ThoiTietTrongNgay tt1 = new ThoiTietTrongNgay();
                tt1.MaKhuVuc = maKV;
                tt1.DoAm = doam;
                tt1.NhietDo = nhietdo;
                tt1.Gio = gio;
                db.ThoiTietTrongNgays.Add(tt1);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        [HttpDelete]
        public bool Xoa(DateTime gio, string maKV)
        {
            ThoiTietTrongNgay tttn = db.ThoiTietTrongNgays.FirstOrDefault(x => x.MaKhuVuc == maKV
            && x.Gio == gio);
            if (tttn != null)
            {         

                db.ThoiTietTrongNgays.Remove(tttn);
                db.SaveChanges();
                return true;
            }
            return false;
           
            
        }

    }
}
