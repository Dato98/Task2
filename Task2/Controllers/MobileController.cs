using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Task2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using DAL.Entities;
using AutoMapper;

namespace Task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileController : Controller
    {
        private readonly IMobileRepository mobileRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IMapper mapper;
        public MobileController(IMobileRepository mobileRepository, IHostingEnvironment hostingEnvironment,IMapper mapper)
        {
            this.mobileRepository = mobileRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.mapper = mapper;
        }

        [HttpGet("SearchMobile/{name}/{manufacturer}/{pricestart}/{priceend}")]
        public ActionResult<IEnumerable<MobileDTO>> GetSearchMobile(string name,string manufacturer,double pricestart,double priceend)
        {
            var result = mobileRepository.FindByCondition(x => x.Manufacturer.Contains(manufacturer) && x.Name.Contains(name) && pricestart <= x.Price && x.Price <= priceend).ToList();
            if(result == null || result.Count == 0)
            {
                return NotFound();
            }
            return Ok(mapper.Map<MobileDTO>(result));
        }


        [HttpPost("CreateMobile")]
        public ActionResult CreateMobile([FromBody] MobileForm model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            Mobile dbModel = mapper.Map<Mobile>(model);
            dbModel.VideoThumb = UploadFile(model.Video);
            foreach(var pic in model.Pictures)
            {
                dbModel.MobilePictures.Add(new MobilePictures() { MobileId = model.Id, Thumb = UploadFile(pic) });
            }
            
            mobileRepository.Create(dbModel);

            return Ok();
        }

        [HttpPut("UpdateMobile")]
        public ActionResult PutMobile([FromBody]MobileForm model)
        {
            var dbModel = mobileRepository.Get(model.Id);
            if (dbModel == null)
                return NotFound();

            mapper.Map<MobileForm, Mobile>(model, dbModel);
            mobileRepository.Update(dbModel);

            return Ok();
        }
        

        [HttpDelete("DeleteMobile/{Id}")]
        public ActionResult DeleteMobile(int Id)
        {
            var model = mobileRepository.Get(Id);
            if (model == null)
            {
                return NotFound();
            }
            mobileRepository.Delete(model);
            return Ok();
        }



        private string GenerateFileDirectoryName()
        {
            return $"{DateTime.Now.Year}/{DateTime.Now.Month}/";
        }

        private void checkAndCreateDirectory(string path)
        {
            bool exists = Directory.Exists(Path.Combine(hostingEnvironment.WebRootPath, path));
            if (!exists)
            {
                Directory.CreateDirectory(Path.Combine(hostingEnvironment.WebRootPath, path));
            }
        }

        private string FileVersionCheckAndUpdate(string filename, string path, string ext)
        {
            int count = 1;
            string newFilename = filename;
            string newPath = Path.Combine(path, filename + ext);
            while (System.IO.File.Exists(Path.Combine(hostingEnvironment.WebRootPath, newPath)))
            {
                newFilename = String.Format("{0}({1})", filename, count++);
                newPath = Path.Combine(path, newFilename + ext);
            }
            return newFilename;
        }

        private string UploadFile(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                string name = Path.GetFileNameWithoutExtension(file.FileName);
                string ext = Path.GetExtension(file.FileName);
                string fileDirectoryName = GenerateFileDirectoryName();
                checkAndCreateDirectory($"Storage/{fileDirectoryName}");
                name = FileVersionCheckAndUpdate(name, $"Storage/{fileDirectoryName}", ext);
                var path = Path.Combine(hostingEnvironment.WebRootPath, "Storage", fileDirectoryName + name + ext);

                using (var stream = System.IO.File.Create(path))
                {
                    file.CopyTo(stream);
                }
                return Path.Combine("Storage", fileDirectoryName + name + ext);
            }
            return String.Empty;
        }
    }
}