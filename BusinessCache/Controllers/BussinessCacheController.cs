using System;
using System.Linq;
using BusinessCache.Common;
using BusinessCache.Core;
using BusinessCache.Models;
using BusinessCache.TestData.CacheData;
using BusinessCache.TestData.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public string Put([FromBody] UpdateModel model)
        {
            model.EntityName = KeyMap.SubjectNameWeibo;
            model.Param.Add("UserId", "1");
            model.Param.Add("WeiboId", "11");
            DefaultData.Weibos.FirstOrDefault(p => p.Id == 11).LikeCount += 1;
            DefaultData.UserLikeRecords.FirstOrDefault(p => p.UserId == 1 && p.WeiboId == 11).LikeCount += 1;
            _cacheManager.Notify(model.EntityName, model.Param);


            var weiboCacheStr = JsonConvert.SerializeObject(DefaultCacheData.WeiboCaches, Formatting.Indented);
            var userCacheStr = JsonConvert.SerializeObject(DefaultCacheData.UserCaches, Formatting.Indented);
            return weiboCacheStr + Environment.NewLine + userCacheStr;
        }

    }
}