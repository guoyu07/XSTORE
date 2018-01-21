 
using System;
using System.Data;
using System.Collections.Generic;
using DTcms.Common;
using DTcms.Model;
namespace DTcms.BLL
{
	/// <summary>
	/// t_Users
	/// </summary>
	public partial class t_Users
	{
		private readonly DTcms.DAL.t_Users dal=new DTcms.DAL.t_Users();
		public t_Users()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

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
		public bool Add(DTcms.Model.t_Users model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DTcms.Model.t_Users model)
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
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DTcms.Model.t_Users GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

        /////// <summary>
        /////// 得到一个对象实体，从缓存中
        /////// </summary>
        ////public DTcms.Model.t_Users GetModelByCache(int id)
        ////{
			
        ////    string CacheKey = "t_UsersModel-" + id;
        ////    object objModel = wp.Common.DataCache.GetCache(CacheKey);
        ////    if (objModel == null)
        ////    {
        ////        try
        ////        {
        ////            objModel = dal.GetModel(id);
        ////            if (objModel != null)
        ////            {
        ////                int ModelCache = wp.Common.ConfigHelper.GetConfigInt("ModelCache");
        ////                wp.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        ////            }
        ////        }
        ////        catch{}
        ////    }
        ////    return (DTcms.Model.t_Users)objModel;
        ////}

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
		public List<DTcms.Model.t_Users> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DTcms.Model.t_Users> DataTableToList(DataTable dt)
		{
			List<DTcms.Model.t_Users> modelList = new List<DTcms.Model.t_Users>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DTcms.Model.t_Users model;
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

		#endregion  ExtensionMethod

        public DataTable DataTableToList(string spsql)
        {
            throw new NotImplementedException();
        }
    }
}

