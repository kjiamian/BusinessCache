using BusinessCache.Core;
using BusinessCache.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessCache.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BussinessCacheController : ControllerBase
    {
        private CacheManager _cacheManager = new CacheManager();
        /// <summary>
        /// 更新缓存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Put([FromBody] UpdateModel model)
        {
            _cacheManager.Notify(model.EntityName, model.Param);
            return true;
        }

    }
}