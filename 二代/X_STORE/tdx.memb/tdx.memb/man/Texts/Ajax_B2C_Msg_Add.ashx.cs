using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Collections;
using Creatrue.kernel;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using tdx.database;

namespace tdx.memb.man.Texts
{
    /// <summary>
    /// Ajax_B2C_Msg_Add 的摘要说明
    /// </summary>
    public class Ajax_B2C_Msg_Add : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request.QueryString["target"] != null)
            {
                string targetName = context.Request.QueryString["target"].ToString();
            }

            string type = context.Request.QueryString["type"].ToString();
            switch (type)
            {
                case "addPic":
                    if (UploadPicAsMul3(context.Request.Files["selectFile"], context) > 0)
                    {
                        context.Response.Write(getTargetFilename());
                    }
                    break;
                case "update":
                    save(context);
                    //context.Response.Write(add(context, targetName));
                    break;
                case "save":
                    save(context);
                    break;
            }
        }
        #region 上传方法
        //kbytes，缺省20000kbytes，即20M
        private int maxLen = 20000;
        //' 定义随机文件名
        private string RndFile = "";
        private string targetPath = "";
        private string targetFilename = "";
        //'  定义一个arraylist，用来定义许可的上传文件类型
        private ArrayList allowFileType = new ArrayList();

        internal string errStr = "";
        private int rnd = 0;
        //'图片上传函数,并自动生成几种尺寸
        private int UploadPicAsMul3(HttpPostedFile postedfile, HttpContext context)
        {
            int result = 0;
            Int32 intImgSize = default(Int32);
            //获取用户上传文件的大小, 
            intImgSize = postedfile.ContentLength / 1000;
            //如果要上传的文件不为空
            if (intImgSize != 0)
            {
                //如果大于最大尺寸, 则禁止上传
                if (intImgSize > maxLen)
                {
                    result = 0;
                    context.Response.Write("图片尺寸太大,超过了" + maxLen + "KB");
                    return result;
                    //throw new NotSupportedException("图片尺寸太大,超过了" + maxLen + "KB");
                    //return result;
                }

                //定义一个变量储存用户上传图片的文件类型
                string strImgType = postedfile.FileName;

                //只接受.gif格式的图片
                //string[] filesplit = Regex.Split(strImgType, ".");
                //设置上传格式
                addFileType("jpg"); addFileType("gif"); addFileType("png"); addFileType("bpm");
                string[] filesplit = strImgType.Split('.');
                strImgType = filesplit[filesplit.Length - 1].ToLower();
                if (!isAllowFileType(strImgType))
                {
                    errStr = "图片格式不对，只支持格式" + strImgType;
                    result = 0;
                    context.Response.Write("图片格式不对，只支持" + getFileType() + "格式,当前为:" + strImgType);
                    return result;
                    //throw new NotSupportedException("图片格式不对，只支持" + getFileType() + "格式,当前为:" + strImgType);
                    //return result;
                }
                setTargetPath();
                setRndFile();
                string FileName = getTargetPath() + "/" + getRndFile();
                //Dim FileName As String = getTargetPath() & "/" & getRndFile() & "." & strImgType
                string img_all = FileName + "_all." + strImgType;
                string img_png = FileName + ".png";
                string img_min = FileName + "_min." + strImgType;
                string img_middle = FileName + "_mid." + strImgType;
                string img_max = FileName + "_max." + strImgType;
                //先将原图保存起来
                postedfile.SaveAs(context.Server.MapPath(img_all));
                //加载大图
                System.Drawing.Image allimg = System.Drawing.Image.FromFile(context.Server.MapPath(img_all));
                //存储png格式
                allimg.Save(context.Server.MapPath(img_png), System.Drawing.Imaging.ImageFormat.Png);
                allimg.Dispose();
                //取出png格式文件和尺寸
                System.Drawing.Image pngimg = System.Drawing.Image.FromFile(context.Server.MapPath(img_png));
                int png_width = pngimg.Width;
                int png_height = pngimg.Height;

                //开始存储各种尺寸图片
                //以高为基准来存储图片
                if (consts.pic_w_or_h == 1)
                {
                    //最小尺寸
                    int height_min = consts.pic_minSize;
                    if (height_min > png_height)
                        height_min = png_height;
                    int width_min = png_width * height_min / png_height;
                    pngimg.GetThumbnailImage(width_min, height_min, null, new System.IntPtr()).Save(context.Server.MapPath(img_min));
                    //中尺寸
                    int height_middle = consts.pic_middelSize;
                    if (height_middle > png_height)
                        height_middle = png_height;
                    int width_middle = png_width * height_middle / png_height;
                    pngimg.GetThumbnailImage(width_middle, height_middle, null, new System.IntPtr()).Save(context.Server.MapPath(img_middle));
                    //大尺寸
                    int height_max = consts.pic_maxSize;
                    if (height_max > png_height)
                        height_max = png_height;
                    int width_max = png_width * height_max / png_height;
                    pngimg.GetThumbnailImage(width_max, height_max, null, new System.IntPtr()).Save(context.Server.MapPath(img_max));
                    //以宽为基准来存储图片
                }
                else
                {
                    //最小尺寸
                    int width_min = consts.pic_minSize;
                    if (width_min > png_width)
                        width_min = png_width;
                    int height_min = png_height * width_min / png_width;
                    pngimg.GetThumbnailImage(width_min, height_min, null, new System.IntPtr()).Save(context.Server.MapPath(img_min));
                    //中尺寸
                    int width_middle = consts.pic_middelSize;
                    if (width_middle > png_width)
                        width_middle = png_width;
                    int height_middle = png_height * width_middle / png_width;
                    pngimg.GetThumbnailImage(width_middle, height_middle, null, new System.IntPtr()).Save(context.Server.MapPath(img_middle));
                    //大尺寸
                    int width_max = consts.pic_maxSize;
                    if (width_max > png_width)
                        width_max = png_width;
                    int height_max = png_height * width_max / png_width;
                    pngimg.GetThumbnailImage(width_max, height_max, null, new System.IntPtr()).Save(context.Server.MapPath(img_max));
                }
                pngimg.Dispose();
                //删除Png文件
                System.IO.File.Delete(context.Server.MapPath(img_png));
                setTargetFilename(img_all);

                result = 1;
            }
            else
            {
                result = 0;
                context.Response.Write("没有选择图片");
                return result;
                //throw new NotSupportedException("没有选择图片.");
            }

            return result;
        }
        internal bool isAllowFileType(string subfilename)
        {
            if (allowFileType.Contains(subfilename))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //' 关于许可上传文件类型的系列函数
        internal string getFileType()
        {
            //获得当前允许的类型
            string result = "";
            object[] ft = allowFileType.ToArray();
            foreach (object s in ft)
            {
                result = result + s.ToString() + "|";
            }
            result = result.Substring(0, result.Length - 1);
            return result;
        }
        internal void setTargetPath()
        {
            try
            {
                targetPath = consts.uploadPath + "/" + DateTime.Now.Year + DateTime.Now.Month.ToString("00");
                string MonthPath = System.Web.HttpContext.Current.Server.MapPath(targetPath);
                if (System.IO.Directory.Exists(MonthPath) == false)
                {
                    System.IO.Directory.CreateDirectory(MonthPath);
                }
                targetPath = targetPath + "/" + DateTime.Now.Day.ToString("00");
                string DayPath = MonthPath + "\\" + DateTime.Now.Day.ToString("00");
                if (System.IO.Directory.Exists(DayPath) == false)
                {
                    System.IO.Directory.CreateDirectory(DayPath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal void setRndFile()
        {
            //Random Rand = new Random();
            //rnd = Rand.Next(0, 10);
            //rnd = Rand.Next(0, rnd);            
            string RndDate = System.DateTime.Now.ToString();

            RndFile = RndDate.Replace(" ", "").Replace(":", "").Replace("-", "").Replace("/", "").Replace("\\", "") + rnd;
            rnd = rnd + 1;
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        internal string getTargetPath()
        {
            return targetPath;
        }
        internal void setTargetFilename(string f)
        {
            targetFilename = f;
        }
        internal string getRndFile()
        {
            return RndFile;
        }
        internal string getTargetFilename()
        {
            return targetFilename;
        }
        internal void addFileType(string s)
        {
            if (!allowFileType.Contains(s))
            {
                allowFileType.Add(s);
            }
        }
        #endregion
        #region 保存
        private void save(HttpContext context)
        {
            int errorNum = 0;
            try
            {
                var json = context.Request.Form[0].ToString();
                JObject jo = new JObject();
                JArray item = new JArray();
                //json = context.Server.UrlDecode(json);
                jo = (JObject)JsonConvert.DeserializeObject(json);
                string guid = jo["guid"].ToString().Trim();
                string keysname = jo["keysname"].ToString().Trim().Replace("，", ",");
                string del = jo["del"].ToString();
                int wid = Convert.ToInt32(jo["wid"].ToString());
                item = (JArray)jo["item"];
                string[] d = del.Split(',');
                for (int i = 0; i < d.Length; i++)
                {
                    if (!string.IsNullOrEmpty(d[i]))
                    {
                        wx_keys.myDel(Convert.ToInt32(d[i]));
                    }
                }
                for (int i = 0; i < item.Count; i++)
                {
                    errorNum++;
                    int itemid = (item[i]["itemid"].ToString().Trim() == "") ? 0 : Convert.ToInt32(item[i]["itemid"].ToString().Trim());
                    string title = item[i]["title"].ToString().Trim();
                    string pic = item[i]["pic"].ToString().Trim();
                    string author = item[i]["author"].ToString().Trim();
                    string body = item[i]["body"].ToString().Trim();
                    string summary = item[i]["summary"].ToString().Trim();
                    //body = body.Replace("&", "&amp;").Replace("\"", "&quot;").Replace("<", "&lt;").Replace(">", "&gt;").Replace(",nbsp;", "&nbsp;").Replace(" ","");
                    string body_url = item[i]["body_url"].ToString().Trim();
                    //存入数据库时用解码
                    wx_keys wk = new wx_keys();
                    wk.id = itemid;
                    wk.guid = comFunction.NoHTML(comfun.DeCodeHtml(guid));
                    wk.k_words = comFunction.NoHTML(comfun.DeCodeHtml(keysname).Trim().Replace("，", ","));
                    wk.k_answer = comFunction.NoHTML(comfun.DeCodeHtml(title));
                    wk.k_image = comFunction.NoHTML(comfun.DeCodeHtml(pic));
                    wk.k_content = comfun.DeCodeHtml(body);
                    wk.k_sort = comFunction.NoHTML(comfun.DeCodeHtml((i + 1).ToString()));
                    wk.k_des = comFunction.NoHTML(comfun.DeCodeHtml(summary));
                    wk.k_url2 = comFunction.NoHTML(comfun.DeCodeHtml(body_url));
                    wk.k_url2 = context.Server.HtmlDecode(wk.k_url2).Replace("'", string.Empty).Replace("\"", string.Empty);
                    wk.cityID = wid;
                    wk.Update();
                    // comfun
                }
                context.Response.Write("ok");
            }
            catch (Exception)
            {

                context.Response.Write("从第" + errorNum + "条保存失败");
            }
            //context.Response.Write(json.Replace("\"", "&quot;").Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("&nbsp;", "&nbsp;"));
        }
        #endregion
        //#region 更新
        //private void update(HttpContext context)
        //{
        //    int errorNum = 0;
        //    try
        //    {
        //        var json = context.Request.Form[0];
        //        JObject jo = new JObject();
        //        JArray item = new JArray();
        //        jo = (JObject)JsonConvert.DeserializeObject(json);
        //        string guid = jo["guid"].ToString().Trim();
        //        string keysname = jo["keysname"].ToString().Trim().Replace("，", ",").Replace(" ", "");
        //        string del = jo["del"].ToString();
        //        int wid = Convert.ToInt32(jo["wid"].ToString());
        //        item = (JArray)jo["item"];
        //        for (int i = 0; i < item.Count; i++)
        //        {
        //            errorNum++;
        //            Regex r;
        //            int itemid = (item[i]["itemid"].ToString().Trim() == "") ? 0 : Convert.ToInt32(item[i]["itemid"].ToString().Trim());
        //            string title = item[i]["title"].ToString().Trim();
        //            string pic = item[i]["pic"].ToString().Trim();
        //            string author = item[i]["author"].ToString().Trim();
        //            string body = item[i]["body"].ToString().Trim();
        //            string dest = body;
        //            r = new Regex(@"<(S*?)[^>]*>.*?|<.*? \/>");
        //            MatchCollection mc;
        //            mc = r.Matches(body);
        //            if (mc.Count > 0)
        //            {
        //                for (int j = 0; j < mc.Count; j++)
        //                {
        //                    dest = dest.Replace(mc[j].Value, "");
        //                }
        //            }
        //            if (dest.Length > 54)
        //            {
        //                dest = dest.Substring(0, 54);
        //            }
        //            r = new Regex(@"<script.*?>.*?<\/script>");
        //            Match m;
        //            m = r.Match(body);
        //            if (m.Value.Length > 0)
        //            {
        //                body = body.Replace(m.Value, "");
        //            }
        //            body = body.Replace("\"", "&quot;").Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("&nbsp;", "&nbsp;");
        //            string body_url = item[i]["body_url"].ToString().Trim();
        //            wx_keys wk = new wx_keys();
        //            wk.id = itemid;
        //            wk.guid = guid;
        //            wk.k_words = keysname;
        //            wk.k_answer = title;
        //            wk.k_image = pic;
        //            wk.k_content = body;
        //            wk.k_sort = (i + 1).ToString();
        //            wk.k_des = dest;
        //            wk.k_url2 = body_url;
        //            wk.cityID = wid;
        //            wk.Update();
        //            // comfun
        //        }
        //        context.Response.Write("ok");
        //    }
        //    catch (Exception)
        //    {
        //        context.Response.Write("从第" + errorNum + "条保存失败");
        //    }
        //}
        //#endregion
    }
}