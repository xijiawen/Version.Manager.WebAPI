using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Version.Manager.Model.Models.InDto;
using Version.Manager.Model;

namespace Version.Manager.Service.IServices
{
    public interface IFileService
    {
        void UploadFile(List<IFormFile> files, string subDirectory);
        (string fileType, byte[] archiveData, string archiveName) DownloadFiles(string subDirectory);
        void DownFiles(string sourceFile, string descFile, string fileName);
        void DownLoadFiles(string sourcDict, string descDict, string[] fileType);
        string SizeConverter(long bytes);
        public void addFile(FileUploadInDto InDto);
    }
}
