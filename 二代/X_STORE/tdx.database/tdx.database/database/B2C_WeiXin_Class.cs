using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creatrue.kernel;
using System.Data.SqlClient;
using System.Data;

namespace tdx.database
{
    public class B2C_WeiXin_Class
    {
        public int id = 0;
        public string number = "";
        public string name = "";
        public string image = "";
        public string url = "";
        public int sort = 99;

        public string describe = "";
        public int is_active = 0;
        public int is_delete = 0;
      
        public DateTime reg_time = System.DateTime.Now;
       
        public int fat_Id = 0;
        public int class_level = 0;
        public int child_number = 0;
        public int city_ID=0;
        public int count_child = 0;

        public B2C_WeiXin_Class() { }
        public B2C_WeiXin_Class(int _id)
        {
            this.id = _id;
            this.LoadData();
        }
        public B2C_WeiXin_Class(string _uname)
        {
            this.number = _uname;
            this.id = 0;
            this.LoadData();
        }
        public static DataTable GetList(string _dzd, string _sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = comfun.GetDataTableBySQL("select " + _dzd + " from weixin_class where " + _sql + "");
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
            _sql += " from weixin_class where 1=1";
            if (this.id != 0)
            {
                _sql += " and id=" + this.id;
            }
            else if (this.number != "")
            {
                _sql += " and number='" + this.number + "'";
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
                throw (new Exception("weixin_class取值不唯一."));
            }
            else if (dt.Rows.Count < 1)
            {
                throw (new Exception("weixin_class没有找到."));
            }
            else
            {
                DataRow dr = dt.Rows[0];
                id = Convert.IsDBNull(dr["id"]) ? 0 : Convert.ToInt32(dr["id"]);
                number = Convert.IsDBNull(dr["number"]) ? "" : Convert.ToString(dr["number"]);
                name = Convert.IsDBNull(dr["name"]) ? "" : Convert.ToString(dr["name"]);
                
                image = Convert.IsDBNull(dr["image"]) ? "" : Convert.ToString(dr["image"]);
                url = Convert.IsDBNull(dr["url"]) ? "" : Convert.ToString(dr["url"]);
                sort = Convert.IsDBNull(dr["sort"]) ? 0 : Convert.ToInt32(dr["sort"]);
               
                describe = Convert.IsDBNull(dr["describe"]) ? "" : Convert.ToString(dr["describe"]);

                is_active = Convert.IsDBNull(dr["is_active"]) ? 0 : Convert.ToInt32(dr["is_active"]);
                is_delete = Convert.IsDBNull(dr["is_delete"]) ? 0 : Convert.ToInt32(dr["is_delete"]);
                reg_time = Convert.IsDBNull(dr["reg_time"]) ? System.DateTime.Now : Convert.ToDateTime(dr["reg_time"]);
                fat_Id = Convert.IsDBNull(dr["fat_Id"]) ? 0 : Convert.ToInt32(dr["fat_Id"]);
                class_level = Convert.IsDBNull(dr["class_level"]) ? 0 : Convert.ToInt32(dr["class_level"]);
                child_number = Convert.IsDBNull(dr["child_number"]) ? 0 : Convert.ToInt32(dr["child_number"]);
                city_ID = Convert.IsDBNull(dr["city_ID"]) ? 0 : Convert.ToInt32(dr["city_ID"]);
                count_child = Convert.IsDBNull(dr["count_child"]) ? 0 : Convert.ToInt32(dr["count_child"]);
                dr = null;
            }
            dt.Dispose();
            dt = null;
        }
        /// <summary>
        /// 插入方法
        /// </summary>

        private void myInsertMethod(string _number, string _name, string _image, string _url, int _sort, string _describe, int _is_active, int _is_delete, int _fat_Id, int _class_level, int _child_number, int _city_ID, int _count_child)
        {
            if (!string.IsNullOrEmpty(_number))
            {
                this.name = _name;
            }
            else
            {
                throw new NotSupportedException("请输入名称");
            }

            string sql = @"insert into weixin_class(number,name,image,url,sort,describe,is_active,is_delete,reg_time,fat_Id,class_level,child_number,city_ID,count_child) 
                         values (@number,@name,@image,@url,@sort,@describe,@is_active,@is_delete,@reg_time,@fat_Id,@class_level,@child_number,@city_ID,@count_child)";
            SqlParameter[] paras = new SqlParameter[] { 
                    new SqlParameter("@number", _number), 
                    new SqlParameter("@name", _name), 
                    new SqlParameter("@image", _image), 
                    new SqlParameter("@url", _url), 
                    new SqlParameter("@sort", _sort), 
                    new SqlParameter("@describe", _describe), 
                    new SqlParameter("@is_active", _is_active), 
                    new SqlParameter("@is_delete", _is_delete), 
                    new SqlParameter("@reg_time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")), 
                    new SqlParameter("@fat_Id", _fat_Id), 
                    new SqlParameter("@class_level", _class_level), 
                    new SqlParameter("@child_number", _child_number), 
                    new SqlParameter("@city_ID", _city_ID),
                    new SqlParameter("@count_child", _count_child)
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

        private void myUpdateMethod(int _id, string _number, string _name, string _image, string _url, int _sort, string _describe, int _is_active, int _is_delete, int _fat_Id, int _class_level, int _child_number, int _city_ID,int _count_child)
        {
            string sql = @"update weixin_class set number=@number,name=@name,image=@image,
                         url=@url,sort=@sort,describe=@describe,is_active=@is_active,is_delete=@is_delete,
                         fat_Id=@fat_Id,class_level=@class_level,child_number=@child_number,city_ID=@city_ID,count_child=@count_child where id=@id";
            SqlParameter[] paras = new SqlParameter[] { 
                      new SqlParameter("@number", _number), 
                    new SqlParameter("@name", _name), 
                    new SqlParameter("@image", _image), 
                    new SqlParameter("@url", _url), 
                    new SqlParameter("@sort", _sort), 
                    new SqlParameter("@describe", _describe), 
                    new SqlParameter("@is_active", _is_active), 
                    new SqlParameter("@is_delete", _is_delete), 
                    new SqlParameter("@reg_time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")), 
                    new SqlParameter("@fat_Id", _fat_Id), 
                    new SqlParameter("@class_level", _class_level), 
                    new SqlParameter("@child_number", _child_number), 
                    new SqlParameter("@city_ID", _city_ID),
                    new SqlParameter("@id",_id),
                    new SqlParameter("@count_child",_count_child)
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
                string sql = "delete from weixin_class where id=" + _id;

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
            this.number = "";
            this.name = "";
            this.image ="";
            this.url = "";
            this.sort = 99;
            this.describe = "";
            this.is_active = 0;
            this.is_delete = 0;

            this.reg_time = System.DateTime.Now;
            this.fat_Id = 0;
            this.class_level =0;
            this.child_number = 0;
            this.city_ID = 0;
            this.count_child = 0;
        }
        /// <summary>
        /// 更新方法
        /// </summary>
        public void Update()
        {
            if (this.id != 0)
            {
                this.myUpdateMethod(this.id, this.number, this.name, this.image, this.url, this.sort, this.describe, this.is_active, this.is_delete,this.fat_Id, this.class_level, this.child_number, this.city_ID,this.count_child);
            }
            else
            {
                this.myInsertMethod(this.number, this.name, this.image, this.url, this.sort, this.describe, this.is_active, this.is_delete, this.fat_Id, this.class_level, this.child_number, this.city_ID, this.count_child);
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

            string sql = "delete from weixin_class where id in (" + _ids + ")";
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