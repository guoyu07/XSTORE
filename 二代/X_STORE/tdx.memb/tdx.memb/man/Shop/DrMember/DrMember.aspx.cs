using DTcms.Common;
using DTcms.DBUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tdx.memb.man.Shop.DrMember
{
    public partial class DrMember : System.Web.UI.Page
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = DTRequest.GetQueryString("keywords");

            this.pageSize = 20;
            if (!Page.IsPostBack)
            {

                RptBind(" a.id asc ");
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            txt_codecard.Text = this.keywords;

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select a.id,a.code as 会员编号,a.cardcode as 会员卡号,b.name as 会员类型,a.name as 会员姓名
,a.effectivedate as 生效日期,a.expirationdate as 失效日期
,a.memberstate as 会员状态,a.mobilephone as 联系电话,0 as 储值余额
from UFTData629131_000001.dbo.AA_DR_Member a left join UFTData629131_000001.dbo.AA_DR_MemberType b
on a.idmembertype=b.id");
            if (txt_codecard.Text.Trim() != "")
            {
                strSql.Append(" where a.cardcode like '%"+txt_codecard.Text+"%' ");
            }
            int recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            this.Rp_UserInfo.DataSource = DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, this.page, strSql.ToString(), " id asc"));
            this.Rp_UserInfo.DataBind();

            //绑定页码
            //txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("DrMember.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(20, this.page, recordCount, pageUrl, 8);
        }
        #endregion

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("DrMember.aspx", "keywords={0}", txt_codecard.Text));
        }


    }
}

