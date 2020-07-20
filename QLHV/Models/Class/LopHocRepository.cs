using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLHV.Models.Class
{
    public class LopHocRepository : ILopHocRepository
    {
        private readonly AppDbContext context;

        public LopHocRepository(AppDbContext context)
        {
            this.context = context;
        }
        public LopHoc Create(LopHoc lopHoc)
        {
            context.LopHoc.Add(lopHoc);
            context.SaveChanges();
            return lopHoc;
        }

        public bool Delete(int id)
        {
            var emp = context.LopHoc.Find(id);
            if(emp != null)
            {
                context.Remove(emp);
                return context.SaveChanges() > 0;
            }
            return false;
        }

        public LopHoc Edit(LopHoc lopHoc)
        {
            var emp = context.LopHoc.Attach(lopHoc);
            emp.State = EntityState.Modified;
            context.SaveChanges();
            return lopHoc;
        }

        public LopHoc Get(int id)
        {
            return context.LopHoc.Find(id);
        }

        public IEnumerable<LopHoc> Gets()
        {
            return context.LopHoc;
        }
    }
}
