using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version.Manager.Model.Models.Enum
{
    public enum FileTypeEnum
    {
        /// <summary>
        /// 产品软硬件
        /// </summary>
        MPS = 1,
        MPH = 2,

        /// <summary>
        /// FPGA软硬件
        /// </summary>
        MFS = 3,
        MFH = 4,

        /// <summary>
        /// STM32软硬件
        /// </summary>
        MSS = 5,
        MSH = 6,

        /// <summary>
        /// 上位机软件
        /// </summary>
        MPC = 7,

        /// <summary>
        /// 测试配置文件
        /// </summary>
        MTC =8
    }
}
