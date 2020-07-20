using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLHV.Models
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }       
        public DbSet<LopHoc>LopHoc { get; set; }
        public DbSet<Students>Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Students>().HasData(

                new Students()
                {
                    ID = 1,
                    Email = "xuanc25@gmail.com",
                    GioiTinh = Dept.Nam,
                    HoTen = "Đinh Xuân Cường",
                    LopHocId =1,
                    
                },
                 new Students()
                 {
                     ID = 2,
                     Email = "xuanc55@gmail.com",
                     GioiTinh = Dept.Nam,
                     HoTen = "Nguyễn Đinh Tuấn",
                     LopHocId = 2,

                 });
               
            modelBuilder.Entity<LopHoc>().HasData(

              new LopHoc()
              {
                  LopHocId = 1,
                  LopHocName = "12A4"
              } ,
            new LopHoc()
            {
                LopHocId = 2,
                LopHocName = "12A4"
            });


        }
    }
}
