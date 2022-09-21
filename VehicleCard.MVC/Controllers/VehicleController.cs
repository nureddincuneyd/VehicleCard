using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System;
using VehicleCard.MVC.Models;
using VehilceCard.ENT.Models;
using VehicleCard.MAP.MapModel;

namespace VehicleCard.MVC.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        List<ModelAll> mdlAll = new List<ModelAll>();
        readonly string uploadPath = "https://localhost:44360/images/";
        public VehicleController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            ServiceMethod service = new ServiceMethod();
            var resp = service.GetAllVehicle();
            List<ViewVehicle> lVehicle = new List<ViewVehicle>();
            var respMdl = service.GetAllModel();
            List<ViewModel> lModel = new List<ViewModel>();
            if (resp.Content != null && respMdl.Content != null)
            {
                lVehicle = JsonConvert.DeserializeObject<List<ViewVehicle>>(resp.Content);
                lModel = JsonConvert.DeserializeObject<List<ViewModel>>(respMdl.Content);
            }
            mdlAll.Add(new ModelAll
            {
                lVehicle = lVehicle,
                lModel = lModel
            });

            return View(mdlAll);
        }

        public JsonResult DeleteVehicle(int id)
        {
            ServiceMethod service = new ServiceMethod();
            var resp = service.DeleteVehicle(id);
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

        public IActionResult NewVehicle()
        {
            ServiceMethod service = new ServiceMethod();
            var resp = service.GetAllModel();
            List<ViewModel> lModel = new List<ViewModel>();
            if (resp.Content != null)
            {
                lModel = JsonConvert.DeserializeObject<List<ViewModel>>(resp.Content);
            }
            mdlAll.Add(new ModelAll
            {
                lModel = lModel
            });
            return View(mdlAll);
        }

        public JsonResult CreateVehicle(ViewVehicle vhl, string imgName)
        {
            ServiceMethod service = new ServiceMethod();
            vhl.VehicleImgUrl = uploadPath + imgName;
            var resp = service.CreateVehicle(vhl);
            if (resp.Content != null)
            {
                return Json(Ok());
            }
            else
            {
                return Json(BadRequest());
            }
        }

        public IActionResult UpdateVehicle(int id)
        {
            ServiceMethod service = new ServiceMethod();
            var resp = service.GetByIdVehicle(id);
            ViewVehicle rVehicles = new ViewVehicle();
            var respMdl = service.GetAllModel();
            List<ViewModel> lModel = new List<ViewModel>();
            if (resp.Content != null && respMdl.Content != null)
            {
                rVehicles = JsonConvert.DeserializeObject<ViewVehicle>(resp.Content);
                lModel = JsonConvert.DeserializeObject<List<ViewModel>>(respMdl.Content);
            }
            mdlAll.Add(new ModelAll
            {
                lModel = lModel,
                rVehicle = rVehicles
            });

            return View(mdlAll);
        }

        public JsonResult UpdateVhl(ViewVehicle vhl, string imgName)
        {
            ServiceMethod service = new ServiceMethod();
            if (vhl.VehicleImgUrl != (uploadPath + imgName))
            {
                vhl.VehicleImgUrl = uploadPath + imgName;
            }
            var result = service.UpdateVehicle(vhl);
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
