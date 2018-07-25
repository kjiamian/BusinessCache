using BusinessCache.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessCache.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BussinessCacheController : ControllerBase
    {
        /// <summary>
        /// 更新缓存
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Put(int id, [FromBody] UpdateModel model)
        {
            return true;
        }

    }
}