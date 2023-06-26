using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using Version.Manager.Model;
using Version.Manager.Model.Models;
using Version.Manager.Model.Models.InDto;
using Version.Manager.Model.Models.OutDto;
using Version.Manager.Service.IServices;
using Version.Manager.Service.Services;

namespace Version.Manager.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        public HomeController()
        {
        }
        [HttpGet]
        public  void Index()
        {
            DBCreate.createDB();
        }
    }
}
