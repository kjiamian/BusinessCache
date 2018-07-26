using System.Linq;
using BusinessCache.Core;
using BusinessCache.Models;
using BusinessCache.TestData.Data;
using Microsoft.AspNetCore.Mvc;

namespace BusinessCache.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BussinessCacheController : ControllerBase
    {
        private readonly CacheManager _cacheManager;
        public BussinessCacheController(CacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }

        /// <summary>
        /// 更新缓存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public bool Put([FromBody] UpdateModel model)
        {
            DefaultData.Weibos.FirstOrDefault(p => p.Id == 11).LikeCount += 1;
            DefaultData.UserLikeRecords.FirstOrDefault(p => p.UserId == 1 && p.WeiboId == 11).LikeCount += 1;
            _cacheManager.Notify(model.EntityName, model.Param);
            return true;
        }

    }
}