using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookManagement.Models;
using BookManagement.Models.TheLoaiTruyen;
using BookManagement.ViewsModels;

namespace BookManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookRespository bookRespository;
        private readonly ITheLoaiRepository theLoaiRepository;

        public HomeController(IBookRespository bookRespository, ITheLoaiRepository theLoaiRepository)
        {
            this.bookRespository = bookRespository;
            this.theLoaiRepository = theLoaiRepository;
        }
        public IActionResult Index()
        {
            var data = (from l in theLoaiRepository.Gets().ToList()
                        select new TheLoai()
                        {
                            TheLoaiId = l.TheLoaiId,
                            TheLoaiName = l.TheLoaiName
                        }).ToList();
            return View(data);
        }
        public IActionResult Table(int id)
        {
            var data = (from b in bookRespository.Gets().ToList()
                        join t in theLoaiRepository.Gets().ToList()
                        on b.TheLoaiId equals t.TheLoaiId
                        where t.TheLoaiId == id
                        select new DetailsViewsModels()
                        {
                            Id = b.Id,
                            Mota = b.Mota,
                            SoLuong = b.SoLuong,
                            TenSach = b.TenSach,
                            Nsx = b.Nsx,
                            TenTacGia = b.TenTacGia,
                            Name = t.TheLoaiName,
                        }).ToList();
            return View(data);
        }
        public IActionResult Create()
        {
            ViewBag.TheLoais = GetTheLoais();
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateBooksViewsModel model)
        {
            if (ModelState.IsValid)
            {
                var emp = bookRespository.Gets();
                var stu = new Book()
                {
                    SoLuong = model.SoLuong,
                    Mota = model.Mota,
                    TenSach = model.TenSach,
                    Nsx = model.Nsx,
                    TenTacGia = model.TenTacGia,
                    TheLoaiId = model.TheLoaiId
                };
                var stud = bookRespository.Create(stu);
                if (stu != null)
                {
                    return RedirectToAction("Index", new { id = stu.Id });
                }
            }
            return View(model);

        }
        public IActionResult Edit(int id)
        {
            if (ModelState.IsValid)
            {
                //ViewBag.TheLoais = GetTheLoais();
                var emp = bookRespository.Get(id);
                var students = new EditBooksViewsModel
                { 
                    Mota = emp.Mota,
                    SoLuong = emp.SoLuong,
                    TenSach = emp.TenSach,
                     Nsx = emp.Nsx,
                     TenTacGia = emp.TenTacGia,
                     TheLoaiId = emp.TheLoaiId
                };
                ViewBag.TheLoais = GetTheLoais();
                return View(students);
            }
            return View();

        }
        [HttpPost]
        public IActionResult Edit(EditBooksViewsModel model)
        {
            var emp = bookRespository.Get(model.Id);
            var stu = new Book()
            {
               SoLuong = model.SoLuong,
               TenSach = model.TenSach,
               Id =model.Id,
               Mota = model.Mota,
               Nsx = model.Nsx,
               TenTacGia =model.TenTacGia,
               TheLoaiId = model.TheLoaiId

            };
            var lophoc = bookRespository.Edit(stu);
            if (lophoc != null)
            { 
                return RedirectToAction("Index", new { id = lophoc.Id });
            }
            ViewBag.TheLoais = GetTheLoais();
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var emp = bookRespository.Get(id);
            if (emp != null)
            {
                bookRespository.Delete(emp.Id);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Details(int? id)
        {
            var emp = bookRespository.Get(id ?? 1);
            var stu = new BooksDetailsViewsModels()
            {
              Id = emp.Id,
              SoLuong = emp.SoLuong,
              TenSach = emp.TenSach,
              Mota = emp.Mota,
              Nsx = emp.Nsx,
              TenTacGia =emp.TenTacGia,
              TheLoaiName = emp.TheLoaiName
            };
            return View(stu);
        }
        public List<TheLoai> GetTheLoais()
        {
            return theLoaiRepository.Gets().ToList();
        }

    }
}
