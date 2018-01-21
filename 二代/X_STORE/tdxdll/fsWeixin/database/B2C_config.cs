using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using tdx.kernel;

namespace tdx.database
{
    public class B2C_Config
    {
        public int id = 0;                     //编号，自增
        public string shop_name = ""; //名称  
        public string shop_lang = ""; //编码、语言 
        public string shop_addr = "";//地址
        public string shop_zip = "";//邮编
        public string shop_tel = "";//电话
        public string shop_fax = "";//传真
        public string shop_mobile = "";//手机号码
        public string shop_email = "";//Email
        public string shop_url = "";//网址
        public string shop_qq = "";//qq
        public string shop_ww = "";//旺旺
        public string shop_msn = "";//msn
        public string shop_wb = "";//微博
        public string shop_IM = "";//其他IM
        public string shop_beian = "";//备案号
        public string shop_title = "";//
        public string shop_key = "";//
        public string shop_des = "";//
        public string shop_tj = "";//第三方统计代码
        public string shop_path = ""; //存储路径
        public string shop_gif = ""; //logo图片
        public string shop_msg = ""; //简介
        public string shop_ver = ""; //版本号
        public string shop_Auth = ""; //授权
        public DateTime shop_uptime = System.DateTime.Now; //最后更新时间
        public DateTime regtime = System.DateTime.Now; //注册时间
         
