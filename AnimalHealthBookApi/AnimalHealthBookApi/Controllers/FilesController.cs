using AnimalHealthBookApi.Context;
using AnimalHealthBookApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimalHealthBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {

        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly AHBContext _context;

        public FilesController(
                       IWebHostEnvironment webHostEnvironment,
                       AHBContext context
                       )
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }

        // GET api/files/{id}
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var file = _context.UploadFiles.Find(id);

            if (file == null)
            {
                return NotFound();
            }

            // Ensure the file exists
            if (!System.IO.File.Exists(file.Path))
            {
                return NotFound();
            }

            // Read the file content and return it
            byte[] fileBytes = System.IO.File.ReadAllBytes(file.Path);
            //add extension
            string fullName = file.Name + Path.GetExtension(file.Path);
            return File(fileBytes, "application/octet-stream", fullName);
        }

        // POST api/files
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] UploadFile file)
        {
            if (file == null || file.FormFile.Length <= 0)
                return BadRequest("File is null");

            try
            {
                if(!Directory.Exists(_webHostEnvironment.WebRootPath + "\\uploads\\"))
                {
                    Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\uploads\\");
                }

                string fileExtension = Path.GetExtension(file.FormFile.FileName);

                // Generate a unique filename with the original extension
                Guid Id = Guid.NewGuid();

                string uniqueFileName = Id.ToString() + fileExtension;

                using (var fileStream = new FileStream(_webHostEnvironment.WebRootPath + "\\uploads\\" + uniqueFileName, FileMode.Create))
                {
                    await file.FormFile.CopyToAsync(fileStream);
                    fileStream.Flush();

                    var newFile = new UploadFile
                    {
                        Id = Id,
                        Name = file.Name,
                        Path = _webHostEnvironment.WebRootPath + "\\uploads\\" + uniqueFileName
                    };

                    _context.UploadFiles.Add(newFile);

                    await _context.SaveChangesAsync();

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        // PUT api/files/{id}
        [HttpPut]
        public async Task<IActionResult> Put([FromForm] UploadFile file)
        {

            var existingFile = await _context.UploadFiles.FindAsync(file.Id);

            if (existingFile == null)
            {
                return NotFound();
            }

            try
            {
                if (file.FormFile != null && file.FormFile.Length > 0)
                {
                    // Delete the existing file
                    if (System.IO.File.Exists(existingFile.Path))
                    {
                        System.IO.File.Delete(existingFile.Path);
                    }

                    string fileExtension = Path.GetExtension(file.FormFile.FileName);

                    // Generate a unique filename with the original extension
                    string uniqueFileName = Guid.NewGuid().ToString() + fileExtension;

                    using (var fileStream = new FileStream(Path.Combine(_webHostEnvironment.WebRootPath, "uploads", uniqueFileName), FileMode.Create))
                    {
                        await file.FormFile.CopyToAsync(fileStream);
                        fileStream.Flush();

                        existingFile.Path = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", uniqueFileName);
                    }
                }

                // Update the file name if provided
                if (!string.IsNullOrEmpty(file.Name))
                {
                    existingFile.Name = file.Name;
                }

                _context.Entry(existingFile).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

    }
}
