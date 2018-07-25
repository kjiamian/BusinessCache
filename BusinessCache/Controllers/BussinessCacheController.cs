using BusinessCache.Core;
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
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Put([FromBody] UpdateModel model)
        {
            new CacheManager();
            return true;
        }

    }
}