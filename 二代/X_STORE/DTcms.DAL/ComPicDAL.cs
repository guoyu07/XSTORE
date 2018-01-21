using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.Common;
using DTcms.DBUtility;

namespace DTcms.DAL
{
    public class ComPicDAL
    {
        public void DoPic(string 商品编号)
        {
            DataTable dt = new DataTable();
            SubTables st = new SubTables();
            List<DTcms.Model.WP_商品图片表> ls = new List<DTcms.Model.WP_商品图片表>();
            string[] albumArr = DTRequest.GetFormString("hid_photo_name").Split(',');
            string[] xuhao = DTRequest.GetFormString("txt_序号").Split(',');//取的是表单名称
            int num = DbHelperSQL.ExecuteSql("select * from WP_商品图片表 where 商品编号='" + 商品编号 + "'");
            if (num <= 0)//修改
            {
                DbHelperSQL.ExecuteSql("delete from WP_商品图片表 where 商品编号='" + 商品编号 + "'");
            }
            if (albumArr != null && albumArr.Length > 0 && albumArr[0] != "")
            {
                for (int i = 0; i < albumArr.Length; i++)
                {
                    DTcms.Model.WP_商品图片表 src = new DTcms.Model.WP_商品图片表();
                    src.商品编号 = 商品编号;
                    int xh = 99;
                    int.TryParse(xuhao[i], out xh);
                    src.序号 = xh;
                    //src.标题 = attachFileNameArr[i];
                    src.图片路径 = albumArr[i].Split('|')[1].ToString();
                    ls.Add(src);
                }
            }

            foreach (DTcms.Model.WP_商品图片表 model in ls)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into WP_商品图片表(");
                strSql.Append("商品编号,图片路径,序号)");
                strSql.Append(" values (");
                strSql.Append("@商品编号,@图片路径,@序号)");
                SqlParameter[] parameters = {
					new SqlParameter("@商品编号", SqlDbType.VarChar,50),
                    					new SqlParameter("@序号", SqlDbType.Int,0),
					new SqlParameter("@图片路径", SqlDbType.VarChar,250)};
                parameters[0].Value = model.商品编号;
                parameters[1].Value = model.序号;
                parameters[2].Value = model.图片路径;
                int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
        }
        public void DoPic1(string 商品编号)
        {
            DataTable dt = new DataTable();
            SubTables st = new SubTables();
            List<DTcms.Model.TM_商品图片表> ls = new List<DTcms.Model.TM_商品图片表>();
            string[] albumArr = DTRequest.GetFormString("hid_photo_name").Split(',');
            string[] xuhao = DTRequest.GetFormString("txt_序号").Split(',');
            int num = DbHelperSQL.ExecuteSql("select * from TM_商品图片表 where 商品编号='" + 商品编号 + "'");
            if (num <= 0)//修改
            {
                DbHelperSQL.ExecuteSql("delete from TM_商品图片表 where 商品编号='" + 商品编号 + "'");
            }
            if (albumArr != null && albumArr.Length > 0 && albumArr[0] != "")
            {
                for (int i = 0; i < albumArr.Length; i++)
                {
                    DTcms.Model.TM_商品图片表 src = new DTcms.Model.TM_商品图片表();
                    src.商品编号 = 商品编号;
                    int xh = 99;
                    int.TryParse(xuhao[i],out xh);
                    src.序号 = xh;
                    src.图片路径 = albumArr[i].Split('|')[1].ToString();
                    ls.Add(src);
                }
            }

            foreach (DTcms.Model.TM_商品图片表 model in ls)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into TM_商品图片表(");
                strSql.Append("商品编号,图片路径,序号)");
                strSql.Append(" values (");
                strSql.Append("@商品编号,@图片路径,@序号)");
                SqlParameter[] parameters = {
					new SqlParameter("@商品编号", SqlDbType.VarChar,50),
					new SqlParameter("@序号", SqlDbType.Int,0),
					new SqlParameter("@图片路径", SqlDbType.VarChar,250)};
                parameters[0].Value = model.商品编号;
                parameters[1].Value = model.序号;
                parameters[2].Value = model.图片路径;
                int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
        }

        public void DoPic2(string 编号)
        {
            DataTable dt = new DataTable();
            SubTables st = new SubTables();
            List<DTcms.Model.TK_发帖图片表> ls = new List<DTcms.Model.TK_发帖图片表>();
            string[] albumArr = DTRequest.GetFormString("hid_photo_name").Split(',');
            int num = DbHelperSQL.ExecuteSql("select * from TK_发帖图片表 where 编号='" + 编号 + "'");
            if (num <= 0)//修改
            {
                DbHelperSQL.ExecuteSql("delete from TK_发帖图片表 where 编号='" + 编号 + "'");
            }
            if (albumArr != null && albumArr.Length > 0 && albumArr[0] != "")
            {
                for (int i = 0; i < albumArr.Length; i++)
                {
                    DTcms.Model.TK_发帖图片表 src = new DTcms.Model.TK_发帖图片表();
                    src.编号 = 编号;
                    //src.标题 = attachFileNameArr[i];
                    src.图片路径 = albumArr[i].Split('|')[1].ToString();
                    ls.Add(src);
                }
            }

            foreach (DTcms.Model.TK_发帖图片表 model in ls)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into TK_发帖图片表(");
                strSql.Append("编号,图片路径)");
                strSql.Append(" values (");
                strSql.Append("@编号,@图片路径)");
                SqlParameter[] parameters = {
					new SqlParameter("@编号", SqlDbType.VarChar,50),
					new SqlParameter("@图片路径", SqlDbType.VarChar,250)};
                parameters[0].Value = model.编号;
                parameters[1].Value = model.图片路径;
                int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
        }
    }
}
