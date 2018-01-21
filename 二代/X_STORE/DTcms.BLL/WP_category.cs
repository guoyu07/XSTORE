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
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int c_id)
		{
			return dal.Exists(c_id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(DTcms.Model.WP_category model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(DTcms.Model.WP_category model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int c_id)
		{
			
			return dal.Delete(c_id);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string c_idlist )
		{
			return dal.DeleteList(c_idlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public DTcms.Model.WP_category GetModel(int c_id)
		{
			
			return dal.GetModel(c_id);
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<DTcms.Model.WP_category> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
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
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// ��ҳ��ȡ�����б�
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
            //DTcms.BLL.WP_category BLL_��Ʒ = new DTcms.BLL.WP_category();
            DTcms.Model.WP_category cate = new DTcms.Model.WP_category();
            //��ȡ��Ʒ������
            cate = GetModel(classid);
            DataTable dt_Have = DbHelperSQL.Query("select * from WP_category where c_parent=" + classid + " order by c_id").Tables[0];
            if (cate.c_parent > 0)
            {
                depth = 1;
            }
            while (depth > 0)
            {
                texts += "��";
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

