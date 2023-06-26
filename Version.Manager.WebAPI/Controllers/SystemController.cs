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
    public class SystemController : ControllerBase
    {
        private readonly ISystemService iSystemService;
        public SystemController(ISystemService iSystemService)
        {
            this.iSystemService = iSystemService;
        }

        /// <summary>
        /// 更新或者保存系统信息
        /// </summary>
        /// <param name="InDto"></param>
        [HttpPost]
        public APIReturnResult<object> SaveSystem(SystemInDto InDto)
        {
            iSystemService.SaveEntity(InDto); 
            return new object();
        }

        /// <summary>
        /// 根据Id删除指定的系统信息
        /// </summary>
        /// <param name="Id"></param>
        [HttpPost]
        public APIReturnResult<object> DeleteSystem([FromBody] string Id)
        {
            iSystemService.DeleteById(Id); 
            return new object();
        }

        /// <summary>
        /// 根据Id查询单条信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public APIReturnResult<SystemOutDto> QuerySingalById(string Id)
        {
            return iSystemService.QueryById(Id);
        }

        /// <summary>
        /// 根据Id查询单条信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public APIReturnResult<SystemOutDto> QuerySingalByName(string name)
        {
            return iSystemService.QueryByName(name);
        }

        /// <summary>
        /// 根据条件查询对应的系统信息
        /// </summary>
        /// <param name="InDto"></param>
        /// <returns></returns>
        [HttpGet]
        public APIReturnResult<List<SystemOutDto>> QueryList(SystemInDto InDto)
        {
            return iSystemService.QueryList(InDto);
        }
    }
}
