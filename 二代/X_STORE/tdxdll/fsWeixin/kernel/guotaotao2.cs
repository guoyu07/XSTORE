using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using tdx.database;

namespace tdx.kernel
{
    public class guotaotao2
    {
        private string _content = "";
        public string _FromUserName = "";
        public int msgType = 0;
        public int isFirst = 0;
        public int pid = 0;
        public string _toUserName = "";
        public string _nichen = "";
        private string _GNTheme = "appvbsj";

        #region "构造函数"
        public guotaotao2()
        {
        }
        public guotaotao2(string content)
        {
            this._content = content;
        }
        public guotaotao2(string content, string FromUserName)
        {
            this._content = content;
            this._FromUserName = FromUserName;
        }
        public guotaotao2(string content, string FromUserName, string ToUserName)
        {
            this._content = content;
            this._FromUserName = FromUserName;
            this._toUserName = ToUserName;
        }
        #endregion

        public string GetReMsg()
        {
            string resXML = "";
            try
            {
                string _sql = "select id,k_answer,fid,k_url,k_image,k_content,k_url2,k_des from wx_keys where (','+k_words+',') like '%," + this._content + ",%' and cityID in (select id from wx_mp where wx_ID='" + this._toUserName + "') and k_words=(select top 1 k_words from wx_keys where (','+k_words+',') like '%," + this._content + ",%' and cityID in (select id from wx_mp where wx_ID='" + this._toUserName + "') group by k_words order by newID()) order by k_sort,id desc";
                _sql += ";\r\n select wx_nichen,wx_FirstIsGif from wx_mp where wx_ID='" + this._toUserName + "'";
                _sql += ";\r\n select top 1 * from b2c_ads where cno like '003%' and cityID in (select id from wx_mp where wx_ID='" + this._toUserName + "') order by a_sort,id desc";
                _sql += ";\r\n select top 6 * from b2c_goods where g_name like '%" + this._content + "%' and g_isactive=1 and g_isdel=0 and cityID in (select wid from wx_mp where wx_ID='" + this._toUserName + "') order by g_sort,id desc";
                _sql += ";\r\n select top 6 * from b2c_tmsg where t_title like '%" + this._content + "%' and t_isactive=1 and t_isdel=0 and cityID in (select wid from wx_mp where wx_ID='" + this._toUserName + "') order by t_sort,id desc";
                _sql += ";\r\n select top 1 wx_GNTheme from b2c_worker where id in (select wid from wx_mp where wx_ID='" + this._toUserName + "')";
                DataSet ds = comfun.GetDataSetBySQL(_sql);
                if (ds.Tables[0].Rows.Count > 0) //有内容可回复
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    DataRow dr2 = ds.Tables[1].Rows[0];
                    DataRow dr3 = ds.Tables[2].Rows[0];
                    DataRow dr5 = ds.Tables[5].Rows[0];
                    _GNTheme = dr5["wx_GNTheme"].ToString().Trim();

                    string _title = FilterMsg(dr3["a_name"].ToString().Trim());
                    string _pic = string.IsNullOrEmpty(dr["k_image"].ToString().Trim()) ? "http://www.tdx.cn" + dr3["a_adGif"].ToString().Trim() : dr["k_image"].ToString().Trim();
                    string _des = dr["k_answer"].ToString().Trim();
                    string _url = string.IsNullOrEmpty(dr["k_image"].ToString().Trim()) ? ("http://www.tdx.cn/" + dr5["wx_GNTheme"].ToString().Trim() + "/showKey.aspx?id=" + dr["id"].ToString().Trim() + "&") : (dr3["a_url"].ToString().Trim() + "?");
                    _url += "WWX=" + this._toUserName + "&WWV=" + this._FromUserName;

                    if (!string.IsNullOrEmpty(dr["k_url"].ToString()))
                    {
                        string _outUrl = dr["k_url"].ToString();
                        if (_outUrl.IndexOf("?") != -1)
                            _outUrl += "&q=" + this._content + "&v=" + this._FromUserName + "&u=" + this._toUserName;
                        else
                            _outUrl += "?q=" + this._content + "&v=" + this._FromUserName + "&u=" + this._toUserName;

                        _des = func.webRequestGet(_outUrl);//通过外部地址获取内容
                    }

                    if (Convert.ToInt32(dr["fid"]) == 0)
                    {
                        if (!string.IsNullOrEmpty(dr["k_image"].ToString()))//判断关键词回复是否图文模式
                        {

                            resXML = "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>" + ds.Tables[0].Rows.Count.ToString() + "</ArticleCount><Articles>";
                            foreach (DataRow dr4 in ds.Tables[0].Rows)
                            {
                                _title = FilterMsg(dr4["k_answer"].ToString().Trim());
                                _pic = "http://www.tdx.cn" + dr4["k_image"].ToString().Trim();
                                _des = string.IsNullOrEmpty(dr4["k_des"].ToString().Trim()) ? dr4["k_answer"].ToString().Trim() : dr4["k_des"].ToString().Trim();
                                _url = "http://www.tdx.cn/" + this._GNTheme + "/showKeys.aspx?WWX=" + this._toUserName + "&WWV=" + this._FromUserName + "&id=" + dr4["id"].ToString().Trim();
                                if (!string.IsNullOrEmpty(dr4["k_url2"].ToString()))
                                {
                                    _url = dr4["k_url2"].ToString().Trim();
                                }
                                resXML += GetSingleNews(_title, _pic, _des, _url);
                            }
                            resXML += "</Articles>";
                        }
                        else
                        {
                            if (Convert.ToInt32(dr2["wx_FirstIsGif"]) == 1)
                            {
                                resXML = "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>1</ArticleCount><Articles>";
                                resXML += GetSingleNews(_title, _pic, _des, _url);
                                resXML += "</Articles>";
                            }
                            else
                            {
                                resXML = "<MsgType><![CDATA[text]]></MsgType><Content><![CDATA[" + _des + "]]></Content>";
                            }
                        }
                    }
                    else
                    {
                        switch (Convert.ToInt32(dr["fid"]))
                        {
                            case 1:
                                resXML += GetRanGoods();
                                break;
                            case 2:
                                resXML += GetCategory();
                                break;
                            case 3:
                                resXML += GetTopGoods();
                                break;
                            case 4:
                                resXML += GetRanNews();
                                break;
                            case 5:
                                resXML += GetTopNews();
                                break;
                            case 6:
                                resXML = "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>1</ArticleCount><Articles>";
                                resXML += GetYouhui(this._FromUserName);
                                resXML += "</Articles>";
                                break;
                            case 7:
                                resXML = "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>1</ArticleCount><Articles>";
                                resXML += GetHonor(this._FromUserName);
                                resXML += "</Articles>";
                                break;
                            case 8:
                                resXML = GetFirst();
                                break;
                        }
                    }
                }
                else if (ds.Tables[3].Rows.Count > 0) //有产品与之相匹配
                {
                    DataRow dr2 = ds.Tables[1].Rows[0];
                    string _url = "http://www.tdx.cn/" + this._GNTheme + "/prolist.aspx?WWX=" + this._toUserName + "&WWV=" + this._FromUserName;
                    string _des = ds.Tables[3].Rows[0]["g_name"].ToString().Trim() + "\r\n" + ds.Tables[3].Rows[0]["g_des"].ToString().Trim();
                    if (Convert.ToInt32(dr2["wx_FirstIsGif"]) == 1)
                    {
                        resXML = "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>" + (ds.Tables[3].Rows.Count + 1).ToString() + "</ArticleCount><Articles>";
                        foreach (DataRow dr4 in ds.Tables[3].Rows)
                        {
                            string _title = FilterMsg(dr4["g_name"].ToString().Trim());
                            string _pic = "http://www.tdx.cn" + dr4["g_gif"].ToString().Trim();
                            _des = dr4["g_des"].ToString().Trim();
                            _url = "http://www.tdx.cn/" + this._GNTheme + "/showpro.aspx?WWX=" + this._toUserName + "&WWV=" + this._FromUserName + "&id=" + dr4["id"].ToString().Trim();
                            resXML += GetSingleNews(_title, _pic, _des, _url);
                        }
                        resXML += GetSingleNews("更多请点击>>>", "", "", "http://www.tdx.cn/" + this._GNTheme + "/prolist.aspx?WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                        resXML += "</Articles>";
                    }
                    else
                    {
                        resXML = "<MsgType><![CDATA[text]]></MsgType><Content><![CDATA[" + _des + "]]></Content>";
                    }
                }
                else //如果没有回复内容则
                {

                    resXML = GetDefault();
                }
            }
            catch (Exception ex)
            {
                resXML += "<MsgType><![CDATA[text]]></MsgType><Content><![CDATA[" + ex.Message + "]]></Content>"; ;
            }

            return resXML;
        }
        public string GetDefault()
        {
            string ReMsg = "";
            ReMsg = "输入\"?\"或\"帮助\"或\"Help\"或\"求助\"，获取帮助信息。";
            string resXML = "";
            try
            {
                string _sql = "";
                _sql += ";\r\n select wx_nichen,wx_FirstIsGif from wx_mp where wx_ID='" + this._toUserName + "'";
                _sql += ";\r\n select top 1 * from b2c_ads where cno like '003%' and cityID in (select id from wx_mp where wx_ID='" + this._toUserName + "') order by a_sort,id desc";

                DataSet ds = comfun.GetDataSetBySQL(_sql);

                DataRow dr2 = ds.Tables[0].Rows[0];
                DataRow dr3 = ds.Tables[1].Rows[0];
                string _title = "亲，没看懂您的意思 " + this._content;
                string _pic = "http://www.tdx.cn" + dr3["a_adGif"].ToString().Trim();
                string _des = ReMsg;
                string _url = dr3["a_url"].ToString().Trim() + "?WWX=" + this._toUserName + "&WWV=" + this._FromUserName;
                if (ds.Tables[1].Rows.Count > 0)
                {
                    _des = dr3["a_des"].ToString().Trim();
                }

                if (Convert.ToInt32(dr2["wx_FirstIsGif"]) == 1)
                {
                    resXML = "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>1</ArticleCount><Articles>";
                    resXML += GetSingleNews(_title, _pic, _des, _url);
                    resXML += "</Articles>";
                }
                else
                {

                    resXML = "<MsgType><![CDATA[text]]></MsgType><Content><![CDATA[" + _des + "]]></Content>";
                }
            }
            catch (Exception ex)
            {
                resXML = resXML = "<MsgType><![CDATA[text]]></MsgType><Content><![CDATA[" + ex.Message + "]]></Content>"; ;
            }

            return resXML;
        }

