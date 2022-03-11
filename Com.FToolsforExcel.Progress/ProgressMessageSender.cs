using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.FToolsforExcel.Progress
{
    public abstract class ProgressMessageSender
    {
        /// <summary>
        /// 传递有数字标识的进度消息。
        /// </summary>
        /// <param name="progressChangedEventHandler">委托类型的方法</param>
        /// <param name="currentIndex">当前处理记录的索引值</param>
        /// <param name="recordCount">总的记录数</param>
        protected virtual void OnProgressChanged(ProgressChangedEventHandler progressChangedEventHandler,int currentIndex,int recordCount)
        {
            ProgressChangedEventArgs eventArgs = new ProgressChangedEventArgs
            {
                Message=$">>>正在处理第{currentIndex} / {recordCount} 条记录。"
            };
            if (progressChangedEventHandler != null)
                progressChangedEventHandler.Invoke(this, eventArgs);
        }
 
        /// <summary>
        /// 传递无数字标识的进度消息，即传递文本消息。
        /// </summary>
        /// <param name="progressChangedEventHandler">委托类型的方法</param>
        /// <param name="message">进度消息</param>
        protected virtual void OnProgressChanged(ProgressChangedEventHandler progressChangedEventHandler,string message)
        {
            ProgressChangedEventArgs eventArgs = new ProgressChangedEventArgs
            {
                Message = message
            };
            if (progressChangedEventHandler != null)
                progressChangedEventHandler.Invoke(this, eventArgs);
        }

        //protected virtual void OnProgressChanged(Action<string> action, int currentIndex, int recordCount)
        //{
        //    if (action != null)
        //        action.Invoke($">>>正在处理第{currentIndex} / {recordCount} 条记录。");
        //}
        //protected virtual void OnProgressChanged(Action<string> action, string message)
        //{
        //    if (action != null)
        //        action.Invoke(message);
        //}
    }
}
