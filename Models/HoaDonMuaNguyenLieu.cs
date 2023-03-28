namespace CuaHangDoAn.Models
{
    public class HoaDonMuaNguyenLieu
    {
        public int Id { get; set; }
        public DateTime NgayDat { get; set; }
        public int SoLuong { get; set; }
        public NguyenLieu NguyenLieu { get; set; }
        public float GiaNguyenLieu { get; set; }
        public float TongTien { get; set; }
        public NhaCungCap NhaCungCap { get; set; }

    }
}
