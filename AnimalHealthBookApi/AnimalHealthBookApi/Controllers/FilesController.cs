using AnimalHealthBookApi.Context;
using AnimalHealthBookApi.Models;
using AnimalHealthBookApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimalHealthBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly FileService _fileService;
        private readonly AHBContext _context;

        public FilesController(
            FileService fileService,
            AHBContext context
            )
        {
            _fileService = fileService;
            _context = context;
        }

        // GET api/files/{id}
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var file = _fileService.Get(id);

            if (file == null)
            {
                return NotFound();
            }

            return file;
        }

        // POST api/files
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] UploadFile file)
        {
            UploadFile savedFile = _fileService.Save(file);
            return Ok();
        }

        // PUT api/files/{id}
        [HttpPut]
        public async Task<IActionResult> Put([FromForm] UploadFile file)
        {

            var updated = _context.Update(file);
            return Ok(updated);
        }

    }
}
