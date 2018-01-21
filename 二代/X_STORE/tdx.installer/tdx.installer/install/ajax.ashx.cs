using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Xml;
using System.Text;
using System.Collections;
using System.Security.Cryptography;

namespace tdx.installer.install
{
    /// <summary>
    /// ajax 的摘要说明
    /// </summary>
    public class ajax : IHttpHandler
    {
        HttpContext context = null;
        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            string type = context.Request.Params["t"];

            switch (type)
            {
                case "checkdbconnection":
                    CheckDbConn();
                    break;
                case "dbsourceexist":
                    tdExists();
                    break;
                case "savedbset":
                    SaveDbSet();
                    break;
                case "createtable":
                    CreateTbs();
                    break;
                case "initsource":
                    InitSource();
                    break;
            }
        }


        void CheckDbConn()
        {
            string ip = context.Request.Params["ip"];
            string dbname = context.Request.Params["name"];
            string loginname = context.Request.Params["loginname"];
            string loginpwd = context.Request.Params["loginpwd"];
            string connstr = "Data Source=" + ip + ";Initial Catalog=" + dbname + ";Persist Security Info=True;User ID=" + loginname + ";Password=" + loginpwd + ";";
            //select 1 from master,dbo.sysdatabases where [name]=
            string sql = "select name from master.dbo.sysdatabases where name = '" + dbname + "'";

            try
            {
                DataTable dt = GetDataTable(connstr, sql);
                if (dt == null || dt.Rows.Count == 0)
                {
                    ajaxMsg("no", "4060", "");
                }
                else
                {
                    ajaxMsg("ok", "", "");
                }
            }
            catch (Exception ex)
            {
                ajaxMsg("no", "4060", "");
                throw new Exception(ex.Message);
            }
        }

        void tdExists()
        {
            if (File.Exists(context.Request.MapPath("upload/lock.txt")))
            {
                ajaxMsg("ok", "", "");
            }
            else
            {
                ajaxMsg("no", "", "");
            }
        }

