using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System;
using VehicleCard.BLL.RepositoryPattern.Interfaces;
using VehilceCard.ENT.Models;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using VehicleCard.MAP.MapModel;
using AutoMapper;

namespace VehicleCard.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        readonly IRepository<Product> _product;
        private readonly IMapper _mapper;

        public ProductController(IRepository<Product> product,IMapper mapper)
        {
            _product = product;
            _mapper = mapper;
        }

        [Route("GetAll")]
        [HttpGet]
        public ActionResult GetAll()
        {
            var resp = _mapper.Map<IEnumerable<ViewProduct>>(_product.GetAll());
            return Ok(resp);
        }

        [Route("GetByFilter")]
        [HttpPost]
        public ActionResult GetByFilter(Expression<Func<Product, bool>> exp)
        {
            var resp = _mapper.Map<IEnumerable<ViewProduct>>(_product.GetByFilter(exp));
            return Ok(resp);
        }

        [Route("GetById")]
        [HttpPost]
        public ActionResult GetById(int id)
        {
            var resp = _mapper.Map<ViewProduct>(_product.GetById(id));
            if (resp != null)
            {
                return Ok(resp);
            }
            else
            {
                return NotFound(id);
            }
            
        }

        [Route("Update")]
        [HttpPost]
        public ActionResult Update(ViewProduct prd)
        {
            var resp = _product.Update(_mapper.Map<Product>(prd));
            return Ok(resp);
        }

        [Route("Create")]
        [HttpPost]
        public ActionResult Create(ViewProduct prd)
        {
            prd.Id = 0;
            var resp = _product.Create(_mapper.Map<Product>(prd));
            return Ok(resp);
        }

        [Route("Delete")]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            _product.Delete(id);
            return Ok("Id'si " + id + " olan ürün silindi.");
        }
    }
}
