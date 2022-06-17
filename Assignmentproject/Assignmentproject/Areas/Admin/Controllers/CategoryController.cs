using Microsoft.AspNetCore.Mvc;
using MyApp.DataAccessLayer.Data;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.Models;
using MyApp.Models.ViewModels;
using System.Collections.Generic;

namespace Assignmentproject.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private IUnitOfWork _UnitOfWork;

        public CategoryController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        public IActionResult Index()
        {
            CategoryVm categoryVm = new CategoryVm();
            categoryVm.categories = _UnitOfWork.Category.GetAll();
        

            return View(categoryVm);
        }
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Category category)

        //{
        //    if (ModelState.IsValid)

        //    {
        //        _UnitOfWork.Category.Add(category);
        //        _UnitOfWork.save();
        //        TempData["success"] = "Category Created Done";
        //        return RedirectToAction("Index");
        //    }
        //    return View(category);

        //}
        [HttpGet]
        public IActionResult CreateUpdate(int? id)

        {
            CategoryVm vm = new CategoryVm();
            if (id == null || id == 0)
            {
                return View(vm);
            }
            else
            {
                vm.category = _UnitOfWork.Category.GetT(x => x.Id == id);
                if (vm.category == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(vm.category);
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate(CategoryVm vm)

        {
            if (ModelState.IsValid)
            {
                if(vm.category.Id==0)
                {
                    _UnitOfWork.Category.Add(vm.category);
                }
                else
                {
                    _UnitOfWork.Category.Update(vm.category);
                }
                
                _UnitOfWork.save();
                TempData["success"] = "Category Updated Done";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _UnitOfWork.Category.GetT(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(int? id)

        {
            var category = _UnitOfWork.Category.GetT(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _UnitOfWork.Category.Delete(category);
            _UnitOfWork.save();
            TempData["success"] = "Category Deleted Done";
            return RedirectToAction("Index");

        }


    }

}



