using Microsoft.AspNetCore.Mvc;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
using VehicleCard.MVC.Models;
using VehilceCard.ENT.Models;

namespace VehicleCard.MVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ServiceMethod service = new ServiceMethod();
            var resp = service.GetAllProduct();
            List<Product> lProducts = new List<Product>();
            if (resp.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //lProducts = JsonSerializer.Deserialize<Product>(resp);
            }

            return View();
        }
    }
}
