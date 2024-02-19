using AnimalHealthBookApi.Context;
using AnimalHealthBookApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimalHealthBookApi.Services
{
    public class FileService 
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly AHBContext _context;

        public FileService(
                                  IWebHostEnvironment webHostEnvironment,
                                                        AHBContext context
                                  )
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }

        public FileContentResult? Get(Guid id)
        {
            var file = _context.UploadFiles.Find(id);
            if (file == null)
            {
                return null;
            }
            if (!System.IO.File.Exists(file.Path))
            {
                throw new Exception("File not found");
            }
            byte[] fileBytes = System.IO.File.ReadAllBytes(file.Path);
            string fullName = file.Name + Path.GetExtension(file.Path);

            return new FileContentResult(fileBytes, "application/octet-stream")
            {
                FileDownloadName = fullName
            };
        }

        public UploadFile Save(UploadFile file)
        {
            if (file == null || file.FormFile.Length <= 0)
                throw new Exception("File is null");
            try
            {
                if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\uploads\\"))
                {
                    Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\uploads\\");
                }
                string fileExtension = Path.GetExtension(file.FormFile.FileName);

                Guid Id = Guid.NewGuid();

                string uniqueFileName = Id.ToString() + fileExtension;

                using (var fileStream = new FileStream(_webHostEnvironment.WebRootPath + "\\uploads\\" + uniqueFileName, FileMode.Create))
                {
                    file.FormFile.CopyTo(fileStream);
                    fileStream.Flush();

                    var newFile = new UploadFile
                    {
                        Id = Id,
                        Name = file.Name,
                        Path = _webHostEnvironment.WebRootPath + "\\uploads\\" + uniqueFileName
                    };

                    _context.UploadFiles.Add(newFile);

                    _context.SaveChanges();
                    return newFile;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving file", ex);
            }
        }

        public UploadFile Update(UploadFile file)
        {
            var fileToUpdate = _context.UploadFiles.Find(file.Id);
            if (fileToUpdate == null)
            {
                throw new Exception("File not found");
            }
            if (!System.IO.File.Exists(fileToUpdate.Path))
            {
                throw new Exception("File not found");
            }
            System.IO.File.Delete(fileToUpdate.Path);
            string fileExtension = Path.GetExtension(file.FormFile.FileName);

            string uniqueFileName = file.Id.ToString() + fileExtension;

            using (var fileStream = new FileStream(_webHostEnvironment.WebRootPath + "\\uploads\\" + uniqueFileName, FileMode.Create))
            {
                file.FormFile.CopyTo(fileStream);
                fileStream.Flush();
                fileToUpdate.Name = file.Name;
                fileToUpdate.Path = _webHostEnvironment.WebRootPath + "\\uploads\\" + uniqueFileName;
                _context.Entry(fileToUpdate).State = EntityState.Modified; //?
                _context.SaveChanges();
                return file;
            }
        }


        public void Delete(Guid id)
        {
            var file = _context.UploadFiles.Find(id);
            if (file == null)
            {
                throw new Exception("File not found");
            }
            if (!System.IO.File.Exists(file.Path))
            {
                throw new Exception("File not found");
            }
            System.IO.File.Delete(file.Path);
            _context.UploadFiles.Remove(file);
            _context.SaveChanges();
        }   
    }
}