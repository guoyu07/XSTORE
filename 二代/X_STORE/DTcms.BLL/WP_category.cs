using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using DTcms.DBUtility;
using DTcms.Model;
namespace DTcms.BLL
{
	/// <summary>
	/// WP_category
	/// </summary>
	public partial class WP_category
	{
		private readonly DTcms.DAL.WP_category dal=new DTcms.DAL.WP_category();
		public WP_category()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int c_id)
		{
			return dal.Exists(c_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(DTcms.Model.WP_category model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DTcms.Model.WP_category model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int c_id)
		{
			
			return dal.Delete(c_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string c_idlist )
		{
			return dal.DeleteList(c_idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DTcms.Model.WP_category GetModel(int c_id)
		{
			
			return dal.GetModel(c_id);
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DTcms.Model.WP_category> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DTcms.Model.WP_category> DataTableToList(DataTable dt)
		{
			List<DTcms.Model.WP_category> modelList = new List<DTcms.Model.WP_category>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DTcms.Model.WP_category model;
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
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
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
            DTcms.Model.WP_category cate = new DTcms.Model.WP_category();
            //获取商品类别对象
            cate = GetModel(classid);
            DataTable dt_Have = DbHelperSQL.Query("select * from WP_category where c_parent=" + classid + " order by c_id").Tables[0];
            if (cate.c_parent > 0)
            {
                depth = 1;
            }
            while (depth > 0)
            {
                texts += "　";
                depth = depth - 1;
            }
            values = cate.c_no;

            if (dt_Have.Rows.Count == 0)
            {
                texts += " - " + cate.c_name;
                cid.Items.Add(new ListItem(texts, values));
            }
            else
            {
                texts += " + " + cate.c_name;
                cid.Items.Add(new ListItem(texts, values));
                DataTable classidArry1 = DbHelperSQL.Query("select * from WP_category where c_parent=" + classid + " order by c_id").Tables[0];
                foreach (DataRow dr in classidArry1.Rows)
                {
                    getOneClassTree(Convert.ToInt32(dr["c_id"]), cid);
                }
            }
        }

		#endregion  ExtensionMethod
	}
}

