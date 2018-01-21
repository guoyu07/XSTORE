using Creatrue.kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tdx.memb.man.ShoppingMall.GoodsManage
{
    public class HeavyWorkOrders
    {
        //flag>0  操作成功

        /// <summary>
        ///  增加
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <param name="standard"></param>
        /// <param name="caseName"></param>
        /// <param name="number"></param>
        /// <param name="samplingSize"></param>
        /// <param name="badnessNumber"></param>
        /// <param name="rejectRatio"></param>
        /// <param name="dtTime"></param>
        /// <param name="manufactureDate"></param>
        /// <param name="type"></param>
        /// <param name="badnessDescribe"></param>
        /// <param name="describe"></param>
        /// <returns></returns>
        public bool Insert(string serialNumber,string standard,string caseName,string number,string samplingSize,string badnessNumber,string rejectRatio,string dtTime,string manufactureDate,string type,string badnessDescribe,string describe){
        int flag=-1;
        try
        {
            flag = new comfun().Insert(@"insert into  [dbo].[重工单] (开单编号,规格,案名,数量,抽样数,不良数,不良率,通知时间,制造日期,类型,不良描述,重工方法)values('" + serialNumber + "','" + standard + "','" + caseName + "','" + number + "','" + samplingSize + "','" + badnessNumber + "','" + rejectRatio + "','" + dtTime + "','" + manufactureDate + "','" + type + "','" + badnessDescribe + "','" + describe + "')");
            if (flag > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            throw;
        }
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <param name="standard"></param>
        /// <param name="caseName"></param>
        /// <param name="number"></param>
        /// <param name="samplingSize"></param>
        /// <param name="badnessNumber"></param>
        /// <param name="rejectRatio"></param>
        /// <param name="dtTime"></param>
        /// <param name="manufactureDate"></param>
        /// <param name="type"></param>
        /// <param name="badnessDescribe"></param>
        /// <param name="describe"></param>
        /// <returns></returns>
        public bool Update(string serialNumber, string standard, string caseName, string number, string samplingSize, string badnessNumber, string rejectRatio, string dtTime, string manufactureDate, string type, string badnessDescribe, string describe)
        {
            int flag = 0;
            try
            {
                flag = new comfun().Update(@"update [dbo].[重工单] set 规格='"+standard+"',案名='"+caseName+"',数量='"+number+"',抽样数='"+samplingSize+"',不良数='"+badnessNumber+"',不良率='"+rejectRatio+"',通知时间='"+dtTime+"',制造日期='"+manufactureDate+"',类型='"+type+"',不良描述='"+badnessDescribe+"',重工方法='"+describe+"' where 开单编号='"+serialNumber+"'");
                if (flag > 0)
                {
                    return true;
                }
                else {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        public bool Delete(string serialNumber) {
            try
            {
                int flag = -1;
                flag = new comfun().Del(@"DELETE from [dbo].[重工单] where 开单编号='"+serialNumber+"'");
                if (flag > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        
        }

    }
}