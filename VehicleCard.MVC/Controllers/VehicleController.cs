using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System;
using VehicleCard.MVC.Models;
using VehilceCard.ENT.Models;

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
            List<Vehicle> lVehicle = new List<Vehicle>();
            var respMdl = service.GetAllModel();
            List<Model> lModel = new List<Model>();
            if (resp.Content != null && respMdl.Content != null)
            {
                lVehicle = JsonConvert.DeserializeObject<List<Vehicle>>(resp.Content);
                lModel = JsonConvert.DeserializeObject<List<Model>>(respMdl.Content);
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
            List<Model> lModel = new List<Model>();
            if (resp.Content != null)
            {
                lModel = JsonConvert.DeserializeObject<List<Model>>(resp.Content);
            }
            mdlAll.Add(new ModelAll
            {
                lModel = lModel
            });
            return View(mdlAll);
        }

        public JsonResult CreateVehicle(Vehicle vhl, string imgName)
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
            Vehicle rVehicles = new Vehicle();
            var respMdl = service.GetAllModel();
            List<Model> lModel = new List<Model>();
            if (resp.Content != null && respMdl.Content != null)
            {
                rVehicles = JsonConvert.DeserializeObject<Vehicle>(resp.Content);
                lModel = JsonConvert.DeserializeObject<List<Model>>(respMdl.Content);
            }
            mdlAll.Add(new ModelAll
            {
                lModel = lModel,
                rVehicle = rVehicles
            });

            return View(mdlAll);
        }

        public JsonResult UpdateVhl(Vehicle vhl, string imgName)
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
