using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Creatrue.kernel;

namespace tdx.Weixin
{
    public class WeixinMember
    {
        public static weixinUser GetWeiXinRequest(string _wwv, string _developID, string _developPsw)
        {

            weixin _weixin = new weixin();
            weixinUser _user = new weixinUser();

            _user = _weixin.GetInfo(_wwv, _developID, _developPsw);
            return _user;


        }
    }
}
