using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using VehicleCard.BLL.RepositoryPattern.Interfaces;
using VehicleCard.MAP.MapModel;
using VehilceCard.ENT.Models;

namespace VehicleCard.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsWithVehiclesController : ControllerBase
    {

        readonly IRepository<ProductsWithVehicles> _proWtVeh;
        private readonly IMapper _mapper;
        public ProductsWithVehiclesController(IRepository<ProductsWithVehicles> proWtVeh, IMapper mapper)
        {
            _proWtVeh = proWtVeh;
            _mapper = mapper;
        }

        [Route("GetAll")]
        [HttpGet]
        public ActionResult GetAll()
        {
            var resp = _mapper.Map<IEnumerable<ViewProductWithVehicle>>(_proWtVeh.GetAll());
            return Ok(resp);
        }

        [Route("GetByFilter")]
        [HttpPost]
        public ActionResult GetByFilter(Expression<Func<ProductsWithVehicles, bool>> exp)
        {
            var resp = _mapper.Map<IEnumerable<ViewProductWithVehicle>>(_proWtVeh.GetByFilter(exp));
            return Ok(resp);
        }

        [Route("GetById")]
        [HttpPost]
        public ActionResult GetById(int id)
        {
            var resp = _mapper.Map<ViewProductWithVehicle>(_proWtVeh.GetById(id));
            return Ok(resp);
        }

        [Route("Update")]
        [HttpPost]
        public ActionResult Update(ViewProductWithVehicle pWv)
        {
            var resp = _proWtVeh.Update(_mapper.Map<ProductsWithVehicles>(pWv));
            return Ok(resp);
        }

        [Route("Create")]
        [HttpPost]
        public ActionResult Create(List<ViewProductWithVehicle> lPWv)
        {
            _proWtVeh.CreateRange(_mapper.Map<List<ProductsWithVehicles>>(lPWv));
            return Ok();
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
