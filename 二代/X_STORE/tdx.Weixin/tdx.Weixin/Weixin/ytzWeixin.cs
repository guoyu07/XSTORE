using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Creatrue.kernel;

namespace tdx.Weixin
{
    class ytzWeixin
    {
        public static string GetErWeiCode(string _key,string _wwx,string _wwv)
        {
            string result = "";
            //_key = _key.Substring(8, _key.Length - 8);
            guotaotao mi = new guotaotao();

            switch (_key)
            {
                case "20149":
                    //取内容
                    result = GetCaimiStr("猜谜", _wwx, _wwv);
                    break;
                case "20145":
                    result = GetCaimiP(_wwx, _wwv);
                    break;
                default:
                    result = "<MsgType><![CDATA[text]]></MsgType><Content><![CDATA[" + _key + "]]></Content>";
                    break;
            }

            return result;
        }
        public static string GetCaimiP(string _wwx, string _wwv)
        {
            string _sql = "select * from wx_acm_gain where wwv='" + _wwv + "'";
            _sql += ";select * from wx_acm_gain where ga_wwv='" + _wwv + "'";

            string result = "";
            DataSet ds = comfun.GetDataSetBySQL(_sql);
            if (ds.Tables[0].Rows.Count > 0)
            { 
                if (ds.Tables[1].Rows.Count == 0)
                {//可以取票
                    result = "<MsgType><![CDATA[text]]></MsgType><Content><![CDATA[亲爱的网友,感谢您参加我们的猜谜活动,您获得了2014鼋头渚中秋赏月音乐烟花大会门票一张。请将此消息给售票工作人员查看，以便于Ta为您打印门票。欢迎您继续关注我们的微信活动。祝您中秋节快乐！今晚在鼋头渚玩的开心。" + "]]></Content>";
                    try
                    {
                        _sql = "update wx_acm_gain set ga_wwv='" + _wwv + "',ga_gdate=getDate() where wwv='" + _wwv + "'";
                        comfun.UpdateBySQL(_sql);
                    }
                    catch (Exception ex) { }
                }
                else
                {//已经取过票
                    result = "<MsgType><![CDATA[text]]></MsgType><Content><![CDATA[抱歉！您已经于" + ds.Tables[0].Rows[0]["ga_gdate"].ToString() + "取过票了，不能重复取票。]]></Content>";       
                }
            }
            else
            {//你没有获奖
                result = "<MsgType><![CDATA[text]]></MsgType><Content><![CDATA[抱歉您没有中奖。请参加我们今晚的游园活动，有机会获得魅力新江南2014休闲游园年卡一张。]]></Content>";
            }
             
            return result;
        }
        public static string GetCaimiStr(string _key,string _wwx,string _wwv)
        {
            string result = "";
           
                string _url = "http://www.tdx.cn/caimi/index2.aspx?id=3";  
                if(_url.IndexOf("wwx")==-1 && _url.IndexOf("WWX")==-1){
                   _url +=  _url.IndexOf("?")!=-1 ? "&":"?";
                    _url +="wwx=" + _wwx;
                }
                if(_url.IndexOf("wwv")==-1 && _url.IndexOf("WWv")==-1){
                   _url +=  _url.IndexOf("?")!=-1 ? "&":"?";
                    _url +="wwv=" + _wwv;
                }
                result = "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>1</ArticleCount><Articles>";
                result += ytzWeixin.GetSingleNews("2014 鼋头渚中秋微信猜谜活动", "http://www.tdx.cn/upload/201409/01/2014911712160_all.jpg", "中秋佳节，鼋头渚怎少得了安排“猜谜”这个传统有趣的活动！三重猜谜猜不停，大奖小奖等你来赢哦！跟我一起来猜谜，Let‘ Go！", _url);
                result += "</Articles>";
           

            return result;
        }
        public static string GetSingleNews(string _title, string _pic, string _des, string _url)
        {
            string resxml = "";
            string _xml = "<item><Title><![CDATA[{0}]]></Title><Description><![CDATA[{1}]]></Description><PicUrl><![CDATA[{2}]]></PicUrl><Url><![CDATA[{3}]]></Url></item>"; ;
            resxml = string.Format(_xml, _title, _des, _pic, _url);

            return resxml;
        }
    }
}
