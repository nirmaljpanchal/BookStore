using CoreAbstraction;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Collections.Generic;

namespace BookStoreApi.Controllers
{
    public abstract class AbstractController<TEntity,TService> : ControllerBase
        where TEntity: class, IBaseModel
        where TService: IBaseService<TEntity>
    {
        protected TService _service;
        public AbstractController(TService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<TEntity> Get()
        {
            return _service.GetAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public TEntity Get(int id)
        {
            return _service.GetById(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] TEntity value)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
            }
            UploadFiles(value);
            _service.Save(value);
            return Ok(value);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TEntity value)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
            }
            if (id != value.Id)
                return BadRequest();
            if (_service.GetById(id) == null)
                return NotFound();
            UploadFiles(value);
            _service.Update(value);
            return Ok(value);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public virtual void Delete(int id)
        {
            _service.Delete(id);
        }

        protected virtual void UploadFiles(TEntity value)
        {

        }
    }
}
