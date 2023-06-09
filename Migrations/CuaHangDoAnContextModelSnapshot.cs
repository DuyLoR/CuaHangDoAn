﻿// <auto-generated />
using System;
using CuaHangDoAn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CuaHangDoAn.Migrations
{
    [DbContext(typeof(CuaHangDoAnContext))]
    partial class CuaHangDoAnContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CuaHangDoAn.Models.DonHang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DiaChiGiaoHang")
                        .HasColumnType("longtext");

                    b.Property<bool>("DichVuGiaoHang")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("KhachHangId")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayDat")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("NhanVienId")
                        .HasColumnType("int");

                    b.Property<int?>("PhuongThucThanhToanId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<float>("TongTien")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("KhachHangId");

                    b.HasIndex("NhanVienId");

                    b.HasIndex("PhuongThucThanhToanId");

                    b.ToTable("DonHangs");
                });

            modelBuilder.Entity("CuaHangDoAn.Models.HoaDonMuaNguyenLieu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("GiaNguyenLieu")
                        .HasColumnType("float");

                    b.Property<DateTime>("NgayDat")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("NguyenLieuId")
                        .HasColumnType("int");

                    b.Property<int>("NhaCungCapId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<float>("TongTien")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("NguyenLieuId");

                    b.HasIndex("NhaCungCapId");

                    b.ToTable("HoaDonMuaNguyenLieus");
                });

            modelBuilder.Entity("CuaHangDoAn.Models.KhachHang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Sdt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("KhachHangs");
                });

            modelBuilder.Entity("CuaHangDoAn.Models.KhoNguyenLieu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("KhoNguyenLieus");
                });

            modelBuilder.Entity("CuaHangDoAn.Models.MonAn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("DonHangId")
                        .HasColumnType("int");

                    b.Property<float>("Gia")
                        .HasColumnType("float");

                    b.Property<string>("TenMon")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("DonHangId");

                    b.ToTable("MonAns");
                });

            modelBuilder.Entity("CuaHangDoAn.Models.NguyenLieu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DonViTinh")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TenNguyenLieu")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("NguyenLieus");
                });

            modelBuilder.Entity("CuaHangDoAn.Models.NhaCungCap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Sdt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("NhaCungCaps");
                });

            modelBuilder.Entity("CuaHangDoAn.Models.NhanVien", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Sdt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("NhanViens");
                });

            modelBuilder.Entity("CuaHangDoAn.Models.PhuongThucThanhToan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("TenPhuongThuc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("PhuongThucThanhToans");
                });

            modelBuilder.Entity("CuaHangDoAn.Models.DonHang", b =>
                {
                    b.HasOne("CuaHangDoAn.Models.KhachHang", "KhachHang")
                        .WithMany()
                        .HasForeignKey("KhachHangId");

                    b.HasOne("CuaHangDoAn.Models.NhanVien", "NhanVien")
                        .WithMany()
                        .HasForeignKey("NhanVienId");

                    b.HasOne("CuaHangDoAn.Models.PhuongThucThanhToan", "PhuongThucThanhToan")
                        .WithMany()
                        .HasForeignKey("PhuongThucThanhToanId");

                    b.Navigation("KhachHang");

                    b.Navigation("NhanVien");

                    b.Navigation("PhuongThucThanhToan");
                });

            modelBuilder.Entity("CuaHangDoAn.Models.HoaDonMuaNguyenLieu", b =>
                {
                    b.HasOne("CuaHangDoAn.Models.NguyenLieu", "NguyenLieu")
                        .WithMany()
                        .HasForeignKey("NguyenLieuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CuaHangDoAn.Models.NhaCungCap", "NhaCungCap")
                        .WithMany()
                        .HasForeignKey("NhaCungCapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguyenLieu");

                    b.Navigation("NhaCungCap");
                });

            modelBuilder.Entity("CuaHangDoAn.Models.MonAn", b =>
                {
                    b.HasOne("CuaHangDoAn.Models.DonHang", null)
                        .WithMany("DsMonAn")
                        .HasForeignKey("DonHangId");
                });

            modelBuilder.Entity("CuaHangDoAn.Models.DonHang", b =>
                {
                    b.Navigation("DsMonAn");
                });
#pragma warning restore 612, 618
        }
    }
}
