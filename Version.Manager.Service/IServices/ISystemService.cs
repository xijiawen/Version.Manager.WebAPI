using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Version.Manager.Model.Models.InDto;
using Version.Manager.Model.Models.OutDto;
using Version.Manager.Model.Models;

namespace Version.Manager.Service.IServices
{
    public interface ISystemService
    {
        /// <summary>
        /// 根据Id查询对应的系统信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public SystemOutDto QueryById(string Id);
        public SystemOutDto QueryByName(string name);

        /// <summary>
        /// 新增和更新
        /// </summary>
        /// <param name="InDto"></param>
        public void SaveEntity(SystemInDto InDto);

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
        /// 查所有系统的信息
        /// </summary>
        /// <returns></returns>
        public List<SystemOutDto> QueryList(SystemInDto InDto);
    }
}
