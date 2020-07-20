using Microsoft.AspNetCore.Mvc;
using QLHV.Models;
using QLHV.Models.Class;
using QLHV.ViewsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLHV.Controllers
{
    public class LopHocController:Controller
    {
        private readonly ILopHocRepository lopHocRepository;

        public LopHocController(ILopHocRepository lopHocRepository)
        {
            this.lopHocRepository = lopHocRepository;
        }
        public IActionResult Index()
        {

            var emp = lopHocRepository.Gets();
            var result = new List<LopHoc>();

            result = emp.Select(a => new LopHoc()
            {
                LopHocId= a.LopHocId,
                LopHocName = a.LopHocName
            }).ToList();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateLopHocViewsModels model)
        {
            var emp = new LopHoc()
            {
                LopHocName = model.Name
            };
            if(emp !=null)
            {
                lopHocRepository.Create(emp);
                return RedirectToAction("Index");
            }
            return View(model);
            
        }
        public IActionResult Edit(int id)
        {
            var emp = lopHocRepository.Get(id);
            var result = new EditLopHocViewsModels()
            {
                Name = emp.LopHocName,
                Id = emp.LopHocId
            };
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(EditLopHocViewsModels models)
        {
            var empl = new LopHoc()
            {
                LopHocId = models.Id,
                LopHocName = models.Name
            };
            if(empl != null)
            {
                lopHocRepository.Edit(empl);
                return RedirectToAction("Index", new {id = empl.LopHocId});
            }
            return View(models);
        }
        public IActionResult Delete(int id)
        {
            var emp = lopHocRepository.Get(id);
            if(emp != null)
            {
                lopHocRepository.Delete(emp.LopHocId);
                return RedirectToAction("Index");
            }
            return View();
        }
        
    }
}
