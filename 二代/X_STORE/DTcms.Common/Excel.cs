using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DTcms.Common
{
   public class Excel
    {
       
        /// <summary> 
        /// Datatable to Excel带自定文件名的导出 
        /// </summary> 
        /// <param name="dt"></param> 
        /// <param name="FileName"></param> 
       public static void DataTable4Excel(System.Data.DataTable dt, string FileName)
        {
            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);
            DataGrid excel = new DataGrid();
            
            System.Web.UI.WebControls.TableItemStyle headerStyle = new TableItemStyle();
           
            headerStyle.BackColor = System.Drawing.Color.LightGray;
            headerStyle.Font.Bold = true;
            headerStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Center;
           
            excel.HeaderStyle.MergeWith(headerStyle);
            
            excel.GridLines = GridLines.Both;
            excel.HeaderStyle.Font.Bold = true;
            excel.DataSource = dt.DefaultView; //输出DataTable的内容 
            excel.DataBind(); 
            excel.RenderControl(htmlWriter);

            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename='" + FileName + ".xls'"); 
            HttpContext.Current.Response.Charset = "GB2312";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312"); 
            HttpContext.Current.Response.ContentType = ".xls";
            HttpContext.Current.Response.Write("<meta http-equiv=\"Content-Type\" content=\"text/html;charset=gb2312\"/>" + stringWriter.ToString());
            HttpContext.Current.Response.End();

        }
    }
}
