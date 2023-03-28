using CuaHangDoAn.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Principal;

namespace CuaHangDoAn.Data
{
    public class CuaHangDoAnContext : DbContext
    {
        public CuaHangDoAnContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<PhuongThucThanhToan>? PhuongThucThanhToans { get; set; } = default!;
        public DbSet<KhachHang>? KhachHangs { get; set; } = default!;
        public DbSet<NguyenLieu>? NguyenLieus { get; set; } = default!;
        public DbSet<KhoNguyenLieu>? KhoNguyenLieus { get; set; } = default!;
        public DbSet<NhaCungCap>? NhaCungCaps { get; set; } = default!;
        public DbSet<HoaDonMuaNguyenLieu>? HoaDonMuaNguyenLieus { get; set; } = default!;
        public DbSet<MonAn>? MonAns { get; set; } = default!;
        public DbSet<DonHang>? DonHangs { get; set; } = default!;
        public DbSet<NhanVien>? NhanViens { get; set; } = default!;

    }
}
