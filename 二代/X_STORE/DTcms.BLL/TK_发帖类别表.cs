using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using DTcms.DBUtility;
using DTcms.Model;
namespace DTcms.BLL
{
    /// <summary>
    /// TK_发帖类别表
    /// </summary>
    public partial class TK_发帖类别表
    {
        private readonly DTcms.DAL.TK_发帖类别表 dal = new DTcms.DAL.TK_发帖类别表();
        public TK_发帖类别表()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DTcms.Model.TK_发帖类别表 model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DTcms.Model.TK_发帖类别表 model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            return dal.Delete(id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DTcms.Model.TK_发帖类别表 GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DTcms.Model.TK_发帖类别表> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DTcms.Model.TK_发帖类别表> DataTableToList(DataTable dt)
        {
            List<DTcms.Model.TK_发帖类别表> modelList = new List<DTcms.Model.TK_发帖类别表>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DTcms.Model.TK_发帖类别表 model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod
        public void getOneClassTree(int classid, System.Web.UI.HtmlControls.HtmlSelect cid)
        {
            string texts = "";
            string values = "";
            int depth = 0;
            //DTcms.BLL.WP_category BLL_商品 = new DTcms.BLL.WP_category();
            DTcms.Model.TK_发帖类别表 cate = new DTcms.Model.TK_发帖类别表();
            //获取商品类别对象
            cate = GetModel(classid);
            DataTable dt_Have = DbHelperSQL.Query("select * from TK_发帖类别表 where c_parent=" + classid + " order by id").Tables[0];
            if (cate.c_parent > 0)
            {
                depth = 1;
            }
            while (depth > 0)
            {
                texts += "　";
                depth = depth - 1;
            }
            values = cate.类别编号;

            if (dt_Have.Rows.Count == 0)
            {
                texts += " - " + cate.类别名;
                cid.Items.Add(new ListItem(texts, values));
            }
            else
            {
                texts += " + " + cate.类别名;
                cid.Items.Add(new ListItem(texts, values));
                DataTable classidArry1 = DbHelperSQL.Query("select * from TK_发帖类别表 where c_parent=" + classid + " order by id").Tables[0];
                foreach (DataRow dr in classidArry1.Rows)
                {
                    getOneClassTree(Convert.ToInt32(dr["id"]), cid);
                }
            }
        }
        #endregion  ExtensionMethod
    }
}

