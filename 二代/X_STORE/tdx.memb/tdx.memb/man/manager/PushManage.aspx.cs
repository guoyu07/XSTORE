using Creatrue.kernel;
using DTcms.DBUtility;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database.Common_Pay.WeiXinPay;
using tdx.Weixin;
using DTcms.Common;
using Creatrue.Common.Msgbox;

namespace tdx.memb.man.manager
{
    public partial class PushManage : System.Web.UI.Page
    {
        /// <summary>
        /// 推送类型
        /// 1 补货推送
        /// 2 发货
        /// 3 群发
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bind();
            }
        }
        protected void bind() {
            string sql = @"select 推送时间,推送类型 from 消息推送表 group by 推送时间,推送类型";
            DataTable dt = new comfun().GetDataTable(sql);
            dt.Columns.Add("消息内容",typeof(string));
            if(dt.Rows.Count>0){
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sel_sql = @"select 消息内容,推送类型 from 消息推送表 where 推送时间='"+dt.Rows[i]["推送时间"]+"' and 推送类型="+dt.Rows[i]["推送类型"];
                }
            }
            rp_push.DataSource = dt;
            rp_push.DataBind();

        }
        //补货推送
        protected void LBtn_replenishment_Click(object sender, EventArgs e)
        {

            tuisong();
            MessageBox.Show(this,"消息推送成功!");
        }

        //补货推送
        protected void tuisong() {

            weixin wx = new weixin();
            //获取AccessToken
            string AccessToken = wx.GetAccessToken();
            msgData msg = new msgData();
            alertData alert = new alertData();
            msgfirst msg_first = new msgfirst();
            DataTable dt = kcbz();
            string  dtt =DateTime.Now.ToString();
            msgkeyword1 msg_keyword1 = new msgkeyword1();
            msgkeyword2 msg_keyword2 = new msgkeyword2();
            msgkeyword3 msg_keyword3 = new msgkeyword3();
            msgkeyword4 msg_keyword4 = new msgkeyword4();
            msgkeyword5 msg_keyword5 = new msgkeyword5();
            msgremark msg_remark = new msgremark();
            for (int i = 0; i < dt.Rows.Count; i++)
			{
                DataTable dtc = new comfun().GetDataTable(@"
  select openid,用户名 from WP_用户权限 a left join WP_用户表 b  on a.用户id=b.id left join WP_用户角色 c on b.角色id=c.id 
  where b.IsShow=1 and 角色id in (1,2,3) and openid is not null and openid!='' and a.仓库id=" + dt.Rows[i]["仓库id"]);
                for (int j = 0; j < dtc.Rows.Count; j++)
                {
                    msg_first.value = "补货提醒";
                    msg_first.color = "";
                    msg_keyword1.value = dt.Rows[i]["仓库名"].ObjToStr();
                    msg_keyword1.color = "";
                    msg_keyword2.value = dt.Rows[i]["房间数量"].ObjToStr();
                    msg_keyword2.color = "";
                    msg_keyword3.value = dt.Rows[i]["商品数量"].ObjToStr();
                    msg_keyword3.color = "";
                    msg_keyword4.value = "";
                    msg_keyword4.color = "";
                    msg_keyword5.value = dtt;
                    msg_keyword5.color = "";
                    msg_remark.value = "";
                    msg_remark.color = "";

                    alert.first = msg_first;
                    alert.keyword1 = msg_keyword1;
                    alert.keyword2 = msg_keyword2;
                    alert.keyword3 = msg_keyword3;
                    alert.keyword4 = msg_keyword4;
                    alert.keyword5 = msg_keyword5;
                    alert.remark = msg_remark;
                    msg.touser = Utils.ObjectToStr(dtc.Rows[j]["openid"].ObjToStr());
                    msg.template_id = "_Nd6o6vv9w1DCdxlJwDqqsteRZ0tLEdB1lY49WlvZVo";
                    if (!string.IsNullOrEmpty(msg.touser))
                    {
                        //给用户
                        //Log.WriteLog("补货提醒", "推送给酒店管理", "");
                        msg.url = "";
                        msg.data = alert;
                        string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}", AccessToken);
                        string postData = JsonSerialize(msg);
                        func.webRequestPost(url, postData);
                    }
                }
              
            }
        }



        #region  实体类
        private struct msgData
        {
            public string touser;

            public string template_id;

            public string url;

            public Object data;
        }

        public struct alertData
        {
            public object first;
            public object keyword1;
            public object keyword2;
            public object keyword3;
            public object keyword4;
            public object keyword5;
            public object remark;
        }

        private struct msgfirst
        {
            public string value;
            public string color;
        }
        private struct msgkeyword1
        {
            public string value;
            public string color;
        }
        private struct msgkeyword2
        {
            public string value;
            public string color;
        }
        private struct msgkeyword3
        {
            public string value;
            public string color;
        }
        private struct msgkeyword4
        {
            public string value;
            public string color;
        }
        private struct msgkeyword5
        {
            public string value;
            public string color;
        }
        private struct msgremark
        {
            public string value;
            public string color;
        }


        struct errReg
        {
            public int state;
            public string info;
            public string guid;
        }
        #endregion

        public static string JsonSerialize(object obj)
        {
            System.Text.StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            IsoDateTimeConverter idtc = new IsoDateTimeConverter();
            idtc.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(idtc);
            JsonWriter jw = new JsonTextWriter(sw);
            jw.Formatting = Formatting.Indented;
            serializer.Serialize(jw, obj);
            return sb.ToString();
        }

        protected DataTable kcbz(){
            string sql = @"  select 仓库id from WP_箱子表 a left join WP_库位表 b on a.库位id =b.id left join WP_仓库表 c on b.仓库id=c.id 
  where c.IsShow=1 and b.IsShow=1 and a.IsShow=1 and b.箱子MAC is not null group by 仓库id ";
            DataTable dt = new comfun().GetDataTable(sql);
            dt.Columns.Add("房间数量",typeof(string));
            dt.Columns.Add("商品数量",typeof(string));
            dt.Columns.Add("仓库名", typeof(string));
            if(dt.Rows.Count>0){
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataTable dtb=new comfun().GetDataTable(@"select 仓库id,仓库名 from WP_箱子表 a left join WP_库位表 b on a.库位id =b.id left join WP_仓库表 c on b.仓库id =c.id where  b.仓库id="+dt.Rows[i]["仓库id"]);
                    if(dtb.Rows.Count>0){
                        DataTable dtc = new comfun().GetDataTable(@"  select count(库位id) as 房间数量 
  from WP_箱子表 a left join WP_库位表 b on a.库位id=b.id 
  where 默认商品id!=0 and 箱子MAC is not null and 实际商品id=0 and 位置<12 group by 库位id");
                        DataTable dtd = new comfun().GetDataTable(@"  select count(库位id) as 商品数量 
  from WP_箱子表 a left join WP_库位表 b on a.库位id=b.id 
  where 默认商品id!=0 and 箱子MAC is not null and 实际商品id=0 and 位置<12 ");
                        if(dtc.Rows.Count>0&&dtd.Rows.Count>0){
                            dt.Rows[i]["房间数量"] = dtc.Rows.Count;
                            dt.Rows[i]["商品数量"] = dtd.Rows[0]["商品数量"];
                            dt.Rows[i]["仓库名"] = dtb.Rows[0]["仓库名"];
                        }
                    }
                }
            }

            return dt;

        }


    }
}