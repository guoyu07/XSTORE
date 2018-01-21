using Creatrue.Common.Msgbox;
using Creatrue.kernel;
using DTcms.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database.Common_Pay.WeiXinPay;
using tdx.Weixin;
using Telerik.Web.UI;

namespace tdx.memb.man.jiesuan
{
    public partial class Collocate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                bind();
                ComboxDataBound();
            }
        }

        protected void bind() {
            int id = int.Parse(string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"]);//id
            int zt = int.Parse(string.IsNullOrEmpty(Request["zt"]) ? "-1" : Request["zt"]);//状态
            if(zt==2){
                string sql = @"select a.id,操作员,时间,仓库id,仓库名,a.酒店id,酒店全称 from WP_配货信息表 a left join WP_仓库表 b on a.仓库id=b.id left join WP_酒店表 c on a.酒店id=c.id where a.id="+id;
                DataTable dt = new comfun().GetDataTable(sql);
                if(dt.Rows.Count>0){
                    tb_czy.Text = dt.Rows[0]["操作员"].ObjToStr();
                    tb_time.Text = dt.Rows[0]["时间"].ObjToStr();
                    ddl_hotelGroup.DataSource = dt;
                    ddl_hotelGroup.DataValueField = "酒店id";
                    ddl_hotelGroup.DataTextField = "酒店全称";
                    ddl_hotelGroup.DataBind();
                    ddl_hotel.DataSource = dt;
                    ddl_hotel.DataValueField = "仓库id";
                    ddl_hotel.DataTextField = "仓库名";
                    ddl_hotel.DataBind();
                }

           }
        }
        protected string Getzt2(string str)
        {
            int zt = int.Parse(string.IsNullOrEmpty(Request["zt"]) ? "-1" : Request["zt"]);//状态
            string ztz = "true";
            if (zt == 2)
            {//申请配货
                ztz = "none";
            }
            return ztz;
        }
        //点击保存
        protected void Button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"]);//id
            string goods_id=group_name.SelectedValue.ObjToStr();//商品id
            string number = tb_number.Text.ObjToStr();//数量
            string wlgs = rcb_wl.SelectedValue.ObjToStr();//物流公司id
            string wldh = wuliu_number.Text;//物流单号
            if(goods_id==""){
                MessageBox.Show(this,"请选择商品!");
                return;
            }
            if(number==""){
                MessageBox.Show(this, "请填写数量!");
                return;
            }
            else
            {
                if (!shuzi(number))
                {
                    MessageBox.Show(this,"数量请填写正整数!");
                    return;
                }
            }
            if(wlgs==""){
                MessageBox.Show(this, "请选择物流公司!");
                return;
            }
            if (wldh=="")
            {
                MessageBox.Show(this, "请填写物流单号!");
                return;
            }
            string sql = @"update WP_配货信息表 set 商品id="+goods_id+",数量="+number+",物流公司='"+wlgs+"',物流单号='"+wldh+"',状态=3 where id="+id;
            int flag=new comfun().Update(sql);
            if (flag != 0)
            {
                tuisong();
                MessageBox.ShowAndRedirect(this, "操作成功!","peihuoxinxi.aspx");
                return;
            }
            else
            {
                MessageBox.Show(this, "操作失败!");
                return;
            }
        }
        //是否是正整数
        public bool shuzi(string s)
        {
            string pattern = "^[0-9]*$";
            Regex rx = new Regex(pattern);
            return rx.IsMatch(s);
        }

        protected void ComboxDataBound()
        {
            int id = int.Parse(string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"]);//id
            int zt = int.Parse(string.IsNullOrEmpty(Request["zt"]) ? "-1" : Request["zt"]);//状态
            int ckid = int.Parse(string.IsNullOrEmpty(Request["ckid"]) ? "-1" : Request["ckid"]);//仓库id
            if (zt == 2)
            {
                string sql = @"select e.品名,商品id,数量 from WP_配货信息表 a left join WP_仓库表 b on a.仓库id=b.id left join WP_酒店表 c on a.酒店id=c.id left join 快递表 d on a.物流公司=d.id left join WP_商品表 e on a.商品id=e.id 
                    where a.id=" + id;
                DataTable dt = new comfun().GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    string number = dt.Rows[0]["数量"].ObjToStr();
                    tb_number.Text = number;
                    string goods = @"select 商品id,品名 from WP_酒店商品 a left join WP_商品表 b on a.商品id=b.id where 仓库id=" + ckid;
                    DataTable dtb = new comfun().GetDataTable(goods);
                    group_name.DataSource = dtb;
                    group_name.DataBind();
                    group_name.SelectedValue = dt.Rows[0]["商品id"].ObjToStr();
                }
                string kd_sql = @"select 快递公司,id,code from 快递表";
                DataTable dta = new comfun().GetDataTable(kd_sql);
                rcb_wl.DataSource = dta;
                rcb_wl.DataBind();

            }
        }
        //推送发货消息
        protected void tuisong() {
            weixin wx = new weixin();
            //获取AccessToken
            string AccessToken = wx.GetAccessToken();
            msgData msg = new msgData();
            alertData alert = new alertData();
            msgfirst msg_first = new msgfirst();
            msgkeyword1 msg_keyword1 = new msgkeyword1();
            msgkeyword2 msg_keyword2 = new msgkeyword2();
            msgkeyword3 msg_keyword3 = new msgkeyword3();
            msgkeyword4 msg_keyword4 = new msgkeyword4();
            msgremark msg_remark = new msgremark();
            DataTable dt = jdry();
            if(dt.Rows.Count>0){
                string dtt = DateTime.Now.ToString();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    msg_first.value = "发货提醒";
                    msg_first.color = "";
                    msg_keyword1.value = "";//单号
                    msg_keyword1.color = "";
                    msg_keyword2.value = rcb_wl.SelectedItem.Text.ObjToStr();//公司
                    msg_keyword2.color = "";
                    msg_keyword3.value = wuliu_number.Text.ObjToStr();//单号
                    msg_keyword3.color = "";
                    msg_keyword4.value = dtt;//时间
                    msg_keyword4.color ="";
                    msg_keyword4.value = "";
                    msg_remark.value = "";
                    msg_remark.color = "";

                    alert.first = msg_first;
                    alert.keyword1 = msg_keyword1;
                    alert.keyword2 = msg_keyword2;
                    alert.keyword3 = msg_keyword3;
                    alert.keyword4 = msg_keyword4;
                    alert.remark = msg_remark;
                    msg.touser = Utils.ObjectToStr(dt.Rows[i]["openid"].ObjToStr());
                    msg.template_id = "_Nd6o6vv9w1DCdxlJwDqqsteRZ0tLEdB1lY49WlvZVo";
                    if (!string.IsNullOrEmpty(msg.touser))
                    {
                        //给用户
                        Log.WriteLog("发货提醒", "推送给酒店经理和配送员", "");
                        msg.url = "";
                        msg.data = alert;
                        string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}", AccessToken);
                        string postData = JsonSerialize(msg);
                        func.webRequestPost(url, postData);
                    }
                
                }
            }

        }
        //查找酒店的人员
        protected DataTable jdry()
        {
            int ckid = int.Parse(string.IsNullOrEmpty(Request["ckid"]) ? "-1" : Request["ckid"]);//仓库id
            DataTable dt = new comfun().GetDataTable(@"select openid,用户名 from WP_用户权限 a left join WP_用户表 b  on a.用户id=b.id left join WP_用户角色 c on b.角色id=c.id 
  where b.IsShow=1 and 角色id in (1,3) and openid is not null and openid!='' and a.仓库id=" + ckid);
            return dt;

        }

        #region  推送公共类
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
        #endregion

      
    }
}