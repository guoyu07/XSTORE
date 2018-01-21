using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using Creatrue.kernel;

namespace tdx.memb.man.formcontrols
{
    public partial class baoshijiemail : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //  string _sql = "select top(3) * from B2C_mailaddress where order by id asc";
                DataTable dt = B2C_mailaddress.GetList(" top(3) * ", " 1=1 order by id asc");
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            huodong1.Value = dt.Rows[i]["mailaddress"].ToString();
                            continue;
                        }
                        if (i == 1)
                        {
                            fuwu1.Value = dt.Rows[i]["mailaddress"].ToString();
                            continue;
                        }
                        if (i == 2)
                        {
                            shiji.Value = dt.Rows[i]["mailaddress"].ToString();
                            continue;
                        }
                    }
                }
            }
        }
        protected void save(object sender, EventArgs e)
        {

            string huodong_t = "update b2c_mailaddress set mailaddress = '" + huodong1.Value + "'  where id=1 ;";
            string fuwu_t = "update b2c_mailaddress set mailaddress = '" + fuwu1.Value + "'  where id=2 ;";
            string shijia_t = "update b2c_mailaddress set mailaddress = '" + shiji.Value + "'  where id=3 ";
            int yingxiang = comfun.UpdateBySQL(huodong_t + fuwu_t + shijia_t);
            if (yingxiang > 0)
            {
                Response.Write("<script language='javascript'>alert('修改成功!');</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>alert('修改失败!');</script>");
            }

        }
        string neirong = @"您好测试！
                            <br/>
                          通过微信“上海闵行保时捷中心服务号”收到以下需求
                           <br/>
                          车型名称  Boxster
                            <br/>
                          服务地点  上海闵行保时捷中心(中春路7358号)
                            <br/>
                          服务日期  2014-2-28 0:00:00
                            <br/>
                          服务项目  普通保养
                            <br/>
                          服务顾问  倪帅军
                            <br/>
                          客户姓名  shenkai
                            <br/>
                          手机号码  13916296172
                            <br/>
                          车牌号码  沪a35k11
                            <br/>
                          申请时间  2014-2-18 21:07:27
                            <br/>
                          ";
        protected void huodongsave(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(huodong1.Value))
            {
                string mails = huodong1.Value;
                string[] ms = mails.Split(new char[] { ';' });
                for (int i = 0; i < ms.Length; i++)
                {
                    if (!string.IsNullOrEmpty(ms[i]))
                    {
                        comSendMail.bsjsendMail(ms[i], "来自微信的活动预约", neirong);
                    }
                }
            }


        }
        protected void fuwusave(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(fuwu1.Value))
            {
                string mails = fuwu1.Value;
                string[] ms = mails.Split(new char[] { ';' });
                for (int i = 0; i < ms.Length; i++)
                {
                    if (!string.IsNullOrEmpty(ms[i]))
                    {
                        comSendMail.bsjsendMail(ms[i], "来自微信的服务预约", neirong);
                    }
                }
            }
        }
        protected void shijiasave(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(shiji.Value))
            {
                string mails = shiji.Value;
                string[] ms = mails.Split(new char[] { ';' });
                for (int i = 0; i < ms.Length; i++)
                {
                    if (!string.IsNullOrEmpty(ms[i]))
                    {
                        comSendMail.bsjsendMail(ms[i], "来自微信的试驾预约", neirong);
                    }
                }
            }

        }
    }
}