using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using tdx.database;
using Creatrue.kernel;
using System.Collections;

namespace tdx.memb.man.Ads
{
    /// <summary>
    /// B2C_ADS_ADD 的摘要说明
    /// </summary>
    public class Ajax_B2C_ADS_ADD : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string type = context.Request.QueryString["type"].ToString();
            switch (type)
            {
                case "save":
                    save(context);
                    break;
                case "pic":
                    uploadPic(context);
                    break;
                case "del":
                    delete(context);
                    break;
                default:
                    context.Response.Write("非法访问");
                    break;
            }
        }
        private void save(HttpContext context)
        {
            try
            {
                var json = context.Request.Form[0].ToString();
                JObject jo = new JObject();
                json = context.Server.UrlDecode(json);
                jo = (JObject)JsonConvert.DeserializeObject(json);
                //添加模式
                B2C_ads adss = new B2C_ads();
                if (!string.IsNullOrEmpty(jo["ads_id"].ToString().Trim()))
                {
                    adss = new B2C_ads(Convert.ToInt32(jo["ads_id"].ToString()));
                }
                else
                {
                    adss.addNew();
                }
                adss.cno = "009";
                adss.a_name = comFunction.NoHTML(jo["ads_name"].ToString().Trim());
                adss.a_gif = comFunction.NoHTML(jo["ads_pic"].ToString().Trim());
                adss.a_adgif = comFunction.NoHTML(jo["ads_pic"].ToString().Trim());
                adss.a_url = comFunction.NoHTML(jo["ads_url"].ToString().Trim());
                adss.a_btime = DateTime.Now;
                adss.a_etime = DateTime.Now;
                int i = 99;
                if (int.TryParse(jo["ads_sort"].ToString().Trim(), out i) || string.IsNullOrEmpty(jo["ads_sort"].ToString().Trim()))
                {
                    adss.a_sort = i;
                }
                else
                {
                    context.Response.Write("排序规则必须为数字");
                    return;
                }

                adss.a_des = "";
                //adss.cityID = Convert.ToInt32(context.Session["wid"]);
                if (string.IsNullOrEmpty(adss.a_name))
                {
                    context.Response.Write("标题不能为空");
                    return;
                }
                else if (string.IsNullOrEmpty(adss.a_adgif))
                {
                    context.Response.Write("请上传图片");
                    return;
                }
                else
                {
                    adss.Update();
                    context.Response.Write(1);
                }
                return;
            }
            catch (Exception ee)
            {
                context.Response.Write("保存失败");
            }
        }
        private void uploadPic(HttpContext context)
        {
            int i = UploadPicAsMul3(context.Request.Files["fileimg"], context);
            if (i > 0)
            {
                context.Response.Write(getTargetFilename());
            }
            // cu.UploadPicAsMul3(context.Request.Files["selectFile"], context)
        }
        private void delete(HttpContext context)
        {
            try
            {
                int wid = Convert.ToInt32(context.Session["wid"]);
                int ads_id = Convert.ToInt32(context.Request.QueryString["adsid"]);
                B2C_ads adss = new B2C_ads(ads_id);
                if (adss.id == 0)
                {
                    context.Response.Write(0);
                }
                else
                {
                    int i = B2C_ads.myDeleteMethod2(adss.id);
                    context.Response.Write(i);
                }
            }
            catch (Exception)
            {

                throw;
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

    }
}