        void SaveDbSet()
        {
            string ip = context.Request.Params["ip"];
            string dbname = context.Request.Params["name"];
            string loginname = context.Request.Params["loginname"];
            string loginpwd = context.Request.Params["loginpwd"];
            string connstr = "Data Source=" + ip + ";Initial Catalog=" + dbname + ";Persist Security Info=True;User ID=" + loginname + ";Password=" + loginpwd + ";";

            try
            {
                WriteDbSet("ConnStr", connstr);
                ajaxMsg("ok", "", "操作成功");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        void CreateTbs()
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            try
            {
                List<String> list = GetSqls("upload");
                bool isSuccess = false;
                if (list != null && list.Count > 0)
                {
                    isSuccess = ExecuteSqlTran(list, connStr);
                    if (isSuccess)
                    {
                        ajaxMsg("ok", "", "");
                    }
                    else
                    {
                        ajaxMsg("no", "", "");
                    }
                }
            }
            catch (Exception ex)
            {
                ajaxMsg("no", "", "");
                throw new Exception(ex.Message);
            }
        }

        void InitSource()
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            string user = context.Request.Params["admin"];
            string pwd = Encrypt(context.Request.Params["pwd"], "28LH48");

            List<string> sqls = new List<string>();
            //1.添加管理员角色信息
            sqls.Add("insert into dt_manager_role(role_name, role_type, is_sys) values('超级管理组',1,1)");
            sqls.Add("insert into dt_manager_role(role_name, role_type, is_sys) values('系统管理组',2,0)");

            //2.添加管理员
            StringBuilder temp = new StringBuilder();
            
            sqls.Add("insert into dt_manager(role_id, role_type, user_name, password, salt ,real_name, is_lock) values(1,1,'" + user + "','" + pwd + "','28LH48','超级管理员',0)");
            
            //3.添加导航信息
            //0
            
            sqls.Add("insert into dt_navigation values('System','sys_contents','内容管理','内容','',99,0,'',0,',1,',1,0,'Show',1)");
            

            
            sqls.Add("insert into dt_navigation values('System','sys_business','业务管理','业务','',100,0,'系统默认导航，不可修改导航ID',0,',2,',1,0,'Show',1)");
            

            
            sqls.Add("insert into dt_navigation values('System','sys_wechat','微信号管理','微信号','',101,0,'系统默认导航，不可修改导航ID',0,',3,',1,0,'Show',1)");
            

            
            sqls.Add("insert into dt_navigation values('System','sys_micropage','微官网管理','微官网','',102,0,'系统默认导航，不可修改导航ID',0,',4,',1,0,'Show',1)");
            

            
            sqls.Add("insert into dt_navigation values('System','sys_microshop','微商城管理','微商城','',103,0,'系统默认导航，不可修改导航ID',0,',5,',1,0,'Show',1)");
            

            
            sqls.Add("insert into dt_navigation values('System','sys_config','系统配置','配置','',105,0,'系统默认导航，不可修改导航ID',0,',6,',1,0,'Show',1)");
            

            
            sqls.Add("insert into dt_navigation values('System','sys_interface','界面管理','界面','',106,0,'系统默认导航，不可修改导航ID',0,',7,',1,0,'Show',1)");
            

            //1
            
            sqls.Add("insert into dt_navigation values('System','cont_page','页面管理','','',99,0,'',1,',1,8,',2,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','cont_news','新闻管理','','',100,0,'',1,',1,9,',2,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','cont_product','产品管理','','',101,0,'',1,',1,10,',2,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','cont_picture','图片管理','','',102,0,'',1,',1,11,',2,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','cont_download','下载管理','','',103,0,'',1,',1,12,',2,0,'Show',0)");
            

            
            sqls.Add("insert into dt_navigation values('System','cont_page_list','页面内容','','Texts/B2C_tpage_List.aspx',99,0,'',8,',1,8,13,',3,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','cont_page_category','页面类别','','Texts/B2C_TPclass_List.aspx',100,0,'',8,',1,8,14,',3,0,'Show',0)");
            

            
            sqls.Add("insert into dt_navigation values('System','news_contman','新闻内容','','Texts/B2C_tmsg_List.aspx',99,0,'',9,',1,9,15,',3,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','news_conClass','新闻类别','','Texts/B2C_tclass_List.aspx',100,0,'',9,',1,9,16,',3,0,'Show',0)");
            

            
            sqls.Add("insert into dt_navigation values('System','pros_conman','产品内容','','Goods/B2C_Goods_List.aspx',99,0,'',10,',1,10,17,',3,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','pro_conClass','产品类别','','Goods/B2C_category_List.aspx',100,0,'',10,',1,10,18,',3,0,'Show',0)");
            

            
            sqls.Add("insert into dt_navigation values('System','pic_conman','图片内容','','Texts/B2C_Honor_List.aspx',99,0,'',11,',1,11,19,',3,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','pic_conClass','图片类别','','Texts/B2C_Hclass_List.aspx',100,0,'',11,',1,11,20,',3,0,'Show',0)");
            

            
            sqls.Add("insert into dt_navigation values('System','down_conman','下载内容','','Texts/B2C_Downs_List.aspx',99,0,'',12,',1,12,21,',3,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','down_conClass','下载类别','','Texts/B2C_Dclass_List.aspx',100,0,'',12,',1,12,22,',3,0,'Show',0)");
            

            //2
            
            sqls.Add("insert into dt_navigation values('System','bus_advert','广告管理','','',99,0,'',2,',2,23,',2,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','bus_links','友情链接','','Ads/B2C_Links_List.aspx',100,0,'',2,',2,24,',2,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','bus_message','留言管理','','Texts/B2C_note_List.aspx',101,0,'',2,',2,25,',2,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','bus_xunpan','询盘管理','','Texts/B2C_inq_List.aspx',102,0,'',2,',2,26,',2,0,'Show',0)");
            

            
            sqls.Add("insert into dt_navigation values('System','advert_picman','广告内容','','Ads/B2C_ADS_List.aspx',99,0,'',23,',2,23,27,',3,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','advert_picposman','广告类别','','Ads/B2C_Adclass_List.aspx',100,0,'',23,',2,23,28,',3,0,'Show',0)");
            

            //3 wechat_IDbind 绑定新微信号

            sqls.Add("insert into dt_navigation values('System','wechat_IDbind','绑定新微信号','','Sets/wx_mp_List.aspx',99,0,'',3,',3,29,',2,0,'Show',0)");
            

            //4 
            
            sqls.Add("insert into dt_navigation values('System','mpage_microwebsite','微官网设置','','',99,0,'',4,',4,30,',2,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','mpage_microactivity','微活动管理','','',100,0,'',4,',4,31,',2,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','mpage_wanneng','万能表单管理','','',101,0,'',4,',4,32,',2,0,'Show',0)");

            sqls.Add("insert into wx_config (M_company) values('无锡实创科技')");



            sqls.Add("insert into dt_navigation values('System','mpage_vortman','投票管理','','',102,0,'',4,',4,33,',2,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','mpage_caimi','猜谜管理','','',103,0,'',4,',4,34,',2,0,'Show',0)");
            

            
            sqls.Add("insert into dt_navigation values('System','microw_template','模板选择','','Sets/wxConfig_mb.aspx',99,0,'',30,',4,30,35,',3,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','microw_index','首页栏目','','Sets/B2C_menu_List.aspx',100,0,'',30,',4,30,36,',3,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','microw_pic','背景图片','','Ads/B2C_ADS_Add3.aspx',101,0,'',30,',4,30,37,',3,0,'Show',0)");


            sqls.Add("insert into dt_navigation values('System','microw_huandengpian','幻灯片','','Ads/B2C_ADS_Add2.aspx',102,0,'',30,',4,30,38,',3,0,'Show',0)");



            sqls.Add("insert into dt_navigation values('System','weihuodong_new','添加新活动','','actions/Edit_Action.aspx',99,0,'',31,',4,31,39,',3,0,'Show',0)");

                sqls.Add("insert into wx_actions (ac_name) values ('大转盘')");
                sqls.Add("insert into wx_actions (ac_name) values ('刮刮卡')");
                sqls.Add("insert into wx_actions (ac_name) values ('抽奖')");
                sqls.Add("insert into wx_actions (ac_name) values ('砸金蛋')");

            sqls.Add("insert into dt_navigation values('System','weihuodong_running','正在进行活动','','actions/Action_Now.aspx',100,0,'',31,',4,31,40,',3,0,'Show',0)");


            sqls.Add("insert into dt_navigation values('System','weihuodong_starting','即将开始活动','','actions/Action_Will.aspx',101,0,'',31,',4,31,41,',3,0,'Show',0)");


            sqls.Add("insert into dt_navigation values('System','weihuodong_outtime','已过期活动','','actions/Action_Passed.aspx',102,0,'',31,',4,31,42,',3,0,'Show',0)");


            sqls.Add("insert into dt_navigation values('System','weihuodong_all','所有活动','','actions/TurntableList.aspx',103,0,'',31,',4,31,43,',3,0,'Show',0)");



            sqls.Add("insert into dt_navigation values('System','wanneng_feedback','在线反馈','','formcontrols/ShowControlList.aspx?obj=1',99,0,'',32,',4,32,44,',3,0,'Show',0)");


            sqls.Add("insert into dt_navigation values('System','wanneng_yuding','在线预订','','formcontrols/ShowControlList.aspx?obj=2',100,0,'',32,',4,32,45,',3,0,'Show',0)");


            sqls.Add("insert into dt_navigation values('System','wanneng_baoming','在线报名','','formcontrols/ShowControlList.aspx?obj=3',101,0,'',32,',4,32,46,',3,0,'Show',0)");


            sqls.Add("insert into dt_navigation values('System','wanneng_yuyue','在线预约','','formcontrols/ShowControlList.aspx?obj=4',102,0,'',32,',4,32,47,',3,0,'Show',0)");


            sqls.Add("insert into dt_navigation values('System','wanneng_guahao','在线挂号','','formcontrols/ShowControlList.aspx?obj=5',103,0,'',32,',4,32,48,',3,0,'Show',0)");


            sqls.Add("insert into dt_navigation values('System','wanneng_peizhi','万能表单配置','','formcontrols/objControlsList.aspx',104,0,'',32,',4,32,49,',3,0,'Show',0)");


            sqls.Add("insert into dt_navigation values('System','wanneng_cakan','万能表单结果查看','','formcontrols/objControlResultList.aspx',105,0,'',32,',4,32,50,',3,0,'Show',0)");

            sqls.Add("insert into control_dict values('1','文本框','1','文本框')");
            sqls.Add("insert into control_dict values('2','文本域','1','文本域')");
            sqls.Add("insert into control_dict values('3','日期','1','日期')");
            sqls.Add("insert into control_dict values('4','单选框','0','单选框')");
            sqls.Add("insert into control_dict values('5','多选框','0','多选框')");
            sqls.Add("insert into control_dict values('6','下拉菜单','0','下拉菜单')");
            sqls.Add("insert into control_dict values('7','描述文本','1','描述文本')");

            sqls.Add("insert into dt_navigation values('System','vort_iteminfor','投票项信息列表','','Texts/vote_Album_List.aspx',99,0,'',33,',4,33,51,',3,0,'Show',0)");


            sqls.Add("insert into dt_navigation values('System','vort_itemlist','投票项目列表','','Texts/vote_Bigpic_List.aspx',100,0,'',33,',4,33,52,',3,0,'Show',0)");


            sqls.Add("insert into dt_navigation values('System','vort_log','投票日志','','Texts/vote_log_list.aspx',101,0,'',33,',4,33,53,',3,0,'Show',0)");



            sqls.Add("insert into dt_navigation values('System','caimi_huodong','猜谜题库管理','','caimi/wx_acm_test_list.aspx',99,0,'',34,',4,34,54,',3,0,'Show',0)");



            sqls.Add("insert into wx_acm_holiday values('春节')");
            sqls.Add("insert into wx_acm_holiday values('元宵')");
            sqls.Add("insert into wx_acm_holiday values('中秋')");
            sqls.Add("insert into wx_acm_holiday values('元旦')");

            sqls.Add("insert into wx_acm_level values('容易')");
            sqls.Add("insert into wx_acm_level values('正常')");
            sqls.Add("insert into wx_acm_level values('难')");
            sqls.Add("insert into wx_acm_level values('很难')");
            sqls.Add("insert into wx_acm_level values('极难')");


            sqls.Add("insert into wx_acm_with values('喜庆')");
            sqls.Add("insert into wx_acm_with values('欢乐')");
            sqls.Add("insert into wx_acm_with values('游园')");
            

            sqls.Add("insert into dt_navigation values('System','caimi_huodong','猜谜活动管理','','caimi/wx_acm_action_List.aspx',100,0,'',34,',4,34,55,',3,0,'Show',0)");
            

            //5 
            
            sqls.Add("insert into dt_navigation values('System','microshop_con','微商城配置','','Goods/B2C_Shop_Config.aspx',99,0,'',5,',5,56,',2,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','microshop_orderman','订单管理','','',100,0,'',5,',5,57,',2,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','microshop_prosman','产品管理','','',101,0,'',5,',5,58,',2,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','microshop_package','套餐产品','','',102,0,'',5,',5,59,',2,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','microshop_accupoints','积分产品','','',103,0,'',5,',5,60,',2,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','microshop_privilege','特权产品','','',104,0,'',5,',5,61,',2,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','microshop_tuangou','团购管理','','',105,0,'',5,',5,62,',2,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','microshop_miaosha','秒杀管理','','',106,0,'',5,',5,63,',2,0,'Show',0)");
            

            
            sqls.Add("insert into dt_navigation values('System','orders_search','订单查询','','Goods/B2C_order_List.aspx',99,0,'',57,',5,57,64,',3,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','orders_export','订单导出','','',100,0,'',57,',5,57,65,',3,0,'Show',0)");
            

            
            sqls.Add("insert into dt_navigation values('System','prosman_proclass','产品类别','','Goods/B2C_category_List.aspx',99,0,'',58,',5,58,66,',3,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','prosman_pinpai','产品品牌','','Goods/B2C_brand_List.aspx',100,0,'',58,',5,58,67,',3,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','prosman_addpro','产品内容','','Goods/B2C_Goods_List.aspx',101,0,'',58,',5,58,68,',3,0,'Show',0)");
            

            
            sqls.Add("insert into dt_navigation values('System','packpro_new','套餐产品添加','','Goods/B2C_taocan_List.aspx',99,0,'',59,',5,59,69,',3,0,'Show',0)");
            

            
            sqls.Add("insert into dt_navigation values('System','accpros_new','积分产品添加','','Goods/B2C_JiFen_List.aspx',99,0,'',60,',5,60,70,',3,0,'Show',0)");
            

            
            sqls.Add("insert into dt_navigation values('System','special_add','特权产品添加','','Goods/B2C_Vip_List.aspx',99,0,'',61,',5,61,71,',3,0,'Show',0)");
            

            
            sqls.Add("insert into dt_navigation values('System','tuangou_list','团购列表','','Goods/Action_TeamList.aspx',99,0,'',62,',5,62,72,',3,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','tuangou_order','团购订单','','Goods/tm_order_List.aspx',100,0,'',62,',5,62,73,',3,0,'Show',0)");
            

            
            sqls.Add("insert into dt_navigation values('System','miaosha_peizhi','秒杀配置','','Goods/Action_MsList.aspx',99,0,'',63,',5,63,74,',3,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','miaosha_order','秒杀订单','','Goods/ms_order_List.aspx',100,0,'',63,',5,63,75,',3,0,'Show',0)");
            

            //6.
            
            sqls.Add("insert into dt_navigation values('System','site_manage','系统管理','','',99,0,'',6,',6,76,',2,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','site_manager','系统用户','','',100,0,'',6,',6,77,',2,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','site_config','系统设置','','settings/sys_config.aspx',99,0,'',76,',6,76,78,',3,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','manager_list','管理员管理','','manager/manager_list.aspx',99,0,'',77,',6,77,79,',3,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','manager_role','角色管理','','manager/role_list.aspx',100,0,'',77,',6,77,80,',3,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','manager_log','管理日志','','manager/manager_log.aspx',101,0,'',77,',6,77,81,',3,0,'Show',0)");
            

            //7.
            
            sqls.Add("insert into dt_navigation values('System','inter_template','网站模板','','settings/templet_list.aspx',99,0,'',7,',7,82,',2,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','inter_plugin','插件安装配置','','settings/plugin_list.aspx',100,0,'',7,',7,83,',2,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','inter_staticpage','生成静态页面','','settings/builder_html.aspx',101,0,'',7,',7,84,',2,0,'Show',0)");
            
            
            sqls.Add("insert into dt_navigation values('System','inter_navgation','后台导航管理','','settings/nav_list.aspx',102,0,'',7,',7,85,',2,0,'Show',0)");
            

            //8.
            sqls.Add("insert into dt_navigation values('System','sys_vipuser','微会员','微会员','',104,0,'系统默认导航，不可修改导航ID',0,',86,',1,0,'Show',1)");


            sqls.Add("insert into dt_navigation values('System','vipuser_user','会员管理','','',99,0,'',86,',86,87,',2,0,'Show',0)");
            sqls.Add("insert into dt_navigation values('System','vipuser_usercard','会员卡管理','','',100,0,'',86,',86,88,',2,0,'Show',0)");
            sqls.Add("insert into dt_navigation values('System','vipuser_share','会员分享管理','','',101,0,'',86,',86,89,',2,0,'Show',0)");
            sqls.Add("insert into dt_navigation values('System','vipuser_coupons','代金券管理','','',102,0,'',86,',86,90,',2,0,'Show',0)");

            sqls.Add("insert into dt_navigation values('System','vip_user_list','会员列表','','vipmemb/B2C_memList.aspx',99,0,'',87,',86,87,91,',3,0,'Show',0)");
            sqls.Add("insert into dt_navigation values('System','vip_user_add','会员添加','','vipmemb/B2C_memEdit.aspx',100,0,'',87,',86,87,92,',3,0,'Show',0)");
            sqls.Add("insert into dt_navigation values('System','vip_user_count','会员统计','','vipmemb/VIPUser.aspx',101,0,'',87,',86,87,93,',3,0,'Show',0)");
            sqls.Add("insert into dt_navigation values('System','vip_user_jifen','积分设置','','vipmemb/Integral.aspx',102,0,'',87,',86,87,94,',3,0,'Show',0)");
            sqls.Add("insert into dt_navigation values('System','vip_user_money','钱包设置','','vipmemb/Wallet.aspx',103,0,'',87,',86,87,95,',3,0,'Show',0)");
            

            sqls.Add("insert into dt_navigation values('System','vip_card_config','会员卡配置','','vipmemb/VipcardEdit.aspx',99,0,'',88,',86,88,97,',3,0,'Show',0)");
            sqls.Add("insert into dt_navigation values('System','vip_card_share','会员分享管理','','vipmemb/VIP_Share_List.aspx',100,0,'',88,',86,88,98,',3,0,'Show',0)");
            sqls.Add("insert into dt_navigation values('System','vip_card_sharelog','会员分享日志','','vipmemb/VIP_Share_Log.aspx',101,0,'',88,',86,88,99,',3,0,'Show',0)");
            sqls.Add("insert into dt_navigation values('System','vip_card_coupons','优惠券管理','','vipmemb/Voucher_List.aspx',102,0,'',88,',86,88,100,',3,0,'Show',0)");
            sqls.Add("insert into dt_navigation values('System','vip_card_coulog','优惠券日志','','vipmemb/Voucher_Log.aspx',103,0,'',88,',86,88,101,',3,0,'Show',0)");
            sqls.Add("insert into dt_navigation values('System','vip_card_cardcla','会员卡等级','','vipmemb/Rankinfo.aspx',104,0,'',88,',,86,88,102,',3,0,'Show',0)");
            sqls.Add("insert into dt_navigation values('System','vip_card_cardright','会员卡特权','','vipmemb/Franchises.aspx',105,0,'',88,',86,88,103,',3,0,'Show',0)");
            sqls.Add("insert into dt_navigation values('System','vip_card_huodong','会员卡活动','','vipmemb/Vip_Activity.aspx',106,0,'',88,',86,88,104,',3,0,'Show',0)");
            sqls.Add("insert into dt_navigation values('System','vip_card_account','会员卡统计','','vipmemb/VIPCardCount.aspx',107,0,'',88,',86,88,105,',3,0,'Show',0)");

            sqls.Add("insert into dt_navigation values('System','vip_share_add','会员分享添加','','vipmemb/VIP_Share_Add.aspx',99,0,'',89,',86,89,106,',3,0,'Show',0)");
            sqls.Add("insert into dt_navigation values('System','vip_share_log','会员分享日志','','vipmemb/VIP_Share_Log.aspx',100,0,'',89,',86,89,107,',3,0,'Show',0)");

            sqls.Add("insert into dt_navigation values('System','vip_coupons_add','代金券添加','','vipmemb/Voucher_Add.aspx',99,0,'',90,',86,90,108,',3,0,'Show',0)");
            sqls.Add("insert into dt_navigation values('System','vip_coupons_log','代金券日志','','vipmemb/Voucher_Log.aspx',100,0,'',90,',86,90,109,',3,0,'Show',0)");

            //
            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('默认','black',1,1,0)");



            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('大桥','wine',1,1,0)");



            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('天空','white',1,1,0)");



            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('经典','win8',1,1,0)");
            

            
            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('加成','jiach',1,1,0)");
            

            
            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('布勒','minu',1,1,0)");
            

            
            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('蓝色','bangc',1,1,0)");
            

            
            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('商务','gogo',1,1,0)");
            

            
            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('深蓝','blue',1,1,0)");
            

            
            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('北电','wdp',1,1,0)");
            

            
            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('通用列表','list_comm',1,2,0)");
            

            
            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('通用详情','detail_comm',1,3,0)");
            

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('风景','ytz',1,1,0)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('列表2','list_2',1,2,0)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('详情2','detail_2',1,3,0)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('海逸','haiyi',1,1,0)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('科技','creatrue',1,1,1)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('科技列表','list_3',1,2,1)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('科技详情','detail_3',1,3,1)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('健康','health',1,1,0)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('工业一','industry1',1,1,0)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('工业二','industry2',1,1,0)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('新模版1','Tnew1',1,1,0)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('新模版2','Tnew2',1,1,0)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('伊萨','yisa',1,1,0)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('新模版3','Tnew3',1,1,0)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('新模版4','Tnew4',1,1,0)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('新模板5','Tnew5',1,1,0)");
    
            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('新模板6','Tnew6',1,1,0)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('新模板7','Tnew7',1,1,0)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('子玉田园','ziyu',1,1,0)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('辰竹','chenzhuo',1,1,0)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('列表4','list_4',1,2,0)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('列表5','list_5',1,2,0)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('列表6','list_6',1,2,0)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('列表7','list_7',1,2,0)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('列表8','list_8',1,2,0)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('列表9','list_9',1,2,0)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('详情4','detail_4',1,3,0)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('详情5','detail_5',1,3,0)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('红色','red',1,4,0)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('蓝色','blue',1,4,0)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('黑色','black',1,4,0)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('橙色','orange',1,4,0)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('绿色','green',1,4,0)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('上海','yadong',1,1,0)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('梦回江南','mhjn',1,1,0)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('动物园','zoo',1,1,0)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('动物园','zoo',1,2,0)");

            sqls.Add("insert into wx_theme(t_name, t_theme, tvip, cid, isActive) values('动物园','zoo',1,3,0)");


            try
            {
                if (File.Exists(context.Request.MapPath("upload/lock.txt")))
                {
                    File.Delete(context.Request.MapPath("upload/lock.txt"));
                }
                FileStream fs = new FileStream(context.Request.MapPath("upload/lock.txt"), FileMode.CreateNew);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(DateTime.Now);  //这里是写入的内容
                sw.Flush();

                bool isSuccess = ExecuteSqlTran(sqls, connStr);

                if (isSuccess)
                {
                    ajaxMsg("ok", "", "");
                }
                else
                {
                    ajaxMsg("no", "", "");
                }
            }
            catch (Exception ex2)
            {
                ajaxMsg("no", "", "");
                throw new Exception(ex2.Message);
            }
        }

    
        void WriteDbSet(string appSettingsName, string newValue)
        {
            string fileName = HttpContext.Current.Server.MapPath(@"../Web.config");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            XmlNodeList topM = xmlDoc.DocumentElement.ChildNodes;
            foreach (XmlElement element in topM)
            {
                #region 取得目标节点，并赋新值

                if (element.Name == "connectionStrings")
                {
                    XmlNodeList node = element.ChildNodes;
                    if (node.Count > 0)
                    {
                        foreach (XmlElement el in node)
                        {
                            if (el.Attributes["name"].Value == appSettingsName)
                            {
                                el.Attributes["connectionString"].Value = newValue;
                                xmlDoc.Save(fileName);
                                return;
                            }
                        }
                    }
                }
                #endregion
            }
        }

