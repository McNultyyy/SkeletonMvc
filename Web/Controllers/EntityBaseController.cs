using System.Threading.Tasks;
using BLL.Services;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class EntityBaseController<TEntity> : Controller
        where TEntity : IEntity
    {
        private readonly IEntityService<TEntity> _service;

        protected EntityBaseController(IEntityService<TEntity> service)
        {
            _service = service;
        }


        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody]TEntity value)
        {
            await _service.CreateAsync(value);
            return Ok();
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put(int id, [FromBody]TEntity value)
        {
            if (value.Id != id)
                return BadRequest();

            var dbEntity = await _service.GetAsync(id);
            if (dbEntity == null)
                NotFound();

            await _service.UpdateAsync(value);
            return Ok();
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var dbEntity = await _service.GetAsync(id);
            if (dbEntity == null)
                NotFound();

            await _service.DeleteAsync(dbEntity);
            return Ok();
        }
    }

}