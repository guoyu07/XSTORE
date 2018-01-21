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
using Creatrue.kernel;

namespace tdx.database
{
    public class wx_tmsg
    {
        public int id = 0; 
        public string ToUserName = ""; //接受用户名
        public string FromUserName = "";  //发送用户名
		public string MsgType=""; //信息类型
		public string Msg="";//信息内容
		public string MsgId="";//信息ID
        public string Creatime = "";//信息时间

        public string Location_X = "";
        public string Location_Y = "";
        public string Scale = "";
        public string Label = "";
        public string PicUrl = "";

        public string reply = ""; //回复内容 
        public DateTime regtime = System.DateTime.Now;

        public int pid = 0;//获取的图片ID
        public string purl = "";//图片路径
        public string pToUrl = "";//图片链接网址

 
        #region " No Parameter "
        public wx_tmsg()
        {
        }
        #endregion

        #region " With Parameter "
        public wx_tmsg(int _id)
        {
            id = _id;
            this.LoadData();
        }
        #endregion

        private void LoadData()
        {
            string _sql = "SELECT *,(select p_url from wx_photo where wx_photo.id=wx_tmsg.pid) as purl,(select p_tourl from wx_photo where wx_photo.id=wx_tmsg.pid) as ptourl";
			_sql +=" FROM wx_tmsg WHERE id = " + id ;

            DataTable dt = comfun.GetDataTableBySQL(_sql);    
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                {
                    throw new NotSupportedException("wx_tmsgID：" + id + "不唯一");
                }
                else
                {
                    id = Convert.IsDBNull(dt.Rows[0]["id"]) ? 0 : Convert.ToInt32(dt.Rows[0]["id"]);
                    ToUserName = Convert.IsDBNull(dt.Rows[0]["ToUserName"]) ? "" : Convert.ToString(dt.Rows[0]["ToUserName"]);
                    FromUserName = Convert.IsDBNull(dt.Rows[0]["FromUserName"]) ? "" : Convert.ToString(dt.Rows[0]["FromUserName"]);
                    MsgType = Convert.IsDBNull(dt.Rows[0]["MsgType"]) ? "" : Convert.ToString(dt.Rows[0]["MsgType"]);
                    Msg = Convert.IsDBNull(dt.Rows[0]["Msg"]) ? "" : Convert.ToString(dt.Rows[0]["Msg"]);
                    MsgId = Convert.IsDBNull(dt.Rows[0]["MsgId"]) ? "" : Convert.ToString(dt.Rows[0]["MsgId"]);
                    Creatime = Convert.IsDBNull(dt.Rows[0]["Creatime"]) ? "" : Convert.ToString(dt.Rows[0]["Creatime"]);
                    reply = Convert.IsDBNull(dt.Rows[0]["reply"]) ? "" : Convert.ToString(dt.Rows[0]["reply"]);
                    regtime = Convert.IsDBNull(dt.Rows[0]["regtime"]) ? System.DateTime.Now : Convert.ToDateTime(dt.Rows[0]["regtime"]);

                    Location_X = Convert.IsDBNull(dt.Rows[0]["Location_X"]) ? "" : Convert.ToString(dt.Rows[0]["Location_X"]);
                    Location_Y = Convert.IsDBNull(dt.Rows[0]["Location_Y"]) ? "" : Convert.ToString(dt.Rows[0]["Location_Y"]);
                    Scale = Convert.IsDBNull(dt.Rows[0]["Scale"]) ? "" : Convert.ToString(dt.Rows[0]["Scale"]);
                    Label = Convert.IsDBNull(dt.Rows[0]["Label"]) ? "" : Convert.ToString(dt.Rows[0]["Label"]);
                    PicUrl = Convert.IsDBNull(dt.Rows[0]["PicUrl"]) ? "" : Convert.ToString(dt.Rows[0]["PicUrl"]);

                    //图片相关
                    pid = Convert.IsDBNull(dt.Rows[0]["pid"]) ? 0 : Convert.ToInt32(dt.Rows[0]["pid"]);
                    purl = Convert.IsDBNull(dt.Rows[0]["purl"]) ? "" : Convert.ToString(dt.Rows[0]["purl"]);
                    pToUrl = Convert.IsDBNull(dt.Rows[0]["pToUrl"]) ? "" : Convert.ToString(dt.Rows[0]["pToUrl"]);
                }
            }
            else
            {
                throw new NotSupportedException("wx_tmsgID：" + id + "不存在");
            }
        }

