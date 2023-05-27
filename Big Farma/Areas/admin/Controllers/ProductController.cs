using Big_Farma.Models;
using Big_Farma.Repository.IRepository;
using Big_Farma.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using System.Data;
using System.Security.Claims;

namespace Big_Farma.Areas.admin.Controllers
{
    
    [Area("admin")]
    public class ProductController : Controller
    {
        public CustomerStockVm CustomerStock { get; set; }

          private readonly IUnitOfWork _unitOfWork;
          private readonly IWebHostEnvironment _HostEnvironment;

    public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment HostEnviroment)
    {
        _unitOfWork = unitOfWork;
        _HostEnvironment = HostEnviroment;
    }
        [Authorize]
        public IActionResult Index()
    {       var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            //if (User.IsInRole("Admin")){
            //    CustomerStock = new CustomerStockVm()
            //    {
            //        ListProducts = _unitOfWork.product.GetAll()
            //    };
            //}
            //else
            //{
                CustomerStock = new CustomerStockVm()
                {
                    ListProducts = _unitOfWork.product.GetAll(u => u.ApplicationIdentity == claim.Value)
                };

            
          
            return View(CustomerStock);
            
    }

        //get
        [Authorize(Roles = "Customer"+","+"Admin")]
        public IActionResult Upsert(int? id)
    {
        ProductVm productVm = new()
        {
            product = new(),
            CategoryLists = _unitOfWork.category.GetAll().Select(i => new SelectListItem
            {
                Text = i.CategoryName,
                Value = i.ID.ToString(),
            }),
           
        };

        //IEnumerable<SelectListItem> CoverTypeList = _unitOfWork.coverType.GetAll().Select(
        // u => new SelectListItem
        // {
        //     Text = u.Name,
        //     Value = u.ID.ToString()
        // });

        if (id == null || id == 0)
        {
            //create product


            return View(productVm);

        }
        else
        {
            //update the product
            productVm.product = _unitOfWork.product.GetFirstOrDefault(i => i.ID == id);
            return View(productVm);
        }
    }



    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(ProductVm obj, IFormFile? file)
    {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            obj.product.ApplicationIdentity = claim.Value;

            if (ModelState.IsValid)
        {
               


                string wwwRootPath = _HostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"images\products");
                var extension = Path.GetExtension(file.FileName);

                if (obj.product.ImageUrl != null)
                {
                    var oldImagePath = Path.Combine(wwwRootPath, obj.product.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file.CopyTo(fileStreams);
                }
                obj.product.ImageUrl = @"\images\products\" + fileName + extension;

            }

            if (obj.product.ID == 0)
            {
              
                _unitOfWork.product.Add(obj.product);
            }
            else
            {
                _unitOfWork.product.Update(obj.product);
            }


            _unitOfWork.Save();
            TempData["success"] = "Product created successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

        //public IActionResult GetUserTables()
        //{
        //    var claimIdentity = (ClaimsIdentity)User.Identity;
        //    var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);

        //    CustomerStock = new CustomerStockVm()
        //    {
        //        ListProducts = _unitOfWork.product.GetAll(u => u.ApplicationIdentity == claim.Value)
        //    };
        //    return View(CustomerStock);
        //}



    #region API CALLS
    [HttpGet]
    public IActionResult GetAll()
    {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (User.IsInRole("Admin"))
            {

                var ListProducts = _unitOfWork.product.GetAll(includeProperties: "category");
                return Json(new { data = ListProducts });
            }

            else
            {
                var ListProducts = _unitOfWork.product.GetAll(u => u.ApplicationIdentity == claim.Value, includeProperties: "category");
                return Json(new { data = ListProducts });

            }
          return RedirectToAction("Index");
        
    }
    [HttpDelete]
    public IActionResult Delete(int? id)
    {
        var obj = _unitOfWork.product.GetFirstOrDefault(u => u.ID == id);
        if (obj == null)
        {
            return Json(new { success = false, message = "error while deleting" });
        }
        if (obj.ImageUrl != null)
        {
            var oldImagePath = Path.Combine(_HostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
        }


        _unitOfWork.product.Remove(obj);
        _unitOfWork.Save();
        return Json(new { success = true, message = "deleting successfull" });


    }
    #endregion

}


}
