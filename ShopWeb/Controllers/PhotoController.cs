using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.DataAccess.Repository.IRepository;
using Shop.Models;
using Shop.Utility;

namespace ShopWeb.Controllers
{
    [Authorize(Roles = RoleConstant.Role_Admin)]
    public class PhotoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PhotoController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Photo> photos = _unitOfWork.Photo.GetAll().ToList();
            return View(photos);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Photo obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Photo.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Photo created successfully";
                return RedirectToAction("Index", "Photo");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Photo? photoFromUnitOfWOrk = _unitOfWork.Photo.Get(u => u.Id == id);

            if (photoFromUnitOfWOrk == null)
            {
                return NotFound();
            }
            return View(photoFromUnitOfWOrk);
        }
        [HttpPost]
        public IActionResult Edit(Photo obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Photo.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Photo updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Photo? photoFromunitofwork = _unitOfWork.Photo.Get(u => u.Id == id);
            if (photoFromunitofwork == null)
            {
                return NotFound();
            }
            return View(photoFromunitofwork);

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Photo? obj = _unitOfWork.Photo.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Photo.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted succesfully";
            return RedirectToAction("Index");
        }
    }
}
