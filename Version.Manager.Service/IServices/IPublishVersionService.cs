using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Version.Manager.Model.Models.InDto;
using Version.Manager.Model.Models.OutDto;

namespace Version.Manager.Service.IServices
{
    public interface IPublishVersionService
    {
        /// <summary>
        /// 发布新版本
        /// </summary>
        /// <param name="InDto"></param>
        void PublishVersion(PublishVersionInDto InDto);

        /// <summary>
        /// 查询所有历史版本信息
        /// </summary>
        List<PublishVersionOutDto> QueryPublishVersionList(QueryPublishVersionInDto InDto);
        PublishVersionOutDto GetVersionAndFileBySystemId(string SystemId);

        /// <summary>
        /// 更新指定版本为最新版本同时将原版本修改为旧版本
        /// </summary>
        /// <param name="id"></param>
        void UpdateVersionIsNew(string id);
    }
}
