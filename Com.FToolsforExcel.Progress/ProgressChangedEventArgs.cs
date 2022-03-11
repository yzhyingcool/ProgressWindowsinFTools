using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.FToolsforExcel.Progress
{
    public struct ProgressChangedEventArgs
    {
        /// <summary>
        /// 文字描述的进度消息
        /// </summary>
        public string Message { get; set; }
    }
}
