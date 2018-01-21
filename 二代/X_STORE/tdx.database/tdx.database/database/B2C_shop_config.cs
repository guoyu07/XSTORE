using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Creatrue.kernel;
using System.Data.SqlClient;

namespace tdx.database
{
    public class B2C_shop_config
    {
         public int id = 0;
        public int wid=0;
        public int sc_isCategory=0;
        public int Sc_isBrand=0;
        public int Sc_isHot=0;
        public int Sc_isNew=1;
        public int Sc_isSpecial=1;
        public int Sc_isMsg=1;

        public string Sc_wx_appId="";
        public string Sc_wx_appSecret="";
        public string Sc_wx_appSignKey="";
        public string Sc_wx_partnerId="";
        public string Sc_wx_partnerKey="";
        public string Sc_yl_securityKey="";
        public string Sc_yl_merId="";
        public string Sc_yl_merAbbr="";
        public string Sc_yl_acqCode="";        

       

        public B2C_shop_config() { }
        public B2C_shop_config(int _id)
        {
            this.id = _id;
            this.LoadData();
        }        
        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from B2C_shop_config where " + _sql + "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static void MyDelete(string _sql)
        {
            try
            {
                comfun.UpdateBySQL(_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //#region "私有方法"
        private void LoadData() //获取数值
        {
            string _sql = "select *";
            _sql += " from B2C_shop_config where 1=1";
            if (this.id != 0)
            {
                _sql += " and id=" + this.id;
            }           
            else
            {
                //跳出函数前，初始化一下所有字段值
                this.AddNew();
                return;
            }
            DataTable dt = comfun.GetDataTableBySQL(_sql);
            if (dt.Rows.Count > 1)
            {
                throw (new Exception("B2C_shop_config取值不唯一."));
            }
            else if (dt.Rows.Count < 1)
            {
                throw (new Exception("B2C_shop_config没有找到."));
            }
            else
            {
                DataRow dr = dt.Rows[0];
                id = Convert.IsDBNull(dr["id"]) ? 0 : Convert.ToInt32(dr["id"]);
                wid = Convert.IsDBNull(dr["wid"]) ? 0 : Convert.ToInt32(dr["wid"]);
                sc_isCategory = Convert.IsDBNull(dr["sc_isCategory"]) ? 0 : Convert.ToInt32(dr["sc_isCategory"]);
                Sc_isBrand = Convert.IsDBNull(dr["Sc_isBrand"]) ? 0 : Convert.ToInt32(dr["Sc_isBrand"]);
                Sc_isHot = Convert.IsDBNull(dr["Sc_isHot"]) ? 0 : Convert.ToInt32(dr["Sc_isHot"]);
                Sc_isNew = Convert.IsDBNull(dr["Sc_isNew"]) ? 0 : Convert.ToInt32(dr["Sc_isNew"]);
                Sc_isSpecial = Convert.IsDBNull(dr["Sc_isSpecial"]) ? 0 : Convert.ToInt32(dr["Sc_isSpecial"]);
                Sc_isMsg = Convert.IsDBNull(dr["Sc_isMsg"]) ? 0 : Convert.ToInt32(dr["Sc_isMsg"]);


                Sc_wx_appId = Convert.IsDBNull(dr["Sc_wx_appId"]) ? "" : Convert.ToString(dr["Sc_wx_appId"]);
                Sc_wx_appSecret = Convert.IsDBNull(dr["Sc_wx_appSecret"]) ? "" : Convert.ToString(dr["Sc_wx_appSecret"]);
                Sc_wx_appSignKey = Convert.IsDBNull(dr["Sc_wx_appSignKey"]) ? "" : Convert.ToString(dr["Sc_wx_appSignKey"]);
                Sc_wx_partnerId = Convert.IsDBNull(dr["Sc_wx_partnerId"]) ? "" : Convert.ToString(dr["Sc_wx_partnerId"]);
                Sc_wx_partnerKey = Convert.IsDBNull(dr["Sc_wx_partnerKey"]) ? "" : Convert.ToString(dr["Sc_wx_partnerKey"]);
                Sc_yl_securityKey = Convert.IsDBNull(dr["Sc_yl_securityKey"]) ? "" : Convert.ToString(dr["Sc_yl_securityKey"]);
                Sc_yl_merId = Convert.IsDBNull(dr["Sc_yl_merId"]) ? "" : Convert.ToString(dr["Sc_yl_merId"]);
                Sc_yl_merAbbr = Convert.IsDBNull(dr["Sc_yl_merAbbr"]) ? "" : Convert.ToString(dr["Sc_yl_merAbbr"]);
                Sc_yl_acqCode = Convert.IsDBNull(dr["Sc_yl_acqCode"]) ? "" : Convert.ToString(dr["Sc_yl_acqCode"]);
                
                dr = null;
            }
            dt.Dispose();
            dt = null;
        }
        /// <summary>
        /// 插入方法
        /// </summary>

        private void myInsertMethod(int _wid, int _sc_isCategory, int _Sc_isBrand, int _Sc_isHot, int _Sc_isNew, int _Sc_isSpecial, int _Sc_isMsg,string _Sc_wx_appId, string _Sc_wx_appSecret, string _Sc_wx_appSignKey, string _Sc_wx_partnerId, string _Sc_wx_partnerKey, string _Sc_yl_securityKey, string _Sc_yl_merId, string _Sc_yl_merAbbr, string _Sc_yl_acqCode)
        {

            string sql = @"insert into B2C_shop_config(wid,sc_isCategory,Sc_isBrand,Sc_isHot,Sc_isNew,Sc_isSpecial,Sc_isMsg,Sc_wx_appId,Sc_wx_appSecret,Sc_wx_appSignKey,Sc_wx_partnerId,Sc_wx_partnerKey,Sc_yl_securityKey,Sc_yl_merId, Sc_yl_merAbbr,Sc_yl_acqCode) 
                         values (@wid,@sc_isCategory,@Sc_isBrand,@Sc_isHot,@Sc_isNew,@Sc_isSpecial,@Sc_isMsg,@Sc_wx_appId,@Sc_wx_appSecret,@Sc_wx_appSignKey,@Sc_wx_partnerId,@Sc_wx_partnerKey,@Sc_yl_securityKey,@Sc_yl_merId, @Sc_yl_merAbbr,@Sc_yl_acqCode)";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@wid", _wid), 
                    new SqlParameter("@sc_isCategory", _sc_isCategory), 
                    new SqlParameter("@Sc_isBrand", _Sc_isBrand), 
                    new SqlParameter("@Sc_isHot", _Sc_isHot), 
                    new SqlParameter("@Sc_isNew", _Sc_isNew), 
                    new SqlParameter("@Sc_isSpecial", _Sc_isSpecial), 
                    new SqlParameter("@Sc_isMsg", _Sc_isMsg), 
                    new SqlParameter("@Sc_wx_appId", _Sc_wx_appId), 
                    new SqlParameter("@Sc_wx_appSecret", _Sc_wx_appSecret), 
                    new SqlParameter("@Sc_wx_appSignKey", _Sc_wx_appSignKey), 
                    new SqlParameter("@Sc_wx_partnerId", _Sc_wx_partnerId), 
                    new SqlParameter("@Sc_wx_partnerKey", _Sc_wx_partnerKey), 
                    new SqlParameter("@Sc_yl_securityKey", _Sc_yl_securityKey),
                    new SqlParameter("@Sc_yl_merId", _Sc_yl_merId),
                    new SqlParameter("@Sc_yl_merAbbr", _Sc_yl_merAbbr),
                    new SqlParameter("@Sc_yl_acqCode", _Sc_yl_acqCode)
                    };

            try
            {
                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
        /// <summary>
        /// 更新方法

        private void myUpdateMethod(int _id, int _wid, int _sc_isCategory, int _Sc_isBrand, int _Sc_isHot, int _Sc_isNew, int _Sc_isSpecial, int _Sc_isMsg, string _Sc_wx_appId, string _Sc_wx_appSecret, string _Sc_wx_appSignKey, string _Sc_wx_partnerId, string _Sc_wx_partnerKey, string _Sc_yl_securityKey, string _Sc_yl_merId, string _Sc_yl_merAbbr, string _Sc_yl_acqCode)
        {
            string sql = @"update B2C_shop_config set wid=@wid,sc_isCategory=@sc_isCategory,Sc_isBrand=@Sc_isBrand,
                         Sc_isHot=@Sc_isHot,Sc_isNew=@Sc_isNew,Sc_isSpecial=@Sc_isSpecial,Sc_isMsg=@Sc_isMsg,Sc_wx_appId=@Sc_wx_appId,
                         Sc_wx_appSecret=@Sc_wx_appSecret,Sc_wx_appSignKey=@Sc_wx_appSignKey,Sc_wx_partnerId=@Sc_wx_partnerId,Sc_wx_partnerKey=@Sc_wx_partnerKey,Sc_yl_securityKey=@Sc_yl_securityKey,
                         Sc_yl_merId=@Sc_yl_merId,Sc_yl_merAbbr=@Sc_yl_merAbbr,Sc_yl_acqCode=@Sc_yl_acqCode  where id=@id";
            SqlParameter[] paras = new SqlParameter[] { 
                     new SqlParameter("@wid", _wid), 
                    new SqlParameter("@sc_isCategory", _sc_isCategory), 
                    new SqlParameter("@Sc_isBrand", _Sc_isBrand), 
                    new SqlParameter("@Sc_isHot", _Sc_isHot), 
                    new SqlParameter("@Sc_isNew", _Sc_isNew), 
                    new SqlParameter("@Sc_isSpecial", _Sc_isSpecial), 
                    new SqlParameter("@Sc_isMsg", _Sc_isMsg), 
                    new SqlParameter("@Sc_wx_appId", _Sc_wx_appId), 
                    new SqlParameter("@Sc_wx_appSecret", _Sc_wx_appSecret), 
                    new SqlParameter("@Sc_wx_appSignKey", _Sc_wx_appSignKey), 
                    new SqlParameter("@Sc_wx_partnerId", _Sc_wx_partnerId), 
                    new SqlParameter("@Sc_wx_partnerKey", _Sc_wx_partnerKey), 
                    new SqlParameter("@Sc_yl_securityKey", _Sc_yl_securityKey),
                    new SqlParameter("@Sc_yl_merId", _Sc_yl_merId),
                    new SqlParameter("@Sc_yl_merAbbr", _Sc_yl_merAbbr),
                    new SqlParameter("@Sc_yl_acqCode", _Sc_yl_acqCode),
                    new SqlParameter("@id",_id)                    
            };
            try
            {
                comfun con = new comfun();
                con.ExecuteNonQuery(sql, paras);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }

        private void myDeleteMethod(int _id)
        {
            if (_id == 0)
            {
                throw new NotSupportedException("没有取得ID号");
            }
            else
            {
                string sql = "delete from B2C_shop_config where id=" + _id;

                try
                {
                    comfun.UpdateBySQL(sql);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
       
        /// <summary>
        /// 添加新纪录
        /// </summary>
        public void AddNew()
        {
           
            this.id = 0;
            this.wid = 0;
            this.sc_isCategory = 0;
            this.Sc_isBrand =0;
            this.Sc_isHot = 0;
            this.Sc_isNew = 1;
            this.Sc_isSpecial = 1;
            this.Sc_isMsg = 1;

            this.Sc_wx_appId="";
            this.Sc_wx_appSecret="";
            this.Sc_wx_appSignKey="";
            this.Sc_wx_partnerId="";
            this.Sc_wx_partnerKey="";
            this.Sc_yl_securityKey="";
            this.Sc_yl_merId="";
            this.Sc_yl_merAbbr="";
            this.Sc_yl_acqCode="";  
        }
        /// <summary>
        /// 更新方法
        /// </summary>
        public void Update()
        {
            if (this.id != 0)
            {
                this.myUpdateMethod(this.id, this.wid, this.sc_isCategory, this.Sc_isBrand, this.Sc_isHot, this.Sc_isNew, this.Sc_isSpecial, this.Sc_isMsg, this.Sc_wx_appId, this.Sc_wx_appSecret, this.Sc_wx_appSignKey, this.Sc_wx_partnerId, this.Sc_wx_partnerKey, this.Sc_yl_securityKey, this.Sc_yl_merId, this.Sc_yl_merAbbr, this.Sc_yl_acqCode);
            }
            else
            {
                this.myInsertMethod(this.wid, this.sc_isCategory, this.Sc_isBrand, this.Sc_isHot, this.Sc_isNew, this.Sc_isSpecial, this.Sc_isMsg, this.Sc_wx_appId, this.Sc_wx_appSecret, this.Sc_wx_appSignKey, this.Sc_wx_partnerId, this.Sc_wx_partnerKey, this.Sc_yl_securityKey, this.Sc_yl_merId, this.Sc_yl_merAbbr, this.Sc_yl_acqCode);
            }
        }
        /// <summary>
        /// 删除方法
        /// </summary>
        public void Delete()
        {
            if (this.id != 0)
                this.myDeleteMethod(this.id);
        }

        //public void updateHits()
        //{
        //    if (this.id != 0)
        //    {
        //        try
        //        {
        //            comfun.UpdateBySQL("update weixin_class set login_time=getDate() where id=" + this.id);
        //        }
        //        finally { }
        //    }
        //}

        //#region "静态方法"
        /// <summary>
        /// 一次彻底删除一组用户
        /// </summary>
        /// <param name="_ids"></param>
        /// <returns></returns>
        public static int delete(string _ids)
        {
            int result = 0;

            string sql = "delete from B2C_shop_config where id in (" + _ids + ")";
            try
            {
                comfun.UpdateBySQL(sql);
                result = 1;
            }
            catch (Exception ex)
            {
                result = 0;
                throw ex;
            }
            return result;
        }
    }
}