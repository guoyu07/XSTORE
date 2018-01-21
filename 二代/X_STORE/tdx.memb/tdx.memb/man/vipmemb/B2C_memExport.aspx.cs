using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;
using System.Data;
using Creatrue.Common;
using System.Text;

namespace tdx.memb.man.vipmemb
{
    public partial class B2C_memExport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 配置您的需要导出哪些字段，如：姓名、电话号码等。";
                    int _wid = Convert.ToInt32(Session["wID"].ToString());

                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/Goods/B2C_memExport", Session["wID"].ToString());
                }
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_save_ServerClick(object sender, EventArgs e)
        {
            int _id = 0;
            try
            {
                int _wid = Convert.ToInt32(Session["wID"].ToString());
                string _sql = "select id";
                if (show_uname.Checked)
                    _sql += ",m_name";
                if (show_utruename.Checked)
                    _sql += ",m_truename";
                if (show_utel.Checked)
                    _sql += ",m_tel";
                if (show_umobile.Checked)
                    _sql += ",m_mobile";
                if (show_uemail.Checked)
                    _sql += ",m_email";
                if (show_uqq.Checked)
                    _sql += ",m_qq";
                if (show_uaddr.Checked)
                    _sql += ",m_addr";
                if (show_ufax.Checked)
                    _sql += ",m_fax";
                if (show_uwxID.Checked)
                    _sql += ",m_carNo";
                if (show_usex.Checked)
                    _sql += ",m_sex";
                if (show_uregtime.Checked)
                    _sql += ",m_regtime";
                if (show_ubirthday.Checked)
                    _sql += ",m_birthday";
                if (show_utag.Checked)
                    _sql += ",M_tags";
                if (show_uxueli.Checked)
                    _sql += ",M_xueli";

                _sql += " from B2C_mem order by M_regtime,id";//查询微商城配置信息  where cityID=" + _wid + "
                DataTable _dt = comfun.GetDataTableBySQL(_sql);

                string files = "";
                if (_dt.Rows.Count > 0)
                {
                    files = pageList(_dt);
                }
                if (!string.IsNullOrEmpty(files))
                {
                    //不为空则是链接
                    string lj = "hydc_" + DateTime.Now.ToString().Replace(" ", "").Replace(":", "_").Replace("-", "_").Replace("/", "_") + ".csv";
                    string glj = Request.MapPath("/upload/") + lj;
                    string url = "../../down.aspx?filename=" + lj;
                    try
                    {

                        if (System.IO.File.Exists(glj))
                        {
                            System.IO.File.Delete(glj);

                        }
                        Byte[] bys = System.Text.Encoding.GetEncoding("GB2312").GetBytes(files);
                        System.IO.Stream stm = System.IO.File.Create(glj);
                        stm.Write(bys, 0, bys.Length);
                        stm.Close();
                        stm = null;
                        lt_xiazai.Text = "<a href='" + url + "'  class=\"btnGreen\" >下载excel</a>";
                    }
                    catch (System.Exception ex)
                    {
                        lt_xiazai.Text = "<a href='####'  class=\"btnGreen\">导出错误</a>";
                    }
                }

            }
            catch (Exception ex)
            {

                commonTool.Show_Have_Url(lt_result, "导出失败！", "", 1);
                comfun.ChuliException(ex, "man/Goods/B2C_memExport", Session["wID"].ToString());
            }


        }

        private string pageList(DataTable _dt)
        {
            StringBuilder sbex = new StringBuilder();
            if (_dt.Rows.Count > 0)
            {
                sbex.Append("关注用户列表\n");

                //sbex.Append("昵称,");
                //sbex.Append("备注,");
                //sbex.Append("分组名称,");
                //sbex.Append("微信号\n");

                foreach (DataRow dr in _dt.Rows)
                {
                    for (int i = 0; i < dr.ItemArray.Length; i++)
                        sbex.Append(dr.ItemArray[i].ToString() + ",");

                    sbex.Append("\n");
                }
            }

            return sbex.ToString();

        }
    }
}