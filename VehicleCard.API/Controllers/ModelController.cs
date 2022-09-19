using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using VehicleCard.BLL.RepositoryPattern.Interfaces;
using VehilceCard.ENT.Models;

namespace VehicleCard.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        readonly IRepository<Model> _model;
        public ModelController(IRepository<Model> model)
        {
            _model = model;
        }

        [Route("GetAll")]
        [HttpGet]
        public ActionResult GetAll()
        {
            var resp = _model.GetAll();
            return Ok(resp);
        }

        [Route("GetByFilter")]
        [HttpPost]
        public ActionResult GetByFilter(Expression<Func<Model,bool>> exp)
        {
            var resp = _model.GetByFilter(exp);
            return Ok(resp);
        }

        [Route("GetById")]
        [HttpPost]
        public ActionResult GetById(int id)
        {
            var resp = _model.GetById(id);
            return Ok(resp);
        }

        [Route("Update")]
        [HttpPost]
        public ActionResult Update(Model mdl)
        {
            var resp = _model.Update(mdl);
            return Ok(resp);
        }

        [Route("Create")]
        [HttpPost]
        public ActionResult Create(Model mdl)
        {
            mdl.Id = 0;
            var resp = _model.Create(mdl);
            return Ok(resp);
        }

        [Route("Delete")]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var resp = _model.Delete(id);
            return Ok(resp);
        }

    }
}
