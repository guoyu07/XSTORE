using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;

namespace tdx.memb.man.PrintSheet
{
    public partial class MultyReport : DevExpress.XtraReports.UI.XtraReport
    {
        public MultyReport()
        {
          InitializeComponent();
          for (int i = 0; i < 5; i++)
          {
              PrintOrder pEnterPinfo = new PrintOrder("S2016042200001", "WP");
              DevExpress.XtraReports.UI.XRSubreport myreport1 = new XRSubreport();
              myreport1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 12.5F + 1170.52F * i);
              myreport1.Name = "xrSubreportnew" + i;
              myreport1.SizeF = new System.Drawing.SizeF(828F, 1170.52F);
              myreport1.ReportSource = pEnterPinfo;
              this.Detail.Controls.Add(myreport1);
          }
        }
        public MultyReport(Dictionary<string,string> _orderinfo)
        {
            InitializeComponent();
            Dictionary<string, string> orderinfo = _orderinfo;
            List<string> test = new List<string>(orderinfo.Keys);
            for (int i = 0; i < orderinfo.Count;i++ )
            {
                PrintOrder pEnterPinfo = new PrintOrder(test[i].ToString(), orderinfo[test[i].ToString()]);
                DevExpress.XtraReports.UI.XRSubreport myreport1 = new XRSubreport();
                myreport1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 12.5F + 1170.52F * i);
                myreport1.Name = "xrSubreportnew" + i;
                myreport1.SizeF = new System.Drawing.SizeF(828F, 1170.52F);
                myreport1.ReportSource = pEnterPinfo;
                this.Detail.Controls.Add(myreport1);
            } 
         }
    }
}
