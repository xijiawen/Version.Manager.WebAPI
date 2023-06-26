using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version.Manager.Model
{
    /// <summary>
    /// 动态查询的条件
    /// </summary>
    public class MyCondition
    {
        public string ConditionName { get; set; }
        public object ConditionValue { get; set; }
    }
}
