using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    /// <summary>
    /// 模块：App Exception
    /// 说明：自定义异常避免捕获非此应用的异常
    /// 创建人：phq
    /// </summary>
    [Serializable]
    public  class HotelException : System.ApplicationException
    {
         public HotelException()
            : base()
        {

        }

        public HotelException(string Message)
            : base(Message)
        {

        }

        public HotelException(string Message, Exception innerException)
            :base(Message,innerException)
        {

        }
    }
}
