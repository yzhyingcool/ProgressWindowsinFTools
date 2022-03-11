using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.FToolsforExcel.Progress 
{
    /// <summary>
    /// 委托，用于进度变化事件，传递进度消息。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ProgressChangedEventHandler(object sender, ProgressChangedEventArgs e);
}
