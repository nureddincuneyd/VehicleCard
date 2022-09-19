using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using VehicleCard.MVC.Models;
using VehilceCard.ENT.Models;

namespace VehicleCard.MVC.Controllers
{
    public class ModelsController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnvironment;
        List<ModelAll> mdlAll = new List<ModelAll>();
        readonly string uploadPath = "https://localhost:44360/images/";
        public ModelsController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
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

        public JsonResult DeleteModel(int id)
        {
            ServiceMethod service = new ServiceMethod();
            var resp = service.DeleteModel(id);
            if (resp.IsSuccessful)
            {
                return Json(Ok());
            }
            else
            {
                return Json(BadRequest());
            }
        }
        public IActionResult NewModel()
        {
            return View();
        }
        //CreateModel

        public JsonResult CreateModel(Model mdl)
        {
            ServiceMethod service = new ServiceMethod();
            
            var resp = service.CreateModel(mdl);
            if (resp.Content != null)
            {
                return Json(Ok());
            }
            else
            {
                return Json(BadRequest());
            }
        }

        public IActionResult UpdateModel(int id)
        {
            ServiceMethod service = new ServiceMethod();
            var resp = service.GetByIdModel(id);
            Model rModel = new Model();
            if (resp.Content != null)
            {
                rModel = JsonConvert.DeserializeObject<Model>(resp.Content);
            }
            mdlAll.Add(new ModelAll
            {
                rModel = rModel
            });

            return View(mdlAll);
        }

        public JsonResult UpdateMdl(Model mdl)
        {
            ServiceMethod service = new ServiceMethod();

            var result = service.UpdateModel(mdl);
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
