using System.Configuration;
using System.Linq;

namespace SachOnline.Models
{
    public class GioHang
    {
        private dbSachOnlineDataContext db = new dbSachOnlineDataContext(ConfigurationManager.ConnectionStrings["SachOnlineConnectionString"].ConnectionString);
        public int iMaSach { get; set; }
        public string sTenSach { get; set; }
        public string sAnhBia { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }

        public double dThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }

        public GioHang(int ms)
        {
            iMaSach = ms;
            SACH s = db.SACHes.Single(n => n.MaSach == iMaSach);
            sTenSach = s.TenSach;
            sAnhBia = s.AnhBia;
            dDonGia = double.Parse(s.GiaBan.ToString());
            iSoLuong = 1;
        }
    }
}