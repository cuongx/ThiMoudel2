
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Models
{
    public class AppDbContext : IdentityDbContext
    {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        
        public DbSet<TheLoai>TheLoais { get; set; }
        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    TenSach = "Conan",
                    Id = 1,
                    SoLuong = 2,
                    Mota = "Sách hay",
                    TenTacGia = "ConanDoy",
                    TheLoaiId = 1
                });
            modelBuilder.Entity<TheLoai>().HasData(
            new TheLoai()
            {
              TheLoaiId =1,
              TheLoaiName = "Truyện trinh thám"
            },
              new TheLoai()
              {
                  TheLoaiId = 2,
                  TheLoaiName = "Truyện lạng mạn"
              });

        }
    }
}
