﻿using System.Collections.Generic;

namespace BusinessCache.Models
{
    /// <summary>
    /// 更新模板
    /// </summary>
    public class UpdateModel
    {
        public string EntityName { get; set; }
        public Dictionary<string, string> Param { get; set; }
    }
}
