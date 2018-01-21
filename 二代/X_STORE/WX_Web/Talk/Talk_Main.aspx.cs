using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.DBUtility;
using tdx.Weixin;
using DTcms.Common;

namespace Wx_NewWeb.Talk
{
    public partial class Talk_Main : weixinAuth
    {
        private DTcms.BLL.TK_发帖表 TK_发帖表 = new DTcms.BLL.TK_发帖表();
        private DTcms.BLL.advert bll = new DTcms.BLL.advert();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = DbHelperSQL.Query(@"select a.*,isnull(b.主题,0) as 主题,isnull(c.发帖数,0) as 发帖数 from  [dbo].[TK_发帖类别表] a left join (select c_parent,count(1) as 主题 from TK_发帖类别表 Group by c_parent) b on a.id=b.c_parent left join (select c_parent,count(1) as 发帖数 from [dbo].[TK_发帖表] a left join [TK_发帖类别表] b on a.类别号=b.类别编号 Group by c_parent) c on a.id=c.c_parent where a.c_parent=0 order by a.c_sort asc,a.id desc").Tables[0];
                TalkType.DataSource = dt;
                TalkType.DataBind();

                loadTop();
            }
        }

        public string LeftImg = "";
        public string RightImg = "";
        public string LeftBH = "";
        public string RightBH = "";
        public void loadTop()
        {
            //首页轮换
            List<DTcms.Model.advert_pic> pics = new List<DTcms.Model.advert_pic>();
            DTcms.Model.advert src = bll.GetModel(7);
            if (src != null)
            {
                try
                {
                    pics = DTcms.Common.Utils.JsonDeserializeObject<List<DTcms.Model.advert_pic>>(src.array);
                    this.imgList.DataSource = pics;
                    this.imgList.DataBind();

                    string li = "";
                    for (int i = 0; i < pics.Count - 1; i++)
                    {
                        li += "<li></li>";
                    }
                    showNumber.Text = li;
                }
                catch (Exception)
                {
                }
            }

            DTcms.Model.advert srcxqk = bll.GetModel(8);
            if (srcxqk != null)
            {
                try
                {
                    LeftImg =
                        DTcms.Common.Utils.JsonDeserializeObject<List<DTcms.Model.advert_pic>>(srcxqk.array)[0].pic.ToString();

                    LeftBH =
                        //GetBH(DTcms.Common.Utils.JsonDeserializeObject<List<DTcms.Model.advert_pic>>(srcxqk.array)[0].url);
                                               DTcms.Common.Utils.JsonDeserializeObject<List<DTcms.Model.advert_pic>>(srcxqk.array)[0].url;
                }
                catch (Exception)
                {
                }
            }

            DTcms.Model.advert srcxqk1 = bll.GetModel(9);
            if (srcxqk1 != null)
            {
                try
                {
                    RightImg =
                        DTcms.Common.Utils.JsonDeserializeObject<List<DTcms.Model.advert_pic>>(srcxqk1.array)[0].pic.ToString();

                    RightBH =
                        //GetBH(DTcms.Common.Utils.JsonDeserializeObject<List<DTcms.Model.advert_pic>>(srcxqk1.array)[0].url);
                                              DTcms.Common.Utils.JsonDeserializeObject<List<DTcms.Model.advert_pic>>(srcxqk1.array)[0].url;
                }
                catch (Exception)
                {
                }
            }

        }

        public string GetBH(object id)
        {
            string BH = "";
            if (TK_发帖表.GetModel(Utils.ObjToInt(id,0))!=null)
            {
                BH = TK_发帖表.GetModel(Utils.ObjToInt(id, 0)).编号;
            }
            return BH;
        }



    }
}