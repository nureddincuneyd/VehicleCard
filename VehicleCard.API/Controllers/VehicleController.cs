using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System;
using VehicleCard.BLL.RepositoryPattern.Interfaces;
using VehilceCard.ENT.Models;
using AutoMapper;
using System.Collections.Generic;
using VehicleCard.MAP.MapModel;

namespace VehicleCard.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {

        readonly IRepository<Vehicle> _vehicle;
        private readonly IMapper _mapper;
        public VehicleController(IRepository<Vehicle> vehicle, IMapper mapper)
        {
            _vehicle = vehicle;
            _mapper = mapper;
        }

        [Route("GetAll")]
        [HttpGet]
        public ActionResult GetAll()
        {
            var resp = _mapper.Map<IEnumerable<Vehicle>>(_vehicle.GetAll());
            return Ok(resp);
        }

        [Route("GetByFilter")]
        [HttpPost]
        public ActionResult GetByFilter(Expression<Func<Vehicle, bool>> exp)
        {
            var resp = _mapper.Map<IEnumerable<Vehicle>>(_vehicle.GetByFilter(exp));
            return Ok(resp);
        }

        [Route("GetById")]
        [HttpPost]
        public ActionResult GetById(int id)
        {
            var resp = _mapper.Map<Vehicle>(_vehicle.GetById(id));
            return Ok(resp);
        }

        [Route("Update")]
        [HttpPost]
        public ActionResult Update(ViewVehicle vhl)
        {
            var resp = _vehicle.Update(_mapper.Map<Vehicle>(vhl));
            return Ok(resp);
        }

        [Route("Create")]
        [HttpPost]
        public ActionResult Create(ViewVehicle vhl)
        {
            vhl.Id = 0;
            var resp = _vehicle.Create(_mapper.Map<Vehicle>(vhl));
            return Ok(resp);
        }

        [Route("Delete")]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var resp = _vehicle.Delete(id);
            return Ok(resp);
        }
    }
}
