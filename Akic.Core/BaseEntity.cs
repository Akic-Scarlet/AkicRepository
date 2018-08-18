using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Core
{
    public class BaseEntity
    {
        public string Id { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? AddedDate { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// IP地址
        /// </summary>
        
    }
}
