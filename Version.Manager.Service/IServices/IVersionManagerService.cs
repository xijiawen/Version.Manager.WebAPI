using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Version.Manager.Model;
using Version.Manager.Model.Models;
using Version.Manager.Model.Models.InDto;
using Version.Manager.Model.Models.OutDto;

namespace Version.Manager.Service.IServices
{
    public interface IVersionManagerService
    {
        /// <summary>
        /// 保存对应的版本信息
        /// </summary>
        /// <param name="lists"></param>
        public void SaveVersion(List<FileManagerModel> lists);

        /// <summary>
        /// 根据Id查询对应的版本信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public FileManagerModel QueryById(string Id);

        /// <summary>
        /// 新增和更新
        /// </summary>
        /// <param name="InDto"></param>
        public void SaveEntity(VersionManagerUpdateInDto InDto);

        /// <summary>
        /// 根据Id删除指定数据
        /// </summary>
        /// <param name="Id"></param>
        public void DeleteById(string Id);

        /// <summary>
        /// 删除一组数据
        /// </summary>
        /// <param name="Id"></param>
        public void DeleteByIdList(List<string> Id);

        /// <summary>
        /// 查所有版本信息
        /// </summary>
        /// <returns></returns>
        public List<VersionManagerOutDto> QueryList(VersionManagerInDto InDto);
        VersionManagerOutDto QueryVersionBySystemId(string systemId);
    }
}
