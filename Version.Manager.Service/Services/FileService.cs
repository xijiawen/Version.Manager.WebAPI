using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO.Compression;
using Version.Manager.Model.Entitys;
using Version.Manager.Model.Models.Enum;
using Version.Manager.Model.Models.InDto;
using Version.Manager.Service.IServices;

namespace Version.Manager.Service.Services
{
    public class FileService : IFileService
    {
        #region Property
        private IHostingEnvironment _hostingEnvironment;
        #endregion

        #region Constructor
        public FileService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        #endregion

        #region Upload File
        public void UploadFile(List<IFormFile> files, string subDirectory)
        {
            subDirectory = subDirectory ?? string.Empty;
            var target = Path.Combine(_hostingEnvironment.ContentRootPath, subDirectory);

            Directory.CreateDirectory(target);

            files.ForEach(async file =>
            {
                if (file.Length <= 0) return;
                var filePath = Path.Combine(target, file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            });
        }
        #endregion

        #region Download File
        public (string fileType, byte[] archiveData, string archiveName) DownloadFiles(string subDirectory)
        {
            File.Copy("T:\\汽车电子事业部\\研发（上海）分部\\部门内可读\\07测试开发科\\03_部门周报\\TE管理周报_23W15.pptx",
                "D:\\测试临时文件\\TE管理周报_23W15.pptx");

            #region down
            var zipName = $"archive-{DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss")}.zip";

            var files = Directory.GetFiles(subDirectory).ToList();

