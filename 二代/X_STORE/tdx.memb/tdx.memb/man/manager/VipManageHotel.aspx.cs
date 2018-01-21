using Creatrue.Common.Msgbox;
using Creatrue.kernel;
using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace tdx.memb.man.manager
{
    public partial class VipManageHotel : System.Web.UI.Page
    {
        string id = DTRequest.GetQueryString("id");//用户id
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if(!IsPostBack){
                bound_telerik();
              //  compare();
            }

        }
        //绑定
        protected void bound_telerik()
        {
            string province = @" SELECT ('q_'+Convert(nvarchar(250),id)) as id, 名称 as name ,NULL as parentId FROM WP_地区表 
                                             UNION ALL
                                             SELECT  ('j_'+Convert(nvarchar(250),Id)) as id, 酒店全称 as name ,('q_'+Convert(nvarchar(250),区域id )) as parentId FROM WP_酒店表  where IsShow=1
                                             UNION ALL
                                             SELECT Convert(nvarchar(250),id) as id, 仓库名 as name ,('j_'+Convert(nvarchar(250),酒店id)) as parentId FROM WP_仓库表 where IsShow=1";
            DataTable dt = comfun.GetDataTableBySQL(province);
            rtv_status.DataSource = dt;
            rtv_status.DataTextField = "name";
            rtv_status.DataFieldID = "id";
            rtv_status.DataValueField = "id";
            rtv_status.DataFieldParentID = "parentId";
            rtv_status.DataBind();
            BindCheck();
        }

        //绑定完成以后加载比较
        protected void BindCheck()
        {
            rtv_status.ExpandAllNodes();
            string sel_sql = @"select 仓库id from WP_用户权限 where 用户id=" + id;
            DataTable dt = comfun.GetDataTableBySQL(sel_sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    foreach (RadTreeNode items in rtv_status.Nodes)
                    {
                        foreach (RadTreeNode item in items.Nodes)
                        {
                            foreach (RadTreeNode item_jd in item.Nodes)
                            {
                                if (dt.Rows[i]["仓库id"].ObjToStr() == item_jd.Value)
                                {
                                    item_jd.Checked = true;
                                }

                            }
                        }
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int flag = 0;
            var str = rtv_status.CheckedNodes.Select(o => (o as RadTreeNode).Value).Aggregate((x, y) => x + "," + y).ToString();//为空了以后报空值
            String[] ss = str.Split(',');
            string sel_sql = @" select id from WP_用户权限 where 用户id=" + id;
            DataTable dt = comfun.GetDataTableBySQL(sel_sql);
            if (dt.Rows.Count > 0)
            {//权限不为空
                string sql = @"delete from WP_用户权限 where 用户id=" + id;
                flag = new comfun().Del(sql);  

            }
            foreach (var item in ss)
            {
                if (item.IndexOf("_") == -1)//有
                {
                    string ins_sql = @"insert into WP_用户权限 (用户id,仓库id) values(" + id + ",'" + item + "')";
                    flag = new comfun().Insert(ins_sql);

                }
            }
            if (flag != 0)
            {
                MessageBox.ShowAndRedirect(this, "操作成功!", "WX_users.aspx");
                return;
            }
            else {
                MessageBox.Show(this, "操作失败!");
                return;
            }

        }

    }
}