
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;//Please add references
namespace DTcms.DAL
{
    /// <summary>
    /// 数据访问类:t_Users
    /// </summary>
    public partial class t_Users
    {
        public t_Users()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "t_Users");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_Users");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DTcms.Model.t_Users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_Users(");
            strSql.Append("nickname,gender,wechatopenid,wechataccesstoken,wechataccesstokenexpiresin,wechatrefreshtoken,wechattokencreatime,areaid,province,city,country,headimgurl,mobile,ismobileconfirmed,consumes,totalprice,regtime,regipaddress,logintime,logintimes,loginipaddress,authenticationsource,name,surname,[password],isemailconfirmed,emailconfirmationcode,passwordresetcode,isactive,username,tenantid,emailaddress,lastlogintime,isdeleted,deleteruserid,deletiontime,lastmodificationtime,lastmodifieruserid,creationtime,creatoruserid)");
            strSql.Append(" values (");
            strSql.Append("@nickname,@gender,@wechatopenid,@wechataccesstoken,@wechataccesstokenexpiresin,@wechatrefreshtoken,@wechattokencreatime,@areaid,@province,@city,@country,@headimgurl,@mobile,@ismobileconfirmed,@consumes,@totalprice,@regtime,@regipaddress,@logintime,@logintimes,@loginipaddress,@authenticationsource,@name,@surname,@[password],@isemailconfirmed,@emailconfirmationcode,@passwordresetcode,@isactive,@username,@tenantid,@emailaddress,@lastlogintime,@isdeleted,@deleteruserid,@deletiontime,@lastmodificationtime,@lastmodifieruserid,@creationtime,@creatoruserid)");
           // strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@nickname", SqlDbType.NVarChar,255),
                    new SqlParameter("@gender", SqlDbType.Int,4),
                    new SqlParameter("@wechatopenid", SqlDbType.NVarChar,255),
                    new SqlParameter("@wechataccesstoken", SqlDbType.NVarChar,255),
                    new SqlParameter("@wechataccesstokenexpiresin", SqlDbType.BigInt,4),
                    new SqlParameter("@wechatrefreshtoken", SqlDbType.NVarChar,255),
                    new SqlParameter("@wechattokencreatime", SqlDbType.DateTime),
                    new SqlParameter("@areaid", SqlDbType.Int,4),
                    new SqlParameter("@province", SqlDbType.NVarChar,30),
                    new SqlParameter("@city", SqlDbType.NVarChar,30),
                    new SqlParameter("@country", SqlDbType.NVarChar,30),
                    new SqlParameter("@headimgurl", SqlDbType.NVarChar,255),
                    new SqlParameter("@mobile", SqlDbType.NVarChar,1000),
                    new SqlParameter("@ismobileconfirmed", SqlDbType.Bit),
                    new SqlParameter("@consumes", SqlDbType.Int,4),
                    new SqlParameter("@totalprice", SqlDbType.Decimal),
                    new SqlParameter("@regtime", SqlDbType.DateTime),
                    new SqlParameter("@regipaddress", SqlDbType.NVarChar,30),
                    new SqlParameter("@logintime", SqlDbType.DateTime),
                    new SqlParameter("@logintimes", SqlDbType.Int,4),
                    new SqlParameter("@loginipaddress", SqlDbType.NVarChar,30),
                    new SqlParameter("@authenticationsource", SqlDbType.NVarChar,64),
                    new SqlParameter("@name", SqlDbType.NVarChar,32),
                    new SqlParameter("@surname", SqlDbType.NVarChar,32),
                    new SqlParameter("@[password]", SqlDbType.NVarChar,328),
                    new SqlParameter("@isemailconfirmed", SqlDbType.Bit),
                    new SqlParameter("@emailconfirmationcode", SqlDbType.NVarChar,328),
                    new SqlParameter("@passwordresetcode", SqlDbType.NVarChar,328),
                    new SqlParameter("@isactive", SqlDbType.Bit),
                    new SqlParameter("@username", SqlDbType.NVarChar,32),
                    new SqlParameter("@tenantid", SqlDbType.Int,4),
                    new SqlParameter("@emailaddress", SqlDbType.NVarChar,256),
                    new SqlParameter("@lastlogintime", SqlDbType.DateTime),
                    new SqlParameter("@isdeleted", SqlDbType.Bit),
                    new SqlParameter("@deleteruserid", SqlDbType.BigInt,4),
                    new SqlParameter("@deletiontime", SqlDbType.DateTime),
                    new SqlParameter("@lastmodificationtime", SqlDbType.DateTime),
                    new SqlParameter("@lastmodifieruserid", SqlDbType.BigInt,4),
                    new SqlParameter("@creationtime", SqlDbType.DateTime),
                    new SqlParameter("@creatoruserid", SqlDbType.BigInt,4)};
                    
            parameters[0].Value=model.nickname;
            parameters[1].Value=model.gender;
            parameters[2].Value=model.wechatopenid;
            parameters[3].Value=model.wechatAccesstoken;
            parameters[4].Value=model.wechataccesstokenExpiresIn;
            parameters[5].Value=model.wechatRefreshToken;
            parameters[6].Value=model.wechattokencreatime;
            parameters[7].Value=model.areaid;
            parameters[8].Value=model.province;
            parameters[9].Value=model.city;
            parameters[10].Value=model.country;
            parameters[11].Value=model.headImgurl;
            parameters[12].Value=model.mobile;
            parameters[13].Value=model.IsMobileConfirmed;
            parameters[14].Value=model.consumes;
            parameters[15].Value=model.totalprice;
            parameters[16].Value=model.regtime;
            parameters[17].Value=model.regipaddress;
            parameters[18].Value=model.logintime;
            parameters[19].Value=model.logintimes;
            parameters[20].Value=model.loginipaddress;
            parameters[21].Value=model.authenticationsource;
            parameters[22].Value=model.name;
            parameters[23].Value=model.surname;
            parameters[24].Value=model.password;
            parameters[25].Value=model.IsEmailconfiremed;
            parameters[26].Value=model.emailcofirmationcode;
            parameters[27].Value=model.passwordresetcode;
            parameters[28].Value=model.IsActive;
            parameters[29].Value=model.username;
            parameters[30].Value=model.tenantid;
            parameters[31].Value=model.emailaddress;
            parameters[32].Value=model.lastlogintime;
            parameters[33].Value=model.isdeleted;
            parameters[34].Value=model.deleteruserid;
            parameters[35].Value=model.deletiontime;
            parameters[36].Value=model.lastmodificationtime;
            parameters[37].Value=model.lastmodifieruserid;
            parameters[38].Value=model.creationtime;
            parameters[39].Value=model.creatoruserid;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DTcms.Model.t_Users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_Users set ");
            strSql.Append("nickname=@nickname"); 
            strSql.Append("gender=@gender");
            strSql.Append("wechatopendid=@wechatopenid");
            strSql.Append("wechataccesstoken=@wechataccesstoken");
            strSql.Append("wechataccesstokenexpiresin=@wechataccesstokenexpiresin");
            strSql.Append("wechatrefreshtoken=@wechatrefreshtoken");
            strSql.Append("wechattokencreatime=@wechattokencreatime");
            strSql.Append("areaid=@areaid");
            strSql.Append("province=@province");
            strSql.Append("city=@city");
            strSql.Append("country=@country");
            strSql.Append("headimgurl=@headimgurl"); 
            strSql.Append("mobile=@mobile");
            strSql.Append("ismobileconfirmed=@ismobileconfiemed");
            strSql.Append("consumes=@consumes");
            strSql.Append("totalprice=@totalprice");
            strSql.Append("regtime=@regtime");
            strSql.Append("regipaddress=@regipaddress");
            strSql.Append("logintime=@logintime");
            strSql.Append("logintimes=@logintimes");
            strSql.Append("loginipaddress=@loginipaddress");
            strSql.Append("authenticationsource=@authenticationsource");
            strSql.Append("name=@name");
            strSql.Append("surname=@surname");
            strSql.Append("password=@password");
            strSql.Append("isemailconfirmed=@isemailconfirmed");
            strSql.Append("emailconfirmationcode=@emailconfirmationcode");
            strSql.Append("passwordresetcode=@passwordresetcode");
            strSql.Append("isactive=@isavitce");
            strSql.Append("username=@username");
            strSql.Append("tenantid=@tenantid");
            strSql.Append("emailaddress=@emailaddress");
            strSql.Append("lastlogintime=@lastlogintime");
            strSql.Append("isdeleted=@isdeleted");
            strSql.Append("deletiontime=@deletiontime");
            strSql.Append("lastmodificationtime=@lastmodificationtime");
            strSql.Append("lastmodifieruserid=@lastmodiferuserid");
            strSql.Append("creationtime=@creationtime");
            strSql.Append("creatoruserid=@creatoruserid");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@nickname", SqlDbType.NVarChar,255),
                    new SqlParameter("@gender", SqlDbType.Int,4),
                    new SqlParameter("@wechatopenid", SqlDbType.NVarChar,255),
                    new SqlParameter("@wechataccesstoken", SqlDbType.NVarChar,255),
                    new SqlParameter("@wechataccesstokenexpiresin", SqlDbType.BigInt,4),
                    new SqlParameter("@wechatrefreshtoken", SqlDbType.NVarChar,255),
                    new SqlParameter("@wechattokencreatime", SqlDbType.DateTime),
                    new SqlParameter("@areaid", SqlDbType.Int,4),
                    new SqlParameter("@province", SqlDbType.NVarChar,30),
                    new SqlParameter("@city", SqlDbType.NVarChar,30),
                    new SqlParameter("@country", SqlDbType.NVarChar,30),
                    new SqlParameter("@headimgurl", SqlDbType.NVarChar,255),
                    new SqlParameter("@mobile", SqlDbType.NVarChar,1000),
                    new SqlParameter("@ismobileconfirmed", SqlDbType.Bit),
                    new SqlParameter("@consumes", SqlDbType.Int,4),
                    new SqlParameter("@totalprice", SqlDbType.Decimal),
                    new SqlParameter("@regtime", SqlDbType.DateTime),
                    new SqlParameter("@regipaddress", SqlDbType.NVarChar,30),
                    new SqlParameter("@logintime", SqlDbType.DateTime),
                    new SqlParameter("@logintimes", SqlDbType.Int,4),
                    new SqlParameter("@loginipaddress", SqlDbType.NVarChar,30),
                    new SqlParameter("@authenticationsource", SqlDbType.NVarChar,64),
                    new SqlParameter("@name", SqlDbType.NVarChar,32),
                    new SqlParameter("@surname", SqlDbType.NVarChar,32),
                    new SqlParameter("@[password]", SqlDbType.NVarChar,328),
                    new SqlParameter("@isemailconfirmed", SqlDbType.Bit),
                    new SqlParameter("@emailconfirmationcode", SqlDbType.NVarChar,328),
                    new SqlParameter("@passwordresetcode", SqlDbType.NVarChar,328),
                    new SqlParameter("@isactive", SqlDbType.Bit),
                    new SqlParameter("@username", SqlDbType.NVarChar,32),
                    new SqlParameter("@tenantid", SqlDbType.Int,4),
                    new SqlParameter("@emailaddress", SqlDbType.NVarChar,256),
                    new SqlParameter("@lastlogintime", SqlDbType.DateTime),
                    new SqlParameter("@isdeleted", SqlDbType.Bit),
                    new SqlParameter("@deleteruserid", SqlDbType.BigInt,4),
                    new SqlParameter("@deletiontime", SqlDbType.DateTime),
                    new SqlParameter("@lastmodificationtime", SqlDbType.DateTime),
                    new SqlParameter("@lastmodifieruserid", SqlDbType.BigInt,4),
                    new SqlParameter("@creationtime", SqlDbType.DateTime),
                    new SqlParameter("@creatoruserid", SqlDbType.BigInt,4)};

            parameters[0].Value = model.nickname;
            parameters[1].Value = model.gender;
            parameters[2].Value = model.wechatopenid;
            parameters[3].Value = model.wechatAccesstoken;
            parameters[4].Value = model.wechataccesstokenExpiresIn;
            parameters[5].Value = model.wechatRefreshToken;
            parameters[6].Value = model.wechattokencreatime;
            parameters[7].Value = model.areaid;
            parameters[8].Value = model.province;
            parameters[9].Value = model.city;
            parameters[10].Value = model.country;
            parameters[11].Value = model.headImgurl;
            parameters[12].Value = model.mobile;
            parameters[13].Value = model.IsMobileConfirmed;
            parameters[14].Value = model.consumes;
            parameters[15].Value = model.totalprice;
            parameters[16].Value = model.regtime;
            parameters[17].Value = model.regipaddress;
            parameters[18].Value = model.logintime;
            parameters[19].Value = model.logintimes;
            parameters[20].Value = model.loginipaddress;
            parameters[21].Value = model.authenticationsource;
            parameters[22].Value = model.name;
            parameters[23].Value = model.surname;
            parameters[24].Value = model.password;
            parameters[25].Value = model.IsEmailconfiremed;
            parameters[26].Value = model.emailcofirmationcode;
            parameters[27].Value = model.passwordresetcode;
            parameters[28].Value = model.IsActive;
            parameters[29].Value = model.username;
            parameters[30].Value = model.tenantid;
            parameters[31].Value = model.emailaddress;
            parameters[32].Value = model.lastlogintime;
            parameters[33].Value = model.isdeleted;
            parameters[34].Value = model.deleteruserid;
            parameters[35].Value = model.deletiontime;
            parameters[36].Value = model.lastmodificationtime;
            parameters[37].Value = model.lastmodifieruserid;
            parameters[38].Value = model.creationtime;
            parameters[39].Value = model.creatoruserid;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_Users ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
            parameters[0].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_Users ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DTcms.Model.t_Users GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,nickname,gender,wechatopenid,wechataccesstoken,wechataccesstokenexpiresin,wechatrefreshtoken,wechattokencreatime,areaid,province,city,country,headimgurl,mobile,ismobileconfirmed,consumes,totalprice,regtime,regipaddress,logintime,logintimes,loginipaddress,authenticationsource,name,surname,[password],isemailconfirmed,emailconfirmationcode,passwordresetcode,isactive,username,tenantid,emailaddress,lastlogintime,isdeleted,deleteruserid,deletiontime,lastmodificationtime,lastmodifieruserid,creationtime,creatoruserid from t_Users ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
            parameters[0].Value = id;

            DTcms.Model.t_Users model = new DTcms.Model.t_Users();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DTcms.Model.t_Users DataRowToModel(DataRow row)
        {
            DTcms.Model.t_Users model = new DTcms.Model.t_Users();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if(row["nickname"]!=null)
                {
                    model.nickname=row["nickname"].ToString();
                }
                if(row["gender"]!=null)
                {
                    model.gender=int.Parse( row["gender"].ToString());
                }
                if(row["wechatopenid"]!=null)
                {
                    model.wechatopenid=row["wechatopenid"].ToString();
                }
                if (row["wechatAccesstoken"] != null)
                {
                    model.wechatAccesstoken = row["wechatAccesstoken"].ToString();
                }
                if (row["wechataccesstokenExpiresIn"] != null)
                {
                    model.wechataccesstokenExpiresIn =int.Parse( row["wechataccesstokenExpiresIn"].ToString());
                }
                if (row["wechatRefreshToken"] != null)
                {
                    model.wechatRefreshToken = row["wechatRefreshToken"].ToString();
                }
                if (row["wechattokencreatime"] != null)
                {
                    model.wechattokencreatime =DateTime.Parse( row["wechattokencreatime"].ToString());
                }
                if(row["areaid"]!=null)
                {
                    model.areaid=int.Parse( row["areaid"].ToString());
                }
                if (row["province"] != null)
                {
                    model.province = row["province"].ToString();
                }
                if (row["city"] != null)
                {
                    model.city = row["city"].ToString();
                }
                if (row["country"] != null)
                {
                    model.country = row["country"].ToString();
                }
                if (row["headImgurl"] != null)
                {
                    model.headImgurl = row["headImgurl"].ToString();
                }
                if (row["mobile"] != null)
                {
                    model.mobile = row["mobile"].ToString();
                }
                if (row["IsMobileConfirmed"] != null)
                {
                    model.IsMobileConfirmed =Boolean.Parse( row["IsMobileConfirmed"].ToString());
                }
                if (row["consumes"] != null)
                {
                    model.consumes = int.Parse(row["consumes"].ToString());
                }
                if (row["totalprice"] != null)
                {
                    model.totalprice =int.Parse( row["totalprice"].ToString());
                }
                if (row["regtime"] != null)
                {
                    model.regtime =DateTime.Parse( row["regtime"].ToString());
                }
                if (row["regipaddress"] != null)
                {
                    model.regipaddress = row["regipaddress"].ToString();
                }
                if (row["logintime"] != null)
                {
                    model.logintime =DateTime.Parse( row["logintime"].ToString());
                }
                if (row["logintimes"] != null)
                {
                    model.logintimes =int.Parse( row["logintimes"].ToString());
                }
                if (row["loginipaddress"] != null)
                {
                    model.loginipaddress = row["loginipaddress"].ToString();
                }
                if (row["authenticationsource"] != null)
                {
                    model.authenticationsource = row["authenticationsource"].ToString();
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["surname"] != null)
                {
                    model.surname = row["surname"].ToString();
                }
                if (row["password"] != null)
                {
                    model.password = row["password"].ToString();
                }
                if (row["IsEmailconfiremed"] != null)
                {
                    model.IsEmailconfiremed =Boolean.Parse( row[""].ToString());
                }
                if (row["emailcofirmationcode "] != null)
                {
                    model.emailcofirmationcode = row["emailcofirmationcode "].ToString();
                }
                if (row["passwordresetcode"] != null)
                {
                    model.passwordresetcode = row["passwordresetcode"].ToString();
                }
                if (row["IsActive"] != null)
                {
                    model.IsActive =Boolean.Parse( row["IsActive"].ToString());
                }
                if (row["username"] != null)
                {
                    model.username = row["username"].ToString();
                }
                if (row["tenantid"] != null)
                {
                    model.tenantid = int.Parse(row["tenantid"].ToString());
                }
                if (row["emailaddress"] != null)
                {
                    model.emailaddress = row["emailaddress"].ToString();
                } if (row["lastlogintime"] != null)
                {
                    model.lastlogintime =DateTime.Parse( row["lastlogintime"].ToString());
                } if (row["isdeleted"] != null)
                {
                    model.isdeleted = Boolean.Parse(row["isdeleted"].ToString());
                } if (row["deleteruserid"] != null)
                {
                    model.deleteruserid = int.Parse(row["deleteruserid"].ToString());
                } if (row["deletiontime"] != null)
                {
                    model.deletiontime = DateTime.Parse(row["deletiontime"].ToString());
                } if (row["lastmodificationtime"] != null)
                {
                    model.lastmodificationtime = DateTime.Parse(row["lastmodificationtime"].ToString());
                } if (row["lastmodifieruserid"] != null)
                {
                    model.lastmodifieruserid = int.Parse(row["lastmodifieruserid"].ToString());
                } if (row["creationtime"] != null)
                {
                    model.creationtime = DateTime.Parse(row["creationtime"].ToString());
                } if (row["creatoruserid"] != null)
                {
                    model.creatoruserid = int.Parse(row["creatoruserid"].ToString()); ;
                }
                //if (row["openid"] != null)
                //{
                //    model.openid = row["openid"].ToString();
                //}
                //if (row["wx昵称"] != null)
                //{
                //    model.wx昵称 = row["wx昵称"].ToString();
                //}
                //if (row["wx头像"] != null)
                //{
                //    model.wx头像 = row["wx头像"].ToString();
                //}
                //if (row["手机号"] != null)
                //{
                //    model.手机号 = row["手机号"].ToString();
                //}

                //if (row["password"] != null)
                //{
                //    model.password = row["password"].ToString();
                //}

                //if (row["email"] != null)
                //{
                //    model.email = row["email"].ToString();
                //}
                //if (row["qq"] != null)
                //{
                //    model.qq = row["qq"].ToString();
                //}
                //if (row["sex"] != null)
                //{
                //    model.sex = row["sex"].ToString();
                //}
                //if (row["jifen"] != null)
                //{
                //    model.jifen = DTcms.Common.Utils.ObjToInt(row["jifen"].ToString(), 0);
                //}
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,nickname,gender,wechatopenid,wechataccesstoken,wechataccesstokenexpiresin,wechatrefreshtoken,wechattokencreatime,areaid,province,city,country,headimgurl,mobile,ismobileconfirmed,consumes,totalprice,regtime,regipaddress,logintime,logintimes,loginipaddress,authenticationsource,name,surname,[password],isemailconfirmed,emailconfirmationcode,passwordresetcode,isactive,username,tenantid,emailaddress,lastlogintime,isdeleted,deleteruserid,deletiontime,lastmodificationtime,lastmodifieruserid,creationtime,creatoruserid");
            strSql.Append(" FROM t_Users ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" iid,nickname,gender,wechatopenid,wechataccesstoken,wechataccesstokenexpiresin,wechatrefreshtoken,wechattokencreatime,areaid,province,city,country,headimgurl,mobile,ismobileconfirmed,consumes,totalprice,regtime,regipaddress,logintime,logintimes,loginipaddress,authenticationsource,name,surname,[password],isemailconfirmed,emailconfirmationcode,passwordresetcode,isactive,username,tenantid,emailaddress,lastlogintime,isdeleted,deleteruserid,deletiontime,lastmodificationtime,lastmodifieruserid,creationtime,creatoruserid from t_Users  ");
            strSql.Append(" FROM t_Users ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM t_Users ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from t_Users T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }


        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

