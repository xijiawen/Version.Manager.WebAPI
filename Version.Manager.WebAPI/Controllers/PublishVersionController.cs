using Microsoft.AspNetCore.Mvc;
using Version.Manager.Model;
using Version.Manager.Model.Models.InDto;
using Version.Manager.Model.Models.OutDto;
using Version.Manager.Service.IServices;
using Version.Manager.Service.Services;

namespace Version.Manager.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PublishVersionController : ControllerBase
    {
        public readonly IPublishVersionService iPublishVersionService;
        public PublishVersionController(IPublishVersionService iPublishVersionService)
        {
            this.iPublishVersionService = iPublishVersionService;
        }

        /// <summary>
        /// 发布新版本
        /// </summary>
        /// <param name="InDto"></param>
        [HttpPost]
        public APIReturnResult<object> PublishVersion(PublishVersionInDto InDto)
        {
            iPublishVersionService.PublishVersion(InDto);
            return new object();
        }

        /// <summary>
        /// 查询所有已发布的版本信息
        /// </summary>
        /// <param name="InDto"></param>
        [HttpGet]
        public APIReturnResult<List<PublishVersionOutDto>> QueryPublishVersionList([FromQuery]QueryPublishVersionInDto InDto)
        {
            return iPublishVersionService.QueryPublishVersionList(InDto);
        }

        /// <summary>
        /// 查询所有已发布的版本信息
        /// </summary>
        /// <param name="InDto"></param>
        [HttpGet]
        public APIReturnResult<PublishVersionOutDto> GetVersionAndFileBySystemId(string SystemId)
        {
            return iPublishVersionService.GetVersionAndFileBySystemId(SystemId);
        }

        /// <summary>
        /// 更新最新版本为其他版本
        /// </summary>
        [HttpPost]
        public APIReturnResult<object> UpdateVersionIsNew([FromBody]string Id)
        {
            iPublishVersionService.UpdateVersionIsNew(Id);
            return new object();
        }

    }
}
