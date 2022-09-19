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
    public class VehicleController : ControllerBase
    {

        readonly IRepository<Vehicle> _vehicle;
        public VehicleController(IRepository<Vehicle> vehicle)
        {
            _vehicle = vehicle;
        }

        [Route("GetAll")]
        [HttpGet]
        public ActionResult GetAll()
        {
            var resp = _vehicle.GetAll();
            return Ok(resp);
        }

        [Route("GetByFilter")]
        [HttpPost]
        public ActionResult GetByFilter(Expression<Func<Vehicle, bool>> exp)
        {
            var resp = _vehicle.GetByFilter(exp);
            return Ok(resp);
        }

        [Route("GetById")]
        [HttpPost]
        public ActionResult GetById(int id)
        {
            var resp = _vehicle.GetById(id);
            return Ok(resp);
        }

        [Route("Update")]
        [HttpPost]
        public ActionResult Update(Vehicle vhl)
        {
            var resp = _vehicle.Update(vhl);
            return Ok(resp);
        }

        [Route("Create")]
        [HttpPost]
        public ActionResult Create(Vehicle vhl)
        {
            vhl.Id = 0;
            var resp = _vehicle.Create(vhl);
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
