using DTcms.Common;
using DTcms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tdx.memb.man.tuan.YingxiaoManage
{
    public partial class TM_Quan_Card_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string _txt_Num = txt_Num.Text.Trim();
            string _txt_Wei = txt_Wei.Text.Trim();

            if (_txt_Num == "")
            {
                Response.Write("<script language='javascript'>alert('请输入卡券数量！');history.go(-1);</script>");
                Response.End();
                return;
            }
            if (Convert.ToDecimal(_txt_Wei) <= 0)
            {
                Response.Write("<script language='javascript'>alert('请输入卡券位数！');history.go(-1);</script>");
                Response.End();
                return;
            }
            DTcms.BLL.TM_QuanCard  qcard_bll=new DTcms.BLL.TM_QuanCard();
            if (Request["id"] != null)
            {

                int id = Utils.ObjToInt(Request["id"], 0);
                for (int i = 0; i < Utils.StrToInt(_txt_Num,0); i++)
                {
                    Thread.Sleep(50);
                    DTcms.Model.TM_QuanCard qcard_model = new TM_QuanCard();
                    qcard_model.q_id = id;
                    qcard_model.q_no = GeteRandomNumber(Utils.StrToInt(_txt_Wei,10));
                    qcard_bll.Add(qcard_model);
                }

                Response.Write("<script language='javascript'>alert('生成成功！');location.href='TM_Quan_List.aspx';</script>");
                Response.End();
            }





        }

        #region 生成 编号 随机数
        public char[] random = {   
        '0','1','2','3','4','5','6','7','8','9',  
        'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',   
        'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z' };

        public string GeteRandomNumber(int Length)
        {
            StringBuilder randomstr = new StringBuilder(62);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                randomstr.Append(random[rd.Next(62)]);
            }
            return randomstr.ToString();
        }

        #endregion





    }
}