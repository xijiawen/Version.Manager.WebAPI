using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Version.Manager.Model;
using Version.Manager.Model.Models.InDto;
using Version.Manager.Service.IServices;

namespace Version.Manager.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        #region Property
        private readonly IFileService _fileService;
        #endregion

        #region Constructor
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }
        #endregion

        #region Upload
        [HttpPost]
        public IActionResult Upload([Required] List<IFormFile> formFiles, [Required] string subDirectory)
        {
            try
            {
                _fileService.UploadFile(formFiles, subDirectory);

                return Ok(new { formFiles.Count, Size = _fileService.SizeConverter(formFiles.Sum(f => f.Length)) });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Download File
        //[HttpGet]
        //public IActionResult Download([Required] string subDirectory)
        //{

        //    try
        //    {
        //        var (fileType, archiveData, archiveName) = _fileService.DownloadFiles(subDirectory);
        //        return File(archiveData, fileType, archiveName);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //}

        [HttpPost]
        public APIReturnResult<object> Download(FileOperateModel InDto)
        {
             _fileService.DownFiles(InDto.sourceFile, InDto.destFile, InDto.fileName);
             return new object();
        }

        #endregion


        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="InDto"></param>
        /// <returns></returns>
        [HttpPost]
        public APIReturnResult<object> MesFileDownLoad([Required] MesFileDownLoadInDto InDto) 
        {
            _fileService.DownLoadFiles(InDto.mySourcDict, InDto.myDescDict, InDto.myFileType);
            return new object();
        }

        [HttpPost]
        public APIReturnResult<object> addFile(FileUploadInDto InDto) 
        {
            _fileService.addFile(InDto);
            return new object();
        }
    } 
}