            //foreach ( var file in files) 
            //{
            //    if (file.Contains("1.txt")) { 
            //    byte[] bytes = File.ReadAllBytes(file);
            //    string path = "D:\\测试临时文件\\1.txt";
            //    FileStream fs = File.Create(path);
            //    fs.Write(bytes, 0, bytes.Length);}
            //}



            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    files.ForEach(file =>
                    {
                        var theFile = archive.CreateEntry(file);
                        using (var streamWriter = new StreamWriter(theFile.Open()))
                        {
                            streamWriter.Write(File.ReadAllText(file));
                        }
                    });
                }
                File.WriteAllBytes($"D:\\文档资料\\{zipName}", memoryStream.ToArray());
                return ("application/zip", memoryStream.ToArray(), zipName);
            }
            #endregion

        }

        public void DownFiles(string sourceFile, string descFile, string fileName)
        {
            try
            {
                sourceFile = Path.Combine(sourceFile, fileName);
                if (!File.Exists(sourceFile))
                {
                    throw new Exception("源文件不存在");
                }
                if (!Directory.Exists(descFile))
                {
                    throw new Exception("目标文件夹不存在");
                }
                descFile = Path.Combine(descFile, fileName);
                FileStream fsw = new FileStream(descFile, FileMode.OpenOrCreate, FileAccess.Write);//创建写文件流
                using (FileStream fsr = new FileStream(sourceFile, FileMode.OpenOrCreate, FileAccess.Read))//创建读文件流
                {
                    byte[] vs = new byte[1024];
                    while (true)
                    {
                        int r = fsr.Read(vs, 0, vs.Length);
                        if (r == 0) //当读取不到，跳出循环
                        {
                            break;
                        }
                        fsw.Write(vs, 0, vs.Length);
                    }
                }
                fsw.Dispose();//手动释放资源
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// 下载文件到指定目录
        /// </summary>
        /// <param name="sourcDict">源文件夹</param>
        /// <param name="descDict">目标文件夹</param>
        /// <param name="fileType">文件类型</param>
        public void DownLoadFiles(string sourcDict, string descDict, string[] fileType)
        {
            List<MESFileEntity> entityList = new();
            if (!Directory.Exists(sourcDict))
            {
                throw new Exception("源文件夹不存在");
            }
            if (!Directory.Exists(descDict))
            {
                throw new Exception("目标文件夹不存在");
            }
            DirectoryInfo dir = new DirectoryInfo(sourcDict);//文件夹信息
            FileInfo[] fileinfo = dir.GetFiles(); //取得所有文件
            foreach (FileInfo file in fileinfo)
            {
                //如果文件在所选文件内则下载对应文件
                if (fileType.Contains(file.Name.Substring(0, 3).ToUpper()))
                {
                    //下载文件
                    FileStream fsw = new FileStream(Path.Combine(descDict, file.Name), FileMode.OpenOrCreate, FileAccess.Write);//创建写文件流

                    using (FileStream fsr = new FileStream(file.FullName, FileMode.OpenOrCreate, FileAccess.Read))//创建读文件流
                    {
                        byte[] vs = new byte[1024];
                        while (true)
                        {
                            int r = fsr.Read(vs, 0, vs.Length);
                            if (r == 0) //当读取不到，跳出循环
                            {
                                break;
                            }
                            fsw.Write(vs, 0, vs.Length);
                        }
                    }
                    fsw.Dispose();
                    //将对应数据保存到数据库
                    var entityOld = DBContext.GetContextOrcel()
                            .Queryable<MESFileEntity>()
                                            .First(d => d.fileName == file.Name);
                    var entityOld1 = DBContext.GetContextOrcel()
                            .Queryable<MESFileEntity>().ToList();
                    if (entityOld == null)
                    {
                        entityList.Add(new MESFileEntity()
                        {
                            ttFileId = file.Name.Length,
                            fileType = (int)Enum.Parse(typeof(FileTypeEnum), file.Name.Substring(0, 3).ToUpper()),
                            fileName = file.Name,
                            versionNo = file.Name.Split("_").Count() == 2 ? file.Name.Split("_")[2] : "0.0.1",
                            fileUrl = file.FullName,
                            comments = "",
                            createUser = "001",
                            updateUser = "001",
                            createDate = DateTime.Now,
                            updateDate = DateTime.Now
                        });;
                    }
                }
            }
            if (entityList?.Count > 0)
            {
                DBContext.GetContextOrcel()
                .Insertable(entityList).ExecuteCommand();
            }

        }

        /// <summary>
        /// 下载文件到指定目录
        /// </summary>
        /// <param name="sourcDict">源文件夹</param>
        /// <param name="descDict">目标文件夹</param>
        /// <param name="fileType">文件类型</param>
        public async void DownLoadsAsync(string sourcDict, string descDict, string[] fileType)
        {
            List<MESFileEntity> entityList = new();
            if (!File.Exists(sourcDict))
            {
                throw new Exception("源文件夹不存在");
            }
            if (!File.Exists(descDict))
            {
                throw new Exception("目标文件夹不存在");
            }
            DirectoryInfo dir = new DirectoryInfo(sourcDict);//文件夹信息
            FileInfo[] fileinfo = dir.GetFiles(); //取得所有文件
            foreach (FileInfo file in fileinfo)
            {
                //如果文件在所选文件内则下载对应文件
                if (fileType.Contains(file.Name.Substring(0, 3).ToUpper()))
                {
                    //下载文件
                    FileStream fsw = new FileStream(Path.Combine(descDict, file.Name), FileMode.OpenOrCreate, FileAccess.Write);//创建写文件流

                    using (FileStream fsr = new FileStream(file.FullName, FileMode.OpenOrCreate, FileAccess.Read))//创建读文件流
                    {
                        byte[] vs = new byte[1024];
                        while (true)
                        {
                            int r = fsr.ReadAsync(vs, 0, vs.Length).Result;
                            if (r == 0) //当读取不到，跳出循环
                            {
                                break;
                            }
                            await fsw.WriteAsync(vs, 0, vs.Length);
                        }
                    }
                    fsw.Dispose();
                    //将对应数据保存到数据库
                    var entityOld = DBContext.GetContext()
                            .Queryable<MESFileEntity>()
                                            .First(d => d.fileName == file.Name);
                    if (entityOld == null)
                    {
                        entityList.Add(new MESFileEntity()
                        {
                            fileType = (int)Enum.Parse(typeof(FileTypeEnum), file.Name.Substring(0, 3).ToUpper()),
                            fileName = file.Name,
                            versionNo = file.Name.Split("_").Count()==2? file.Name.Split("_")[2]:"0.0.1",
                            fileUrl = file.FullName,
                            comments = "",
                            createUser = "001",
                            updateUser = "001",
                            createDate = DateTime.Now,
                            updateDate = DateTime.Now
                        });
                    }
                }
            }
            if (entityList?.Count > 0)
            {
                DBContext.GetContext()
                .Insertable(entityList).ExecuteCommand();
            }
        }
        #endregion

        #region Size Converter
        public string SizeConverter(long bytes)
        {
            var fileSize = new decimal(bytes);
            var kilobyte = new decimal(1024);
            var megabyte = new decimal(1024 * 1024);
            var gigabyte = new decimal(1024 * 1024 * 1024);

            switch (fileSize)
            {
                case var _ when fileSize < kilobyte:
                    return $"Less then 1KB";
                case var _ when fileSize < megabyte:
                    return $"{Math.Round(fileSize / kilobyte, 0, MidpointRounding.AwayFromZero):##,###.##}KB";
                case var _ when fileSize < gigabyte:
                    return $"{Math.Round(fileSize / megabyte, 2, MidpointRounding.AwayFromZero):##,###.##}MB";
                case var _ when fileSize >= gigabyte:
                    return $"{Math.Round(fileSize / gigabyte, 2, MidpointRounding.AwayFromZero):##,###.##}GB";
                default:
                    return "n/a";
            }
        }

        public void addFile(FileUploadInDto InDto)
        {
            using (FileStream fsw = new FileStream("D:\\MES_Update_ZipFile", FileMode.OpenOrCreate, FileAccess.Write)) 
            {
                fsw.Write(InDto.fileData, 0, InDto.fileSize);
            }
        }
        #endregion




    }
}
