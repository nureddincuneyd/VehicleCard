using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using VehicleCard.MVC.Models;
using VehilceCard.ENT.Models;

namespace VehicleCard.MVC.Controllers
{
    public class ProductWithVehicleController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        List<ModelAll> mdlAll = new List<ModelAll>();
        readonly string uploadPath = "https://localhost:44360/images/";
        public ProductWithVehicleController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            ServiceMethod service = new ServiceMethod();
            var respVhl = service.GetAllVehicle();
            var respPro = service.GetAllProduct();
            var resMdl = service.GetAllModel();

            List<Vehicle> lVehicle = new List<Vehicle>();
            List<Product> lProduct = new List<Product>();
            List<Model> lModel = new List<Model>();


            if (respVhl.Content != null && respPro.Content != null && resMdl.Content != null)
            {
                lVehicle = JsonConvert.DeserializeObject<List<Vehicle>>(respVhl.Content);
                lProduct = JsonConvert.DeserializeObject<List<Product>>(respPro.Content);
                lModel = JsonConvert.DeserializeObject<List<Model>>(resMdl.Content);
            }
            mdlAll.Add(new ModelAll
            {
                lVehicle = lVehicle,
                lModel = lModel,
                lProduct = lProduct
            });
            return View(mdlAll);
        }

        public JsonResult AddOperation(string request)
        {
            ServiceMethod service = new ServiceMethod();
            List<ViewOperation> lOperation = new List<ViewOperation>();
            if (request != null)
            {
                lOperation = JsonConvert.DeserializeObject<List<ViewOperation>>(request);
                List<ProductsWithVehicles> lPWv = new List<ProductsWithVehicles>();
                ProductsWithVehicles pWv = new ProductsWithVehicles();
                foreach (var item in lOperation)
                {

                    pWv.AvailableCapM3 = 0;
                    pWv.AvailableCapKG = item.availableCapKg;
                    pWv.VehiclesId = item.arac;
                    pWv.ProductsId = item.urun;

                    lPWv.Add(pWv);

                }

                var resp = service.CreatePwV(lPWv);
                if (resp.Content != null)
                {
                    return Json(Ok());
                }
                else
                {
                    return Json(BadRequest());
                }


            }
            return Json(BadRequest());
        }
    }
}
