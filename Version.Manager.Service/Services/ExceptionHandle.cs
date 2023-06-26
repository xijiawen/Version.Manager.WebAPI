
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Version.Manager.Model;

namespace Version.Manager.Service.Services
{
    public class ExceptionHandle : IAsyncExceptionFilter
    {
        /// <summary>
        /// 当action中发生未处理的异常就会调用
        /// </summary>
        /// <param name="context">异常上下文对象</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task OnExceptionAsync(ExceptionContext context)
        {
            string message = context.Exception.Message;
            ObjectResult result = new ObjectResult(new APIReturnResult<object> { Code = 1, Message = message });
            context.Result = result;//context.Result的值会返回给客户端
            context.ExceptionHandled = true;//赋值为true其他的ExceptionFilter则不会再被调用
            return Task.CompletedTask;
        }
    }
}
