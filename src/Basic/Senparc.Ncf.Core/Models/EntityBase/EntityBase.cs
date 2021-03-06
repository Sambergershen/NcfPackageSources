﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Senparc.Ncf.Core.Models
{
    /// <summary>
    /// 数据库实体基类
    /// </summary>
    [Serializable]
    public partial class EntityBase : IEntityBase
    {
        /// <summary>
        /// 是否软删除
        /// </summary>
        public bool Flag { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 上次更新时间
        /// </summary>
        public DateTime LastUpdateTime { get; set; }
    }

    /// <summary>
    /// 带单一主键的数据库实体基类
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    [Serializable]
    public partial class EntityBase<TKey> : EntityBase, IEntityBase<TKey>
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public TKey Id { get; set; }

        /// <summary>
        /// 更新最后更新时间
        /// </summary>
        /// <param name="time"></param>
        protected void SetUpdateTime(DateTime? time = null)
        {
            if (AddTime == DateTime.MinValue)
            {
                AddTime = SystemTime.Now.LocalDateTime;//通常在添加的时候发生
            }
            LastUpdateTime = time ?? SystemTime.Now.LocalDateTime;
        }

        /// <summary>
        /// 仅管理员备注
        /// </summary>
        [MaxLength(300)]
        public string AdminRemark { get; set; }

        /// <summary>
        /// 前台用户可见备注
        /// </summary>
        [MaxLength(300)]
        public string Remark { get; set; }
    }
}
