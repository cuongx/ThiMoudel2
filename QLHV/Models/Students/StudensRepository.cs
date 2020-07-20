using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLHV.Models
{
    public class StudensRepository : IStudentsRepository
    {
        private readonly AppDbContext context;

        public StudensRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Students Create(Students students)
        {
            context.Students.Add(students);
            context.SaveChanges();
            return students;
        }

        public bool Delete(int id)
        {
            var emp = context.Students.Find(id);
            if (emp != null)
            {
                context.Students.RemoveRange(emp);
                return context.SaveChanges() > 0;
            }
            return false;
        }


        public StudentsDetailsModelsViews Get(int id)
        {
            var data = (from s in context.Students
                        join l in context.LopHoc
                        on s.LopHocId equals
                        l.LopHocId
                        where s.ID == id
                        select new StudentsDetailsModelsViews()
                        {
                            Id = s.ID,
                            LopHocId = l.LopHocId,
                            LopHocName = l.LopHocName,                       
                            Name = s.HoTen,
                            Email = s.Email
                        }).FirstOrDefault();
            return data;
            //return context.Students.Find(id);
        }


        public IEnumerable<Students> Gets()
        {
            return context.Students;
        }

        public Students Edit(Students employees)
        {
            var empl = context.Students.Attach(employees);
            empl.State = EntityState.Modified;
            context.SaveChanges();
            return employees;
        }      

    }
}
   