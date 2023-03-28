namespace CuaHangDoAn.Models
{
    public class DonHang
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime NgayDat { get; set; } = DateTime.Now;

        public float TongTIen { get; set; }

        public int SoLuong { get; set; }

        public PhuongThucThanhToan? PhuongThucThanhToan { get; set; }

        public KhachHang? KhachHang { get; set; }

        public List<MonAn>? DsMonAn { get; set; }

        public bool DichVuGiaoHang { get; set; }

        public string? DiaChiGiaoHang { get; set; }

    }
}
