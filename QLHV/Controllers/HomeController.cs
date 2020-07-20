using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QLHV.Models;
using QLHV.Models.Class;
using QLHV.ViewsModel;

namespace QLHV.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentsRepository studentsRepository;
        private readonly ILopHocRepository lopHocRepository;

        public HomeController(IStudentsRepository studentsRepository,ILopHocRepository lopHocRepository)
        {
            this.studentsRepository = studentsRepository;
            this.lopHocRepository = lopHocRepository;
        }    
      
        public IActionResult Index()
        {
            var data = (from l in lopHocRepository.Gets().ToList()
                        select new LopHoc()
                        {
                            LopHocId = l.LopHocId,
                            LopHocName = l.LopHocName
                        }).ToList();
            return View(data);
        }
        public IActionResult Table(int id)
        {
            var data = (from s in studentsRepository.Gets().ToList()
                        join l in lopHocRepository.Gets().ToList()
                        on s.LopHocId equals l.LopHocId
                        where l.LopHocId == id
                        select new DetailsViewModel()
                        {
                            Email = s.Email,
                            NgaySinh = s.NgaySinh,
                            GioiTinh = s.GioiTinh,
                            HoTen = s.HoTen,
                            ID = s.ID,
                            LopHocId = l.LopHocId,
                            Name = l.LopHocName
                        }).ToList();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.LopHoc = GetLopHocs();
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateStudentsViewsModels model)
        {
            if (ModelState.IsValid)
            {
                var emp = studentsRepository.Gets();
                var stu = new Students()
                {
                    NgaySinh = model.NgaySinh,
                    Email = model.Email,
                    GioiTinh = model.GioiTinh,
                    HoTen = model.HoTen,
                    LopHocId = model.LopHocId
                };
                var stud = studentsRepository.Create(stu);
                if (stu != null)
                {
                    return RedirectToAction("Index", new { id = stu.ID });
                }
            }
            return View(model);
           
        }
        public List<LopHoc> GetLopHocs()
        {
            return lopHocRepository.Gets().ToList();
        }
        public IActionResult Edit(int id)
        {
            if (ModelState.IsValid)
            {
                var emp = studentsRepository.Get(id);
                var students = new EditStudentsViewsModel
                {
                    Email = emp.Email,
                    NgaySinh = emp.NgaySinh,
                    GioiTinh = emp.GioiTinh,
                    HoTen = emp.Name,
                    Id = emp.Id,
                    LopHocId = emp.LopHocId
                };
                ViewBag.LopHoc = GetLopHocs();
                return View(students);
            }
            return View();
           
        }
        [HttpPost]
        public IActionResult Edit(EditStudentsViewsModel model)
        {
            var emp = studentsRepository.Get(model.Id);
            var stu = new Students()
            {
                NgaySinh = model.NgaySinh,
                Email = model.Email,
                GioiTinh = model.GioiTinh,
                HoTen = model.HoTen,
                LopHocId = model.LopHocId,
                ID = model.Id
                
            };
            var lophoc = studentsRepository.Edit(stu);
            if(lophoc != null)
            {
                return RedirectToAction("Index", new { id = lophoc.ID });
            }
            ViewBag.LopHoc = GetLopHocs();
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var emp = studentsRepository.Get(id);
            if(emp != null)
            {
                studentsRepository.Delete(emp.Id);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Details(int? id)
        {
            var emp = studentsRepository.Get(id??1);
            var stu = new StudentsDetailsModelsViews()
            {
                NgaySinh = emp.NgaySinh,
                Email = emp.Email,
                GioiTinh = emp.GioiTinh,
                Id = emp.Id,
                LopHocName = emp.LopHocName,
                LopHocId = emp.LopHocId,
                Name =emp.Name
            };
            return View(stu);
        }
        //public IActionResult Products(int id)
        //{
        //    List<Students> students = (from c in studentsRepository.Gets() where c.LopHocId == id select c).ToList();
        //    ViewBag.Category = studentsRepository.Gets().ToList();
        //    return View(students);
        //}
    }
}