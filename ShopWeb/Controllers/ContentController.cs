using Microsoft.AspNetCore.Mvc;
using Shop.DataAccess.Repository.IRepository;
using Shop.Models;
using static System.Net.Mime.MediaTypeNames;

namespace ShopWeb.Controllers
{
    public class ContentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ContentController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Content> Contents = _unitOfWork.Content.GetAll().ToList();
            return View(Contents);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Content obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Content.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Content created successfully";
                return RedirectToAction("Index", "Content");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Content? ContentFromUnitOfWOrk = _unitOfWork.Content.Get(u => u.Id == id);

            if (ContentFromUnitOfWOrk == null)
            {
                return NotFound();
            }
            return View(ContentFromUnitOfWOrk);
        }
        [HttpPost]
        public IActionResult Edit(Content obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Content.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Content updated successfully";
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
            Content? ContentFromunitofwork = _unitOfWork.Content.Get(u => u.Id == id);
            if (ContentFromunitofwork == null)
            {
                return NotFound();
            }
            return View(ContentFromunitofwork);

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Content? obj = _unitOfWork.Content.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Content.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Content deleted succesfully";
            return RedirectToAction("Index");
        }
    }
}
