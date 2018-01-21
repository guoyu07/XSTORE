using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using tdx.database;
using System.Data;

namespace tdx.memb.man.formcontrols
{
    /// <summary>
    /// controlSave 的摘要说明
    /// </summary>
    public class controlSave : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            bool isSucc = false;  //是否处理成功
            context.Response.ContentType = "text/plain";
            try
            {


                if (context.Request["isedit"].ToString() == "0")  //添加
                {
                    if (context.Request["type"].ToString() != "")
                    {
                        //不为空
                        string txtStr = context.Request["type"].ToString();
                        //if (context.Request["wid"].ToString() != context.Session["wid"].ToString())
                        //{
                        //    context.Response.Write("处理失败");
                        //    return;
                        //}
                        switch (txtStr)
                        {
                            case "4": //单选
                                string valuesSi = context.Request["values"].ToString();
                                string valuedf = context.Request["valuedf"].ToString();
                                isSucc = TJDX(context.Request["wid"].ToString(), valuesSi, "4", valuedf, context.Request["name"].ToString(), context.Request["sort"].ToString());

                                break;
                            case "5":  //多选
                                string valueMu = context.Request["values"].ToString();
                                isSucc = TJDUOX(context.Request["wid"].ToString(), valueMu, "5", context.Request["name"].ToString(), context.Request["sort"].ToString());
                                break;
                            case "6":  //下拉菜单
                                string valueXl = context.Request["values"].ToString();
                                string valueXLF = context.Request["valuedf"].ToString();
                                isSucc = TJXIAL(context.Request["wid"].ToString(), valueXl, "6", valueXLF, context.Request["name"].ToString(), context.Request["sort"].ToString());
                                break;
                            case "7":  //文本
                                string valueWB = context.Request["values"].ToString();
                                isSucc = TJDWB(context.Request["wid"].ToString(), valueWB, "7", context.Request["name"].ToString(), context.Request["sort"].ToString());
                                break;
                            default:
                                isSucc = TJPT(context.Request["wid"].ToString(), txtStr, context.Request["name"].ToString(), context.Request["sort"].ToString());
                                //处理普通的类型
                                break;
                        }
                    }
                }
                else
                {
                    //if (context.Request["isedit"].ToString() == "1")  //修改
                    //{

                    //}
                    //else
                    //{
                    //    //没有处理
                    //}
                }
            }
            catch (System.Exception ex)
            {

                context.Response.Write("处理失败");
            }
            if (isSucc)
            {
                context.Response.Write("处理成功");
            }
            else
            {
                context.Response.Write("处理失败");
            }

        }
        /// <summary>
        /// 添加普通文本
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="values"></param>
        /// <param name="type"></param>
        /// <param name="valuede"></param>
        /// <param name="name"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        private bool TJPT(string wid, string type, string name, string sort)
        {
            control_key ck = new control_key();
            ck.AddNew();
            ck.name = name;
            int.TryParse(sort, out ck.sort);
            ck.type_id = Convert.ToInt32(type);
            ck.wid = Convert.ToInt32(wid);
            ck.Update();
            return true;

        }
        /// <summary>
        /// 单选
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="values"></param>
        /// <param name="valuede"></param>
        /// <returns></returns>
        private bool TJDX(string wid, string values, string type, string valuede, string name, string sort)
        {
            control_key ck = new control_key();
            ck.AddNew();
            ck.name = name;
            int.TryParse(sort, out ck.sort);
            ck.type_id = Convert.ToInt32(type);
            ck.wid = Convert.ToInt32(wid);
            ck.Update();
            //添加单选成功
            //添加列表项目

            DataTable dt = control_key.GetList("id", string.Format("wid={0} and type_id={1} and name='{2}'", ck.wid, ck.type_id, ck.name));
            if (dt.Rows.Count > 0)
            {
                string[] vals = values.Split(new char[] { '\n' });
                for (int i = 0; i < vals.Length; i++)
                {
                    if (string.IsNullOrEmpty(vals[i]))
                    {
                        continue;
                    }
                    control_value cv = new control_value();
                    cv.AddNew();
                    if (vals[i] == valuede)
                    {
                        cv.is_select = 1;
                    }
                    else
                    {
                        cv.is_select = 0;
                    }
                    cv.value = vals[i];
                    cv.sort = i;
                    cv.key_id = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                    cv.Update();
                }

            }
            return true;

        }
        /// <summary>
        /// 下拉菜单
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="values"></param>
        /// <param name="valuede"></param>
        /// <returns></returns>
        private bool TJXIAL(string wid, string values, string type, string valuede, string name, string sort)
        {
            control_key ck = new control_key();
            ck.AddNew();
            ck.name = name;
            int.TryParse(sort, out ck.sort);
            ck.type_id = Convert.ToInt32(type);
            ck.wid = Convert.ToInt32(wid);
            ck.Update();
            //添加单选成功
            //添加列表项目

            DataTable dt = control_key.GetList("id", string.Format("wid={0} and type_id={1} and name='{2}'", ck.wid, ck.type_id, ck.name));
            if (dt.Rows.Count > 0)
            {
                string[] vals = values.Split(new char[] { '\n' });
                for (int i = 0; i < vals.Length; i++)
                {
                    if (string.IsNullOrEmpty(vals[i]))
                    {
                        continue;
                    }
                    control_value cv = new control_value();
                    cv.AddNew();
                    if (vals[i] == valuede)
                    {
                        cv.is_select = 1;
                    }
                    else
                    {
                        cv.is_select = 0;
                    }
                    cv.value = vals[i];
                    cv.sort = i;
                    cv.key_id = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                    cv.Update();
                }

            }
            return true;

        }
        /// <summary>
        /// 添加多选
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="values"></param>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        private bool TJDUOX(string wid, string values, string type, string name, string sort)
        {
            control_key ck = new control_key();
            ck.AddNew();
            ck.name = name;
            int.TryParse(sort, out ck.sort);
            ck.type_id = Convert.ToInt32(type);
            ck.wid = Convert.ToInt32(wid);
            ck.Update();
            //添加单选成功
            //添加列表项目

            DataTable dt = control_key.GetList("id", string.Format("wid={0} and type_id={1} and name='{2}'", ck.wid, ck.type_id, ck.name));
            if (dt.Rows.Count > 0)
            {
                string[] vals = values.Split(new char[] { '\n' });
                for (int i = 0; i < vals.Length; i++)
                {
                    if (string.IsNullOrEmpty(vals[i]))
                    {
                        continue;
                    }
                    control_value cv = new control_value();
                    cv.AddNew();
                    cv.is_select = 0;
                    cv.value = vals[i];
                    cv.sort = i;
                    cv.key_id = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                    cv.Update();
                }

            }
            return true;

        }
        /// <summary>
        /// 添加描述
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="values"></param>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        private bool TJDWB(string wid, string values, string type, string name, string sort)
        {
            control_key ck = new control_key();
            ck.AddNew();
            ck.name = name;
            int.TryParse(sort, out ck.sort);
            ck.type_id = Convert.ToInt32(type);
            ck.wid = Convert.ToInt32(wid);
            ck.Update();
            //添加单选成功
            //添加列表项目

            DataTable dt = control_key.GetList("id", string.Format("wid={0} and type_id={1} and name='{2}'", ck.wid, ck.type_id, ck.name));
            if (dt.Rows.Count > 0)
            {
                control_value cv = new control_value();
                cv.AddNew();
                cv.is_select = 0;
                cv.value = values;
                cv.sort = 0;
                cv.key_id = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                cv.Update();
            }
            else
            {
                return false;
            }
            return true;

        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}