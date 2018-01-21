using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using System.Data;
using Creatrue.kernel;

namespace tdx.memb.man.Sets
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetFunc : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            int _wID = context.Session["wID"] != null ? Convert.ToInt32(context.Session["wID"]) : 0;
            string _q = context.Request["q"] != null ? context.Request["q"].ToString() : "";
            string _r = context.Request["r"] != null ? context.Request["r"].ToString() : "";
            string result = "";
            if (_q != "")
            {
                switch (_q)
                {
                    case "newslist": //返回新闻类别
                        result = GetNewsClassList(_wID);
                        break;
                    case "prolist":
                        result = GetProsClassList(_wID);
                        break; //返回产品类别
                    case "Goodslist":
                        result = GetProsClassList(_wID);
                        break; //返回产品类别
                    case "teamlist":
                    case "mslist":
                        result = GetDefaultClassList(_wID);
                        break;
                    case "honor_list": //返回活动 
                        if (_r != "")
                        {
                            result = GetHuoDong(_wID, _r);
                        }
                        else
                        {
                            result = GetHonorClassList(_wID);
                        }
                        break;
                    case "tpage"://返回页面
                        if (_r != "")
                        {
                            result = GetPageList(_wID, _r);
                        }
                        else
                        {
                            result = GetPageClassList(_wID);
                        }
                        break;
                    case "photolist"://返回相册类别
                        result = GetPhotoClassList(_wID);
                        break;
                    case "controls"://返回表单
                        result = GetControlsList(_wID);
                        break;
                    default:
                        result = "";
                        break;
                }
            }

            context.Response.Write(result);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        private string GetControlsList(int _wID)
        {
            string result = "";
            string _sql = "select id,name from control_obj where wid=" + _wID.ToString() + " order by id";
            DataTable dt = comfun.GetDataTableBySQL(_sql);
            result += "<option value=\"\">全部</option> \r\n";
            foreach (DataRow dr in dt.Rows)
            {
                result += "<option value=\"" + dr["id"].ToString() + "\">" + dr["name"].ToString() + "</option> \r\n";
            }
            dt.Dispose();
            return result;
        }
        private string GetNewsClassList(int _wID)
        {
            string result = "";
            result += "<option value=\"\">全部</option> \r\n";
            result += GetClassFor(_wID, "B2C_tclass", 0);
            return result;
        }
        private string GetProsClassList(int _wID)
        {
            string result = "";
            result += "<option value=\"\">全部</option> \r\n";
            result += GetClassFor(_wID, "B2C_category", 0);
            return result;
        }
        private string GetPageClassList(int _wID)
        {
            string result = "";
            result += "<option value=\"\">全部</option> \r\n";
            result += GetClassFor(_wID, "B2C_tpclass", 0);
            return result;
        }
        private string GetPageList(int _wID, string _cno)
        {
            string result = "";
            string _sql = "select id,gtitle from b2c_tpage where cno like '" + _cno + "%' order by g_sort,id"; //cityID=" + _wID.ToString() + " and
            DataTable dt = comfun.GetDataTableBySQL(_sql);
            result += "<option value=\"\">全部</option> \r\n";
            foreach (DataRow dr in dt.Rows)
            {
                result += "<option value=\"" + dr["id"].ToString() + "\">" + dr["gtitle"].ToString() + "</option> \r\n";
            }
            dt.Dispose();
            return result;
        }
        private string GetPhotoClassList(int _wID)
        {
            string result = "";
            result += "<option value=\"\">全部</option> \r\n";
            result += GetClassFor(_wID, "B2C_hclass", 0);
            return result;
        }
        private string GetHonorClassList(int _wID)
        {
            string result = "";
            result += "<option value=\"\">全部活动</option> \r\n";
            string _sql = "select * from wx_actions";
            DataTable _tab = comfun.GetDataTableBySQL(_sql);
            if (_tab.Rows.Count > 0)
            {
                for (int i = 0; i < _tab.Rows.Count; i++)
                {
                    result += "<option value=\"" + _tab.Rows[i]["id"].ToString() + "\">" + _tab.Rows[i]["ac_name"].ToString() + "</option> \r\n";
                }
            }

            return result;
        }
        private string GetDefaultClassList(int _wID)
        {
            string result = "";
            result += "<option value=\"001\">全部</option> \r\n";
            return result;
        }
        /// <summary>
        /// 获取活动列表
        /// </summary>
        /// <param name="_w"></param>
        /// <param name="_name"></param>
        /// <returns></returns>
        private string GetHuoDong(int _w, string _id)
        {
            string result = "";
            result += "<option value=\"全部\">全部</option> \r\n";
            string _sql = "select top 1 * from wx_actions where id=" + _id + "";
            DataTable _actions = comfun.GetDataTableBySQL(_sql);
            if (_actions.Rows.Count > 0)
            {
                int _type_id = Convert.ToInt32(_actions.Rows[0]["id"].ToString());
                string actionSql = "select * from wx_action where typeid=" + _type_id + " and wid=" + _w.ToString();
                DataTable _tab = comfun.GetDataTableBySQL(actionSql);
                if (_tab.Rows.Count > 0)
                {
                    for (int i = 0; i < _tab.Rows.Count; i++)
                    {
                        result += "<option value=\"" + _tab.Rows[i]["id"].ToString() + "\">" + _tab.Rows[i]["ac_title"].ToString() + "</option> \r\n";
                    }
                }
            }
            _actions.Dispose();
            return result;
        }

        private string GetClassFor(int _wID, string _className, int _parentID)
        {
            string result = "";
            DataTable dt = comfun.GetDataTableBySQL("select c_no,c_name,c_id,c_level,c_child from " + _className + " where c_parent= " + _parentID.ToString() + " and c_isactive=1 and c_isdel=0 order by c_sort,c_id"); //cityid=" + _wID.ToString() + " and
            foreach (DataRow dr in dt.Rows)
            {
                string texts = "";
                string values = "";
                int depth = Convert.ToInt32(dr["c_level"]);
                while (depth > 0)
                {
                    texts += "　";
                    depth = depth - 1;
                }
                values = dr["c_no"].ToString().Trim();
                if (Convert.ToInt32(dr["c_child"]) < 1)
                {
                    texts += " - " + dr["c_name"].ToString().Trim();
                    result += "\r\n";
                    result += "<option value=\"" + values + "\">" + texts + "</option>";
                }
                else
                {
                    texts += " + " + dr["c_name"].ToString().Trim();
                    result += "\r\n";
                    result += "<option value=\"" + values + "\">" + texts + "</option>";
                    result += GetClassFor(_wID, _className, Convert.ToInt32(dr["c_id"]));
                }
            }
            dt.Dispose();
            return result;
        }
    }
}