        public string GetFirst() //修改成图文模式
        {
            string resXML = "";
            string _sql = "select top 1 * from b2c_ads where cno like '001%' and cityID in (select id from wx_mp where wx_ID='" + this._toUserName + "') order by a_sort,id desc";
            _sql += ";\r\n select wx_nichen,wx_FirstIsGif from wx_mp where wx_ID='" + this._toUserName + "'";
            DataSet ds = comfun.GetDataSetBySQL(_sql);
            if (ds.Tables[0].Rows.Count > 0) //有内容可回复
            {
                DataRow dr = ds.Tables[0].Rows[0];
                DataRow dr2 = ds.Tables[1].Rows[0];
                this._nichen = dr2["wx_nichen"].ToString().Trim();
                string _title = FilterMsg(dr["a_name"].ToString().Trim());
                string _pic = "http://www.tdx.cn" + dr["a_adGif"].ToString().Trim();
                string _des = dr["a_des"].ToString().Trim();
                string _url = dr["a_url"].ToString().Trim() + "?WWX=" + this._toUserName + "&WWV=" + this._FromUserName;


                if (Convert.ToInt32(ds.Tables[1].Rows[0]["wx_FirstIsGif"]) == 1)
                {
                    resXML = "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>1</ArticleCount><Articles>";
                    resXML += GetSingleNews(_title, _pic, _des, _url);
                    resXML += "</Articles>";
                }
                else
                {
                    resXML = "<MsgType><![CDATA[text]]></MsgType><Content><![CDATA[" + _des + "]]></Content>";
                }
            }
            return resXML;
        }
        public string GetByebye() //修改成图文模式
        {
            string resXML = "";
            string _sql = "select top 1 * from b2c_ads where cno like '001%' and cityID in (select id from wx_mp where wx_ID='" + this._toUserName + "') order by a_sort,id desc";
            _sql += "select wx_nichen,wx_FirstIsGif from wx_mp where wx_ID='" + this._toUserName + "'";
            DataSet ds = comfun.GetDataSetBySQL(_sql);
            if (ds.Tables[0].Rows.Count > 0) //有内容可回复
            {
                DataRow dr = ds.Tables[0].Rows[0];
                DataRow dr2 = ds.Tables[1].Rows[0];
                string _title = dr["a_name"].ToString().Trim().Replace("{$昵称$}", dr2["wx_nichen"].ToString().Trim());
                string _pic = dr["a_adGif"].ToString().Trim();
                string _des = dr["a_des"].ToString().Trim();
                string _url = dr["a_url"].ToString().Trim() + "?WWX=" + this._toUserName + "&WWV=" + this._FromUserName;

                resXML = "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>1</ArticleCount><Articles>";
                resXML += GetSingleNews(_title, _pic, _des, _url);
                resXML += "</Articles>";
            }
            return resXML;
        }

