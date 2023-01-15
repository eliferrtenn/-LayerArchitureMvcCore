using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InformsISG.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "acil_durum_ekipleri",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ekip_Ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_acil_durum_ekipleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "asi_tur",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Asi_Ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asi_tur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ayarlar",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tehlike_Tip = table.Column<int>(type: "int", nullable: false),
                    Egitim_Sure = table.Column<int>(type: "int", nullable: false),
                    Egitim_Sure_Periyot = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Risk_Sure = table.Column<int>(type: "int", nullable: false),
                    Risk_Sure_Periyot = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Saglik_Kontrol = table.Column<int>(type: "int", nullable: false),
                    Saglik_Kontrol_Periyot = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Igu_Sure = table.Column<int>(type: "int", nullable: false),
                    Igu_Sure_Periyot = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ayarlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "beden_bolge",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Beden_Bolge_Ad = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_beden_bolge", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "egitim_konu",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Egitim_Ad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_egitim_konu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hareket",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sayfa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Hareket_Ad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hareket", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "isg_kurul",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kurul_Ad = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Tehlike_Tip = table.Column<int>(type: "int", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_isg_kurul", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "isveren",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isveren_Ad = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_isveren", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "kkd_tur",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kkd_Tur_Ad = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kkd_tur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "risk_analiz_risk",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Risk = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_risk_analiz_risk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "risk_analiz_tehlike",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tehlike = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_risk_analiz_tehlike", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "risk_gerceklesen",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Risk_Gerceklesen_Ad = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_risk_gerceklesen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sgk_meslek",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isco08 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Meslek_Ad = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sgk_meslek", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tehlike_tanim",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tehlike_Tanim_Ad = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tehlike_tanim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "yaralanma_sekli",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Yaralanma_Sekli_Ad = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_yaralanma_sekli", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "asi_sureleri",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Yas = table.Column<int>(type: "int", nullable: false),
                    Periyot_Birim = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Surekli = table.Column<int>(type: "int", nullable: false),
                    Periyot1_1 = table.Column<int>(type: "int", nullable: false),
                    Periyot1_2 = table.Column<int>(type: "int", nullable: false),
                    Periyot2_1 = table.Column<int>(type: "int", nullable: false),
                    Periyot2_2 = table.Column<int>(type: "int", nullable: false),
                    Periyot3_1 = table.Column<int>(type: "int", nullable: false),
                    Periyot3_2 = table.Column<int>(type: "int", nullable: false),
                    Periyot4_1 = table.Column<int>(type: "int", nullable: false),
                    Periyot4_2 = table.Column<int>(type: "int", nullable: false),
                    Periyot5_1 = table.Column<int>(type: "int", nullable: false),
                    Periyot5_2 = table.Column<int>(type: "int", nullable: false),
                    Asi_Tur_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asi_sureleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_asi_sureleri_asi_tur_Asi_Tur_Id",
                        column: x => x.Asi_Tur_Id,
                        principalTable: "asi_tur",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "egitim_konu_alt_baslik",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alt_Baslik_No = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Alt_Baslik_Ad = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Tehlike_Tip = table.Column<int>(type: "int", nullable: false),
                    Sure = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Egitim_Konu_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_egitim_konu_alt_baslik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_egitim_konu_alt_baslik_egitim_konu_Egitim_Konu_Id",
                        column: x => x.Egitim_Konu_Id,
                        principalTable: "egitim_konu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "alt_isveren",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alt_Isveren_Ad = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Notlar = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Kontrol_Edildi = table.Column<bool>(type: "bit", nullable: false),
                    Isg_Kurul_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alt_isveren", x => x.Id);
                    table.ForeignKey(
                        name: "FK_alt_isveren_isg_kurul_Isg_Kurul_Id",
                        column: x => x.Isg_Kurul_Id,
                        principalTable: "isg_kurul",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "isg_kurul_eleman",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gorev = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ad_Soyad = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Unvan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Birim = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Eposta = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Isg_Kurul_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_isg_kurul_eleman", x => x.Id);
                    table.ForeignKey(
                        name: "FK_isg_kurul_eleman_isg_kurul_Isg_Kurul_Id",
                        column: x => x.Isg_Kurul_Id,
                        principalTable: "isg_kurul",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "isg_kurul_karar",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Toplanti_No = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Saat = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Isg_Kurul_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isveren_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_isg_kurul_karar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_isg_kurul_karar_isg_kurul_Isg_Kurul_Id",
                        column: x => x.Isg_Kurul_Id,
                        principalTable: "isg_kurul",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_isg_kurul_karar_isveren_Isveren_Id",
                        column: x => x.Isveren_Id,
                        principalTable: "isveren",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "kullanici",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kullanici_Ad = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Ad_Soyad = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Fotograf = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Internet_Key = table.Column<bool>(type: "bit", nullable: false),
                    Yetki = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Gecici_Key1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Gecici_Key2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Sonlanma_Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Isg_Kurul_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isveren_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kullanici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_kullanici_isg_kurul_Isg_Kurul_Id",
                        column: x => x.Isg_Kurul_Id,
                        principalTable: "isg_kurul",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_kullanici_isveren_Isveren_Id",
                        column: x => x.Isveren_Id,
                        principalTable: "isveren",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "msds",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Urun_Ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Isg_Kurul_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isveren_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_msds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_msds_isg_kurul_Isg_Kurul_Id",
                        column: x => x.Isg_Kurul_Id,
                        principalTable: "isg_kurul",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_msds_isveren_Isveren_Id",
                        column: x => x.Isveren_Id,
                        principalTable: "isveren",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "kkd_tur_alt",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kkd_Tur_Alt_Ad = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Kkd_Tur_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kkd_tur_alt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_kkd_tur_alt_kkd_tur_Kkd_Tur_Id",
                        column: x => x.Kkd_Tur_Id,
                        principalTable: "kkd_tur",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "yaralanan_vucut_bolgesi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Yaralanan_Vucut_Bolgesi_Ad = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Yaralanma_Sekli_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_yaralanan_vucut_bolgesi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_yaralanan_vucut_bolgesi_yaralanma_sekli_Yaralanma_Sekli_Id",
                        column: x => x.Yaralanma_Sekli_Id,
                        principalTable: "yaralanma_sekli",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "egitim_tanimla",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Egitim_Sebep = table.Column<int>(type: "int", nullable: false),
                    Egitim_Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Egitim_Saat = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Egitim_Tur = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Egitim_Yer = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Egitim_Yer_Ad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Egitim_Veren_Tc = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Egitim_Veren_Ad_Soyad = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Tekrar_Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Egitim_Konu_Alt_Baslik_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isg_Kurul_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isveren_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_egitim_tanimla", x => x.Id);
                    table.ForeignKey(
                        name: "FK_egitim_tanimla_egitim_konu_alt_baslik_Egitim_Konu_Alt_Baslik_Id",
                        column: x => x.Egitim_Konu_Alt_Baslik_Id,
                        principalTable: "egitim_konu_alt_baslik",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_egitim_tanimla_isg_kurul_Isg_Kurul_Id",
                        column: x => x.Isg_Kurul_Id,
                        principalTable: "isg_kurul",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_egitim_tanimla_isveren_Isveren_Id",
                        column: x => x.Isveren_Id,
                        principalTable: "isveren",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "birim",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Birim_Ad = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Sgk_No = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Isg_Kurul_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isveren_Id = table.Column<long>(type: "bigint", nullable: false),
                    Alt_IsverenId = table.Column<long>(type: "bigint", nullable: true),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_birim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_birim_alt_isveren_Alt_IsverenId",
                        column: x => x.Alt_IsverenId,
                        principalTable: "alt_isveren",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_birim_isg_kurul_Isg_Kurul_Id",
                        column: x => x.Isg_Kurul_Id,
                        principalTable: "isg_kurul",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_birim_isveren_Isveren_Id",
                        column: x => x.Isveren_Id,
                        principalTable: "isveren",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "isg_kurul_karar_dosya",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dosya = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Isg_Kurul_Karar_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isveren_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_isg_kurul_karar_dosya", x => x.Id);
                    table.ForeignKey(
                        name: "FK_isg_kurul_karar_dosya_isg_kurul_karar_Isg_Kurul_Karar_Id",
                        column: x => x.Isg_Kurul_Karar_Id,
                        principalTable: "isg_kurul_karar",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_isg_kurul_karar_dosya_isveren_Isveren_Id",
                        column: x => x.Isveren_Id,
                        principalTable: "isveren",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "msds_dosya",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dosya = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Msds_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isveren_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_msds_dosya", x => x.Id);
                    table.ForeignKey(
                        name: "FK_msds_dosya_isveren_Isveren_Id",
                        column: x => x.Isveren_Id,
                        principalTable: "isveren",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_msds_dosya_msds_Msds_Id",
                        column: x => x.Msds_Id,
                        principalTable: "msds",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "kkd",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kkd_No = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Kkd_Tanim = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Uretici = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Parca_No = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Standart = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Notlar = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Kullanilma_Durumu = table.Column<bool>(type: "bit", nullable: false),
                    Kkd_Tur_Alt_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isg_Kurul_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isveren_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kkd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_kkd_isg_kurul_Isg_Kurul_Id",
                        column: x => x.Isg_Kurul_Id,
                        principalTable: "isg_kurul",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_kkd_isveren_Isveren_Id",
                        column: x => x.Isveren_Id,
                        principalTable: "isveren",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_kkd_kkd_tur_alt_Kkd_Tur_Alt_Id",
                        column: x => x.Kkd_Tur_Alt_Id,
                        principalTable: "kkd_tur_alt",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "egitim_sinav",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sinav_Ad = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Sinav_Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sinav_Saat = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Isg_Kurul_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isveren_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_egitim_sinav", x => x.Id);
    
                    table.ForeignKey(
                        name: "FK_egitim_sinav_isg_kurul_Isg_Kurul_Id",
                        column: x => x.Isg_Kurul_Id,
                        principalTable: "isg_kurul",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_egitim_sinav_isveren_Isveren_Id",
                        column: x => x.Isveren_Id,
                        principalTable: "isveren",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "acil_eylem_plani",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dosya = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Birim_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isveren_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_acil_eylem_plani", x => x.Id);
                    table.ForeignKey(
                        name: "FK_acil_eylem_plani_birim_Birim_Id",
                        column: x => x.Birim_Id,
                        principalTable: "birim",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_acil_eylem_plani_isveren_Isveren_Id",
                        column: x => x.Isveren_Id,
                        principalTable: "isveren",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tali_birim",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tali_Birim_Ad = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Birim_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isveren_Id = table.Column<long>(type: "bigint", nullable: false),
                    Alt_IsverenId = table.Column<long>(type: "bigint", nullable: true),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tali_birim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tali_birim_alt_isveren_Alt_IsverenId",
                        column: x => x.Alt_IsverenId,
                        principalTable: "alt_isveren",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tali_birim_birim_Birim_Id",
                        column: x => x.Birim_Id,
                        principalTable: "birim",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tali_birim_isveren_Isveren_Id",
                        column: x => x.Isveren_Id,
                        principalTable: "isveren",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "kkd_dosya",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dosya = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Kkd_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isveren_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kkd_dosya", x => x.Id);
                    table.ForeignKey(
                        name: "FK_kkd_dosya_isveren_Isveren_Id",
                        column: x => x.Isveren_Id,
                        principalTable: "isveren",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_kkd_dosya_kkd_Kkd_Id",
                        column: x => x.Kkd_Id,
                        principalTable: "kkd",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "dof",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dof_No = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tip = table.Column<int>(type: "int", nullable: false),
                    Geldigi_Kaynak = table.Column<int>(type: "int", nullable: false),
                    Uygunsuzluk_Tanim = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    Tespit_Eden = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Sorumlular = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Acilis_Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cevap_Sure = table.Column<int>(type: "int", nullable: false),
                    Cevap_Sonlanma_Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sonlanma_Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dof_Acik = table.Column<bool>(type: "bit", nullable: false),
                    Dof_Ad = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    Birim_Id = table.Column<long>(type: "bigint", nullable: false),
                    Tali_Birim_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isg_Kurul_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isveren_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dof", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dof_birim_Birim_Id",
                        column: x => x.Birim_Id,
                        principalTable: "birim",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dof_isg_kurul_Isg_Kurul_Id",
                        column: x => x.Isg_Kurul_Id,
                        principalTable: "isg_kurul",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dof_isveren_Isveren_Id",
                        column: x => x.Isveren_Id,
                        principalTable: "isveren",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dof_tali_birim_Tali_Birim_Id",
                        column: x => x.Tali_Birim_Id,
                        principalTable: "tali_birim",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "makine_ekipman",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ekipman_Kodu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Seri_No = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tanim = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Durum = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Satin_Alma_Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Yil = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Garanti_Baslangic = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Garanti_Bitis = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notlar = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Birim_Id = table.Column<long>(type: "bigint", nullable: false),
                    Tali_Birim_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_makine_ekipman", x => x.Id);
                    table.ForeignKey(
                        name: "FK_makine_ekipman_birim_Birim_Id",
                        column: x => x.Birim_Id,
                        principalTable: "birim",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_makine_ekipman_tali_birim_Tali_Birim_Id",
                        column: x => x.Tali_Birim_Id,
                        principalTable: "tali_birim",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "mali_ihtiyac",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Yil = table.Column<int>(type: "int", nullable: false),
                    Ihtiyac = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Tahmini_Maaliyet = table.Column<int>(type: "int", nullable: false),
                    Dtar = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Birim_Id = table.Column<long>(type: "bigint", nullable: false),
                    Tali_Birim_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isg_Kurul_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mali_ihtiyac", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mali_ihtiyac_birim_Birim_Id",
                        column: x => x.Birim_Id,
                        principalTable: "birim",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_mali_ihtiyac_isg_kurul_Isg_Kurul_Id",
                        column: x => x.Isg_Kurul_Id,
                        principalTable: "isg_kurul",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_mali_ihtiyac_tali_birim_Tali_Birim_Id",
                        column: x => x.Tali_Birim_Id,
                        principalTable: "tali_birim",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ortam_olcum",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Olcum_Tur = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Olcum_Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Olcum_Sonuc = table.Column<bool>(type: "bit", maxLength: 10, nullable: false),
                    Olcum_Birim = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Tali_Birim_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isveren_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ortam_olcum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ortam_olcum_isveren_Isveren_Id",
                        column: x => x.Isveren_Id,
                        principalTable: "isveren",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ortam_olcum_tali_birim_Tali_Birim_Id",
                        column: x => x.Tali_Birim_Id,
                        principalTable: "tali_birim",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "personel_bilgi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Personel_Tipi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fotograf = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Unvan = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Unvan_Kisaltilmis = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Ad_Soyad = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Soyad_Ikinci = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Sicil_No = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sgk_No = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tc_No = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Dogum_Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dogum_Yer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cinsiyet = table.Column<bool>(type: "bit", nullable: false),
                    Is_Giris_Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Medeni_Durum = table.Column<int>(type: "int", nullable: false),
                    Telefon1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Telefon2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Egitim = table.Column<int>(type: "int", nullable: false),
                    Egitim_Meslek = table.Column<int>(type: "int", nullable: false),
                    Eposta = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Is_Cikis_Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kadro_Durumu = table.Column<bool>(type: "bit", nullable: false),
                    Sgk_Meslek_Id = table.Column<long>(type: "bigint", nullable: false),
                    Birim_Id = table.Column<long>(type: "bigint", nullable: false),
                    Tali_Birim_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isveren_Id = table.Column<long>(type: "bigint", nullable: false),
                    Alt_IsverenId = table.Column<long>(type: "bigint", nullable: true),
                    KullaniciId = table.Column<long>(type: "bigint", nullable: true),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personel_bilgi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_personel_bilgi_alt_isveren_Alt_IsverenId",
                        column: x => x.Alt_IsverenId,
                        principalTable: "alt_isveren",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personel_bilgi_birim_Birim_Id",
                        column: x => x.Birim_Id,
                        principalTable: "birim",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_personel_bilgi_isveren_Isveren_Id",
                        column: x => x.Isveren_Id,
                        principalTable: "isveren",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_personel_bilgi_kullanici_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "kullanici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personel_bilgi_sgk_meslek_Sgk_Meslek_Id",
                        column: x => x.Sgk_Meslek_Id,
                        principalTable: "sgk_meslek",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_personel_bilgi_tali_birim_Tali_Birim_Id",
                        column: x => x.Tali_Birim_Id,
                        principalTable: "tali_birim",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ramak_kala",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ramak_Kala_No = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Ad_Soyad = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Saat = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Gorev = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Olay = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Olay_Tam_Yer = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Oneri = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Amir_Gorus = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Igu_Gorus = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Igu_Gorus_Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Termin_Sure = table.Column<int>(type: "int", nullable: false),
                    Is_Tanim = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Tamamlandi = table.Column<bool>(type: "bit", nullable: false),
                    Tamamlandi_Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Birim_Id = table.Column<long>(type: "bigint", nullable: false),
                    Tali_Birim_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isg_Kurul_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isveren_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ramak_kala", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ramak_kala_birim_Birim_Id",
                        column: x => x.Birim_Id,
                        principalTable: "birim",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ramak_kala_isg_kurul_Isg_Kurul_Id",
                        column: x => x.Isg_Kurul_Id,
                        principalTable: "isg_kurul",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ramak_kala_isveren_Isveren_Id",
                        column: x => x.Isveren_Id,
                        principalTable: "isveren",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ramak_kala_tali_birim_Tali_Birim_Id",
                        column: x => x.Tali_Birim_Id,
                        principalTable: "tali_birim",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "risk_analiz",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Analiz_No = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Analiz_Tanim = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Analiz_Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Bitis_Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Analiz_Yapanlar = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Analiz_Yontem = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Notlar = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Dosya = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Birim_Id = table.Column<long>(type: "bigint", nullable: false),
                    Tali_Birim_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isg_Kurul_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_risk_analiz", x => x.Id);
                    table.ForeignKey(
                        name: "FK_risk_analiz_birim_Birim_Id",
                        column: x => x.Birim_Id,
                        principalTable: "birim",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_risk_analiz_isg_kurul_Isg_Kurul_Id",
                        column: x => x.Isg_Kurul_Id,
                        principalTable: "isg_kurul",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_risk_analiz_tali_birim_Tali_Birim_Id",
                        column: x => x.Tali_Birim_Id,
                        principalTable: "tali_birim",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "dof_dosya",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dosya = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Dof_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isveren_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dof_dosya", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dof_dosya_dof_Dof_Id",
                        column: x => x.Dof_Id,
                        principalTable: "dof",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dof_dosya_isveren_Isveren_Id",
                        column: x => x.Isveren_Id,
                        principalTable: "isveren",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "makine_ekipman_bakim_planlari",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Servis_Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Bakim_Tip = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Makine_Ekipman_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_makine_ekipman_bakim_planlari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_makine_ekipman_bakim_planlari_makine_ekipman_Makine_Ekipman_Id",
                        column: x => x.Makine_Ekipman_Id,
                        principalTable: "makine_ekipman",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "acil_durum_ekip_personel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ekip_Lideri = table.Column<bool>(type: "bit", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Birim_Id = table.Column<long>(type: "bigint", nullable: false),
                    Personel_Id = table.Column<long>(type: "bigint", nullable: false),
                    Ekip_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_acil_durum_ekip_personel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_acil_durum_ekip_personel_acil_durum_ekipleri_Ekip_Id",
                        column: x => x.Ekip_Id,
                        principalTable: "acil_durum_ekipleri",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_acil_durum_ekip_personel_birim_Birim_Id",
                        column: x => x.Birim_Id,
                        principalTable: "birim",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_acil_durum_ekip_personel_personel_bilgi_Personel_Id",
                        column: x => x.Personel_Id,
                        principalTable: "personel_bilgi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "asi_personel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Islem_Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Uygulayan_Ad = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Asi_Doz = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Uygulama_Yer = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Uygulama_Sekil = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Uygulandi = table.Column<bool>(type: "bit", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Asi_Tur_Id = table.Column<long>(type: "bigint", nullable: false),
                    Personel_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asi_personel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_asi_personel_asi_tur_Asi_Tur_Id",
                        column: x => x.Asi_Tur_Id,
                        principalTable: "asi_tur",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_asi_personel_personel_bilgi_Personel_Id",
                        column: x => x.Personel_Id,
                        principalTable: "personel_bilgi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "egitim_personel_atama",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Egitime_Katilim = table.Column<int>(type: "int", nullable: false),
                    Sertifika_Basildi = table.Column<bool>(type: "bit", nullable: false),
                    Egitim_Tanimla_Id = table.Column<long>(type: "bigint", nullable: false),
                    Personel_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isveren_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_egitim_personel_atama", x => x.Id);
                    table.ForeignKey(
                        name: "FK_egitim_personel_atama_egitim_tanimla_Egitim_Tanimla_Id",
                        column: x => x.Egitim_Tanimla_Id,
                        principalTable: "egitim_tanimla",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_egitim_personel_atama_isveren_Isveren_Id",
                        column: x => x.Isveren_Id,
                        principalTable: "isveren",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_egitim_personel_atama_personel_bilgi_Personel_Id",
                        column: x => x.Personel_Id,
                        principalTable: "personel_bilgi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "egitim_sinav_not",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sinav_Not = table.Column<int>(type: "int", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Egitim_Tanimla_Id = table.Column<long>(type: "bigint", nullable: false),
                    Egitim_Sinav_Id = table.Column<long>(type: "bigint", nullable: false),
                    Personel_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isg_Kurul_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isveren_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_egitim_sinav_not", x => x.Id);
                    table.ForeignKey(
                        name: "FK_egitim_sinav_not_egitim_sinav_Egitim_Sinav_Id",
                        column: x => x.Egitim_Sinav_Id,
                        principalTable: "egitim_sinav",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_egitim_sinav_not_egitim_tanimla_Egitim_Tanimla_Id",
                        column: x => x.Egitim_Tanimla_Id,
                        principalTable: "egitim_tanimla",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_egitim_sinav_not_isg_kurul_Isg_Kurul_Id",
                        column: x => x.Isg_Kurul_Id,
                        principalTable: "isg_kurul",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_egitim_sinav_not_isveren_Isveren_Id",
                        column: x => x.Isveren_Id,
                        principalTable: "isveren",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_egitim_sinav_not_personel_bilgi_Personel_Id",
                        column: x => x.Personel_Id,
                        principalTable: "personel_bilgi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "kaza",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kaza_No = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Kaza_Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kaza_Saat = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Bildirim_Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ise_Baslama_Saat = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Kaza_Hasar_Tipi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Personel_Disi_Tc_No = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Personel_Disi_Ad_Soyad = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Kaza_Oldugu_Birim = table.Column<long>(type: "bigint", nullable: false),
                    Kaza_Anindaki_Faaliyet = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Kaza_Yer = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Yaralanma_Sekli = table.Column<long>(type: "bigint", nullable: false),
                    Vucut_Kisimlari = table.Column<long>(type: "bigint", nullable: false),
                    Yaralanmaya_Neden_Olan_Olay = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Yaralanmaya_Neden_Olan_Arac = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Tibbi_Mudahele = table.Column<bool>(type: "bit", nullable: false),
                    Tibbi_Mudahele_Aciklama = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Is_Gorememezlik = table.Column<bool>(type: "bit", nullable: false),
                    Is_Gorememezlik_Gun_Sayi = table.Column<int>(type: "int", nullable: false),
                    Kaza_Sonrasi_Calisan_Ne_Yapti = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Mesleki_Egitim = table.Column<bool>(type: "bit", nullable: false),
                    Isg_Egitim = table.Column<bool>(type: "bit", nullable: false),
                    Hasar_Buyuklugu = table.Column<int>(type: "int", nullable: false),
                    Tekrarlanma_Olasiligi = table.Column<int>(type: "int", nullable: false),
                    Gerceklesme_Frekansi = table.Column<int>(type: "int", nullable: false),
                    Maruz_Kalan_Calisanin_Ifadesi = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Gorgu_Ifadesi = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Kaza_Yol_Acan_Sebepler = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Varolmasinda_Temel_Nedenler = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Birim_Sorumlu_Gorus_Oneri = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Isg_Uzmani_Degerlendirme = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Tanik_Tcno1 = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Tanik_Ad_Soyad1 = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Tanik_Eposta1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tanik_Telefon1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Tanik_Adres1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Tanik_Tcno2 = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Tanik_Ad_Soyad2 = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Tanik_Eposta2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tanik_Telefon2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Tanik_Adres2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Dof1 = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    Sorumlu1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Acilis_Tarih1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kapanis_Tarih1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dof2 = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    Sorumlu2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Acilis_Tarih2 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kapanis_Tarih2 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dof3 = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    Sorumlu3 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Acilis_Tarih3 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kapanis_Tarih3 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Personel_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isg_Kurul_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isveren_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kaza", x => x.Id);
                    table.ForeignKey(
                        name: "FK_kaza_isg_kurul_Isg_Kurul_Id",
                        column: x => x.Isg_Kurul_Id,
                        principalTable: "isg_kurul",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_kaza_isveren_Isveren_Id",
                        column: x => x.Isveren_Id,
                        principalTable: "isveren",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_kaza_personel_bilgi_Personel_Id",
                        column: x => x.Personel_Id,
                        principalTable: "personel_bilgi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "kkd_personel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kkd_Atama_Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kkd_Id = table.Column<long>(type: "bigint", nullable: false),
                    Personel_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isg_KurulId = table.Column<long>(type: "bigint", nullable: true),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kkd_personel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_kkd_personel_isg_kurul_Isg_KurulId",
                        column: x => x.Isg_KurulId,
                        principalTable: "isg_kurul",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_kkd_personel_kkd_Personel_Id",
                        column: x => x.Personel_Id,
                        principalTable: "kkd",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_kkd_personel_personel_bilgi_Personel_Id",
                        column: x => x.Personel_Id,
                        principalTable: "personel_bilgi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "muayene",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balcali_No = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Muayene_Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Muayene_Tur = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kan_Grup = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    El_Kullanim = table.Column<int>(type: "int", nullable: false),
                    Kilo = table.Column<int>(type: "int", nullable: false),
                    Boy = table.Column<int>(type: "int", nullable: false),
                    Kitle_Endeks = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Kronik_Hastalik = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Is_Kolu1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Yaptigi_Is1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Giris_Cikis1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Is_Kolu2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Yaptigi_Is2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Giris_Cikis2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Is_Kolu3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Yaptigi_Is3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Giris_Cikis3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Bagisiklik_Tetanoz = table.Column<bool>(type: "bit", nullable: false),
                    Bagisiklik_Hepatit = table.Column<bool>(type: "bit", nullable: false),
                    Bagisiklik_Diger = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Soygecmis_Anne = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Soygecmis_Baba = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Kardes = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cocuk = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nefes_Darligi = table.Column<bool>(type: "bit", nullable: false),
                    Balgamli_Oksuruk = table.Column<bool>(type: "bit", nullable: false),
                    Gogus_Agrisi = table.Column<bool>(type: "bit", nullable: false),
                    Carpinti = table.Column<bool>(type: "bit", nullable: false),
                    Sirt_Agrisi = table.Column<bool>(type: "bit", nullable: false),
                    Ishal_Kabizlik = table.Column<bool>(type: "bit", nullable: false),
                    Eklem_Agri = table.Column<bool>(type: "bit", nullable: false),
                    Kalp_Hastalik = table.Column<bool>(type: "bit", nullable: false),
                    Seker_Hastalik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bobrek_Rahatsizlik = table.Column<bool>(type: "bit", nullable: false),
                    Sarilik = table.Column<bool>(type: "bit", nullable: false),
                    Mide_Ulser = table.Column<bool>(type: "bit", nullable: false),
                    Isitme_Kayip = table.Column<bool>(type: "bit", nullable: false),
                    Gorme_Bozukluk = table.Column<bool>(type: "bit", nullable: false),
                    Sinir_Sistemi = table.Column<bool>(type: "bit", nullable: false),
                    Deri_Hastalik = table.Column<bool>(type: "bit", nullable: false),
                    Besin_Zehirlenme = table.Column<bool>(type: "bit", nullable: false),
                    Kanser = table.Column<bool>(type: "bit", nullable: false),
                    Kas_Iskelet = table.Column<bool>(type: "bit", nullable: false),
                    Akciger_Solunum = table.Column<bool>(type: "bit", nullable: false),
                    Hastane_Yatis = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Ameliyat = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Is_Kazasi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Meslek_Hastalik = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Maluliyet = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Guncel_Tedavi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Aliskanlik_Sigara = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Aliskanlik_Alkol = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Aliskanlik_Uyusturucu = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Fizik_Goz = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fizik_Kbb = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fizik_Deri = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fizik_Kardiyovaskuler = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fizik_Solunum_Sistemi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fizik_Sindirim_Sistemi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fizik_Urogenital = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fizik_Kas_Iskelet = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fizik_Norolojik = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fizik_Psikiyatri = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tansiyon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nabiz = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lab_Biyolojik_Kan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Lab_Biyolojik_Idrar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Lab_Radyolojik = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Lab_Fizyolojik_Odyometre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Lab_Fizyolojik_Sft = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Lab_Psikolojik = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Kanaat1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Kanaat2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Yuksekte_Calisma = table.Column<bool>(type: "bit", nullable: false),
                    Vardiyali_Calisma = table.Column<bool>(type: "bit", nullable: false),
                    Konsultasyon = table.Column<bool>(type: "bit", maxLength: 300, nullable: false),
                    Personel_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isveren_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_muayene", x => x.Id);
                    table.ForeignKey(
                        name: "FK_muayene_isveren_Isveren_Id",
                        column: x => x.Isveren_Id,
                        principalTable: "isveren",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_muayene_personel_bilgi_Personel_Id",
                        column: x => x.Personel_Id,
                        principalTable: "personel_bilgi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "personel_ayrinti",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cocuk = table.Column<int>(type: "int", nullable: false),
                    Kardes = table.Column<int>(type: "int", nullable: false),
                    El_Kullanim = table.Column<int>(type: "int", nullable: false),
                    Kilo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Boy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Kitle_Endeks = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Acil_Durum = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Kan_Grup = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Bagisiklik_Tetanoz = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Bagisiklik_Hepatit = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Bagisiklik_Diger = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Soy_Kalp = table.Column<int>(type: "int", nullable: false),
                    Soy_Hipertansiyon = table.Column<int>(type: "int", nullable: false),
                    Soy_Seker = table.Column<int>(type: "int", nullable: false),
                    Nefes_Darligi = table.Column<bool>(type: "bit", nullable: false),
                    Carpinti = table.Column<bool>(type: "bit", nullable: false),
                    Sirt_Agrisi = table.Column<bool>(type: "bit", nullable: false),
                    Ishal_Kabizlik = table.Column<bool>(type: "bit", nullable: false),
                    Eklem_Agri = table.Column<bool>(type: "bit", nullable: false),
                    Kalp_Hastalik = table.Column<bool>(type: "bit", nullable: false),
                    Seker_Hastalik = table.Column<bool>(type: "bit", nullable: false),
                    Bobrek_Rahatsizlik = table.Column<bool>(type: "bit", nullable: false),
                    Sarilik = table.Column<bool>(type: "bit", nullable: false),
                    Ulser = table.Column<bool>(type: "bit", nullable: false),
                    Isitme_Kayip = table.Column<bool>(type: "bit", nullable: false),
                    Gorme_Bozukluk = table.Column<bool>(type: "bit", nullable: false),
                    Sinir_Sistemi = table.Column<bool>(type: "bit", nullable: false),
                    Deri_Hastalik = table.Column<bool>(type: "bit", nullable: false),
                    Besin_Zehirlenme = table.Column<bool>(type: "bit", nullable: false),
                    Hastane_Yatis = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Ameliyat = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Is_Kazasi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Meslek_Hastalik = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Maluliyet = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Guncel_Tedavi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Aliskanlik_Sigara = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Aliskanlik_Alkol = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Aliskanlik_Uyusturucu = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Aliskanlik_Diger = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Personel_Not = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Engelli = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Eski_Hukumlu = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Agir_Tehlikeli = table.Column<bool>(type: "bit", nullable: false),
                    Yuksekte_Calisma = table.Column<bool>(type: "bit", nullable: false),
                    Gece_Vardiya = table.Column<bool>(type: "bit", nullable: false),
                    Uygunluk_Durumu = table.Column<bool>(type: "bit", nullable: false),
                    Personel_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personel_ayrinti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_personel_ayrinti_personel_bilgi_Personel_Id",
                        column: x => x.Personel_Id,
                        principalTable: "personel_bilgi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "radyasyon",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Radyasyon_Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Temas_Sekli1 = table.Column<bool>(type: "bit", nullable: false),
                    Temas_Sekli2 = table.Column<bool>(type: "bit", nullable: false),
                    Temas_Sekli_Diger = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Limit_Asim = table.Column<bool>(type: "bit", nullable: false),
                    Limit_Asim_Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Radyasyon_Kaza = table.Column<bool>(type: "bit", nullable: false),
                    Radyasyon_Kaza_Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Radyasyon_Maruz = table.Column<bool>(type: "bit", nullable: false),
                    Radyasyon_Maruz_Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Ciltte_Solukluk = table.Column<bool>(type: "bit", nullable: false),
                    Ciltte_Solukluk_Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Genel_Yorgunluk = table.Column<bool>(type: "bit", nullable: false),
                    Genel_Yorgunluk_Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Bas_Donmesi = table.Column<bool>(type: "bit", nullable: false),
                    Bas_Donmesi_Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Atesli_Hastalik = table.Column<bool>(type: "bit", nullable: false),
                    Atesli_Hastalik_Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Uzun_Sure_Enfeksiyon = table.Column<bool>(type: "bit", nullable: false),
                    Uzun_Sure_Enfeksiyon_Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Uzun_Suren_Kanama = table.Column<bool>(type: "bit", nullable: false),
                    Uzun_Suren_Kanama_Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Dis_Eti_Kanama = table.Column<bool>(type: "bit", nullable: false),
                    Dis_Eti_Kanama_Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Ciltte_Morluklar = table.Column<bool>(type: "bit", nullable: false),
                    Ciltte_Morluklar_Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Kil_Donmesi = table.Column<bool>(type: "bit", nullable: false),
                    Kil_Donmesi_Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Ciltte_Bozukluk = table.Column<bool>(type: "bit", nullable: false),
                    Ciltte_Bozukluk_Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Gorme_Bulaniklik = table.Column<bool>(type: "bit", nullable: false),
                    Gorme_Bulaniklik_Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Lenf_Buyume = table.Column<bool>(type: "bit", nullable: false),
                    Lenf_Buyume_Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Telenjiektazi = table.Column<bool>(type: "bit", nullable: false),
                    Telenjiektazi_Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Hiperkeratoz = table.Column<bool>(type: "bit", nullable: false),
                    Hiperkeratoz_Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Atrofi = table.Column<bool>(type: "bit", nullable: false),
                    Atrofi_Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Kil_Dokulmesi2 = table.Column<bool>(type: "bit", nullable: false),
                    Kil_Dokulmesi2_Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Tirnak_Bozukluk = table.Column<bool>(type: "bit", nullable: false),
                    Tirnak_Bozukluk_Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Periferik_Lenfadenopatİ = table.Column<bool>(type: "bit", nullable: false),
                    Periferik_Lenfadenopati_Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Hepatosplenomegali = table.Column<bool>(type: "bit", nullable: false),
                    Hepatosplenomegali_Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Beyaz_Kure = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Trombosit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Hemoglobin = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Kirmizi_Kure = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Lenfosit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Notrofil = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Monosit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Eozinofil = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Bazofil = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Normal_Disi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Katarakt = table.Column<bool>(type: "bit", nullable: false),
                    Goz_Uzman_Degerlendirme = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Diger_Husus = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Ac_Grafisi = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Periferik_Yayma = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Hastalik_Oykusu = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Ek_Biyokimya = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Kullandigi_Ilaclar = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Personel_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isveren_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_radyasyon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_radyasyon_isveren_Isveren_Id",
                        column: x => x.Isveren_Id,
                        principalTable: "isveren",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_radyasyon_personel_bilgi_Personel_Id",
                        column: x => x.Personel_Id,
                        principalTable: "personel_bilgi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "kaza_personel_disi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kaza_No = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Kaza_Kategori = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Kaza_Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kaza_Saat = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Personel_Disi_Tc_No = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Personel_Disi_Ad_Soyad = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Kaza_Yer = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Kaza_Olus_Sekil = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Kaza_Faktor = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Sonuc = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Kok_Neden = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Yapilan_Islem = table.Column<int>(type: "int", nullable: false),
                    Dof1 = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    Sorumlu1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Acilis_Tarih1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dof2 = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    Sorumlu2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Acilis_Tarih2 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dof3 = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    Sorumlu3 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Acilis_Tarih3 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Personel_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaralanma_Sekli_Id = table.Column<long>(type: "bigint", nullable: false),
                    Risk_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isg_Kurul_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isveren_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kaza_personel_disi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_kaza_personel_disi_isg_kurul_Isg_Kurul_Id",
                        column: x => x.Isg_Kurul_Id,
                        principalTable: "isg_kurul",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_kaza_personel_disi_isveren_Isveren_Id",
                        column: x => x.Isveren_Id,
                        principalTable: "isveren",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_kaza_personel_disi_personel_bilgi_Personel_Id",
                        column: x => x.Personel_Id,
                        principalTable: "personel_bilgi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_kaza_personel_disi_risk_analiz_Risk_Id",
                        column: x => x.Risk_Id,
                        principalTable: "risk_analiz",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_kaza_personel_disi_yaralanma_sekli_Yaralanma_Sekli_Id",
                        column: x => x.Yaralanma_Sekli_Id,
                        principalTable: "yaralanma_sekli",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "risk_analiz_tablo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tehlike_Kaynagi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Olasilik1 = table.Column<float>(type: "real", nullable: false),
                    Frekans1 = table.Column<float>(type: "real", nullable: false),
                    Siddet1 = table.Column<float>(type: "real", nullable: false),
                    Risk_Puan1 = table.Column<float>(type: "real", nullable: false),
                    Risk_Seviye1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Duzeltici_Faaliyet = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Etkilenenler = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Olasilik2 = table.Column<float>(type: "real", nullable: false),
                    Frekans2 = table.Column<float>(type: "real", nullable: false),
                    Siddet2 = table.Column<float>(type: "real", nullable: false),
                    Risk_Puan2 = table.Column<float>(type: "real", nullable: false),
                    Risk_Seviye2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Resim = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Risk_Id = table.Column<long>(type: "bigint", nullable: false),
                    Risk_Analiz_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_risk_analiz_tablo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_risk_analiz_tablo_risk_analiz_Risk_Id",
                        column: x => x.Risk_Id,
                        principalTable: "risk_analiz",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_risk_analiz_tablo_risk_analiz_risk_Risk_Analiz_Id",
                        column: x => x.Risk_Analiz_Id,
                        principalTable: "risk_analiz_risk",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "makine_ekipman_yapilan_islem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Yapilan_Islem = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Makine_Ekipman_Bakim_Planlari_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_makine_ekipman_yapilan_islem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_makine_ekipman_yapilan_islem_makine_ekipman_bakim_planlari_Makine_Ekipman_Bakim_Planlari_Id",
                        column: x => x.Makine_Ekipman_Bakim_Planlari_Id,
                        principalTable: "makine_ekipman_bakim_planlari",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "kaza_ayrinti",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hareketler1 = table.Column<bool>(type: "bit", nullable: false),
                    Hareketler2 = table.Column<bool>(type: "bit", nullable: false),
                    Hareketler3 = table.Column<bool>(type: "bit", nullable: false),
                    Hareketler4 = table.Column<bool>(type: "bit", nullable: false),
                    Hareketler5 = table.Column<bool>(type: "bit", nullable: false),
                    Hareketler6 = table.Column<bool>(type: "bit", nullable: false),
                    Hareketler7 = table.Column<bool>(type: "bit", nullable: false),
                    Hareketler8 = table.Column<bool>(type: "bit", nullable: false),
                    Hareketler9 = table.Column<bool>(type: "bit", nullable: false),
                    Hareketler10 = table.Column<bool>(type: "bit", nullable: false),
                    Hareketler11 = table.Column<bool>(type: "bit", nullable: false),
                    Hareketler12 = table.Column<bool>(type: "bit", nullable: false),
                    Hareketler13 = table.Column<bool>(type: "bit", nullable: false),
                    Hareketler14 = table.Column<bool>(type: "bit", nullable: false),
                    Hareketler15 = table.Column<bool>(type: "bit", nullable: false),
                    Hareketler16 = table.Column<bool>(type: "bit", nullable: false),
                    Hareketler17 = table.Column<bool>(type: "bit", nullable: false),
                    Hareketler18 = table.Column<bool>(type: "bit", nullable: false),
                    Kisisel_Faktorler1 = table.Column<bool>(type: "bit", nullable: false),
                    Kisisel_Faktorler2 = table.Column<bool>(type: "bit", nullable: false),
                    Kisisel_Faktorler3 = table.Column<bool>(type: "bit", nullable: false),
                    Kisisel_Faktorler4 = table.Column<bool>(type: "bit", nullable: false),
                    Kisisel_Faktorler5 = table.Column<bool>(type: "bit", nullable: false),
                    Kisisel_Faktorler6 = table.Column<bool>(type: "bit", nullable: false),
                    Kisisel_Faktorler7 = table.Column<bool>(type: "bit", nullable: false),
                    Kisisel_Faktorler8 = table.Column<bool>(type: "bit", nullable: false),
                    Kisisel_Faktorler9 = table.Column<bool>(type: "bit", nullable: false),
                    Kisisel_Faktorler10 = table.Column<bool>(type: "bit", nullable: false),
                    Kisisel_Faktorler11 = table.Column<bool>(type: "bit", nullable: false),
                    Kisisel_Faktorler12 = table.Column<bool>(type: "bit", nullable: false),
                    Kisisel_Faktorler13 = table.Column<bool>(type: "bit", nullable: false),
                    Kisisel_Faktorler14 = table.Column<bool>(type: "bit", nullable: false),
                    Kisisel_Faktorler15 = table.Column<bool>(type: "bit", nullable: false),
                    Kisisel_Faktorler16 = table.Column<bool>(type: "bit", nullable: false),
                    Kisisel_Faktorler17 = table.Column<bool>(type: "bit", nullable: false),
                    Kisisel_Faktorler18 = table.Column<bool>(type: "bit", nullable: false),
                    Calisma_Kosullari1 = table.Column<bool>(type: "bit", nullable: false),
                    Calisma_Kosullari2 = table.Column<bool>(type: "bit", nullable: false),
                    Calisma_Kosullari3 = table.Column<bool>(type: "bit", nullable: false),
                    Calisma_Kosullari4 = table.Column<bool>(type: "bit", nullable: false),
                    Calisma_Kosullari5 = table.Column<bool>(type: "bit", nullable: false),
                    Calisma_Kosullari6 = table.Column<bool>(type: "bit", nullable: false),
                    Calisma_Kosullari7 = table.Column<bool>(type: "bit", nullable: false),
                    Calisma_Kosullari8 = table.Column<bool>(type: "bit", nullable: false),
                    Calisma_Kosullari9 = table.Column<bool>(type: "bit", nullable: false),
                    Calisma_Kosullari10 = table.Column<bool>(type: "bit", nullable: false),
                    Calisma_Kosullari11 = table.Column<bool>(type: "bit", nullable: false),
                    Calisma_Kosullari12 = table.Column<bool>(type: "bit", nullable: false),
                    Calisma_Kosullari13 = table.Column<bool>(type: "bit", nullable: false),
                    Calisma_Kosullari14 = table.Column<bool>(type: "bit", nullable: false),
                    Calisma_Kosullari15 = table.Column<bool>(type: "bit", nullable: false),
                    Calisma_Kosullari16 = table.Column<bool>(type: "bit", nullable: false),
                    Calisma_Kosullari17 = table.Column<bool>(type: "bit", nullable: false),
                    Calisma_Kosullari18 = table.Column<bool>(type: "bit", nullable: false),
                    Calisma_Kosullari19 = table.Column<bool>(type: "bit", nullable: false),
                    Is_Faktorleri1 = table.Column<bool>(type: "bit", nullable: false),
                    Is_Faktorleri2 = table.Column<bool>(type: "bit", nullable: false),
                    Is_Faktorleri3 = table.Column<bool>(type: "bit", nullable: false),
                    Is_Faktorleri4 = table.Column<bool>(type: "bit", nullable: false),
                    Is_Faktorleri5 = table.Column<bool>(type: "bit", nullable: false),
                    Is_Faktorleri6 = table.Column<bool>(type: "bit", nullable: false),
                    Is_Faktorleri7 = table.Column<bool>(type: "bit", nullable: false),
                    Is_Faktorleri8 = table.Column<bool>(type: "bit", nullable: false),
                    Is_Faktorleri9 = table.Column<bool>(type: "bit", nullable: false),
                    Is_Faktorleri10 = table.Column<bool>(type: "bit", nullable: false),
                    Is_Faktorleri11 = table.Column<bool>(type: "bit", nullable: false),
                    Is_Faktorleri12 = table.Column<bool>(type: "bit", nullable: false),
                    Is_Faktorleri13 = table.Column<bool>(type: "bit", nullable: false),
                    Is_Faktorleri14 = table.Column<bool>(type: "bit", nullable: false),
                    Is_Faktorleri15 = table.Column<bool>(type: "bit", nullable: false),
                    Is_Faktorleri16 = table.Column<bool>(type: "bit", nullable: false),
                    Is_Faktorleri17 = table.Column<bool>(type: "bit", nullable: false),
                    Is_Faktorleri18 = table.Column<bool>(type: "bit", nullable: false),
                    Is_Faktorleri19 = table.Column<bool>(type: "bit", nullable: false),
                    Kaza_Turu1 = table.Column<bool>(type: "bit", nullable: false),
                    Kaza_Turu2 = table.Column<bool>(type: "bit", nullable: false),
                    Kaza_Turu3 = table.Column<bool>(type: "bit", nullable: false),
                    Kaza_Turu4 = table.Column<bool>(type: "bit", nullable: false),
                    Kaza_Turu5 = table.Column<bool>(type: "bit", nullable: false),
                    Kaza_Turu6 = table.Column<bool>(type: "bit", nullable: false),
                    Kaza_Turu7 = table.Column<bool>(type: "bit", nullable: false),
                    Kaza_Turu8 = table.Column<bool>(type: "bit", nullable: false),
                    Kaza_Turu9 = table.Column<bool>(type: "bit", nullable: false),
                    Kaza_Turu10 = table.Column<bool>(type: "bit", nullable: false),
                    Kaza_Turu11 = table.Column<bool>(type: "bit", nullable: false),
                    Kaza_Turu12 = table.Column<bool>(type: "bit", nullable: false),
                    Yaralanan_Uzuvlar1 = table.Column<bool>(type: "bit", nullable: false),
                    Yaralanan_Uzuvlar2 = table.Column<bool>(type: "bit", nullable: false),
                    Yaralanan_Uzuvlar3 = table.Column<bool>(type: "bit", nullable: false),
                    Yaralanan_Uzuvlar4 = table.Column<bool>(type: "bit", nullable: false),
                    Yaralanan_Uzuvlar5 = table.Column<bool>(type: "bit", nullable: false),
                    Yaralanan_Uzuvlar6 = table.Column<bool>(type: "bit", nullable: false),
                    Yaralanan_Uzuvlar7 = table.Column<bool>(type: "bit", nullable: false),
                    Yaralanan_Uzuvlar8 = table.Column<bool>(type: "bit", nullable: false),
                    Yaralanan_Uzuvlar9 = table.Column<bool>(type: "bit", nullable: false),
                    Yaralanan_Uzuvlar10 = table.Column<bool>(type: "bit", nullable: false),
                    Yaralanan_Uzuvlar11 = table.Column<bool>(type: "bit", nullable: false),
                    Yaralanan_Uzuvlar12 = table.Column<bool>(type: "bit", nullable: false),
                    Kaza_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kaza_ayrinti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_kaza_ayrinti_kaza_Kaza_Id",
                        column: x => x.Kaza_Id,
                        principalTable: "kaza",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "kaza_dosya",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dosya = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Kaza_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isveren_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kaza_dosya", x => x.Id);
                    table.ForeignKey(
                        name: "FK_kaza_dosya_isveren_Isveren_Id",
                        column: x => x.Isveren_Id,
                        principalTable: "isveren",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_kaza_dosya_kaza_Kaza_Id",
                        column: x => x.Kaza_Id,
                        principalTable: "kaza",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "kaza_personel_disi_dosya",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dosya = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Kaza_Personel_Disi_Id = table.Column<long>(type: "bigint", nullable: false),
                    Isveren_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kaza_personel_disi_dosya", x => x.Id);
                    table.ForeignKey(
                        name: "FK_kaza_personel_disi_dosya_isveren_Isveren_Id",
                        column: x => x.Isveren_Id,
                        principalTable: "isveren",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_kaza_personel_disi_dosya_kaza_personel_disi_Kaza_Personel_Disi_Id",
                        column: x => x.Kaza_Personel_Disi_Id,
                        principalTable: "kaza_personel_disi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "yetkili_gormedi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tablo_Adi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Tablo_Id = table.Column<long>(type: "bigint", nullable: false),
                    Yaratilma_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistirilme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Kullanici_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_yetkili_gormedi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_yetkili_gormedi_risk_analiz_tablo_Tablo_Id",
                        column: x => x.Tablo_Id,
                        principalTable: "risk_analiz_tablo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_acil_durum_ekip_personel_Birim_Id",
                table: "acil_durum_ekip_personel",
                column: "Birim_Id");

            migrationBuilder.CreateIndex(
                name: "IX_acil_durum_ekip_personel_Ekip_Id",
                table: "acil_durum_ekip_personel",
                column: "Ekip_Id");

            migrationBuilder.CreateIndex(
                name: "IX_acil_durum_ekip_personel_Personel_Id",
                table: "acil_durum_ekip_personel",
                column: "Personel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_acil_eylem_plani_Birim_Id",
                table: "acil_eylem_plani",
                column: "Birim_Id");

            migrationBuilder.CreateIndex(
                name: "IX_acil_eylem_plani_Isveren_Id",
                table: "acil_eylem_plani",
                column: "Isveren_Id");

            migrationBuilder.CreateIndex(
                name: "IX_alt_isveren_Isg_Kurul_Id",
                table: "alt_isveren",
                column: "Isg_Kurul_Id");

            migrationBuilder.CreateIndex(
                name: "IX_asi_personel_Asi_Tur_Id",
                table: "asi_personel",
                column: "Asi_Tur_Id");

            migrationBuilder.CreateIndex(
                name: "IX_asi_personel_Personel_Id",
                table: "asi_personel",
                column: "Personel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_asi_sureleri_Asi_Tur_Id",
                table: "asi_sureleri",
                column: "Asi_Tur_Id");

            migrationBuilder.CreateIndex(
                name: "IX_birim_Alt_IsverenId",
                table: "birim",
                column: "Alt_IsverenId");

            migrationBuilder.CreateIndex(
                name: "IX_birim_Isg_Kurul_Id",
                table: "birim",
                column: "Isg_Kurul_Id");

            migrationBuilder.CreateIndex(
                name: "IX_birim_Isveren_Id",
                table: "birim",
                column: "Isveren_Id");

            migrationBuilder.CreateIndex(
                name: "IX_dof_Birim_Id",
                table: "dof",
                column: "Birim_Id");

            migrationBuilder.CreateIndex(
                name: "IX_dof_Isg_Kurul_Id",
                table: "dof",
                column: "Isg_Kurul_Id");

            migrationBuilder.CreateIndex(
                name: "IX_dof_Isveren_Id",
                table: "dof",
                column: "Isveren_Id");

            migrationBuilder.CreateIndex(
                name: "IX_dof_Tali_Birim_Id",
                table: "dof",
                column: "Tali_Birim_Id");

            migrationBuilder.CreateIndex(
                name: "IX_dof_dosya_Dof_Id",
                table: "dof_dosya",
                column: "Dof_Id");

            migrationBuilder.CreateIndex(
                name: "IX_dof_dosya_Isveren_Id",
                table: "dof_dosya",
                column: "Isveren_Id");

            migrationBuilder.CreateIndex(
                name: "IX_egitim_konu_alt_baslik_Egitim_Konu_Id",
                table: "egitim_konu_alt_baslik",
                column: "Egitim_Konu_Id");

            migrationBuilder.CreateIndex(
                name: "IX_egitim_personel_atama_Egitim_Tanimla_Id",
                table: "egitim_personel_atama",
                column: "Egitim_Tanimla_Id");

            migrationBuilder.CreateIndex(
                name: "IX_egitim_personel_atama_Isveren_Id",
                table: "egitim_personel_atama",
                column: "Isveren_Id");

            migrationBuilder.CreateIndex(
                name: "IX_egitim_personel_atama_Personel_Id",
                table: "egitim_personel_atama",
                column: "Personel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_egitim_sinav_Egitim_TanimlaId",
                table: "egitim_sinav",
                column: "Egitim_TanimlaId");

            migrationBuilder.CreateIndex(
                name: "IX_egitim_sinav_Isg_Kurul_Id",
                table: "egitim_sinav",
                column: "Isg_Kurul_Id");

            migrationBuilder.CreateIndex(
                name: "IX_egitim_sinav_Isveren_Id",
                table: "egitim_sinav",
                column: "Isveren_Id");

            migrationBuilder.CreateIndex(
                name: "IX_egitim_sinav_not_Egitim_Sinav_Id",
                table: "egitim_sinav_not",
                column: "Egitim_Sinav_Id");

            migrationBuilder.CreateIndex(
                name: "IX_egitim_sinav_not_Egitim_Tanimla_Id",
                table: "egitim_sinav_not",
                column: "Egitim_Tanimla_Id");

            migrationBuilder.CreateIndex(
                name: "IX_egitim_sinav_not_Isg_Kurul_Id",
                table: "egitim_sinav_not",
                column: "Isg_Kurul_Id");

            migrationBuilder.CreateIndex(
                name: "IX_egitim_sinav_not_Isveren_Id",
                table: "egitim_sinav_not",
                column: "Isveren_Id");

            migrationBuilder.CreateIndex(
                name: "IX_egitim_sinav_not_Personel_Id",
                table: "egitim_sinav_not",
                column: "Personel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_egitim_tanimla_Egitim_Konu_Alt_Baslik_Id",
                table: "egitim_tanimla",
                column: "Egitim_Konu_Alt_Baslik_Id");

            migrationBuilder.CreateIndex(
                name: "IX_egitim_tanimla_Isg_Kurul_Id",
                table: "egitim_tanimla",
                column: "Isg_Kurul_Id");

            migrationBuilder.CreateIndex(
                name: "IX_egitim_tanimla_Isveren_Id",
                table: "egitim_tanimla",
                column: "Isveren_Id");

            migrationBuilder.CreateIndex(
                name: "IX_isg_kurul_eleman_Isg_Kurul_Id",
                table: "isg_kurul_eleman",
                column: "Isg_Kurul_Id");

            migrationBuilder.CreateIndex(
                name: "IX_isg_kurul_karar_Isg_Kurul_Id",
                table: "isg_kurul_karar",
                column: "Isg_Kurul_Id");

            migrationBuilder.CreateIndex(
                name: "IX_isg_kurul_karar_Isveren_Id",
                table: "isg_kurul_karar",
                column: "Isveren_Id");

            migrationBuilder.CreateIndex(
                name: "IX_isg_kurul_karar_dosya_Isg_Kurul_Karar_Id",
                table: "isg_kurul_karar_dosya",
                column: "Isg_Kurul_Karar_Id");

            migrationBuilder.CreateIndex(
                name: "IX_isg_kurul_karar_dosya_Isveren_Id",
                table: "isg_kurul_karar_dosya",
                column: "Isveren_Id");

            migrationBuilder.CreateIndex(
                name: "IX_kaza_Isg_Kurul_Id",
                table: "kaza",
                column: "Isg_Kurul_Id");

            migrationBuilder.CreateIndex(
                name: "IX_kaza_Isveren_Id",
                table: "kaza",
                column: "Isveren_Id");

            migrationBuilder.CreateIndex(
                name: "IX_kaza_Personel_Id",
                table: "kaza",
                column: "Personel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_kaza_ayrinti_Kaza_Id",
                table: "kaza_ayrinti",
                column: "Kaza_Id");

            migrationBuilder.CreateIndex(
                name: "IX_kaza_dosya_Isveren_Id",
                table: "kaza_dosya",
                column: "Isveren_Id");

            migrationBuilder.CreateIndex(
                name: "IX_kaza_dosya_Kaza_Id",
                table: "kaza_dosya",
                column: "Kaza_Id");

            migrationBuilder.CreateIndex(
                name: "IX_kaza_personel_disi_Isg_Kurul_Id",
                table: "kaza_personel_disi",
                column: "Isg_Kurul_Id");

            migrationBuilder.CreateIndex(
                name: "IX_kaza_personel_disi_Isveren_Id",
                table: "kaza_personel_disi",
                column: "Isveren_Id");

            migrationBuilder.CreateIndex(
                name: "IX_kaza_personel_disi_Personel_Id",
                table: "kaza_personel_disi",
                column: "Personel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_kaza_personel_disi_Risk_Id",
                table: "kaza_personel_disi",
                column: "Risk_Id");

            migrationBuilder.CreateIndex(
                name: "IX_kaza_personel_disi_Yaralanma_Sekli_Id",
                table: "kaza_personel_disi",
                column: "Yaralanma_Sekli_Id");

            migrationBuilder.CreateIndex(
                name: "IX_kaza_personel_disi_dosya_Isveren_Id",
                table: "kaza_personel_disi_dosya",
                column: "Isveren_Id");

            migrationBuilder.CreateIndex(
                name: "IX_kaza_personel_disi_dosya_Kaza_Personel_Disi_Id",
                table: "kaza_personel_disi_dosya",
                column: "Kaza_Personel_Disi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_kkd_Isg_Kurul_Id",
                table: "kkd",
                column: "Isg_Kurul_Id");

            migrationBuilder.CreateIndex(
                name: "IX_kkd_Isveren_Id",
                table: "kkd",
                column: "Isveren_Id");

            migrationBuilder.CreateIndex(
                name: "IX_kkd_Kkd_Tur_Alt_Id",
                table: "kkd",
                column: "Kkd_Tur_Alt_Id");

            migrationBuilder.CreateIndex(
                name: "IX_kkd_dosya_Isveren_Id",
                table: "kkd_dosya",
                column: "Isveren_Id");

            migrationBuilder.CreateIndex(
                name: "IX_kkd_dosya_Kkd_Id",
                table: "kkd_dosya",
                column: "Kkd_Id");

            migrationBuilder.CreateIndex(
                name: "IX_kkd_personel_Isg_KurulId",
                table: "kkd_personel",
                column: "Isg_KurulId");

            migrationBuilder.CreateIndex(
                name: "IX_kkd_personel_Personel_Id",
                table: "kkd_personel",
                column: "Personel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_kkd_tur_alt_Kkd_Tur_Id",
                table: "kkd_tur_alt",
                column: "Kkd_Tur_Id");

            migrationBuilder.CreateIndex(
                name: "IX_kullanici_Isg_Kurul_Id",
                table: "kullanici",
                column: "Isg_Kurul_Id");

            migrationBuilder.CreateIndex(
                name: "IX_kullanici_Isveren_Id",
                table: "kullanici",
                column: "Isveren_Id");

            migrationBuilder.CreateIndex(
                name: "IX_makine_ekipman_Birim_Id",
                table: "makine_ekipman",
                column: "Birim_Id");

            migrationBuilder.CreateIndex(
                name: "IX_makine_ekipman_Tali_Birim_Id",
                table: "makine_ekipman",
                column: "Tali_Birim_Id");

            migrationBuilder.CreateIndex(
                name: "IX_makine_ekipman_bakim_planlari_Makine_Ekipman_Id",
                table: "makine_ekipman_bakim_planlari",
                column: "Makine_Ekipman_Id");

            migrationBuilder.CreateIndex(
                name: "IX_makine_ekipman_yapilan_islem_Makine_Ekipman_Bakim_Planlari_Id",
                table: "makine_ekipman_yapilan_islem",
                column: "Makine_Ekipman_Bakim_Planlari_Id");

            migrationBuilder.CreateIndex(
                name: "IX_mali_ihtiyac_Birim_Id",
                table: "mali_ihtiyac",
                column: "Birim_Id");

            migrationBuilder.CreateIndex(
                name: "IX_mali_ihtiyac_Isg_Kurul_Id",
                table: "mali_ihtiyac",
                column: "Isg_Kurul_Id");

            migrationBuilder.CreateIndex(
                name: "IX_mali_ihtiyac_Tali_Birim_Id",
                table: "mali_ihtiyac",
                column: "Tali_Birim_Id");

            migrationBuilder.CreateIndex(
                name: "IX_msds_Isg_Kurul_Id",
                table: "msds",
                column: "Isg_Kurul_Id");

            migrationBuilder.CreateIndex(
                name: "IX_msds_Isveren_Id",
                table: "msds",
                column: "Isveren_Id");

            migrationBuilder.CreateIndex(
                name: "IX_msds_dosya_Isveren_Id",
                table: "msds_dosya",
                column: "Isveren_Id");

            migrationBuilder.CreateIndex(
                name: "IX_msds_dosya_Msds_Id",
                table: "msds_dosya",
                column: "Msds_Id");

            migrationBuilder.CreateIndex(
                name: "IX_muayene_Isveren_Id",
                table: "muayene",
                column: "Isveren_Id");

            migrationBuilder.CreateIndex(
                name: "IX_muayene_Personel_Id",
                table: "muayene",
                column: "Personel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ortam_olcum_Isveren_Id",
                table: "ortam_olcum",
                column: "Isveren_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ortam_olcum_Tali_Birim_Id",
                table: "ortam_olcum",
                column: "Tali_Birim_Id");

            migrationBuilder.CreateIndex(
                name: "IX_personel_ayrinti_Personel_Id",
                table: "personel_ayrinti",
                column: "Personel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_personel_bilgi_Alt_IsverenId",
                table: "personel_bilgi",
                column: "Alt_IsverenId");

            migrationBuilder.CreateIndex(
                name: "IX_personel_bilgi_Birim_Id",
                table: "personel_bilgi",
                column: "Birim_Id");

            migrationBuilder.CreateIndex(
                name: "IX_personel_bilgi_Isveren_Id",
                table: "personel_bilgi",
                column: "Isveren_Id");

            migrationBuilder.CreateIndex(
                name: "IX_personel_bilgi_KullaniciId",
                table: "personel_bilgi",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_personel_bilgi_Sgk_Meslek_Id",
                table: "personel_bilgi",
                column: "Sgk_Meslek_Id");

            migrationBuilder.CreateIndex(
                name: "IX_personel_bilgi_Tali_Birim_Id",
                table: "personel_bilgi",
                column: "Tali_Birim_Id");

            migrationBuilder.CreateIndex(
                name: "IX_radyasyon_Isveren_Id",
                table: "radyasyon",
                column: "Isveren_Id");

            migrationBuilder.CreateIndex(
                name: "IX_radyasyon_Personel_Id",
                table: "radyasyon",
                column: "Personel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ramak_kala_Birim_Id",
                table: "ramak_kala",
                column: "Birim_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ramak_kala_Isg_Kurul_Id",
                table: "ramak_kala",
                column: "Isg_Kurul_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ramak_kala_Isveren_Id",
                table: "ramak_kala",
                column: "Isveren_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ramak_kala_Tali_Birim_Id",
                table: "ramak_kala",
                column: "Tali_Birim_Id");

            migrationBuilder.CreateIndex(
                name: "IX_risk_analiz_Birim_Id",
                table: "risk_analiz",
                column: "Birim_Id");

            migrationBuilder.CreateIndex(
                name: "IX_risk_analiz_Isg_Kurul_Id",
                table: "risk_analiz",
                column: "Isg_Kurul_Id");

            migrationBuilder.CreateIndex(
                name: "IX_risk_analiz_Tali_Birim_Id",
                table: "risk_analiz",
                column: "Tali_Birim_Id");

            migrationBuilder.CreateIndex(
                name: "IX_risk_analiz_tablo_Risk_Analiz_Id",
                table: "risk_analiz_tablo",
                column: "Risk_Analiz_Id");

            migrationBuilder.CreateIndex(
                name: "IX_risk_analiz_tablo_Risk_Id",
                table: "risk_analiz_tablo",
                column: "Risk_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tali_birim_Alt_IsverenId",
                table: "tali_birim",
                column: "Alt_IsverenId");

            migrationBuilder.CreateIndex(
                name: "IX_tali_birim_Birim_Id",
                table: "tali_birim",
                column: "Birim_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tali_birim_Isveren_Id",
                table: "tali_birim",
                column: "Isveren_Id");

            migrationBuilder.CreateIndex(
                name: "IX_yaralanan_vucut_bolgesi_Yaralanma_Sekli_Id",
                table: "yaralanan_vucut_bolgesi",
                column: "Yaralanma_Sekli_Id");

            migrationBuilder.CreateIndex(
                name: "IX_yetkili_gormedi_Tablo_Id",
                table: "yetkili_gormedi",
                column: "Tablo_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "acil_durum_ekip_personel");

            migrationBuilder.DropTable(
                name: "acil_eylem_plani");

            migrationBuilder.DropTable(
                name: "asi_personel");

            migrationBuilder.DropTable(
                name: "asi_sureleri");

            migrationBuilder.DropTable(
                name: "ayarlar");

            migrationBuilder.DropTable(
                name: "beden_bolge");

            migrationBuilder.DropTable(
                name: "dof_dosya");

            migrationBuilder.DropTable(
                name: "egitim_personel_atama");

            migrationBuilder.DropTable(
                name: "egitim_sinav_not");

            migrationBuilder.DropTable(
                name: "hareket");

            migrationBuilder.DropTable(
                name: "isg_kurul_eleman");

            migrationBuilder.DropTable(
                name: "isg_kurul_karar_dosya");

            migrationBuilder.DropTable(
                name: "kaza_ayrinti");

            migrationBuilder.DropTable(
                name: "kaza_dosya");

            migrationBuilder.DropTable(
                name: "kaza_personel_disi_dosya");

            migrationBuilder.DropTable(
                name: "kkd_dosya");

            migrationBuilder.DropTable(
                name: "kkd_personel");

            migrationBuilder.DropTable(
                name: "makine_ekipman_yapilan_islem");

            migrationBuilder.DropTable(
                name: "mali_ihtiyac");

            migrationBuilder.DropTable(
                name: "msds_dosya");

            migrationBuilder.DropTable(
                name: "muayene");

            migrationBuilder.DropTable(
                name: "ortam_olcum");

            migrationBuilder.DropTable(
                name: "personel_ayrinti");

            migrationBuilder.DropTable(
                name: "radyasyon");

            migrationBuilder.DropTable(
                name: "ramak_kala");

            migrationBuilder.DropTable(
                name: "risk_analiz_tehlike");

            migrationBuilder.DropTable(
                name: "risk_gerceklesen");

            migrationBuilder.DropTable(
                name: "tehlike_tanim");

            migrationBuilder.DropTable(
                name: "yaralanan_vucut_bolgesi");

            migrationBuilder.DropTable(
                name: "yetkili_gormedi");

            migrationBuilder.DropTable(
                name: "acil_durum_ekipleri");

            migrationBuilder.DropTable(
                name: "asi_tur");

            migrationBuilder.DropTable(
                name: "dof");

            migrationBuilder.DropTable(
                name: "egitim_sinav");

            migrationBuilder.DropTable(
                name: "isg_kurul_karar");

            migrationBuilder.DropTable(
                name: "kaza");

            migrationBuilder.DropTable(
                name: "kaza_personel_disi");

            migrationBuilder.DropTable(
                name: "kkd");

            migrationBuilder.DropTable(
                name: "makine_ekipman_bakim_planlari");

            migrationBuilder.DropTable(
                name: "msds");

            migrationBuilder.DropTable(
                name: "risk_analiz_tablo");

            migrationBuilder.DropTable(
                name: "egitim_tanimla");

            migrationBuilder.DropTable(
                name: "personel_bilgi");

            migrationBuilder.DropTable(
                name: "yaralanma_sekli");

            migrationBuilder.DropTable(
                name: "kkd_tur_alt");

            migrationBuilder.DropTable(
                name: "makine_ekipman");

            migrationBuilder.DropTable(
                name: "risk_analiz");

            migrationBuilder.DropTable(
                name: "risk_analiz_risk");

            migrationBuilder.DropTable(
                name: "egitim_konu_alt_baslik");

            migrationBuilder.DropTable(
                name: "kullanici");

            migrationBuilder.DropTable(
                name: "sgk_meslek");

            migrationBuilder.DropTable(
                name: "kkd_tur");

            migrationBuilder.DropTable(
                name: "tali_birim");

            migrationBuilder.DropTable(
                name: "egitim_konu");

            migrationBuilder.DropTable(
                name: "birim");

            migrationBuilder.DropTable(
                name: "alt_isveren");

            migrationBuilder.DropTable(
                name: "isveren");

            migrationBuilder.DropTable(
                name: "isg_kurul");
        }
    }
}
