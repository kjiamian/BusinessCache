using System;
using System.Collections.Generic;
using BusinessCache.Entities;

namespace BusinessCache.Data
{
    //默认使用静态数据
    public static class DefaultData
    {
        public static List<UserInfo> UserInfos = new List<UserInfo>()
        {
            new UserInfo(){Id =  1},
            new UserInfo(){Id =  2},
            new UserInfo(){Id =  3},
        };

        public static List<Weibo> Weibos = new List<Weibo>()
        {
            new Weibo(){Id = 11,LikeCount = 10},
            new Weibo(){Id = 12},
            new Weibo(){Id = 13},
        };

        public static List<UserLikeRecord> UserLikeRecords = new List<UserLikeRecord>()
        {
            new UserLikeRecord(){Id =  1,UserId = 1,WeiboId = 11, LikeCount = 10, CreateTime = new DateTime(2018,07,24), UpdateTime = new DateTime(2018,07,24)}
        };
    }
}
