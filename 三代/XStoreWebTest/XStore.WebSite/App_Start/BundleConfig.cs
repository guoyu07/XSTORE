using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace XStore.WebSite
{
    public class BundleConfig
    {
        // 有关捆绑的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
            //                "~/Scripts/WebForms/WebForms.js",
            //                "~/Scripts/WebForms/WebUIValidation.js",
            //                "~/Scripts/WebForms/MenuStandards.js",
            //                "~/Scripts/WebForms/Focus.js",
            //                "~/Scripts/WebForms/GridView.js",
            //                "~/Scripts/WebForms/DetailsView.js",
            //                "~/Scripts/WebForms/TreeView.js",
            //                "~/Scripts/WebForms/WebParts.js"));

            //// 若要使这些文件正常工作，采用适当的顺序是非常重要的；这些文件具有显式依赖关系
            //bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
            //        "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
            //        "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
            //        "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
            //        "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            //// 使用要用于开发和学习的 Modernizr 开发版本。然后，在准备好进行生产时，
            //// 准备生产时，使用 https://modernizr.com 中的生成工具仅选择所需的测试
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //                "~/Scripts/modernizr-*"));

            //ScriptManager.ScriptResourceMapping.AddDefinition(
            //    "respond",
            //    new ScriptResourceDefinition
            //    {
            //        Path = "~/Scripts/respond.min.js",
            //        DebugPath = "~/Scripts/respond.js",
            //    });
            //         < link rel = "stylesheet" href = "../../Content/Login/reset.css" />

            //< link rel = "stylesheet" href = "../../Content/Login/common.css" />

            //   < link rel = "stylesheet" href = "../../Content/Login/Bind.css" />
            bundles.Add(new StyleBundle("~/bundles/CommonStyle").Include(
                "~/Content/Login/reset.css",
                "~/Content/Login/common.css",
                "~/Content/layer.css"
                ));
            bundles.Add(new ScriptBundle("~/bundles/CommonJs").Include(
                "~/Scripts/jquery-1.10.2.min.js",
                "~/Scripts/Plugins/layer.js",
                  "~/Scripts/common.js"
                ));
            #region Swipe
            bundles.Add(new StyleBundle("~/bundles/swiper/css").Include(
               "~/Content/swiper.min.css"
               ));
            bundles.Add(new ScriptBundle("~/bundles/swiper/js").Include(
               "~/Scripts/swiper.min.js"
               ));
            #endregion
            bundles.Add(new StyleBundle("~/bundles/weui/css").Include(
               "~/Content/weui.css"
               ));
            bundles.Add(new ScriptBundle("~/bundles/weui/js").Include(
               "~/Scripts/weui.js"
               ));
            #region WeUi

            #endregion


            #region 登陆界面
            bundles.Add(new StyleBundle("~/bundles/login").Include(
               "~/Content/Login/login.css"
               ));
            #endregion
            #region 欢迎界面
            bundles.Add(new StyleBundle("~/bundles/welcome").Include(
               "~/Content/Login/welcome.css"
               ));
            #endregion
            #region 账号绑定
            bundles.Add(new StyleBundle("~/bundles/bind").Include(
            "~/Content/Login/bind.css"
            ));
            #endregion
            #region 离线页面
            bundles.Add(new StyleBundle("~/bundles/nopower").Include(
          "~/Content/Login/nopower.css"
          ));
            #endregion
            #region 商品列表
            bundles.Add(new StyleBundle("~/bundles/goodslist/css").Include(
           "~/fonts/iconfont.css",
           "~/Content/Goods/buyerIndex.css"
           ));
            bundles.Add(new ScriptBundle("~/bundles/goodslist/js").Include(
                "~/Scripts/Plugins/vipspa.js",
                "~/Scripts/Modules/mySpace.js"
                ));
            #endregion
            #region 商品详情
            bundles.Add(new StyleBundle("~/bundles/detail/css").Include(
              "~/Content/Goods/detail.css"
              ));
            #endregion

            #region 支付中心
            bundles.Add(new StyleBundle("~/bundles/paycenter/css").Include(
             "~/Content/Order/payCenter.css"
             ));
            bundles.Add(new ScriptBundle("~/bundles/paycenter/js").Include(
             "~/Scripts/Modules/payCenter.js"
             ));
            #endregion

            #region 支付成功
            bundles.Add(new StyleBundle("~/bundles/paysuccess/css").Include(
            "~/Content/Order/paySuccess.css"
            ));
            bundles.Add(new ScriptBundle("~/bundles/paysuccess/js").Include(
             "~/Scripts/jquery.myProgress.js"
             ));
            #endregion

            #region 开箱失败
            bundles.Add(new StyleBundle("~/bundles/payfail/css").Include(
            "~/Content/Order/payFail.css"
            ));
            #endregion

            #region 前台个人中心
            bundles.Add(new StyleBundle("~/bundles/employeecenter/css").Include(
                "~/fonts/iconfont.css",
                "~/Content/Center/distributer.css",
                "~/Content/footer.css"
           ));
            bundles.Add(new ScriptBundle("~/bundles/employeecenter/js").Include(
             "~/Scripts/Modules/dsMyself.js"
             ));
            #endregion

            #region 常规补货
            bundles.Add(new StyleBundle("~/bundles/roomselect/css").Include(
                "~/fonts/iconfont.css",
                "~/Content/Opreation/roomSelect.css",
                "~/Content/Center/distributer.css",
                "~/Content/footer.css"
           ));
            bundles.Add(new ScriptBundle("~/bundles/roomselect/js").Include(
             "~/Scripts/Plugins/vipspa.js",
             "~/Scripts/Plugins/vipspa-dev.js"
             ));
            #endregion
        }
    }
}