using Creatrue.Common.Msgbox;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.DBUtility;
using tdx.database;
using Creatrue.kernel;
using System.Xml;
using System.IO;
using System.Web.UI.HtmlControls;


namespace tdx.memb.man.ShoppingMall.GoodsManage
{
    public partial class FerightMainDEdit : System.Web.UI.Page
    {
        public static int spxqid;

        public static int sptpid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindmuban();
                loadprince();
                int id = int.Parse(string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"]);
                if (id > 0)
                {
                  DTcms.Model.WP_FreightMainD mwp=  new DTcms.BLL.WP_FreightMainD().GetModel(id);
                  if (mwp != null)
                  {
                      this.select_模板.Value = mwp.mainid.ToString();
                      this.txt_名称.Text = mwp.name;
                      this.txt_首重.Text = mwp.shouzhong.ToString();
                      this.txt_续重.Text = mwp.xuzhong.ToString();
                      this.txt_地区.Text = mwp.areas;
                      initchk(mwp.areas);
                  }
                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int id = int.Parse(string.IsNullOrEmpty(Request["id"]) ? "-1" : Request["id"]);
            if (id > 0)
            {
                DTcms.BLL.WP_FreightMainD bwpfmain = new DTcms.BLL.WP_FreightMainD();
                DTcms.Model.WP_FreightMainD mwp = bwpfmain.GetModel(id);
                mwp.name = this.txt_名称.Text;
                decimal shouzhong = 0;
                if (decimal.TryParse(this.txt_首重.Text, out shouzhong))
                    mwp.shouzhong = shouzhong;
                decimal xuzhong = 0;
                if (decimal.TryParse(this.txt_续重.Text, out xuzhong))
                    mwp.xuzhong = xuzhong;
                int mainid = 0;
                if (int.TryParse(this.select_模板.Value, out mainid))
                    mwp.mainid = mainid;
                mwp.areas = this.txt_地区.Text;
                bwpfmain.Update(mwp);
                MessageBox.ShowAndRedirect(this, "修改成功！", "FerightDList.aspx?id=" + mwp.mainid);
            }
            else
            {
                DTcms.BLL.WP_FreightMainD bwpfmain = new DTcms.BLL.WP_FreightMainD();
                DTcms.Model.WP_FreightMainD mwp = new DTcms.Model.WP_FreightMainD();
                mwp.name = this.txt_名称.Text;
                int shouzhong = 0;
                if (int.TryParse(this.txt_首重.Text, out shouzhong))
                    mwp.shouzhong = shouzhong;
                int xuzhong = 0;
                if (int.TryParse(this.txt_续重.Text, out xuzhong))
                    mwp.xuzhong = xuzhong;
                int mainid = 0;
                if (int.TryParse(this.select_模板.Value, out mainid))
                    mwp.mainid = mainid;
                mwp.areas = this.txt_地区.Text;
                bwpfmain.Update(mwp);
                bwpfmain.Add(mwp);
                MessageBox.ShowAndRedirect(this, "添加成功！", "FerightDList.aspx?id=" + mwp.mainid);
            }
        }

        private void bindmuban()
        {
            string sql="select  id,name from   WP_FreightMain";
             DataTable dt = comfun.GetDataTableBySQL(sql);
             this.select_模板.Items.Clear();
             this.select_模板.Items.Add(new ListItem("请选择模板",""));
             if (dt != null && dt.Rows.Count > 0)
             {
                 foreach (DataRow dr in dt.Rows)
                 {
                     this.select_模板.Items.Add(new  ListItem( dr["name"].ToString(),dr["id"].ToString()));
                 }
             }
        }

        private void loadprince()
        {
            //rptPrince.DataSource = XmlToDataTableByFile();
           rptPrince.DataSource = CXmlFileToDataSet("Provinces.xml").Tables[0];
            rptPrince.DataBind();
        }

        private void initchk(string areas)
        {
            for (int i = 0; i < rptPrince.Items.Count; i++)
            {
                string provname =  ((HiddenField)rptPrince.Items[i].FindControl("procname")).Value;
                HtmlInputCheckBox cb = (HtmlInputCheckBox)rptPrince.Items[i].FindControl("provck");
                if (areas.Contains(provname))
                {
                    cb.Checked = true;
                }
            }
        }

        //static DataTable XmlToDataTableByFile()
        //{
        //    string filename = HttpContext.Current.Server.MapPath("Provinces.xml");
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(filename);    //加载Xml文件
        //    DataTable dt = new DataTable("Province");
        //    //以第一个元素song的子元素建立表结构
        //    XmlNode songNode = doc.SelectSingleNode("Provinces[1]");
        //    string colName;
        //    dt.Columns.Add("Province");
        //    //if (songNode != null)
        //    //{
        //    //    for (int i = 0; i < songNode.ChildNodes.Count; i++)
        //    //    {
        //    //        colName = songNode.ChildNodes.Item(i).Name;
        //    //        dt.Columns.Add(colName);
        //    //    }
        //    //}
        //    DataSet ds = new DataSet("Provinces");
        //    ds.Tables.Add(dt);
        //    ds.ReadXml(filename);
        //    return dt;
        //}

        public static DataSet CXmlFileToDataSet(string xmlFilePath)
        {
            if (!string.IsNullOrEmpty(xmlFilePath))
            {
                string path = HttpContext.Current.Server.MapPath(xmlFilePath);
                StringReader StrStream = null;
                XmlTextReader Xmlrdr = null;
                try
                {
                    XmlDocument xmldoc = new XmlDocument();
                    //根据地址加载Xml文件
                    xmldoc.Load(path);

                    DataSet ds = new DataSet();
                    //读取文件中的字符流
                    StrStream = new StringReader(xmldoc.InnerXml);
                    //获取StrStream中的数据
                    Xmlrdr = new XmlTextReader(StrStream);
                    //ds获取Xmlrdr中的数据
                    ds.ReadXml(Xmlrdr);
                    return ds;
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    //释放资源
                    if (Xmlrdr != null)
                    {
                        Xmlrdr.Close();
                        StrStream.Close();
                        StrStream.Dispose();
                    }
                }
            }
            else
            {
                return null;
            }
        }
    }
}