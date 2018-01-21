using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DTcms.DBUtility;

namespace tdx.memb.man.Texts
{
    /// <summary>
    /// Apply_actions 的摘要说明
    /// </summary>
    public class Apply_actions : IHttpHandler
    {

        HttpContext context = null;
        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            string type = context.Request.Params["type"];
            switch (type)
            {
                case "first":
                    context.Response.Write(GetPageData());
                    break;
                case "del":
                    DelRows();
                    break;
            }
        }

      
       

        //----------------------------------获取分页数据-------------------------------------------------------

        #region 获取第一页数据 string GetFirstPageData()
        /// <summary>
        /// 获取第一页数据 string GetFirstPageData()
        /// </summary>
        /// <returns></returns>
        string GetPageData()
        {
            string res = "";
            string page = context.Request.Params["page"];
            string pagesize = context.Request.Params["pagesize"];

            
            if (page != "" && pagesize != "")
            {
                if (int.Parse(page) < 1)
                {
                    page = "1";
                }
                int relPages = GetPageCount(int.Parse(pagesize), GetRowsCount());
                if (int.Parse(page) > relPages)
                {
                    page = relPages.ToString();
                }
                res = GetPagedData(int.Parse(page), int.Parse(pagesize));
                res = PageDataAndMsg("ok", relPages.ToString(), res);
            }

            return res;
        }
        #endregion

        #region 获得总页数 int GetPageCount(int pageSize, DataTable dt)
        /// <summary>
        /// 获得总页数 int GetPageCount(int pageSize, DataTable dt)
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        int GetPageCount(int pageSize, int rowsCount)
        {
            int pageCount = 0;
            if (rowsCount < pageSize)
            {
                pageCount = 1;
            }
            if (rowsCount > 0)
            {
                if (rowsCount % pageSize == 0)
                {
                    pageCount = rowsCount / pageSize;
                }
                else
                {
                    pageCount = rowsCount / pageSize + 1;
                }
            }
            return pageCount;
        }
        #endregion

        #region 获取总行数 int GetRowsCount()
        /// <summary>
        /// 获取总行数 int GetRowsCount()
        /// </summary>
        /// <returns></returns>
        int GetRowsCount()
        {
            DataSet dt = DbHelperSQL.Query("select count(id) as rows from pinyuan_ApplyList");
            if (dt != null && dt.Tables[0].Rows.Count > 0)
            {
                return int.Parse(dt.Tables[0].Rows[0]["rows"].ToString());
            }
            return 0;
        }
        #endregion

        #region 页面信息与数据字符串 string PageDataAndMsg(string msg, string pagecount, string data)
        /// <summary>
        /// 页面信息与数据字符串 string PageDataAndMsg(string msg, string pagecount, string data)
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="pagecount"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        string PageDataAndMsg(string msg, string pages, string data)
        {
            string str = "{\"msg\":\"" + msg + "\",\"pages\":\"" + pages + "\",\"array\":" + data + "}";
            return str;
        }
        #endregion

        #region 获取某页的数据 string GetPagedData(int page, int pagesize)
        /// <summary>
        /// 获取某页的数据 string GetPagedData(int page, int pagesize)
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        string GetPagedData(int page, int pagesize)
        {
            string res = "";

            string sql = "select * from (select ROW_NUMBER() over(order by id desc) as rowNum,id,company, address, contact, range, phone, mail, qq, trademark, patent, regTime " +
                         "from pinyuan_ApplyList) t" +
                         " where t.rowNum between " + pagesize + " *(" + page + "-1)+1 and " + pagesize + " * " + page;

            DataSet dt = DbHelperSQL.Query(sql);
            if (dt != null && dt.Tables[0].Rows.Count > 0)
            {
                res = Dt2Json(dt.Tables[0]);
            }

            return res;
        }
        #endregion

        #region 将Datatable转化为json字符串 string Dt2Json(DataTable dt)
        /// <summary>
        /// 将Datatable转化为json字符串
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        string Dt2Json(DataTable dt)
        {
            string json = "[";

            foreach (DataRow dr in dt.Rows)
            {
                json += Dr2Json(dr) + ",";
            }
            json = json.Substring(0, json.Length - 1) + "]";

            return json;
        }
        #endregion

        #region 将dr中的数据转换为json字符串 string Dr2Json(DataRow dr)
        /// <summary>
        /// 将dr中的数据转换为json字符串 string Dr2Json(DataRow dr)
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        string Dr2Json(DataRow dr)
        {
            //company, address, contact, range, phone, mail, qq, trademark, patent, regTime,
            return ReturnJsonData(dr["id"].ToString(),dr["company"].ToString(), dr["address"].ToString(), dr["contact"].ToString(), dr["range"].ToString(), dr["phone"].ToString(), dr["mail"].ToString(), dr["qq"].ToString(), dr["trademark"].ToString(), dr["patent"].ToString(), DateTime.Parse(dr["regTime"].ToString()));
        }
        #endregion

        #region 返回页面数据Json字符串 string ReturnJsonData(string company, string address, string contact, string range, string phone, string mail, string qq, string trademark, string patent, DateTime regTime)
        /// <summary>
        /// 返回页面数据Json字符串
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="mobile"></param>
        /// <param name="name"></param>
        /// <param name="time"></param>
        /// <param name="prizename"></param>
        /// <returns></returns>company, address, contact, range, phone, mail, qq, trademark, patent, regTime
        string ReturnJsonData(string id, string company, string address, string contact, string range, string phone, string mail, string qq, string trademark, string patent, DateTime regTime)
        {
            string str = "{\"id\":\"" + id + "\",\"company\":\"" + company + "\",\"address\":\"" + address + "\",\"contact\":\"" + contact +
                "\",\"range\":\"" + range + "\",\"phone\":\"" + phone + "\",\"mail\":\"" + mail + "\",\"qq\":\"" + qq + "\",\"trademark\":\"" + trademark +
                "\",\"patent\":\"" + patent + "\",\"regTime\":\"" + regTime + "\"}";
            return str;
        }
        #endregion


        #region 删除数据行 void DelRows()
        /// <summary>
        /// 删除数据行
        /// </summary>
        void DelRows()
        {
            string array = context.Request.Params["rows"];
            string[] arr = array.Split('|');

            if (arr.Length > 0)
            {
                List<string> list = new List<string>();
                for (int i = 0; i < arr.Length; i++)
                {
                    list.Add("delete pinyuan_ApplyList where id = " + arr[i]);
                }
                DbHelperSQL.ExecuteSqlTran(list);
                context.Response.Write(RetMsg("ok", "操作成功!"));
            }
            else
            {
                context.Response.Write(RetMsg("no", "请选中要删除的行!"));
            }
        } 
        #endregion

        #region string RetMsg(string staus, string msg)
        /// <summary>
        /// 返回消息
        /// </summary>
        /// <param name="staus"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        string RetMsg(string staus, string msg)
        {
            string str = "{\"status\":\"" + staus + "\",\"msg\":\"" + msg + "\"}";
            return str;
        }
        #endregion


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}