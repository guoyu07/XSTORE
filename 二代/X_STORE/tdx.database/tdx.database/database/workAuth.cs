using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Creatrue.kernel;
using System.Web.SessionState;
using System.Web;

namespace tdx.database
{
    public class workAuth : System.Web.UI.Page
    {
        public workAuth()
        {

            //if (Session["wInfo"] == null)
            //{
            //    //未登录
            //    //System.Web.HttpContext.Current.Response.Write("<script language='javascript'>windows.top.location.href='/master/main.aspx';</script>");
            //    //System.Web.HttpContext.Current.Response.End();
            //    //return;
            //} 
        }
        protected override void OnInit(EventArgs e)
        {
            Session["wID"] = "1";
            if (Session["wInfo"] == null)
            {
                //未登录
                System.Web.HttpContext.Current.Response.Write("<script language='javascript'>window.top.location.href='/man/login.aspx';</script>");
                System.Web.HttpContext.Current.Response.End();
                return;
            }
        }
      
        public void workAuthentication(int _RightID)
        {
            try
            {
                if (Session["wInfo"] != null)
                {
                    string[] wInfo = (string[])Session["wInfo"];
                    if (wInfo[1] == "admin" || wInfo[1] == "administrator" || wInfo[1] == "madaiwusi")
                    {
                        return;
                    }
                    string uRights = wInfo[2];
                    if (uRights.IndexOf("," + _RightID.ToString() + ",") == -1)
                    {
                        System.Web.HttpContext.Current.Response.Write("<script language='javascript'>alert('您没有权限进入该页');location.href='/memb/main.aspx';</script>");
                        System.Web.HttpContext.Current.Response.End();
                        return;
                    }

                }
                else
                {
                    System.Web.HttpContext.Current.Response.Write("<script language='javascript'>window.top.location.href='/login.aspx';</script>");
                    System.Web.HttpContext.Current.Response.End();
                    return;
                }
            }
            catch (Exception ex)
            {
                System.Web.HttpContext.Current.Response.Write("<script language='javascript'>window.top.location.href='/login.aspx';</script>");
                System.Web.HttpContext.Current.Response.End();
                return;
            }           
        }

        public string GetAreaRight()
        {
            if (Session["wInfo"] != null)
            {                
                string[] wInfo = (string[])Session["wInfo"];
                if (wInfo[1] == "admin" || wInfo[1] == "administrator" || wInfo[1] == "madaiwusi")
                    return "";
                else
                    return wInfo[3];
            }
            else
                return "-1";
                //Response.Redirect("/");
        }
    }
}