        /// <summary>
        /// 添加一条记录
        /// </summary>
        private void MyInsertMethod(string _ToUserName, string _FromUserName, string _MsgType, string _Msg, string _MsgId,string _Creatime, string _reply,string _Location_X,string _Location_Y,string _Scale,string _Label,string _PicUrl,int _pid)
        {

            string queryString = " INSERT INTO wx_tmsg (ToUserName,FromUserName,MsgType,Msg,MsgId,Creatime,reply,Location_X,Location_Y,Scale,Label,PicUrl,pid)";
            queryString += " VALUES (@ToUserName,@FromUserName,@MsgType,@Msg,@MsgId,@Creatime,@reply,@LocationX1,@LocationY1,@Scale1,@Label2,@PicUrl," + _pid + ")";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@ToUserName", _ToUserName), 
                new SqlParameter("@FromUserName", _FromUserName),
                new SqlParameter("@MsgType", _MsgType),
                new SqlParameter("@Msg", _Msg),
                new SqlParameter("@MsgId", _MsgId),
                new SqlParameter("@Creatime", _Creatime),
                new SqlParameter("@reply", _reply),
                new SqlParameter("@LocationX1", _Location_X),
                new SqlParameter("@LocationY1", _Location_Y),
                new SqlParameter("@Scale1", _Scale),
                new SqlParameter("@Label2", _Label),
                new SqlParameter("@PicUrl", _PicUrl) };

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

        private void MyUpdateMethod(int _id, string _ToUserName, string _FromUserName, string _MsgType, string _Msg, string _MsgId, string _Creatime, string _reply, string _Location_X, string _Location_Y, string _Scale, string _Label, string _PicUrl,int _pid)
        {
            string queryString = "UPDATE wx_tmsg SET ToUserName=@ToUserName,FromUserName=@FromUserName,MsgType=@MsgType,Msg=@Msg,MsgId=@MsgId,Creatime=@Creatime,reply=@reply,Location_X=@LocationX1,Location_Y=@LocaionY1,Scale=@Scale1,Label=@Label2,PicUrl=@PicUrl,pid=" + _pid + " WHERE id =" + id;
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@ToUserName", _ToUserName), 
                new SqlParameter("@FromUserName", _FromUserName),
                new SqlParameter("@MsgType", _MsgType),
                new SqlParameter("@Msg", _Msg),
                new SqlParameter("@MsgId", _MsgId),
                new SqlParameter("@Creatime", _Creatime),
                new SqlParameter("@reply", _reply),
                new SqlParameter("@LocationX1", _Location_X),
                new SqlParameter("@LocaionY1", _Location_Y),
                new SqlParameter("@Scale1", _Scale),
                new SqlParameter("@Label2", _Label),
                new SqlParameter("@PicUrl", _PicUrl) }; 

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

            ToUserName = "";
            FromUserName = "";
            MsgType = "";
            Msg = "";
            MsgId = "";
            Creatime = "";
            reply = ""; 
			regtime=System.DateTime.Now;

            Location_X = "";
            Location_Y = "";
            Scale = "";
            Label = "";
            PicUrl = "";

            pid = 0;
            purl = "";
        }
        public void Update()
        {
            if (id == 0)
            {
                this.MyInsertMethod(ToUserName, FromUserName, MsgType, Msg, MsgId, Creatime,reply,Location_X ,Location_Y,Scale ,Label ,PicUrl,pid);
            }
            else
            {
                this.MyUpdateMethod(id, ToUserName, FromUserName, MsgType, Msg, MsgId, Creatime, reply, Location_X, Location_Y, Scale, Label, PicUrl,pid);
            }
        }

        public static int Delete(int _id)
        {
            //删除图片
            wx_tmsg tt = new wx_tmsg(_id); 
            try
            {
                return comfun.DelByInt("wx_tmsg", "id", _id);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException("wx_tmsgID：" + _id + "删除失败");
            }
        }

        #endregion 

        public static int GetMsgCount(string _gh)
        {
            DataTable dt = comfun.GetDataTableBySQL("select count(id) from wx_tmsg where FromUserName='" + _gh + "'"); 
            return Convert.ToInt32(dt.Rows[0][0]);
        }
    }
}
