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
    public class VersionManagerController : ControllerBase
    {
        public readonly IVersionManagerService iVersionManagerService;
        public VersionManagerController(IVersionManagerService iVersionManagerService)
        {
            this.iVersionManagerService = iVersionManagerService;
        }

        /// <summary>
        /// 保存版本信息
        /// </summary>
        /// <param name="InDto"></param>
        [HttpPost]
        public APIReturnResult<object> SaveVersion(VersionManagerUpdateInDto InDto) 
        {
            APIReturnResult<object> result = new APIReturnResult<string>();
            iVersionManagerService.SaveEntity(InDto);
            return result;
        }

        /// <summary>
        /// 删除对应的版本信息
        /// </summary>
        /// <param name="Id"></param>
        [HttpPost]
        public APIReturnResult<object> DeleteVersion([FromBody]string Id)
        {
            APIReturnResult<object> result = new APIReturnResult<string>();
            iVersionManagerService.DeleteById(Id);
            return result;
        }

        /// <summary>
        /// 删除对应的版本信息
        /// </summary>
        /// <param name="Id"></param>
        [HttpGet]
        public APIReturnResult<VersionManagerOutDto> QueryVersionBySystemId(string SystemId) 
        {
            return iVersionManagerService.QueryVersionBySystemId(SystemId);
        }

    }
}
