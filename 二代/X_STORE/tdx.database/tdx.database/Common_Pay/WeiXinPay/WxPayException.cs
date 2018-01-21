using System;
using System.Collections.Generic;
using System.Text;

namespace tdx.database.Common_Pay.WeiXinPay
{
    public class WxPayException : Exception
    {
        public WxPayException(string msg)
            : base(msg)
        {

        }
    }
}