        public B2C_Config() { }
        public B2C_Config(int _id)
        {
            id = _id;
            this.load();
        }
        /// <summary>
        /// 根据数据参数c_id读取数据
        /// </summary>
        private void load()
        {
            string sql = "select * from B2C_Config where id=" + id + "";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("B2C_ConfigID：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 1 : Convert.ToInt32(dt.Rows[0]["id"]);
                    shop_name = Convert.IsDBNull(dt.Rows[0]["shop_name"]) ? "" : Convert.ToString(dt.Rows[0]["shop_name"]); ; //名称  
                    shop_lang = Convert.IsDBNull(dt.Rows[0]["shop_lang"]) ? "" : Convert.ToString(dt.Rows[0]["shop_lang"]); ; //编码、语言 
                    shop_addr = Convert.IsDBNull(dt.Rows[0]["shop_addr"]) ? "" : Convert.ToString(dt.Rows[0]["shop_addr"]); ;//地址
                    shop_zip = Convert.IsDBNull(dt.Rows[0]["shop_zip"]) ? "" : Convert.ToString(dt.Rows[0]["shop_zip"]); ;//邮编
                    shop_tel = Convert.IsDBNull(dt.Rows[0]["shop_tel"]) ? "" : Convert.ToString(dt.Rows[0]["shop_tel"]); ;//电话
                    shop_fax = Convert.IsDBNull(dt.Rows[0]["shop_fax"]) ? "" : Convert.ToString(dt.Rows[0]["shop_fax"]); ;//传真
                    shop_mobile = Convert.IsDBNull(dt.Rows[0]["shop_mobile"]) ? "" : Convert.ToString(dt.Rows[0]["shop_mobile"]); ;//手机号码
                    shop_email = Convert.IsDBNull(dt.Rows[0]["shop_email"]) ? "" : Convert.ToString(dt.Rows[0]["shop_email"]); ;//Email
                    shop_url = Convert.IsDBNull(dt.Rows[0]["shop_url"]) ? "" : Convert.ToString(dt.Rows[0]["shop_url"]); ;//网址
                    shop_qq = Convert.IsDBNull(dt.Rows[0]["shop_qq"]) ? "" : Convert.ToString(dt.Rows[0]["shop_qq"]); ;//qq
                    shop_ww = Convert.IsDBNull(dt.Rows[0]["shop_ww"]) ? "" : Convert.ToString(dt.Rows[0]["shop_ww"]); ;//旺旺
                    shop_msn = Convert.IsDBNull(dt.Rows[0]["shop_msn"]) ? "" : Convert.ToString(dt.Rows[0]["shop_msn"]); ;//msn
                    shop_wb = Convert.IsDBNull(dt.Rows[0]["shop_wb"]) ? "" : Convert.ToString(dt.Rows[0]["shop_wb"]); ;//微博
                    shop_IM = Convert.IsDBNull(dt.Rows[0]["shop_IM"]) ? "" : Convert.ToString(dt.Rows[0]["shop_IM"]); ;//其他IM
                    shop_beian = Convert.IsDBNull(dt.Rows[0]["shop_beian"]) ? "" : Convert.ToString(dt.Rows[0]["shop_beian"]); ;//备案号
                    shop_title = Convert.IsDBNull(dt.Rows[0]["shop_title"]) ? "" : Convert.ToString(dt.Rows[0]["shop_title"]); ;//
                    shop_key = Convert.IsDBNull(dt.Rows[0]["shop_key"]) ? "" : Convert.ToString(dt.Rows[0]["shop_key"]); ;//
                    shop_des = Convert.IsDBNull(dt.Rows[0]["shop_des"]) ? "" : Convert.ToString(dt.Rows[0]["shop_des"]); ;//
                    shop_tj = Convert.IsDBNull(dt.Rows[0]["shop_tj"]) ? "" : Convert.ToString(dt.Rows[0]["shop_tj"]); ;//第三方统计代码
                    shop_path = Convert.IsDBNull(dt.Rows[0]["shop_path"]) ? "" : Convert.ToString(dt.Rows[0]["shop_path"]); ; //存储路径
                    shop_gif = Convert.IsDBNull(dt.Rows[0]["shop_gif"]) ? "" : Convert.ToString(dt.Rows[0]["shop_gif"]); ; //logo图片
                    shop_msg = Convert.IsDBNull(dt.Rows[0]["shop_msg"]) ? "" : Convert.ToString(dt.Rows[0]["shop_msg"]); ; //简介
                    shop_ver = Convert.IsDBNull(dt.Rows[0]["shop_ver"]) ? "" : Convert.ToString(dt.Rows[0]["shop_ver"]); ; //版本号
                    shop_Auth = Convert.IsDBNull(dt.Rows[0]["shop_Auth"]) ? "" : Convert.ToString(dt.Rows[0]["shop_Auth"]); ; //授权
                    shop_uptime = Convert.IsDBNull(dt.Rows[0]["shop_uptime"]) ? System.DateTime.Now : Convert.ToDateTime(dt.Rows[0]["shop_uptime"]); ; //最后更新时间
                    regtime = Convert.IsDBNull(dt.Rows[0]["regtime"]) ? System.DateTime.Now : Convert.ToDateTime(dt.Rows[0]["regtime"]); ; //注册时间                    
                }
            }
            else
            {
                throw new NotSupportedException("B2C_ConfigID：" + id + "不存在");
            }

        }

