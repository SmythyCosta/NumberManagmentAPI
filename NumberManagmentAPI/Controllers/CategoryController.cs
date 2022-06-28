using Microsoft.AspNetCore.Mvc;
using NumberManagmentAPI.DTO;
using NumberManagmentAPI.Service;

namespace NumberManagmentAPI.Controllers
{

    [Route("api/category")]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [Route("")]
        [HttpGet]
        public ActionResult getAll()
        {
            return Ok(_service.GetAll());
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult GetOne(int id)
        {
            var obj = _service.GetById(id);

            if (obj == null)
                return NotFound();

            return Ok(obj);
        }

        [Route("")]
        [HttpPost]
        public ActionResult Save([FromBody] CategoryDTO obj)
        {
            if (obj == null)
                return BadRequest();

            _service.Save(obj);

            return Ok("Category successfully created");
        }

        [Route("{id}")]
        [HttpPut]
        public ActionResult Upadte(int id, [FromBody] CategoryDTO obj)
        {
            if (obj == null)
                return BadRequest();

            obj.CategoryId = id;

            var dto = _service.Update(obj);

            if (dto == null)
                return NotFound();

            return Ok(dto);
        }

        [Route("{id}")]
        [HttpDelete]
        public ActionResult Deletar(int id)
        {
            _service.Delete(id);
            
            return NoContent();
        }
    }
}
