using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System;
using VehicleCard.BLL.RepositoryPattern.Interfaces;
using VehilceCard.ENT.Models;

namespace VehicleCard.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsWithVehiclesController : ControllerBase
    {

        readonly IRepository<ProductsWithVehicles> _proWtVeh;
        public ProductsWithVehiclesController(IRepository<ProductsWithVehicles> proWtVeh)
        {
            _proWtVeh = proWtVeh;
        }

        [Route("GetAll")]
        [HttpGet]
        public ActionResult GetAll()
        {
            var resp = _proWtVeh.GetAll();
            return Ok(resp);
        }

        [Route("GetByFilter")]
        [HttpPost]
        public ActionResult GetByFilter(Expression<Func<ProductsWithVehicles, bool>> exp)
        {
            var resp = _proWtVeh.GetByFilter(exp);
            return Ok(resp);
        }

        [Route("GetById")]
        [HttpPost]
        public ActionResult GetById(int id)
        {
            var resp = _proWtVeh.GetById(id);
            return Ok(resp);
        }

        [Route("Update")]
        [HttpPost]
        public ActionResult Update(ProductsWithVehicles pWv)
        {
            var resp = _proWtVeh.Update(pWv);
            return Ok(resp);
        }

        [Route("Create")]
        [HttpPost]
        public ActionResult Create(ProductsWithVehicles pWv)
        {
            pWv.Id = 0;
            var resp = _proWtVeh.Create(pWv);
            return Ok(resp);
        }

        [Route("Delete")]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var resp = _proWtVeh.Delete(id);
            return Ok(resp);
        }
    }
}