        /// <summary>
        /// 增加一条新的记录
        /// </summary>
        private void myInsert(string _shop_name, string _shop_lang, string _shop_addr, string _shop_zip, string _shop_tel, string _shop_fax, string _shop_mobile, string _shop_email, string _shop_url, string _shop_qq, string _shop_ww, string _shop_msn, string _shop_wb, string _shop_IM, string _shop_beian, string _shop_title, string _shop_key, string _shop_des, string _shop_tj, string _shop_path, string _shop_gif, string _shop_msg, string _shop_ver, string _shop_Auth)
        {
            try
            {
                string sql = "insert into B2C_Config ( shop_name , shop_lang , shop_addr ,shop_zip ,shop_tel , shop_fax , shop_mobile , shop_email , shop_url ,  shop_qq, shop_ww , shop_msn , shop_wb ,   shop_IM ,shop_beian, shop_title , shop_key , shop_des ,shop_tj , shop_path ,shop_gif ,  shop_msg , shop_ver ,   shop_Auth) values ( @shop_name , @shop_lang , @shop_addr ,@shop_zip ,@shop_tel , @shop_fax , @shop_mobile , @shop_email , @shop_url ,  @shop_qq, @shop_ww , @shop_msn , @shop_wb ,   @shop_IM ,@shop_beian, @shop_title , @shop_key , @shop_des ,@shop_tj , @shop_path ,@shop_gif ,  @shop_msg , @shop_ver ,   @shop_Auth)";
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@shop_name", _shop_name), 
                    new SqlParameter("@shop_lang", _shop_lang), 
                    new SqlParameter("@shop_addr", _shop_addr),
                    new SqlParameter("@shop_zip", _shop_zip),
                    new SqlParameter("@shop_tel", _shop_tel),
                    new SqlParameter("@shop_fax", _shop_fax),
                    new SqlParameter("@shop_mobile", _shop_mobile), 
                    new SqlParameter("@shop_email", _shop_email), 
                    new SqlParameter("@shop_url", _shop_url),
                    new SqlParameter("@shop_qq", _shop_qq),
                    new SqlParameter("@shop_ww", _shop_ww),
                    new SqlParameter("@shop_msn", _shop_msn),
                    new SqlParameter("@shop_wb", _shop_wb),
                    new SqlParameter("@shop_IM", _shop_IM),
                    new SqlParameter("@shop_beian", _shop_beian),
                    new SqlParameter("@shop_title", _shop_title),
                    new SqlParameter("@shop_key", _shop_key),
                    new SqlParameter("@shop_des", _shop_des),
                    new SqlParameter("@shop_tj", _shop_tj),
                    new SqlParameter("@shop_path", _shop_path),
                    new SqlParameter("@shop_gif", _shop_gif),
                    new SqlParameter("@shop_msg", _shop_msg),
                    new SqlParameter("@shop_ver", _shop_ver),
                    new SqlParameter("@shop_Auth", _shop_Auth) };

                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        /// <summary>
        /// 修改一条新的记录
        /// </summary>
        private void myUpdate(int _id, string _shop_name, string _shop_lang, string _shop_addr, string _shop_zip, string _shop_tel, string _shop_fax, string _shop_mobile, string _shop_email, string _shop_url, string _shop_qq, string _shop_ww, string _shop_msn, string _shop_wb, string _shop_IM, string _shop_beian, string _shop_title, string _shop_key, string _shop_des, string _shop_tj, string _shop_path, string _shop_gif, string _shop_msg, string _shop_ver, string _shop_Auth)
        {
            try
            {
                string sql = "update B2C_Config set shop_name=@shop_name,shop_lang=@shop_lang,shop_addr=@shop_addr,shop_zip=@shop_zip,shop_tel=@shop_tel,shop_fax=@shop_fax,shop_mobile=@shop_mobile,shop_email=@shop_email,shop_url=@shop_url,shop_qq=@shop_qq,shop_ww=@shop_ww,shop_msn=@shop_msn,shop_wb=@shop_wb,shop_im=@shop_im,shop_beian=@shop_beian,shop_title=@shop_title,shop_key=@shop_key,shop_des=@shop_des,shop_tj=@shop_tj,shop_path=@shop_path,shop_gif=@shop_gif,shop_msg=@shop_msg,shop_ver=@shop_ver,shop_auth=@shop_auth where id=" + _id;
                SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@shop_name", _shop_name), 
                    new SqlParameter("@shop_lang", _shop_lang), 
                    new SqlParameter("@shop_addr", _shop_addr),
                    new SqlParameter("@shop_zip", _shop_zip),
                    new SqlParameter("@shop_tel", _shop_tel),
                    new SqlParameter("@shop_fax", _shop_fax),
                    new SqlParameter("@shop_mobile", _shop_mobile), 
                    new SqlParameter("@shop_email", _shop_email), 
                    new SqlParameter("@shop_url", _shop_url),
                    new SqlParameter("@shop_qq", _shop_qq),
                    new SqlParameter("@shop_ww", _shop_ww),
                    new SqlParameter("@shop_msn", _shop_msn),
                    new SqlParameter("@shop_wb", _shop_wb),
                    new SqlParameter("@shop_IM", _shop_IM),
                    new SqlParameter("@shop_beian", _shop_beian),
                    new SqlParameter("@shop_title", _shop_title),
                    new SqlParameter("@shop_key", _shop_key),
                    new SqlParameter("@shop_des", _shop_des),
                    new SqlParameter("@shop_tj", _shop_tj),
                    new SqlParameter("@shop_path", _shop_path),
                    new SqlParameter("@shop_gif", _shop_gif),
                    new SqlParameter("@shop_msg", _shop_msg),
                    new SqlParameter("@shop_ver", _shop_ver),
                    new SqlParameter("@shop_Auth", _shop_Auth)};

                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary> 
        public static int myDel(int _cid)
        {
            int res = 0;
            string sql = "delete from B2C_Config where id=" + _cid + "";
            try
            {
                comfun.UpdateBySQL(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        /// <summary>
        /// 根据参数判断添加或者修改
        /// </summary>
        public void Update()
        {
            if (id == 0)
            {
                this.myInsert(shop_name, shop_lang, shop_addr, shop_zip, shop_tel, shop_fax, shop_mobile, shop_email, shop_url, shop_qq, shop_ww, shop_msn, shop_wb, shop_IM, shop_beian, shop_title, shop_key, shop_des, shop_tj, shop_path, shop_gif, shop_msg, shop_ver, shop_Auth);
            }
            else
            {
                this.myUpdate(id, shop_name, shop_lang, shop_addr, shop_zip, shop_tel, shop_fax, shop_mobile, shop_email, shop_url, shop_qq, shop_ww, shop_msn, shop_wb, shop_IM, shop_beian, shop_title, shop_key, shop_des, shop_tj, shop_path, shop_gif, shop_msg, shop_ver, shop_Auth);
            }
        }
        /// <summary>
        /// 添加方法
        /// </summary>
        public void Addnew()
        {
            id = 0;
            shop_name = ""; //名称  
            shop_lang = ""; //编码、语言 
            shop_addr = "";//地址
            shop_zip = "";//邮编
            shop_tel = "";//电话
            shop_fax = "";//传真
            shop_mobile = "";//手机号码
            shop_email = "";//Email
            shop_url = "";//网址
            shop_qq = "";//qq
            shop_ww = "";//旺旺
            shop_msn = "";//msn
            shop_wb = "";//微博
            shop_IM = "";//其他IM
            shop_beian = "";//备案号
            shop_title = "";//
            shop_key = "";//
            shop_des = "";//
            shop_tj = "";//第三方统计代码
            shop_path = ""; //存储路径
            shop_gif = ""; //logo图片
            shop_msg = ""; //简介
            shop_ver = ""; //版本号
            shop_Auth = ""; //授权
            shop_uptime = System.DateTime.Now; //最后更新时间
            regtime = System.DateTime.Now; //注册时间
        }

        public static DataTable GetList(int _page, string _dzd, string _sql)
        {
            int totalcount = 0;
            int totalpage = 0;
            int pagesize = consts.pagesize_Txt;
            int beginItem = 0;
            int endItem = 0;

            string sql = "select count(*) from B2C_Config where 1=1 and " + _sql + " ";
            totalcount = Convert.ToInt32(comfun.GetDataTableBySQL(sql).Rows[0][0]);
            totalpage = totalcount / pagesize;
            if (totalpage < totalcount / pagesize)
            {
                totalpage = totalpage + 1;
            }

            beginItem = pagesize * (_page - 1);
            endItem = pagesize * _page - 1;
            if (endItem > (totalcount - 1))
            {
                endItem = totalcount - 1;
            }

            if (beginItem < 0)
            {
                beginItem = 0;
            }

            try
            {
                DataTable proTable = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_Config where " + _sql + " order by id desc");
                DataTable dt2 = proTable.Clone();
                for (int i = beginItem; i <= endItem; i++)
                {
                    dt2.ImportRow(proTable.Rows[i]);
                }
                return dt2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
    }
}
