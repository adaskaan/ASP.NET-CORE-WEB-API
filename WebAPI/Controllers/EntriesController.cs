using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntriesController : ControllerBase
    {
        private IEntryService _entriesService;
        public EntriesController(IEntryService entriesService)
        {
            _entriesService = entriesService;
        }
        [HttpGet(template: "getall")]
        public IActionResult GetList()
        {
            var result = _entriesService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet(template: "getbycategory")]
        public IActionResult GetByCategory(int id)
        {
            var result = _entriesService.GetListByCategory(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet(template: "get")]
        public IActionResult Get(int id)
        {
            var result = _entriesService.Get(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost(template: "add")]
        public IActionResult Add(Entry entry)
        {
            var result = _entriesService.Add(entry);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost(template: "delete")]
        public IActionResult Delete(Entry entry)
        {
            var result = _entriesService.Delete(entry);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost(template: "update")]
        public IActionResult Update(Entry entry)
        {
            var result = _entriesService.Update(entry);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
