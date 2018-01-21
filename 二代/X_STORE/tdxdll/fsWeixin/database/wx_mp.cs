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
    public class wx_mp
    {
        public int id = 0;
        public int wid = 0;
        public string wname = "";
        public string cno = "";
        public string ano = "";
        public string wx_name = "";
        public string wx_nichen = "";
        public string wx_2wm = "";
        public string wx_ID = "";
        public string wx_DID = "";
        public string wx_Dpsw = "";
        public int wx_FirstIsGif = 1;
        public string wx_des = "";
        public int wx_cid = 1;
        public string wx_cname = "服务号";
        public int wx_isActive = 1;
        public DateTime regtime = System.DateTime.Now;
      
 
        #region " No Parameter "
        public wx_mp()
        {
        }
        #endregion

        #region " With Parameter "
        public wx_mp(int _id)
        {
            id = _id;
            this.LoadData();
        }
        public wx_mp(string _wxID)
        {
            this.wx_ID = _wxID;
            this.LoadData();
        }
        #endregion

        private void LoadData()
        {
            string _sql = "SELECT *,(select m_name from b2c_worker where wx_mp.wid=b2c_worker.id) as wname ";
			_sql +=" FROM wx_mp WHERE id = " + this.id ;
            if (!string.IsNullOrEmpty(wx_ID))
            {
                _sql = "SELECT *,(select m_name from b2c_worker where wx_mp.wid=b2c_worker.id) as wname ";
                _sql += " FROM wx_mp WHERE wx_ID = '" + this.wx_ID + "'";
            }

            DataTable dt = comfun.GetDataTableBySQL(_sql);    
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("wx_mpID：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 0 : Convert.ToInt32(dt.Rows[0]["id"]);
                    wid = Convert.IsDBNull(dt.Rows[0]["wid"]) ? 0 : Convert.ToInt32(dt.Rows[0]["wid"]);
                    wname = Convert.IsDBNull(dt.Rows[0]["wname"]) ? "" : Convert.ToString(dt.Rows[0]["wname"]);
                    cno = Convert.IsDBNull(dt.Rows[0]["cno"]) ? "" : Convert.ToString(dt.Rows[0]["cno"]);
                    ano = Convert.IsDBNull(dt.Rows[0]["ano"]) ? "" : Convert.ToString(dt.Rows[0]["ano"]);
                    wx_name = Convert.IsDBNull(dt.Rows[0]["wx_name"]) ? "" : Convert.ToString(dt.Rows[0]["wx_name"]);
                    wx_nichen = Convert.IsDBNull(dt.Rows[0]["wx_nichen"]) ? "" : Convert.ToString(dt.Rows[0]["wx_nichen"]);
                    wx_2wm = Convert.IsDBNull(dt.Rows[0]["wx_2wm"]) ? "" : Convert.ToString(dt.Rows[0]["wx_2wm"]);
                    wx_ID = Convert.IsDBNull(dt.Rows[0]["wx_ID"]) ? "" : Convert.ToString(dt.Rows[0]["wx_ID"]);
                    wx_DID = Convert.IsDBNull(dt.Rows[0]["wx_DID"]) ? "" : Convert.ToString(dt.Rows[0]["wx_DID"]);
                    wx_Dpsw = Convert.IsDBNull(dt.Rows[0]["wx_Dpsw"]) ? "" : Convert.ToString(dt.Rows[0]["wx_Dpsw"]);
                    wx_FirstIsGif = Convert.IsDBNull(dt.Rows[0]["wx_FirstIsGif"]) ? 1 : Convert.ToInt32(dt.Rows[0]["wx_FirstIsGif"]);
                    wx_des = Convert.IsDBNull(dt.Rows[0]["wx_des"]) ? "" : Convert.ToString(dt.Rows[0]["wx_des"]);
                    wx_cid = Convert.IsDBNull(dt.Rows[0]["wx_cid"]) ? 1 : Convert.ToInt32(dt.Rows[0]["wx_cid"]);
                    wx_cname = wx_cid == 1 ? "服务号" : "订阅号";
                    wx_isActive = Convert.IsDBNull(dt.Rows[0]["wx_isActive"]) ? 1 : Convert.ToInt32(dt.Rows[0]["wx_isActive"]);
                    regtime = Convert.IsDBNull(dt.Rows[0]["regtime"]) ? System.DateTime.Now : Convert.ToDateTime(dt.Rows[0]["regtime"]); 
                  
                }
            }
            else
            {
                throw new NotSupportedException("wx_mpID：" + id + "不存在");
            }
        }

        /// <summary>
        /// 添加一条记录
        /// </summary>
        private void MyInsertMethod(int _wid,string _cno,string _ano,string _wx_name, string _wx_nichen, string _wx_2wm, string _wx_ID, string _wx_DID,string _wx_Dpsw, int _wx_FirstIsGif,string _wx_des,int _wx_cid)
        {

            string queryString = " INSERT INTO wx_mp (wid,cno,ano,wx_name,wx_nichen,wx_2wm,wx_ID,wx_DID,wx_Dpsw,wx_FirstIsGif,wx_des,wx_cid)";
            queryString += " VALUES (@wid,@cno,@ano,@wx_name,@wx_nichen,@wx_2wm,@wx_ID,@wx_DID,@wx_Dpsw,@wx_FirstIsGif,@wx_des,@wx_cid)";
           
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@wid", _wid), 
                new SqlParameter("@cno", _cno),
                new SqlParameter("@ano", _ano),
                new SqlParameter("@wx_name", _wx_name),
                new SqlParameter("@wx_nichen", _wx_nichen),
                new SqlParameter("@wx_2wm", _wx_2wm),
                new SqlParameter("@wx_ID", _wx_ID),
                new SqlParameter("@wx_DID", _wx_DID),
                new SqlParameter("@wx_Dpsw", _wx_Dpsw),
                new SqlParameter("@wx_FirstIsGif", _wx_FirstIsGif),
                new SqlParameter("@wx_des", _wx_des),
                new SqlParameter("@wx_cid", _wx_cid)  };

            try
            {
                comfun con = new comfun();
                con.ExecuteNonQuery(queryString, paras);

                string _sql = "";
                _sql += "\r\n; insert into wx_keys(k_words,k_answer,fid,cityID,k_isSys) values('?,？,help,帮助,帮忙,求助','输入1,查看商品；输入2，查看新闻；输入3，查看介绍',0,{0},2)"; //创建几条关键词
                _sql += "\r\n; insert into wx_keys(k_words,k_answer,fid,cityID,k_isSys) values('产品,products,pro,1','',1,{0},2)";
                _sql += "\r\n; insert into wx_keys(k_words,k_answer,fid,cityID,k_isSys) values('2,新闻,new,news','',5,{0},2)";
                _sql += "\r\n; insert into wx_keys(k_words,k_answer,fid,cityID,k_isSys) values('3,关于,介绍,公司','',8,{0},2)";
                _sql += "\r\n; insert into wx_keys(k_words,k_answer,fid,cityID,k_isSys) values('产品类别','',2,{0},2)";
                _sql += "\r\n; insert into wx_keys(k_words,k_answer,fid,cityID,k_isSys) values('优惠券,yhq','',6,{0},2)";
                _sql += "\r\n; insert into wx_keys(k_words,k_answer,fid,cityID,k_isSys) values('抽奖,cj,活动','',7,{0},2)";
                _sql += "\r\n;insert into b2c_ads(cno,a_name,a_gif,a_adgif,a_url,cityID,a_isSys) values('001','欢迎收听[$昵称$]','/upload/201311/12/201311121955150.jpg','/upload/201311/12/201311121955150.jpg','http://www.tdx.cn/appv/index.aspx',{0},1)";
                _sql += "\r\n;insert into b2c_ads(cno,a_name,a_gif,a_adgif,a_url,cityID,a_isSys) values('003','您输入的关键词是[$关键词$]','/upload/201311/12/201311121955150.jpg','/upload/201311/12/201311121955150.jpg','http://www.tdx.cn/appv/index.aspx',{0},1)";
                _sql += "\r\n;insert into b2c_ads(cno,a_name,a_gif,a_adgif,a_url,cityID,a_isSys) values('007','优惠券','/upload/201311/12/201311121955150.jpg','/upload/201311/12/201311121955150.jpg','http://www.tdx.cn/appv/index.aspx',{0},1)";
                _sql += "\r\n;insert into b2c_ads(cno,a_name,a_gif,a_adgif,a_url,cityID,a_isSys) values('008','抽奖','/upload/201311/12/201311121955150.jpg','/upload/201311/12/201311121955150.jpg','http://www.tdx.cn/appv/honor_action.aspx',{0},1)";
            
                this.wx_ID = _wx_ID;
                this.LoadData();
                _sql = string.Format(_sql, this.id.ToString());
                comfun.UpdateBySQL(_sql);

            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }

        private void MyUpdateMethod(int _id, int _wid, string _cno, string _ano, string _wx_name, string _wx_nichen, string _wx_2wm, string _wx_ID, string _wx_DID, string _wx_Dpsw, int _wx_FirstIsGif, string _wx_des, int _wx_cid)
        {
            string queryString = "UPDATE wx_mp SET wid=@wid,cno=@cno,ano=@ano,wx_name=@wx_name,wx_nichen=@wx_nichen,wx_2wm=@wx_2wm,wx_ID=@wx_ID,wx_DID=@wx_DID,wx_Dpsw=@wx_Dpsw,wx_FirstIsGif=@wx_FirstIsGif,wx_des=@wx_des,wx_cid=@wx_cid WHERE id =" + id;
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@wid", _wid),
                new SqlParameter("@cno", _cno),
                new SqlParameter("@ano", _ano), 
                new SqlParameter("@wx_name", _wx_name),
                new SqlParameter("@wx_nichen", _wx_nichen),
                new SqlParameter("@wx_2wm", _wx_2wm),
                new SqlParameter("@wx_ID", _wx_ID),
                new SqlParameter("@wx_DID", _wx_DID),
                new SqlParameter("@wx_Dpsw", _wx_Dpsw),
                new SqlParameter("@wx_FirstIsGif", _wx_FirstIsGif),
                new SqlParameter("@wx_des", _wx_des),
                new SqlParameter("@wx_cid", _wx_cid) }; 

            try
            {
                comfun con = new comfun();
                con.ExecuteNonQuery(queryString, paras);

            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }


        #region " 添加、修改、删除 "
        public void AddNew()
        {
            id = 0;
            wid = 0;
            wname = "";
            cno = "";
            ano = "";
            wx_name = "";
            wx_nichen = "";
            wx_2wm = "";
            wx_ID = "";
            wx_DID = "";
            wx_Dpsw = "";
            wx_FirstIsGif = 1;
            wx_des = "";
            wx_cid = 1;
            wx_cname = "服务号";
            wx_isActive = 1;
            regtime = System.DateTime.Now; 
        }
        public void Update()
        {
            if (id == 0)
            {
                this.MyInsertMethod(this.wid,this.cno,this.ano,this.wx_name,this.wx_nichen,this.wx_2wm,this.wx_ID,this.wx_DID,this.wx_Dpsw,this.wx_FirstIsGif,this.wx_des,this.wx_cid);
            }
            else
            {
                this.MyUpdateMethod(this.id, this.wid, this.cno, this.ano, this.wx_name, this.wx_nichen, this.wx_2wm, this.wx_ID, this.wx_DID, this.wx_Dpsw, this.wx_FirstIsGif, this.wx_des, this.wx_cid);
            }
        }

        public static int Delete(int _id)
        {
            //删除图片
            wx_mp tt = new wx_mp(_id);
            int _wid = (System.Web.HttpContext.Current.Session["wID"]==null?0:Convert.ToInt32(System.Web.HttpContext.Current.Session["wID"].ToString()));
            if (_wid == 0 || _wid != tt.wid)
            {
                throw new NotSupportedException("不是您的微信公众号不能删除.");
            }
            if (!string.IsNullOrEmpty(tt.wx_2wm))
            {
                if (System.IO.File.Exists(System.Web.HttpContext.Current.Request.MapPath(tt.wx_2wm)))
                {
                    System.IO.File.Delete(System.Web.HttpContext.Current.Request.MapPath(tt.wx_2wm));
                }
            }
            string _sql = "delete from wx_mp where id=" + _id.ToString();
            _sql += "\r\n;delete from wx_keys where cityID=" + _id.ToString();
            _sql += "\r\n;delete from b2c_ads where cityID=" + _id.ToString();
            //还要删除自定义菜单
            try
            {
                return comfun.UpdateBySQL(_sql);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException("wx_mpID：" + _id + "删除失败" + ex.Message.Replace("'",""));
            }
        }

        #endregion 

        public static DataTable GetWxList(int _wid)
        {
            DataTable dt = comfun.GetDataTableBySQL("SELECT *,(select m_name from b2c_worker where wx_mp.wid=b2c_worker.id) as wname,(select wx_GNTheme from b2c_worker where wx_mp.wid=b2c_worker.id) as GNTheme from wx_mp where wid=" + _wid); 
            return dt;
        }
        public static DataTable GetWxList(string _sql, int _page,int pagesize)
        {
            string sql = "SELECT row_number() over(order by g_wdate desc) as rown,*,(select m_name from b2c_worker where wx_mp.wid=b2c_worker.id) as wname from wx_mp where 1=1 and " + _sql;
            sql = "with c as (" + sql + ") select top " + pagesize.ToString() + " * from c where rown > " + ((_page - 1) * pagesize).ToString() + "order by rown";
            
            DataTable dt = comfun.GetDataTableBySQL(sql);
            return dt;
        }
        
    }
}
