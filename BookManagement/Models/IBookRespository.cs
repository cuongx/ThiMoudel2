using BookManagement.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Models
{
  public  interface IBookRespository
    {
        IEnumerable<Book> Gets();
        BooksDetailsViewsModels Get(int id);
        Book Create(Book book);
        Book Edit(Book book);
        bool Delete(int id);
    }
}
