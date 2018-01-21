using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using Creatrue.kernel;
using System.Security.Cryptography;
using System.Text;

namespace tdx.memb.man.Sets
{
    public partial class wxPsw : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int _id = Convert.ToInt32(Session["wID"].ToString());

                string sql = "select * from dt_manager where id = " + _id;
                DataTable dt = comfun.GetDataTableBySQL(sql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    lt_wname.Text = dt.Rows[0]["user_name"].ToString().Trim();
                }

            }
        }
        protected void Button1_ServerClick(object sender, EventArgs e)
        {
            string _id = Session["wID"].ToString();
            string _psw = txtpsw.Value.Trim();
            string _psw2 = txtpsw2.Value.Trim();

            if (_psw.Trim() == "")
            {
                lt_result.Text = "请输入密码.";
                return;
            }
            if (_psw2.Trim() == "")
            {
                lt_result.Text = "请重复密码";
                return;
            }
            if (_psw.Trim() != _psw2.Trim())
            {
                lt_result.Text = "两次输入的密码不一致。";
                return;
            }

            try
            {

                string sql = "select salt from dt_manager where id = " + _id;
                DataTable dt = comfun.GetDataTableBySQL(sql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    sql = "update dt_manager set password = '" + Encrypt(_psw,dt.Rows[0]["salt"].ToString()) + "' where id = " + _id;
                    comfun.UpdateBySQL(sql);
                    lt_result.Text = "密码修改成功！";
                    lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='wxPsw.aspx';},300);</script>";
                }
            }
            catch (Exception ex)
            {
                lt_result.Text = ex.Message;
            }

        }


        public string Encrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray;
            inputByteArray = Encoding.Default.GetBytes(Text);
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }


    }
}