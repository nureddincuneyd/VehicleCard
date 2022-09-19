using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.IO;
using VehicleCard.MVC.Models;
using VehilceCard.ENT.Models;

namespace VehicleCard.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        List<ModelAll> mdlAll = new List<ModelAll>();
        readonly string uploadPath = "https://localhost:44360/images/";
        public ProductController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            ServiceMethod service = new ServiceMethod();
            var resp = service.GetAllProduct();
            List<Product> lProducts = new List<Product>();
            if (resp.Content != null)
            {
                lProducts = JsonConvert.DeserializeObject<List<Product>>(resp.Content);
            }
            mdlAll.Add(new ModelAll
            {
                lProduct = lProducts
            });

            return View(mdlAll);
        }

        public JsonResult DeleteProduct(int id)
        {
            ServiceMethod service = new ServiceMethod();
            var resp = service.DeleteProduct(id);
            if (resp.IsSuccessful)
            {
                return Json(Ok());
            }
            else
            {
                return Json(BadRequest());
            }
        }
        public IActionResult UploadFile(IFormFile formFile)
        {
            if (formFile != null)
            {
                string type = Guid.NewGuid().ToString() + ".png";
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images/");
                string filePath = Path.Combine(uploadsFolder, type);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    formFile.CopyTo(fileStream);
                }
                return new ObjectResult(new { status = "success", proState = type });
            }
            return new ObjectResult(new { status = "fail" });
        }

        public IActionResult NewProduct()
        {
            return View();
        }

        public JsonResult CreateProduct(Product pro, string imgName)
        {
            ServiceMethod service = new ServiceMethod();
            pro.ProImgUrl = uploadPath + imgName;
            var resp = service.CreateProduct(pro);
            if (resp.Content != null)
            {
                return Json(Ok());
            }
            else
            {
                return Json(BadRequest());
            }
        }

        public IActionResult UpdateProduct(int id)
        {
            ServiceMethod service = new ServiceMethod();
            var resp = service.GetByIdProduct(id);
            Product rProducts = new Product();
            if (resp.Content != null)
            {
                rProducts = JsonConvert.DeserializeObject<Product>(resp.Content);
            }
            mdlAll.Add(new ModelAll
            {
                rProduct = rProducts
            });

            return View(mdlAll);
        }

        public JsonResult UpdatePro(Product pro, string imgName)
        {
            ServiceMethod service = new ServiceMethod();
            if (pro.ProImgUrl != (uploadPath + imgName))
            {
                pro.ProImgUrl = uploadPath + imgName;
            }
            var result = service.UpdateProduct(pro);
            if (result.Content != null)
            {
                return Json(Ok(result.Content));
            }
            else
            {
                return Json(BadRequest());
            }
        }
    }
}
