using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Creatrue.kernel;

namespace tdx.database
{
    public class appsConfig
    {
        public double _Gprice1 = 1000; //
        public double _Gprice2 = 2000; //
        public double _zhekou = 0.1; //
        public double _wuliuZhekou = 0.05;
        public double _tixianZhekou = 0.05;
        public int _tixianQixian = -1;

        //2016-02-23添加
        public double _xiaoshouButie = 0.01;
        public double _xiaoshouButie_xiane = 1500;
        public double _xiaoshouButie_xiane2 = 4000;

        //2016-02-23添加
        public double _xiaoshouLevel = 500;
        public double _xiaoshouLevel2 = 1000;
        public double _xiaoshouLevel_max = 1500;

        //2016-03-03天加
        public double _guanlijiang1 = 0.05;
        public double _guanlijiang2 = 0.03;
        public double _guanlijiang3 = 0.02;

        public appsConfig() { }

        public void init()
        {
            string _sql = "";
            _sql += "select Mvip_id,Mvip_price from b2c_memvip order by Mvip_id";
            _sql += ";select id,b2c_price from b2c_config where id in (10,11,12,13,15,16,17) order by id";
            DataSet ds = comfun.GetDataSetBySQL(_sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    switch (Convert.ToInt32(dr["Mvip_id"].ToString().Trim()))
                    {
                        case 1:
                            _Gprice1 = Convert.ToDouble(dr["mvip_price"].ToString().Trim());
                            break;
                        case 2:
                            _Gprice2 = Convert.ToDouble(dr["mvip_price"].ToString().Trim());
                            break;
                        default:
                            break;
                    }
                } 
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    switch (Convert.ToInt32(dr["id"].ToString().Trim()))
                    {
                        case 10:
                            _zhekou = Convert.ToDouble(dr["b2c_price"].ToString().Trim());
                            break;
                        case 11:
                            _wuliuZhekou = Convert.ToDouble(dr["b2c_price"].ToString().Trim());
                            break;
                        case 12:
                            _tixianZhekou = Convert.ToDouble(dr["b2c_price"].ToString().Trim());
                            break;
                        case 13:
                            _tixianQixian = (int)(Convert.ToDouble(dr["b2c_price"].ToString().Trim()));
                            break;
                        case 15:
                            _xiaoshouButie = Convert.ToDouble(dr["b2c_price"].ToString().Trim());
                            break;
                        case 16:
                            _xiaoshouButie_xiane = Convert.ToDouble(dr["b2c_price"].ToString().Trim());
                            break;
                        case 17:
                            _xiaoshouButie_xiane2 = Convert.ToDouble(dr["b2c_price"].ToString().Trim());
                            break;
                        default:
                            break;
                    }
                } 
            }
            ds.Dispose(); 
        }

        public double GetPrice(int _id)
        {
            double result = 0;
            string _sql = "select id,b2c_price from b2c_config where id=" + _id.ToString().Trim();
            DataTable dt = comfun.GetDataTableBySQL(_sql);
            if (dt.Rows.Count > 0)
            {
                result = Convert.ToDouble(dt.Rows[0]["b2c_price"].ToString().Trim());
            }
            dt.Dispose();
            return result;
        }

        public double GetGPrice(int _id)
        {
            double result = 0;
            string _sql = "select Mvip_id,Mvip_price from b2c_memvip where Mvip_id=" + _id.ToString().Trim();
            DataTable dt = comfun.GetDataTableBySQL(_sql);
            if (dt.Rows.Count > 0)
            {
                result = Convert.ToDouble(dt.Rows[0]["Mvip_price"].ToString().Trim());
            }
            dt.Dispose();
            return result;
        }
    }
}
