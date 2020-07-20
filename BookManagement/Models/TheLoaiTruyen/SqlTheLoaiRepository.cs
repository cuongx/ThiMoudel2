using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Models.TheLoaiTruyen
{
    public class SqlTheLoaiRepository : ITheLoaiRepository
    {
        private readonly AppDbContext context;

        public SqlTheLoaiRepository(AppDbContext context)
        {
            this.context = context;
        }

        public TheLoai Create(TheLoai theloai)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TheLoai Edit(TheLoai theloai)
        {
            throw new NotImplementedException();
        }

        public TheLoai Get(int id)
        {
            return context.TheLoais.Find(id);
        }

        public IEnumerable<TheLoai> Gets()
        {
            return context.TheLoais;
        }
    }
}
