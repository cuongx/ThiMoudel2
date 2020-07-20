using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Models.TheLoaiTruyen
{
  public  interface ITheLoaiRepository
    {
        IEnumerable<TheLoai> Gets();
        TheLoai Get(int id);
        TheLoai Create(TheLoai theloai);
        TheLoai Edit(TheLoai theloai);
        bool Delete(int id);
    }
}
