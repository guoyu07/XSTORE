using System;

namespace tdx.database
{
    public class userAuthor : System.Web.UI.Page 
    {
        public userAuthor()
        { 
            //if (Session["uInfo"] == null)
            //{
            //    //未登录
            //    //System.Web.HttpContext.Current.Response.Write("<script language='javascript'>windows.top.location.href='/master/main.aspx';</script>");
            //    //System.Web.HttpContext.Current.Response.End();
            //    //return;
            //}  
        }
        protected override void OnInit(EventArgs e)
        {
            if (Session["uInfo"] == null)
            {
                //未登录
                System.Web.HttpContext.Current.Response.Write("<script language='javascript'>window.top.location.href='/agent/login.aspx';</script>");
                System.Web.HttpContext.Current.Response.End();
                return;
            }
        }
        public void userAuthentication(int _RightID)
        {
            try
            {
                if (Session["uInfo"] != null)
                {
                    string[] uInfo = (string[])Session["uInfo"];
                    if (uInfo[1] == "admin" || uInfo[1] == "administrator" || uInfo[1] == "madaiwusi")
                    {
                        return;
                    }
                    string uRights = uInfo[2];
                    if (uRights.IndexOf("," + _RightID.ToString() + ",") == -1)
                    {
                        System.Web.HttpContext.Current.Response.Write("<script language='javascript'>alert('您没有权限进入该页');location.href='/agent/admin_index.aspx';</script>");
                        System.Web.HttpContext.Current.Response.End();
                        return;
                    }

                }
                else
                {
                    System.Web.HttpContext.Current.Response.Write("<script language='javascript'>window.top.location.href='/';</script>");
                    System.Web.HttpContext.Current.Response.End();
                    return;
                }
            }
            catch (Exception ex)
            {
                System.Web.HttpContext.Current.Response.Write("<script language='javascript'>window.top.location.href='/';</script>");
                System.Web.HttpContext.Current.Response.End();
                return;
            }           
        }

        public string GetAreaRight()
        {
            if (Session["uInfo"] != null)
            {                
                string[] uInfo = (string[])Session["uInfo"];
                if (uInfo[1] == "admin" || uInfo[1] == "administrator" || uInfo[1] == "madaiwusi")
                    return "";
                else
                    return uInfo[3];
            }
            else
                return "-1";
                //Response.Redirect("/");
        }
    } 
   
}