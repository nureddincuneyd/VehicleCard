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
    public class ProductController : ControllerBase
    {

        readonly IRepository<Product> _product;
        public ProductController(IRepository<Product> product)
        {
            _product = product;
        }

        [Route("GetAll")]
        [HttpGet]
        public ActionResult GetAll()
        {
            var resp = _product.GetAll();
            return Ok(resp);
        }

        [Route("GetByFilter")]
        [HttpPost]
        public ActionResult GetByFilter(Expression<Func<Product, bool>> exp)
        {
            var resp = _product.GetByFilter(exp);
            return Ok(resp);
        }

        [Route("GetById")]
        [HttpPost]
        public ActionResult GetById(int id)
        {
            var resp = _product.GetById(id);
            return Ok(resp);
        }

        [Route("Update")]
        [HttpPost]
        public ActionResult Update(Product prd)
        {
            var resp = _product.Update(prd);
            return Ok(resp);
        }

        [Route("Create")]
        [HttpPost]
        public ActionResult Create(Product prd)
        {
            prd.Id = 0;
            var resp = _product.Create(prd);
            return Ok(resp);
        }

        [Route("Delete")]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var resp = _product.Delete(id);
            return Ok(resp);
        }
    }
}
