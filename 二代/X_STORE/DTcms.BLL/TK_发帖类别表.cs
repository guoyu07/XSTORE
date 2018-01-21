using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using DTcms.DBUtility;
using DTcms.Model;
namespace DTcms.BLL
{
    /// <summary>
    /// TK_��������
    /// </summary>
    public partial class TK_��������
    {
        private readonly DTcms.DAL.TK_�������� dal = new DTcms.DAL.TK_��������();
        public TK_��������()
        { }
        #region  BasicMethod
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(DTcms.Model.TK_�������� model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(DTcms.Model.TK_�������� model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int id)
        {

            return dal.Delete(id);
        }
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public DTcms.Model.TK_�������� GetModel(int id)
        {

            return dal.GetModel(id);
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<DTcms.Model.TK_��������> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<DTcms.Model.TK_��������> DataTableToList(DataTable dt)
        {
            List<DTcms.Model.TK_��������> modelList = new List<DTcms.Model.TK_��������>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DTcms.Model.TK_�������� model;
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
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
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
            DTcms.Model.TK_�������� cate = new DTcms.Model.TK_��������();
            //��ȡ��Ʒ������
            cate = GetModel(classid);
            DataTable dt_Have = DbHelperSQL.Query("select * from TK_�������� where c_parent=" + classid + " order by id").Tables[0];
            if (cate.c_parent > 0)
            {
                depth = 1;
            }
            while (depth > 0)
            {
                texts += "��";
                depth = depth - 1;
            }
            values = cate.�����;

            if (dt_Have.Rows.Count == 0)
            {
                texts += " - " + cate.�����;
                cid.Items.Add(new ListItem(texts, values));
            }
            else
            {
                texts += " + " + cate.�����;
                cid.Items.Add(new ListItem(texts, values));
                DataTable classidArry1 = DbHelperSQL.Query("select * from TK_�������� where c_parent=" + classid + " order by id").Tables[0];
                foreach (DataRow dr in classidArry1.Rows)
                {
                    getOneClassTree(Convert.ToInt32(dr["id"]), cid);
                }
            }
        }
        #endregion  ExtensionMethod
    }
}

