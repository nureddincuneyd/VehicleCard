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
    public class ModelController : ControllerBase
    {
        readonly IRepository<Model> _model;
        private readonly IMapper _mapper;
        public ModelController(IRepository<Model> model, IMapper mapper)
        {
            _model = model;
            _mapper = mapper;

        }

        [Route("GetAll")]
        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var resp = _mapper.Map<IEnumerable<ViewModel>>(_model.GetAll());
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Route("GetByFilter")]
        [HttpPost]
        public ActionResult GetByFilter(Expression<Func<Model, bool>> exp)
        {
            try
            {
                var resp = _mapper.Map<IEnumerable<ViewModel>>(_model.GetByFilter(exp));
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetById")]
        [HttpPost]
        public ActionResult GetById(int id)
        {

            try
            {
                var resp = _mapper.Map<ViewModel>(_model.GetById(id));
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Update")]
        [HttpPost]
        public ActionResult Update(ViewModel mdl)
        {
            try
            {
                var resp = _model.Update(_mapper.Map<Model>(mdl));
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Create")]
        [HttpPost]
        public ActionResult Create(ViewModel mdl)
        {
            try
            {
                mdl.Id = 0;
                var resp = _model.Create(_mapper.Map<Model>(mdl));
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Delete")]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var resp = _model.Delete(id);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
