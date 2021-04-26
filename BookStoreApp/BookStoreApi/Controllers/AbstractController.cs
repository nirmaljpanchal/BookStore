using AutoMapper;
using BookStoreApi.ViewModel;
using CoreAbstraction;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Collections.Generic;

namespace BookStoreApi.Controllers
{
    public abstract class AbstractController<TEntity,TService,TViewModel> : ControllerBase
        where TEntity: class, IBaseModel
        where TService: IBaseService<TEntity>
        where TViewModel : BaseViewModel
    {
        private readonly TService _service;
        private readonly IMapper _mapper;
        public AbstractController(TService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public IEnumerable<TViewModel> Get()
        {
            return _mapper.Map<List<TViewModel>>(_service.GetAll());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public TEntity Get(int id)
        {
            return _service.GetById(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] TViewModel value)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
            }
            var entity = _mapper.Map<TEntity>(value);
            UploadFiles(entity);
            _service.Save(entity);
            return Ok(value);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TViewModel value)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
            }
            if (id != value.Id)
                return BadRequest();
            if (_service.GetById(id) == null)
                return NotFound();
            var entity = _mapper.Map<TEntity>(value);
            UploadFiles(entity);

            _service.Update(entity);
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
