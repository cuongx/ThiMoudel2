using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookManagement.ViewsModels;

namespace BookManagement.Models
{
    public class SqlBookRepository : IBookRespository
    {
        private readonly AppDbContext context;

        public SqlBookRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Book Create(Book students)
        {
            context.Books.Add(students);
            context.SaveChanges();
            return students;
        }

        public bool Delete(int id)
        {
            var emp = context.Books.Find(id);
            if (emp != null)
            {
                context.Books.RemoveRange(emp);
                return context.SaveChanges() > 0;
            }
            return false;
        }


        public BooksDetailsViewsModels Get(int id)
        {
            var data = (from b in context.Books
                        join t in context.TheLoais
                        on b.TheLoaiId equals
                        t.TheLoaiId
                        where b.Id == id
                        select new BooksDetailsViewsModels()
                        {
                           Id = b.Id,
                           SoLuong = b.SoLuong,
                           TenSach = b.TenSach,
                           Mota =b.Mota,
                           Nsx = b.Nsx,
                           TenTacGia = b.TenTacGia,
                           TheLoaiId =t.TheLoaiId,
                           TheLoaiName = t.TheLoaiName
                        }).FirstOrDefault();
            return data;
          
        }


        public IEnumerable<Book> Gets()
        {
            return context.Books;
        }

        public Book Edit(Book employees)
        {
            var empl = context.Books.Attach(employees);
            empl.State = EntityState.Modified;
            context.SaveChanges();
            return employees;
        }

    }
}
   