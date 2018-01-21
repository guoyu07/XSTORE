using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTcms.Model
{
   public partial class WP_地区表
	{
       public WP_地区表()
       {}
       #region Model
        private int _id;
       private  string _名称;
       private  int _父级id;
       private Boolean _是否删除;
       private int _删除人id;
       private DateTime _删除时间;
       private DateTime _最后修改时间;
       private int _最后修改人id;
       private DateTime _创建时间;
       private int _创建人id;
       public int id
       {
           set { _id = value; }
           get { return _id; }
       }
       public string 名称
       {
         set{_名称=value;}
         get{return _名称;}
       }
       public int 父级id
       {
           set { _父级id = value; }
           get { return _父级id; }
       }
       public Boolean 是否删除
       {
           set { _是否删除 = value; }
           get { return _是否删除; }
       }
       public int 删除人id
       {
           set { _删除人id = value; }
           get { return _删除人id; }
       }
       public DateTime 删除时间
       {
           set { _删除时间 = value; }
           get { return _删除时间; }
       }
       public DateTime 最后修改时间
       {
           set { _最后修改时间 = value; }
           get { return _最后修改时间; }
       }
       public int 最后修改人id
       {
           set { _最后修改人id = value; }
           get { return _最后修改人id; }
       }
       public DateTime 创建时间
       {
           set { _创建时间 = value; }
           get { return _创建时间; }
       }
       public int 创建人id
       {
           set { _创建人id = value; }
           get { return _创建人id; }
       }
       #endregion
   }


}
