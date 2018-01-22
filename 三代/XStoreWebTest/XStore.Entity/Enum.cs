using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XStore.Entity
{
    public class Enum
    {
        #region -----用户状态-----
        public enum UserStateEnum : int
        {
            启用 = 1,
            停用 = -1
        }
        #endregion

        #region -----角色权限-----
        public enum UserRoleEnum : int
        {
            经理 = 1,
            财务 = 2,
            前台 = 3,
            区域经理 = 4,
            集团经理 = 5,
            集团财务 = 6,
            后台财务 = 7,
            后台管理员 = 8,
            测试员 = 9,
            配水员 = 10
        }
        #endregion
    }
}
