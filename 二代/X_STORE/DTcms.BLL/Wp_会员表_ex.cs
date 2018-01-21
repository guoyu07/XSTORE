using System;
using System.Data;
using System.Collections.Generic;
using DTcms.Common;
using DTcms.Model;
namespace DTcms.BLL
{
	/// <summary>
	/// WP_会员表
	/// </summary>
	public partial class WP_会员表
	{
        public DataTable GetVipInfo(string where, int pageindex)
        {
            return dal.GetVipInfo(where, pageindex);
        }
        public DataSet GetListNew(string strWhere)
        {
            return dal.GetListNew(strWhere);
        }
    }
}