        DataTable GetDataTable(string connStr, string sql)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter ada = new SqlDataAdapter(sql, conn);
                ada.Fill(dt);
            }
            return dt;
        }

        void ajaxMsg(string result,string code,string message)
        {
            string str = "{\"result\":\"" + result + "\",\"code\":\"" + code + "\",\"message\":\"" + message + "\"}";
            context.Response.Write(str);
        }

        //bool Exists(string db, string tb)
        //{
        //    string sql = "select * from " + db + ".dbo.sysobjects where name = '" + tb + "'";
        //    return GetDataTable(sql) != null;
        //}

        int ExecuteNonQuery(string sql,string connStr)
        {
            int res = -1;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                        //SqlTransaction tr = conn.BeginTransaction();
                        cmd.CommandText = sql;
                        //cmd.Transaction = tr;
                        cmd.Connection = conn;

                        try
                        {
                            res = cmd.ExecuteNonQuery();
                            //tr.Commit();
                        }
                        catch (Exception ex)
                        {
                            //tr.Rollback();
                            throw new Exception(ex.Message);
                        }
                    }
                }
            }
            return res;
        }

        //DataTable GetDataTable(string sql)
        //{
        //    string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        //    DataTable dt = new DataTable();
        //    using (SqlConnection conn = new SqlConnection(connStr))
        //    {
        //        SqlDataAdapter ada = new SqlDataAdapter(sql, conn);
        //        ada.Fill(dt);
        //    }
        //    return dt;
        //}

        List<String> GetSqls(string folder)
        {
            ArrayList list = GetAllFilesByFolder(context.Request.MapPath(folder), "*.sql", false);

            List<String> sqls = new List<string>();
            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    string sql = GetFileContent(list[i].ToString());
                    if (!string.IsNullOrEmpty(sql))
                    {
                        sqls.Add(sql);
                    }
                }
            }
            return sqls;
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>		
        bool ExecuteSqlTran(List<String> SQLStringList,string connStr)
        {
            bool isSuccess = false;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    //int count = 0;
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n];
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            //count += cmd.ExecuteNonQuery();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                    isSuccess = true;
                }
                catch
                {
                    tx.Rollback();
                }
            }
            return isSuccess;
        }


        /// <summary>  
        /// 获取文件的内容  
        /// </summary>  
        /// <param name="file"></param>  
        /// <returns></returns>  
        public static string GetFileContent(string file)
        {
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.Default);
            StringBuilder output = new StringBuilder();
            string rl;
            while ((rl = sr.ReadLine()) != null)
            {
                if (rl != "GO")
                {
                    output.Append(rl + "\n");
                }
            }
            sr.Close();
            fs.Close();
            return output.ToString();
        }

        #region 获取指定文件夹下所有的文件名称 ArrayList GetAllFilesByFolder(string foldername, string filefilter, bool iscontainsubfolder)
        /// <summary>
        /// 获取指定文件夹下所有的文件名称
        /// </summary>
        /// <param name="foldername">指定文件夹名称,绝对路径</param>
        /// <param name="filefilter">文件类型过滤,根据文件后缀名,如:*,*.txt,*.xls</param>
        /// <param name="iscontainsubfolder">是否包含子文件夹</param>
        /// <returns>arraylist数组,为所有需要的文件路径名称</returns>
        ArrayList GetAllFilesByFolder(string foldername, string filefilter, bool iscontainsubfolder)
        {
            ArrayList resarray = new ArrayList();
            string[] files = Directory.GetFiles(foldername, filefilter);
            for (int i = 0; i < files.Length; i++)
            {
                resarray.Add(files[i]);
            }
            if (iscontainsubfolder)
            {
                string[] folders = Directory.GetDirectories(foldername);
                for (int j = 0; j < folders.Length; j++)
                {
                    //遍历所有文件夹
                    ArrayList temp = GetAllFilesByFolder(folders[j], filefilter, iscontainsubfolder);
                    resarray.AddRange(temp);
                }
            }
            return resarray;
        }
        #endregion



        /// <summary> 
        /// 加密数据 
        /// </summary> 
        /// <param name="Text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public string Encrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray;
            inputByteArray = Encoding.Default.GetBytes(Text);
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }



        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}