using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using VehicleCard.MAP.MapModel;
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

            List<ViewVehicle> lVehicle = new List<ViewVehicle>();
            List<ViewProduct> lProduct = new List<ViewProduct>();
            List<ViewModel> lModel = new List<ViewModel>();


            if (respVhl.Content != null && respPro.Content != null && resMdl.Content != null)
            {
                lVehicle = JsonConvert.DeserializeObject<List<ViewVehicle>>(respVhl.Content);
                lProduct = JsonConvert.DeserializeObject<List<ViewProduct>>(respPro.Content);
                lModel = JsonConvert.DeserializeObject<List<ViewModel>>(resMdl.Content);
            }
            mdlAll.Add(new ModelAll
            {
                lVehicle = lVehicle,
                lModel = lModel,
                lProduct = lProduct
            });
            return View(mdlAll);
        }

        public JsonResult AddOperation(string request,string oprName)
        {
            ServiceMethod service = new ServiceMethod();
            List<ViewOperation> lOperation = new List<ViewOperation>();
            if (request != null && oprName != null)
            {
                lOperation = JsonConvert.DeserializeObject<List<ViewOperation>>(request);
                List<ViewProductWithVehicle> lPWv = new List<ViewProductWithVehicle>();
               
                foreach (var item in lOperation)
                {

                    ViewProductWithVehicle pWv = new ViewProductWithVehicle();
                    pWv.AvailableCapM3 = 0;
                    pWv.AvailableCapKG = item.availableCapKg;
                    pWv.VehiclesId = item.arac;
                    pWv.ProductsId = item.urun;
                    pWv.OperationName = oprName;
                    pWv.Status = true;
                    

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
            return Json(BadRequest("Araç ve Ürün seçimi yaptığınıza, Operasyona isim verdiğinize emin olun!"));
        }

        public IActionResult Operations()
        {
            ServiceMethod service = new ServiceMethod();
            var respVhl = service.GetAllVehicle();
            var respPro = service.GetAllProduct();
            var resMdl = service.GetAllModel();
            var resOpr = service.GetAllOperations();

            List<ViewVehicle> lVehicle = new List<ViewVehicle>();
            List<ViewProduct> lProduct = new List<ViewProduct>();
            List<ViewModel> lModel = new List<ViewModel>();
            List<ViewProductWithVehicle> lOperation = new List<ViewProductWithVehicle>();


            if (respVhl.Content != null && respPro.Content != null && resMdl.Content != null && resOpr.Content != null)
            {
                lVehicle = JsonConvert.DeserializeObject<List<ViewVehicle>>(respVhl.Content);
                lProduct = JsonConvert.DeserializeObject<List<ViewProduct>>(respPro.Content);
                lModel = JsonConvert.DeserializeObject<List<ViewModel>>(resMdl.Content);
                lOperation = JsonConvert.DeserializeObject<List<ViewProductWithVehicle>>(resOpr.Content);
            }


            mdlAll.Add(new ModelAll
            {
                lVehicle = lVehicle,
                lModel = lModel,
                lProduct = lProduct,
                lProductsWithVehicles = lOperation
            });
            return View(mdlAll);
        }
    }
}
