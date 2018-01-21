 
using System;
using System.Data;
using System.Collections.Generic;
using DTcms.Common;
using DTcms.Model;
namespace DTcms.BLL
{
	/// <summary>
	/// TM_会员表
	/// </summary>
	public partial class TM_会员表
	{
		private readonly DTcms.DAL.TM_会员表 dal=new DTcms.DAL.TM_会员表();
		public TM_会员表()
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
		public bool Add(DTcms.Model.TM_会员表 model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DTcms.Model.TM_会员表 model)
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
		public DTcms.Model.TM_会员表 GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

        /////// <summary>
        /////// 得到一个对象实体，从缓存中
        /////// </summary>
        ////public DTcms.Model.TM_会员表 GetModelByCache(int id)
        ////{
			
        ////    string CacheKey = "TM_会员表Model-" + id;
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
        ////    return (DTcms.Model.TM_会员表)objModel;
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
		public List<DTcms.Model.TM_会员表> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DTcms.Model.TM_会员表> DataTableToList(DataTable dt)
		{
			List<DTcms.Model.TM_会员表> modelList = new List<DTcms.Model.TM_会员表>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DTcms.Model.TM_会员表 model;
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
	}
}

