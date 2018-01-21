using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.Common.Tools;
using System.Configuration;

namespace tdx.memb.man.ShoppingMall.GrogshopManage
{
    public partial class BarCodeCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        protected void PageInit()
        {
            string where_sql = " 1=1";
            string key_word = txtKeywords.Text.ObjToStr();
            int hasbind = has_bind_ddl.SelectedValue.ObjToInt(0);
            if (!string.IsNullOrEmpty(key_word))
            {
                where_sql += string.Format(" AND (BarCode LIKE '%{0}%' OR ICCID  LIKE '%{0}%' OR Serial LIKE '%{0}%' OR Number LIKE '%{0}%' OR Code LIKE '%{0}%')", key_word);
            }
            if (hasbind != 99)
            {
                where_sql += string.Format(" AND HasBind = {0}", hasbind);
            }
      //      [BarCode]
      //,[CreateTime]
      //,[BindTime]
      //,[KuWeiId]
      //,[HotelId]
      //,[HasBind]
      //,[房间名]
      //,[酒店名]
      //,[图片路径]
      //,[ICCID]
      //,[Number]
      //,[Serial]
      //,[Code]
      var sql = "SELECT BarCode as IMEI,ICCID,Code as 二维码下面编码,Serial as 流水号,Number as 号码,酒店名 as 绑定酒店,图片路径,房间名 as 绑定房间,HasBind,BindTime,CreateTime FROM 视图获取IMEI WHERE " + where_sql;
            var leadOutSql = "SELECT BarCode as IMEI,ICCID,Code as 二维码下面编码,Serial as 流水号,Number as 号码,酒店名 as 绑定酒店,房间名 as 绑定房间,case HasBind when 1 then '已绑定' else '未绑定' end as 是否绑定,Convert(nvarchar(19),BindTime,120) as 绑定时间,convert(nvarchar(19),CreateTime,120) as 创建时间 FROM 视图获取IMEI WHERE " + where_sql;
            ViewState["sql"] = leadOutSql;
            var dt = comfun.GetDataTableBySQL(sql);
            barcode_repeater.DataSource = dt;
            barcode_repeater.DataBind();

        }

        #region 判断是否绑定
        public string GetHasBind(int has_bind)
        {
            string return_str = string.Empty;
            switch (has_bind)
            {
                case 0:
                    return return_str = string.Format("<span style='{0}'>{1}</span>", "color:red;", "未绑定");
                case 1:
                    return return_str = string.Format("<span style='{0}'>{1}</span>", "color:green;", "已绑定");
            }
            return return_str;
        }
        #endregion

        #region 搜索
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            PageInit();
        }

        #endregion

        #region 跳转导入页面
        protected void btnLeading_Click(object sender, EventArgs e)
        {
            var url = "LeadingIMEI.aspx";
            Response.Redirect(url);
        }
        #endregion

        #region 导出

       

        protected void btnLeadOut_OnClick(object sender, EventArgs e)
        {
            var sql = ViewState["sql"].ObjToStr();
            DataTable dt = comfun.GetDataTableBySQL(sql);
            DTcms.Common.NPOIHelper.RenderDataTableToExcel_Web(dt, "IMEI" + DateTime.Now.ToString("yyyy-MM-dd"));
        }
        #endregion
        protected void btnDownload_OnClick(object sender, EventArgs e)
        {
            var needZipDictory =Server.MapPath("~/Upload/BarCode/");
            var zipedDictory = Server.MapPath("~/Upload/barCode.zip");
            SharpZip.PackFiles(zipedDictory, needZipDictory);
            string root = ConfigurationManager.AppSettings["HomeUrl"].ObjToStr();
            var downloadUrl = root + "/Upload/barCode.zip";
            Response.Write(string.Format("<script>window.open('{0}','newWindow','width=0,height=0');</script>", downloadUrl));
        }
    }
}