        #region "功能函数"
        public string GetRanGoods()
        {
            string resxml = "";
            string _xml = "<item><Title><![CDATA[{0}]]></Title><Description><![CDATA[{1}]]></Description><PicUrl><![CDATA[{2}]]></PicUrl><Url><![CDATA[{3}]]></Url></item>"; ;
            string _sql = "select top 6 * from B2C_goods where g_isactive=1 and g_isdel=0 and cityID in (select wid from wx_mp where  wx_id='" + this._toUserName + "') order by newid()";
            _sql += "\r\n; select top 1 * from b2c_ads where cno='004' and cityID in (select id from wx_mp where wx_id='" + this._toUserName + "')";
            DataSet ds = comfun.GetDataSetBySQL(_sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    resxml += "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>" + (ds.Tables[0].Rows.Count + 2).ToString() + "</ArticleCount><Articles>";
                    DataRow dr = ds.Tables[1].Rows[0];
                    resxml += string.Format(_xml, dr["a_name"].ToString().Trim(), dr["a_des"].ToString().Trim(), "http://www.tdx.cn" + dr["a_adgif"].ToString().Trim().Replace("all", "min"), dr["a_url"].ToString().Trim() + "?WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                }
                else
                {
                    resxml += "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>" + (ds.Tables[0].Rows.Count + 1).ToString() + "</ArticleCount><Articles>";
                }

                this.pid = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    resxml += string.Format(_xml, dr["g_name"].ToString().Trim(), dr["g_des"].ToString().Trim(), "http://www.tdx.cn" + dr["g_gif"].ToString().Trim().Replace("all", "min"), "http://www.tdx.cn/" + this._GNTheme + "/showpro.aspx?id=" + dr["id"].ToString() + "&WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                }
                resxml += string.Format(_xml, "更多商品请点击", "更多商品请点击", "", "http://www.tdx.cn/" + this._GNTheme + "/pros.aspx?WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                resxml += "</Articles>";
            }
            else
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    resxml += "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>1</ArticleCount><Articles>";
                    DataRow dr = ds.Tables[1].Rows[0];
                    resxml += string.Format(_xml, dr["a_name"].ToString().Trim(), dr["a_des"].ToString().Trim(), "http://www.tdx.cn" + dr["a_adgif"].ToString().Trim().Replace("all", "min"), dr["a_url"].ToString().Trim() + "?WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                    resxml += "</Articles>";
                }
                else
                {
                    resxml += "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>1</ArticleCount><Articles>";
                    resxml += string.Format(_xml, "你想查看本站商品吗？", "抱歉本站还没有商品", "", "http://www.tdx.cn/" + this._GNTheme + "/pros.aspx?WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                    resxml += "</Articles>";
                }
            }

            ds.Dispose();
            ds = null;

            return resxml;
        }
        public string GetTopGoods()
        {
            string resxml = "";
            string _xml = "<item><Title><![CDATA[{0}]]></Title><Description><![CDATA[{1}]]></Description><PicUrl><![CDATA[{2}]]></PicUrl><Url><![CDATA[{3}]]></Url></item>"; ;
            string _sql = "select top 6 * from B2C_goods where g_isactive=1 and g_isdel=0 and cityID in (select wid from wx_mp where wx_id='" + this._toUserName + "') order by g_sort,id desc";
            _sql += "\r\n; select top 1 * from b2c_ads where cno='004' and cityID in (select id from wx_mp where wx_id='" + this._toUserName + "')";
            DataSet ds = comfun.GetDataSetBySQL(_sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    resxml += "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>" + (ds.Tables[0].Rows.Count + 2).ToString() + "</ArticleCount><Articles>";
                    DataRow dr = ds.Tables[1].Rows[0];
                    resxml += string.Format(_xml, dr["a_name"].ToString().Trim(), dr["a_des"].ToString().Trim(), "http://www.tdx.cn" + dr["a_adgif"].ToString().Trim().Replace("all", "min"), dr["a_url"].ToString().Trim() + "?WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                }
                else
                {
                    resxml += "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>" + (ds.Tables[0].Rows.Count + 1).ToString() + "</ArticleCount><Articles>";
                }

                this.pid = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    resxml += string.Format(_xml, dr["g_name"].ToString().Trim(), dr["g_des"].ToString().Trim(), "http://www.tdx.cn" + dr["g_gif"].ToString().Trim().Replace("all", "min"), "http://www.tdx.cn/" + this._GNTheme + "/showpro.aspx?id=" + dr["id"].ToString() + "&WWX=" + this._toUserName + "+&WWV=" + this._FromUserName);
                }
                resxml += string.Format(_xml, "更多商品请点击", "更多商品请点击", "", "http://www.tdx.cn/" + this._GNTheme + "/pros.aspx?WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                resxml += "</Articles>";
            }
            else
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    resxml += "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>1</ArticleCount><Articles>";
                    DataRow dr = ds.Tables[1].Rows[0];
                    resxml += string.Format(_xml, dr["a_name"].ToString().Trim(), dr["a_des"].ToString().Trim(), "http://www.tdx.cn" + dr["a_adgif"].ToString().Trim().Replace("all", "min"), dr["a_url"].ToString().Trim() + "?WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                    resxml += "</Articles>";
                }
                else
                {
                    resxml += "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>1</ArticleCount><Articles>";
                    resxml += string.Format(_xml, "你想查看本站商品吗？", "抱歉本站还没有商品", "", "http://www.tdx.cn/" + this._GNTheme + "/pros.aspx?WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                    resxml += "</Articles>";
                }
            }

            ds.Dispose();
            ds = null;

            return resxml;
        }
        public string GetCategory()
        {
            string resxml = "";
            string _xml = "<item><Title><![CDATA[{0}]]></Title><Description><![CDATA[{1}]]></Description><PicUrl><![CDATA[{2}]]></PicUrl><Url><![CDATA[{3}]]></Url></item>"; ;
            string _sql = "select top 6 * from B2C_category where c_isactive=1 and c_isdel=0 and cityID in (select wid from wx_mp where wx_id='" + this._toUserName + "') order by newid()";
            _sql += "\r\n; select top 1 * from b2c_ads where cno='004' and cityID in (select id from wx_mp where wx_id='" + this._toUserName + "')";
            DataSet ds = comfun.GetDataSetBySQL(_sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    resxml += "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>" + (ds.Tables[0].Rows.Count + 2).ToString() + "</ArticleCount><Articles>";
                    DataRow dr = ds.Tables[1].Rows[0];
                    resxml += string.Format(_xml, dr["a_name"].ToString().Trim(), dr["a_des"].ToString().Trim(), "http://www.tdx.cn" + dr["a_adgif"].ToString().Trim().Replace("all", "min"), dr["a_url"].ToString().Trim() + "?WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                }
                else
                {
                    resxml += "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>" + (ds.Tables[0].Rows.Count + 1).ToString() + "</ArticleCount><Articles>";
                }

                this.pid = Convert.ToInt32(ds.Tables[0].Rows[0]["c_id"].ToString());
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    resxml += string.Format(_xml, dr["c_name"].ToString().Trim(), dr["c_des"].ToString().Trim(), "http://www.tdx.cn" + dr["c_gif"].ToString().Trim().Replace("all", "min"), "http://www.tdx.cn/" + this._GNTheme + "/prolist.aspx?cno=" + dr["c_no"].ToString() + "&WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                }
                resxml += string.Format(_xml, "更多商品请点击", "更多商品请点击", "", "http://www.tdx.cn/" + this._GNTheme + "/pros.aspx?WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                resxml += "</Articles>";
            }
            else
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    resxml += "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>1</ArticleCount><Articles>";
                    DataRow dr = ds.Tables[1].Rows[0];
                    resxml += string.Format(_xml, dr["a_name"].ToString().Trim(), dr["a_des"].ToString().Trim(), "http://www.tdx.cn" + dr["a_adgif"].ToString().Trim().Replace("all", "min"), dr["a_url"].ToString().Trim() + "?WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                    resxml += "</Articles>";
                }
                else
                {
                    resxml += "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>1</ArticleCount><Articles>";
                    resxml += string.Format(_xml, "你想查看本站商品吗？", "抱歉本站还没有商品", "", "http://www.tdx.cn/" + this._GNTheme + "/pros.aspx?WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                    resxml += "</Articles>";
                }
            }

            ds.Dispose();
            ds = null;

            return resxml;
        }
        public string GetRanNews()
        {
            string resxml = "";
            string _xml = "<item><Title><![CDATA[{0}]]></Title><Description><![CDATA[{1}]]></Description><PicUrl><![CDATA[{2}]]></PicUrl><Url><![CDATA[{3}]]></Url></item>"; ;
            string _sql = "select top 6 * from B2C_tmsg where t_isactive=1 and t_isdel=0 and cityID in (select wid from wx_mp where wx_id='" + this._toUserName + "') order by newid()";
            _sql += "\r\n; select top 1 * from b2c_ads where cno='005' and cityID in (select id from wx_mp where wx_id='" + this._toUserName + "')";
            DataSet ds = comfun.GetDataSetBySQL(_sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    resxml += "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>" + (ds.Tables[0].Rows.Count + 2).ToString() + "</ArticleCount><Articles>";
                    DataRow dr = ds.Tables[1].Rows[0];
                    resxml += string.Format(_xml, dr["a_name"].ToString().Trim(), dr["a_des"].ToString().Trim(), "http://www.tdx.cn" + dr["a_adgif"].ToString().Trim().Replace("all", "min"), dr["a_url"].ToString().Trim() + "?WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                }
                else
                {
                    resxml += "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>" + (ds.Tables[0].Rows.Count + 1).ToString() + "</ArticleCount><Articles>";
                }

                this.pid = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    resxml += string.Format(_xml, dr["t_title"].ToString().Trim(), dr["t_des"].ToString().Trim(), "http://www.tdx.cn" + dr["t_gif"].ToString().Trim().Replace("all", "min"), "http://www.tdx.cn/" + this._GNTheme + "/shownews.aspx?id=" + dr["id"].ToString() + "&WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                }
                resxml += string.Format(_xml, "更多动态请点击", "更多动态请点击", "", "http://www.tdx.cn/" + this._GNTheme + "/news.aspx?WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                resxml += "</Articles>";
            }
            else
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    resxml += "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>1</ArticleCount><Articles>";
                    DataRow dr = ds.Tables[1].Rows[0];
                    resxml += string.Format(_xml, dr["a_name"].ToString().Trim(), dr["a_des"].ToString().Trim(), "http://www.tdx.cn" + dr["a_adgif"].ToString().Trim().Replace("all", "min"), dr["a_url"].ToString().Trim() + "?WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                    resxml += "</Articles>";
                }
                else
                {
                    resxml += "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>1</ArticleCount><Articles>";
                    resxml += string.Format(_xml, "你想查看本站动态吗？", "抱歉本站还没有动态信息", "", "http://www.tdx.cn/" + this._GNTheme + "/news.aspx?WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                    resxml += "</Articles>";
                }
            }

            ds.Dispose();
            ds = null;

            return resxml;
        }
        public string GetTopNews()
        {
            string resxml = "";
            string _xml = "<item><Title><![CDATA[{0}]]></Title><Description><![CDATA[{1}]]></Description><PicUrl><![CDATA[{2}]]></PicUrl><Url><![CDATA[{3}]]></Url></item>"; ;
            string _sql = "select top 6 * from B2C_tmsg where t_isactive=1 and t_isdel=0 and cityID in (select wid from wx_mp where wx_id='" + this._toUserName + "') order by t_sort,id desc";
            _sql += "\r\n; select top 1 * from b2c_ads where cno='005' and cityID in (select id from wx_mp where wx_id='" + this._toUserName + "')";
            DataSet ds = comfun.GetDataSetBySQL(_sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    resxml += "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>" + (ds.Tables[0].Rows.Count + 2).ToString() + "</ArticleCount><Articles>";
                    DataRow dr = ds.Tables[1].Rows[0];
                    resxml += string.Format(_xml, dr["a_name"].ToString().Trim(), dr["a_des"].ToString().Trim(), "http://www.tdx.cn" + dr["a_adgif"].ToString().Trim().Replace("all", "min"), dr["a_url"].ToString().Trim() + "?WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                }
                else
                {
                    resxml += "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>" + (ds.Tables[0].Rows.Count + 1).ToString() + "</ArticleCount><Articles>";
                }

                this.pid = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    resxml += string.Format(_xml, dr["t_title"].ToString().Trim(), dr["t_des"].ToString().Trim(), "http://www.tdx.cn" + dr["t_gif"].ToString().Trim().Replace("all", "min"), "http://www.tdx.cn/" + this._GNTheme + "/shownews.aspx?id=" + dr["id"].ToString() + "&WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                }
                resxml += string.Format(_xml, "更多动态请点击", "更多动态请点击", "", "http://www.tdx.cn/" + this._GNTheme + "/news.aspx?WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                resxml += "</Articles>";
            }
            else
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    resxml += "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>1</ArticleCount><Articles>";
                    DataRow dr = ds.Tables[1].Rows[0];
                    resxml += string.Format(_xml, dr["a_name"].ToString().Trim(), dr["a_des"].ToString().Trim(), "http://www.tdx.cn" + dr["a_adgif"].ToString().Trim().Replace("all", "min"), dr["a_url"].ToString().Trim() + "?WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                    resxml += "</Articles>";
                }
                else
                {
                    resxml += "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>1</ArticleCount><Articles>";
                    resxml += string.Format(_xml, "你想查看本站动态吗？", "抱歉本站还没有动态信息", "", "http://www.tdx.cn/" + this._GNTheme + "/news.aspx?WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                    resxml += "</Articles>";
                }
            }

            ds.Dispose();
            ds = null;

            return resxml;
        }
        public string GetTopNews(string _cno)
        {
            string resxml = "";
            string _xml = "<item><Title><![CDATA[{0}]]></Title><Description><![CDATA[{1}]]></Description><PicUrl><![CDATA[{2}]]></PicUrl><Url><![CDATA[{3}]]></Url></item>"; ;
            string _sql = "select top 6 * from B2C_tmsg where cno like '" + _cno + "%' and t_isactive=1 and t_isdel=0 and cityID in (select wid from wx_mp where wx_id='" + this._toUserName + "') order by t_sort,id desc";
            _sql += "\r\n; select top 1 * from b2c_ads where cno='005' and cityID in (select id from wx_mp where wx_id='" + this._toUserName + "')";
            DataSet ds = comfun.GetDataSetBySQL(_sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    resxml += "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>" + (ds.Tables[0].Rows.Count + 2).ToString() + "</ArticleCount><Articles>";
                    DataRow dr = ds.Tables[1].Rows[0];
                    resxml += string.Format(_xml, dr["a_name"].ToString().Trim(), dr["a_des"].ToString().Trim(), "http://www.tdx.cn" + dr["a_adgif"].ToString().Trim().Replace("all", "min"), dr["a_url"].ToString().Trim() + "?WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                }
                else
                {
                    resxml += "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>" + (ds.Tables[0].Rows.Count + 1).ToString() + "</ArticleCount><Articles>";
                }

                this.pid = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    resxml += string.Format(_xml, dr["t_title"].ToString().Trim(), dr["t_des"].ToString().Trim(), "http://www.tdx.cn" + dr["t_gif"].ToString().Trim().Replace("all", "min"), "http://www.tdx.cn/" + this._GNTheme + "/shownews.aspx?id=" + dr["id"].ToString() + "&WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                }
                resxml += string.Format(_xml, "更多动态请点击", "更多动态请点击", "", "http://www.tdx.cn/" + this._GNTheme + "/news.aspx?WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                resxml += "</Articles>";
            }
            else
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    resxml += "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>1</ArticleCount><Articles>";
                    DataRow dr = ds.Tables[1].Rows[0];
                    resxml += string.Format(_xml, dr["a_name"].ToString().Trim(), dr["a_des"].ToString().Trim(), "http://www.tdx.cn" + dr["a_adgif"].ToString().Trim().Replace("all", "min"), dr["a_url"].ToString().Trim() + "?WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                    resxml += "</Articles>";
                }
                else
                {
                    resxml += "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>1</ArticleCount><Articles>";
                    resxml += string.Format(_xml, "你想查看本站动态吗？", "抱歉本站还没有动态信息", "", "http://www.tdx.cn/" + this._GNTheme + "/news.aspx?WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                    resxml += "</Articles>";
                }
            }

            ds.Dispose();
            ds = null;

            return resxml;
        }
        public string GetTopNews(string _cno, int _num)
        {
            string resxml = "";//
            string _xml = "<item><Title><![CDATA[{0}]]></Title><Description><![CDATA[{1}]]></Description><PicUrl><![CDATA[{2}]]></PicUrl><Url><![CDATA[{3}]]></Url></item>"; ;
            string _sql = "select top " + _num + " * from B2C_tmsg where cno like '" + _cno + "%' and t_isactive=1 and t_isdel=0 and cityID in (select wid from wx_mp where wx_id='" + this._toUserName + "') order by t_sort,id desc";
            _sql += "\r\n; select top 1 * from b2c_ads where cno='005' and cityID in (select id from wx_mp where wx_id='" + this._toUserName + "')";
            DataSet ds = comfun.GetDataSetBySQL(_sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    resxml += "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>" + (ds.Tables[0].Rows.Count + 1).ToString() + "</ArticleCount><Articles>";
                    DataRow dr = ds.Tables[1].Rows[0];
                    resxml += string.Format(_xml, dr["a_name"].ToString().Trim(), dr["a_des"].ToString().Trim(), "http://www.tdx.cn" + dr["a_adgif"].ToString().Trim().Replace("all", "min"), dr["a_url"].ToString().Trim() + "?WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                }
                else
                {
                    resxml += "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>" + ds.Tables[0].Rows.Count.ToString() + "</ArticleCount><Articles>";
                }

                this.pid = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string _url = dr["t_url"].ToString().Trim();
                    if (string.IsNullOrEmpty(_url))
                    {
                        _url = "http://www.tdx.cn/" + this._GNTheme + "/shownews.aspx?id=" + dr["id"].ToString();
                    }
                    if (_url.IndexOf("?") == -1)
                        _url = _url + "?";
                    else
                        _url = _url + "&";
                    resxml += string.Format(_xml, dr["t_title"].ToString().Trim(), dr["t_des"].ToString().Trim(), "http://www.tdx.cn" + dr["t_gif"].ToString().Trim().Replace("all", "min"), _url + "WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                }
                //resxml += string.Format(_xml, "更多动态请点击", "更多动态请点击", "", "http://www.tdx.cn/" + this._GNTheme + "/news.aspx?WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                resxml += "</Articles>";
            }
            else
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    resxml += "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>1</ArticleCount><Articles>";
                    DataRow dr = ds.Tables[1].Rows[0];
                    resxml += string.Format(_xml, dr["a_name"].ToString().Trim(), dr["a_des"].ToString().Trim(), "http://www.tdx.cn" + dr["a_adgif"].ToString().Trim().Replace("all", "min"), dr["a_url"].ToString().Trim() + "?WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                    resxml += "</Articles>";
                }
                else
                {
                    resxml += "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>1</ArticleCount><Articles>";
                    resxml += string.Format(_xml, "你想查看本站动态吗？", "抱歉本站还没有动态信息", "", "http://www.tdx.cn/" + this._GNTheme + "/news.aspx?WWX=" + this._toUserName + "&WWV=" + this._FromUserName);
                    resxml += "</Articles>";
                }
            }

            ds.Dispose();
            ds = null;

            return resxml;
        }
        public string GetYouhui(string _fromUser) //修改成图文模式
        {
            string resXML = "";
            string _yhNo = comEncrypt.GetRndPassword().ToUpper();
            string _title = this._nichen + "现金抵用券";
            string _pic = "http://www.tdx.cn/images/weixin/youhui.png";
            string _des = this._nichen + "抵用券可以在" + this._nichen + "购物时当现金使用。此抵用券不提现，不找零。您获得5元优惠券号码为: " + _yhNo;
            string _url = "http://www.tdx.cn/" + this._GNTheme + "/index.aspx?WWX=" + this._toUserName + "&WWV=" + this._FromUserName;

            DataTable dt = comfun.GetDataTableBySQL("select top 1 * from b2c_ads where cno='007' and cityID in (select id from wx_mp where wx_id='" + this._toUserName + "')");
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                if (!string.IsNullOrEmpty(dr["a_gif"].ToString()))
                    _pic = dr["a_gif"].ToString().Trim();
                if (!string.IsNullOrEmpty(dr["a_url"].ToString()))
                    _url = dr["a_url"].ToString().Trim() + "?WWX=" + this._toUserName + "&WWV=" + this._FromUserName;
            }
            dt.Dispose();

            resXML += GetSingleNews(_title, _pic, _des, _url);
            //插入数据库
            try
            {
                wx_youhui.MyInsert(_fromUser, _yhNo);
            }
            catch (Exception ex) { }

            return resXML;
        }
        public string GetHonor(string _fromUser) //修改成图文模式
        {
            string resXML = "";
            string _title = this._nichen + "幸运大抽奖";
            string _pic = "http://www.tdx.cn/images/weixin/honor.png";
            string _des = "每个账号每天3次抽奖机会.抽到三个连号即中奖,奖品为一瓶石榴汁.抽到三个7，即\"777\",为特等奖,奖品为一瓶石榴汁+一个果淘淘保温杯. ----- 立即开始抽奖";
            string _url = "http://www.tdx.cn/" + this._GNTheme + "/honor_action.aspx?userID=" + _fromUser + "&WWX=" + this._toUserName;
            //resXML = "<MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>1</ArticleCount><Articles>";
            resXML += GetSingleNews(_title, _pic, _des, _url);
            //resXML += "</Articles>";
            DataTable dt = comfun.GetDataTableBySQL("select top 1 * from b2c_ads where cno='008' and cityID in (select id from wx_mp where wx_id='" + this._toUserName + "')");
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                if (!string.IsNullOrEmpty(dr["a_gif"].ToString()))
                    _pic = dr["a_gif"].ToString().Trim();
                //if (!string.IsNullOrEmpty(dr["a_url"].ToString()))
                //    _url = dr["a_url"].ToString().Trim();
            }
            dt.Dispose();
            return resXML;
        }
        #endregion

        public string GetSingleNews(string _title, string _pic, string _des, string _url)
        {
            string resxml = "";
            string _xml = "<item><Title><![CDATA[{0}]]></Title><Description><![CDATA[{1}]]></Description><PicUrl><![CDATA[{2}]]></PicUrl><Url><![CDATA[{3}]]></Url></item>"; ;
            resxml = string.Format(_xml, _title, _des, _pic, _url);

            return resxml;
        }

        public string GetMenuHandle(RequestXML requestXML)
        {
            string resXML = "";
            //guotaotao mi = new guotaotao();
            switch (requestXML.eventKey) //按键的值是设置菜单时开发人员自己设置的
            {
                case "gtt_menu_001001": //无糖系列产品：返回前10个产品。这里要测试能否直接跳转到外部页面上去。
                    //System.Web.HttpContext.Current.Response.Redirect("http://www.fsWeixin.com"); 
                    resXML += GetTopNews("008", 8);//全系车型 
                    break;
                case "gtt_menu_001002": //展厅现车 
                    resXML += GetTopNews("009", 8);//展厅现车 
                    break;
                case "gtt_menu_001003": //认可维修 
                    resXML += GetTopNews("011", 8);//认可维修 
                    break;
                case "gtt_menu_001005": //预约试驾: 
                    resXML += GetTopNews("003", 8);//预约试驾 //修改为8 初始1
                    break;
                case "gtt_menu_001006"://帮助
                    resXML += GetTopNews("023", 8);//新添加  帮助类别
                    break;
                case "gtt_menu_002001": //服务预约: 
                    resXML += GetTopNews("004", 8);
                    break;
                case "gtt_menu_002002": //保时捷服务: 
                    resXML += GetTopNews("019", 8);
                    break;
                case "gtt_menu_002003": //精品和配件:  
                    resXML += GetTopNews("012", 8);
                    break;
                case "gtt_menu_002004": //违章查询:    //原来是独家配件
                    resXML += GetTopNews("013", 8);
                    break;
                case "gtt_menu_002005": //保时捷救援: 
                    resXML += GetTopNews("006", 8);
                    break;
                case "gtt_menu_003001": //车主活动: 
                    resXML += GetTopNews("001", 8);
                    break;
                case "gtt_menu_003002": //活动报名:  
                    resXML += GetTopNews("020", 8); //预约试驾 //修改为8 初始1
                    break;
                   
                case "gtt_menu_003003": //中心简介: 
                    resXML += GetTopNews("014", 8);
                    break;
                case "gtt_menu_003004": //团队介绍:  
                    resXML += GetTopNews("015", 8);
                    break;
                case "gtt_menu_003005": //联系我们:  
                    resXML += GetTopNews("024", 8);
                    //DataTable dt = comfun.GetDataTableBySQL("select top 1 gcontent from b2c_tpage where id=137");
                    //string _pagedes = "";
                    //if (dt.Rows.Count > 0)
                    //    _pagedes = dt.Rows[0][0].ToString().Trim();
                    //resXML = "<MsgType><![CDATA[text]]></MsgType><Content><![CDATA[" + _pagedes + "]]></Content>";
                    //dt.Dispose();
                    break;
                default: //缺省返回说明界面
                    resXML = GetFirst();
                    break;
            }

            return resXML;
        }
        public string createMenuDate()
        {
            string postData = "{" + "\r\n";
            postData += "\"button\":[ " + "\r\n";
            postData += "{	" + "\r\n";
            postData += "\"name\":\"销售车型\"," + "\r\n";
            postData += "\"sub_button\":[" + "\r\n";
            postData += "{	" + "\r\n";
            postData += "   \"type\":\"click\"," + "\r\n";
            postData += "   \"name\":\"全系车型\", " + "\r\n";
            postData += "   \"key\":\"gtt_menu_001001\"" + "\r\n";
            postData += "}," + "\r\n";
            postData += "{	" + "\r\n";
            postData += "   \"type\":\"click\"," + "\r\n";
            postData += "   \"name\":\"现车与热车\", " + "\r\n";
            postData += "   \"key\":\"gtt_menu_001002\"" + "\r\n";
            postData += "}," + "\r\n";
            postData += "{	" + "\r\n";
            postData += "   \"type\":\"click\"," + "\r\n";
            postData += "   \"name\":\"易手车及置换\", " + "\r\n";
            postData += "   \"key\":\"gtt_menu_001003\"" + "\r\n";
            postData += "}," + "\r\n";
            postData += "{	" + "\r\n";
            postData += "   \"type\":\"click\"," + "\r\n";
            postData += "   \"name\":\"预约试驾\", " + "\r\n";
            postData += "   \"key\":\"gtt_menu_001005\"" + "\r\n";
            postData += "}," + "\r\n";
            postData += "{	" + "\r\n";
            postData += "   \"type\":\"click\"," + "\r\n";  //之前是view
            postData += "   \"name\":\"帮助\", " + "\r\n";  //原来是 3d全景修改为 帮助
            postData += "   \"key\":\"gtt_menu_001006\"" + "\r\n";//http://www.tdx.cn/appvbsj/d3/\ 原来
            postData += " }]" + "\r\n";
            postData += "}," + "\r\n";
            postData += "{" + "\r\n";
            postData += "\"name\":\"售后服务\", " + "\r\n";
            postData += "\"sub_button\":[" + "\r\n";
            postData += "{	" + "\r\n";
            postData += "   \"type\":\"click\"," + "\r\n";
            postData += "   \"name\":\"服务预约\", " + "\r\n";
            postData += "   \"key\":\"gtt_menu_002001\"" + "\r\n";
            postData += "}," + "\r\n";
            postData += "{	" + "\r\n";
            postData += "   \"type\":\"click\"," + "\r\n";
            postData += "   \"name\":\"保时捷服务\", " + "\r\n";
            postData += "   \"key\":\"gtt_menu_002002\"" + "\r\n";
            postData += "}," + "\r\n";
            postData += "{	" + "\r\n";
            postData += "   \"type\":\"click\"," + "\r\n";
            postData += "   \"name\":\"精品和配件\", " + "\r\n"; //原来是车主精品
            postData += "   \"key\":\"gtt_menu_002003\"" + "\r\n";
            postData += "}," + "\r\n";
            postData += "{	" + "\r\n";
            postData += "   \"type\":\"click\"," + "\r\n";
            postData += "   \"name\":\"违章查询\", " + "\r\n";  //原来是度假配件
            postData += "   \"key\":\"gtt_menu_002004\"" + "\r\n";
            postData += "}," + "\r\n";
            postData += "{	" + "\r\n";
            postData += "   \"type\":\"click\"," + "\r\n";
            postData += "   \"name\":\"保时捷道路救援\", " + "\r\n";
            postData += "   \"key\":\"gtt_menu_002005\"" + "\r\n";
            postData += " }]" + "\r\n";
            postData += "}," + "\r\n";
            postData += "{" + "\r\n";
            postData += "\"name\":\"其他\"," + "\r\n";
            postData += "\"sub_button\":[" + "\r\n";
            postData += "{	" + "\r\n";
            postData += "   \"type\":\"click\"," + "\r\n";
            postData += "   \"name\":\"车主活动\", " + "\r\n";
            postData += "   \"key\":\"gtt_menu_003001\"" + "\r\n";
            postData += "}," + "\r\n";
            postData += "{	" + "\r\n";
            postData += "   \"type\":\"click\"," + "\r\n";
            postData += "   \"name\":\"活动报名\", " + "\r\n";
            postData += "   \"key\":\"gtt_menu_003002\"" + "\r\n";
            postData += "}," + "\r\n";
            postData += "{	" + "\r\n";
            postData += "   \"type\":\"click\"," + "\r\n";
            postData += "   \"name\":\"中心简介\", " + "\r\n";
            postData += "   \"key\":\"gtt_menu_003003\"" + "\r\n";
            postData += "}," + "\r\n";
            postData += "{	" + "\r\n";
            postData += "   \"type\":\"view\"," + "\r\n";
            postData += "   \"name\":\"保时捷专享App\", " + "\r\n";
            postData += "   \"url\":\"http://tinyurl.com/ojfcs26\"" + "\r\n";
            postData += "}," + "\r\n";
            postData += "{	" + "\r\n";
            postData += "   \"type\":\"click\"," + "\r\n";
            postData += "   \"name\":\"找到我们\", " + "\r\n";  //联系我们修改为找到我们
            postData += "   \"key\":\"gtt_menu_003005\"" + "\r\n";
            postData += " }]" + "\r\n";
            postData += "}]" + "\r\n";
            postData += "}" + "\r\n";

            return postData;
        }

        public string GetReMap()
        {
            return "";
        }

        private string FilterMsg(string _source)
        {
            _source = _source.Replace("[$昵称$]", this._nichen);
            _source = _source.Replace("[$关键词$]", this._content);

            return _source;
        }
    }
}
