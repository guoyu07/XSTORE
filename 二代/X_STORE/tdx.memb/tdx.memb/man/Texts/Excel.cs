using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace tdx.memb.man.Texts
{
    public class Excel
    {
        public void CreateExcel(DataTable dt, string FileName)
        {
            HttpResponse Response = HttpContext.Current.Response;
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("Content-Disposition", string.Format("attachment; filename=" + HttpUtility.UrlEncode(ChangeName(FileName)) + ".csv"));
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            Response.ContentType = "application/vnd.ms-excel";

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sb.Append(dt.Columns[i].ColumnName + ",");
            }
            sb.Append("\r\n");

            foreach (DataRow item in dt.Rows)
            {
                for (int i = 0; i < item.ItemArray.Length; i++)
                {
                 
                        sb.Append(item.ItemArray[i].ToString().Replace(",", " ").Replace("\r\n", "     ").Replace("/", "-") + ",");
                    
                }
                sb.Append("\r\n");
            }
            if (Response != null)
            {
                Response.Write(sb.ToString());
            }
            Response.End();
        }
        private string ChangeName(string input)
        {
            string s = Regex.Replace(input, @"\s+", "_", RegexOptions.IgnoreCase);
            return s;
        }


    }
}