using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;
using System.Web;
using System.Text.RegularExpressions;

namespace tdx.kernel
{
    /// <summary>
    /// 编写本类实现这样几个功能
    /// 一、上传图片，文件名为时间数
    /// 二、上传图片并且生成几种尺寸
    /// 三、上传图片并且加水印
    /// 四、上传其他文件（下载用）
    /// 五、其他上传还没想到的（share形式，可以上传一切形式）。
    /// </summary>
    /// <remarks></remarks>
    public class comUpload : System.Web.UI.Page
    {


        private int rnd = 0;
        public comUpload()
        {
            //构造函数
        }

        //'  定义一个arraylist，用来定义许可的上传文件类型
        private ArrayList allowFileType = new ArrayList();
        //' 定义一个上传类别:0:上传图片；1：上传文件 
        private int uploadType = 0;
        //' 定义最大size
        //kbytes，缺省20000kbytes，即20M
        private int maxLen = 20000;
        //' 定义随机文件名
        private string RndFile = "";
        private string targetPath = "";
        private string targetFilename = "";

        public string errStr = "";
        public int getUploadType()
        {
            return uploadType;
        }
        public void setUploadType(int t)
        {
            uploadType = t;
        }

        public int getMaxLen()
        {
            return maxLen;
        }
        public void setMaxLen(int ml)
        {
            maxLen = ml;
        }

        public string getRndFile()
        {
            return RndFile;
        }
        public void setRndFile()
        {
            //Random Rand = new Random();
            //rnd = Rand.Next(0, 10);
            //rnd = Rand.Next(0, rnd);            
            string RndDate = System.DateTime.Now.ToString();

            RndFile = RndDate.Replace(" ", "").Replace(":", "").Replace("-", "").Replace("/", "").Replace("\\", "") + rnd;
            rnd = rnd + 1;
        }
        public string getTargetPath()
        {
            return targetPath;
        }
        public void setTargetPath()
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
        public string getTargetFilename()
        {
            return targetFilename;
        }
        public void setTargetFilename(string f)
        {
            targetFilename = f;
        }

        //' 关于许可上传文件类型的系列函数
        public string getFileType()
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
        public void clearFileType()
        {
            allowFileType.Clear();
        }
        public void addFileType(string s)
        {
            if (!allowFileType.Contains(s))
            {
                allowFileType.Add(s);
            }
        }
        public void removeFileType(string s)
        {
            if (allowFileType.Contains(s))
            {
                allowFileType.Remove(s);
            }
        }
        public bool isAllowFileType(string subfilename)
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


        //'先写一个图片上传函数
        public int UploadPic(System.Web.UI.HtmlControls.HtmlInputFile PicFile)
        {
            int result = 0;

            HttpPostedFile postedfile = PicFile.PostedFile;
            int intImgSize = 0;
            //获取用户上传文件的大小, 
            intImgSize = postedfile.ContentLength / 1000;
            //如果要上传的文件不为空
            if (intImgSize != 0)
            {
                //如果大于最大尺寸, 则禁止上传
                if (intImgSize > maxLen)
                {
                    result = 0;      
                    throw new NotSupportedException("尺寸太大,超过了" + maxLen + "KB");                          
                    //return result;
                }

                //定义一个变量储存用户上传图片的文件类型
                string strImgType = "";
                strImgType = postedfile.FileName;

                //只接受.gif格式的图片
                string[] filesplit = strImgType.Split('.');
                strImgType = filesplit[filesplit.Length - 1].ToLower();
                if (!isAllowFileType(strImgType))
                {
                    result = 0;
                    throw new NotSupportedException("格式不对，只支持" + getFileType() + "格式,当前为:" + strImgType);
                    //errStr = "图片格式不对，只支持格式" & strImgType                
                    //return result;
                }

                setTargetPath();
                setRndFile();
                string FileName = getTargetPath() + "/" + getRndFile() + "." + strImgType;
                //将上传的图片保存到服务器当前目录的headimg文件夹中
                setTargetFilename(FileName);
                postedfile.SaveAs(Server.MapPath(FileName));

                result = 1;
            }
            else
            {
                result = 0;
                throw new NotSupportedException("尺寸太小或者没有选择上传文件.");            
            }

            return result;
        }

        //'图片上传函数,并自动生成几种尺寸
        public int UploadPicAsMul(System.Web.UI.HtmlControls.HtmlInputFile PicFile)
        {
            int result = 0;

            HttpPostedFile postedfile = PicFile.PostedFile;
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
                    throw new NotSupportedException("图片尺寸太大,超过了" + maxLen + "KB");                
                    //return result;
                }

                //定义一个变量储存用户上传图片的文件类型
                string strImgType = postedfile.FileName;

                //只接受.gif格式的图片
                //string[] filesplit = Regex.Split(strImgType, ".");
                string[] filesplit = strImgType.Split('.');
                strImgType = filesplit[filesplit.Length - 1].ToLower();
                if (!isAllowFileType(strImgType))
                {
                    errStr = "图片格式不对，只支持格式" + strImgType;
                    result = 0;
                    throw new NotSupportedException("图片格式不对，只支持" + getFileType() + "格式,当前为:" + strImgType);
                    //return result;
                }

                setTargetPath();
                setRndFile();
                string FileName = getTargetPath() + "/" + getRndFile();
                //Dim FileName As String = getTargetPath() & "/" & getRndFile() & "." & strImgType
                string img_all = FileName + ".all." + strImgType;
                string img_png = FileName + ".png";
                string img_min = FileName + ".min." + strImgType;
                string img_middle = FileName + ".middle." + strImgType;
                string img_max = FileName + ".max." + strImgType;
                //先将原图保存起来
                postedfile.SaveAs(Server.MapPath(img_all));
                //加载大图
                System.Drawing.Image allimg = System.Drawing.Image.FromFile(Server.MapPath(img_all));
                //存储png格式
                allimg.Save(Server.MapPath(img_png), System.Drawing.Imaging.ImageFormat.Png);
                allimg.Dispose();
                //取出png格式文件和尺寸
                System.Drawing.Image pngimg = System.Drawing.Image.FromFile(Server.MapPath(img_png));
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
                    pngimg.GetThumbnailImage(width_min, height_min, null, new System.IntPtr()).Save(Server.MapPath(img_min));
                    //中尺寸
                    //Dim height_middle As Integer = consts.pic_middelSize : If height_middle > png_height Then height_middle = png_height
                    //Dim width_middle As Integer = png_width * height_middle / png_height
                    //pngimg.GetThumbnailImage(width_middle, height_middle, Nothing, New System.IntPtr()).Save(Server.MapPath(img_middle))
                    //大尺寸
                    int height_max = consts.pic_maxSize;
                    if (height_max > png_height)
                        height_max = png_height;
                    int width_max = png_width * height_max / png_height;
                    pngimg.GetThumbnailImage(width_max, height_max, null, new System.IntPtr()).Save(Server.MapPath(img_max));
                    //以宽为基准来存储图片
                }
                else
                {
                    //最小尺寸
                    int width_min = consts.pic_minSize;
                    if (width_min > png_width)
                        width_min = png_width;
                    int height_min = png_height * width_min / png_width;
                    pngimg.GetThumbnailImage(width_min, height_min, null, new System.IntPtr()).Save(Server.MapPath(img_min));
                    //中尺寸
                    //Dim width_middle As Integer = consts.pic_middelSize : If width_middle > png_width Then width_middle = png_width
                    //Dim height_middle As Integer = png_height * width_middle / png_width
                    //pngimg.GetThumbnailImage(width_middle, height_middle, Nothing, New System.IntPtr()).Save(Server.MapPath(img_middle))
                    //大尺寸
                    int width_max = consts.pic_maxSize;
                    if (width_max > png_width)
                        width_max = png_width;
                    int height_max = png_height * width_max / png_width;
                    pngimg.GetThumbnailImage(width_max, height_max, null, new System.IntPtr()).Save(Server.MapPath(img_max));
                }
                pngimg.Dispose();
                //删除Png文件
                System.IO.File.Delete(Server.MapPath(img_png));
                setTargetFilename(img_all);

                result = 1;
            }
            else
            {
                result = 0;
                throw new NotSupportedException("没有选择图片.");           
            }

            return result;
        }

        //'图片上传函数,并自动生成几种尺寸
        public int UploadPicAsMul3(System.Web.UI.HtmlControls.HtmlInputFile PicFile)
        {
            int result = 0;

            HttpPostedFile postedfile = PicFile.PostedFile;
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
                    throw new NotSupportedException("图片尺寸太大,超过了" + maxLen + "KB");
                    //return result;
                }

                //定义一个变量储存用户上传图片的文件类型
                string strImgType = postedfile.FileName;

                //只接受.gif格式的图片
                //string[] filesplit = Regex.Split(strImgType, ".");
                string[] filesplit = strImgType.Split('.');
                strImgType = filesplit[filesplit.Length - 1].ToLower();
                if (!isAllowFileType(strImgType))
                {
                    errStr = "图片格式不对，只支持格式" + strImgType;
                    result = 0;
                    throw new NotSupportedException("图片格式不对，只支持" + getFileType() + "格式,当前为:" + strImgType);
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
                postedfile.SaveAs(Server.MapPath(img_all));
                //加载大图
                System.Drawing.Image allimg = System.Drawing.Image.FromFile(Server.MapPath(img_all));
                //存储png格式
                allimg.Save(Server.MapPath(img_png), System.Drawing.Imaging.ImageFormat.Png);
                allimg.Dispose();
                //取出png格式文件和尺寸
                System.Drawing.Image pngimg = System.Drawing.Image.FromFile(Server.MapPath(img_png));
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
                    pngimg.GetThumbnailImage(width_min, height_min, null, new System.IntPtr()).Save(Server.MapPath(img_min));
                    //中尺寸
                    int height_middle =  consts.pic_middelSize;
                    if(height_middle > png_height)
                        height_middle = png_height;
                    int width_middle = png_width * height_middle/png_height; 
                    pngimg.GetThumbnailImage(width_middle, height_middle, null, new System.IntPtr()).Save(Server.MapPath(img_middle));
                    //大尺寸
                    int height_max = consts.pic_maxSize;
                    if (height_max > png_height)
                        height_max = png_height;
                    int width_max = png_width * height_max / png_height;
                    pngimg.GetThumbnailImage(width_max, height_max, null, new System.IntPtr()).Save(Server.MapPath(img_max));
                    //以宽为基准来存储图片
                }
                else
                {
                    //最小尺寸
                    int width_min = consts.pic_minSize;
                    if (width_min > png_width)
                        width_min = png_width;
                    int height_min = png_height * width_min / png_width;
                    pngimg.GetThumbnailImage(width_min, height_min, null, new System.IntPtr()).Save(Server.MapPath(img_min));
                    //中尺寸
                    int width_middle = consts.pic_middelSize;
                    if( width_middle > png_width)
                        width_middle = png_width;
                    int height_middle = png_height * width_middle / png_width;
                    pngimg.GetThumbnailImage(width_middle, height_middle, null, new System.IntPtr()).Save(Server.MapPath(img_middle));
                    //大尺寸
                    int width_max = consts.pic_maxSize;
                    if (width_max > png_width)
                        width_max = png_width;
                    int height_max = png_height * width_max / png_width;
                    pngimg.GetThumbnailImage(width_max, height_max, null, new System.IntPtr()).Save(Server.MapPath(img_max));
                }
                pngimg.Dispose();
                //删除Png文件
                System.IO.File.Delete(Server.MapPath(img_png));
                setTargetFilename(img_all);

                result = 1;
            }
            else
            {
                result = 0;
                throw new NotSupportedException("没有选择图片.");
            }

            return result;
        }

        //'单图片上传并且加水印函数
        public int UploadPicAddWater(System.Web.UI.HtmlControls.HtmlInputFile PicFile)
        {
            int result = 0;

            HttpPostedFile postedfile = PicFile.PostedFile;
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
                    throw new NotSupportedException("图片尺寸太大,超过了" + maxLen + "KB");               
                    //return result;
                }

                //定义一个变量储存用户上传图片的文件类型
                string strImgType = postedfile.FileName;

                //只接受.gif格式的图片
                //string[] filesplit = Regex.Split(strImgType, ".");
                string[] filesplit = strImgType.Split('.');
                strImgType = filesplit[filesplit.Length - 1].ToLower();
                if (!isAllowFileType(strImgType))
                {
                    result = 0;
                    throw new NotSupportedException("图片格式不对，只支持" + getFileType() + "格式,当前为:" + strImgType);
                    //errStr = "图片格式不对，只支持格式" & strImgType               
                    //return result;
                }

                setTargetPath();
                setRndFile();
                string FileName = getTargetPath() + "/" + getRndFile() + "." + strImgType;
                string filename_tmp = getTargetPath() + "/" + getRndFile() + ".source." + strImgType;
                //将上传的图片保存到服务器当前目录的headimg文件夹中
                setTargetFilename(FileName);
                postedfile.SaveAs(Server.MapPath(filename_tmp));
                //存储原图
                //' 开始加载水印
                //水印图片
                string wImageFile = Server.MapPath(consts.pic_water);
                System.Drawing.Image wImage = System.Drawing.Image.FromFile(wImageFile);
                //加载原图
                System.Drawing.Image AllImg = AddWater(System.Drawing.Image.FromFile(Server.MapPath(filename_tmp)), wImage);
                AllImg.Save(Server.MapPath(FileName));
                //将图存成加水印的格式
                AllImg.Dispose();
                wImage.Dispose();

                result = 1;
            }
            else
            {
                result = 0;
                throw new NotSupportedException("没有选择图片.");            
            }

            return result;
        }

        //'图片上传函数,并自动生成几种尺寸并且加水印
        public int UploadPicAsMulAddWater(System.Web.UI.HtmlControls.HtmlInputFile PicFile)
        {
            int result = 0;

            HttpPostedFile postedfile = PicFile.PostedFile;
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
                    throw new NotSupportedException("图片尺寸太大,超过了" + maxLen + "KB");                
                    //return result;
                }

                //定义一个变量储存用户上传图片的文件类型
                string strImgType = postedfile.FileName;

                //只接受.gif格式的图片
                //string[] filesplit = Regex.Split(strImgType, ".");
                string[] filesplit = strImgType.Split('.');
                strImgType = filesplit[filesplit.Length - 1].ToLower();
                if (!isAllowFileType(strImgType))
                {
                    result = 0;
                    throw new NotSupportedException("图片格式不对，只支持" + getFileType() + "格式,当前为:" + strImgType);
                    //errStr = "图片格式不对，只支持格式" & strImgType                
                    //return result;
                }

                setTargetPath();
                setRndFile();
                string FileName = getTargetPath() + "/" + getRndFile();
                //Dim FileName As String = getTargetPath() & "/" & getRndFile() & "." & strImgType
                string img_all = FileName + ".all." + strImgType;
                string img_png = FileName + ".png";
                string img_min = FileName + ".min." + strImgType;
                string img_middle = FileName + ".middle." + strImgType;
                string img_max = FileName + ".max." + strImgType;
                //先将原图保存起来
                postedfile.SaveAs(Server.MapPath(img_all));
                //水印图片
                string wImageFile = Server.MapPath(consts.pic_water);
                System.Drawing.Image wImage = System.Drawing.Image.FromFile(wImageFile);
                //加载大图
                System.Drawing.Image allimg = AddWater(System.Drawing.Image.FromFile(Server.MapPath(img_all)), wImage);
                //存储png格式
                allimg.Save(Server.MapPath(img_png), System.Drawing.Imaging.ImageFormat.Png);
                allimg.Dispose();
                wImage.Dispose();
                //取出png格式文件和尺寸
                System.Drawing.Image pngimg = System.Drawing.Image.FromFile(Server.MapPath(img_png));
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
                    pngimg.GetThumbnailImage(width_min, height_min, null, new System.IntPtr()).Save(Server.MapPath(img_min));
                    //中尺寸
                    int height_middle = consts.pic_middelSize;
                    if (height_middle > png_height)
                        height_middle = png_height;
                    int width_middle = png_width * height_middle / png_height;
                    pngimg.GetThumbnailImage(width_middle, height_middle, null, new System.IntPtr()).Save(Server.MapPath(img_middle));
                    //大尺寸
                    int height_max = consts.pic_maxSize;
                    if (height_max > png_height)
                        height_max = png_height;
                    int width_max = png_width * height_max / png_height;
                    pngimg.GetThumbnailImage(width_max, height_max, null, new System.IntPtr()).Save(Server.MapPath(img_max));
                    //以宽为基准来存储图片
                }
                else
                {
                    //最小尺寸
                    int width_min = consts.pic_minSize;
                    if (width_min > png_width)
                        width_min = png_width;
                    int height_min = png_height * width_min / png_width;
                    pngimg.GetThumbnailImage(width_min, height_min, null, new System.IntPtr()).Save(Server.MapPath(img_min));
                    //中尺寸
                    int width_middle = consts.pic_middelSize;
                    if (width_middle > png_width)
                        width_middle = png_width;
                    int height_middle = png_height * width_middle / png_width;
                    pngimg.GetThumbnailImage(width_middle, height_middle, null, new System.IntPtr()).Save(Server.MapPath(img_middle));
                    //大尺寸
                    int width_max = consts.pic_maxSize;
                    if (width_max > png_width)
                        width_max = png_width;
                    int height_max = png_height * width_max / png_width;
                    pngimg.GetThumbnailImage(width_max, height_max, null, new System.IntPtr()).Save(Server.MapPath(img_max));
                }
                pngimg.Dispose();
                //删除Png文件
                System.IO.File.Delete(Server.MapPath(img_png));
                setTargetFilename(img_all);

                result = 1;
            }
            else
            {
                result = 0;
                throw new NotSupportedException("没有选择图片.");            
            }

            return result;
        }

        /// <summary>
        /// 加水印给图片
        /// </summary>
        /// <param name="oBmp"></param>
        /// <param name="water"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public System.Drawing.Image AddWater(System.Drawing.Image oBmp, System.Drawing.Image water)
        {
           // string says = "Green";
            System.Drawing.Graphics oGrap = System.Drawing.Graphics.FromImage(oBmp);
            Int32 bmpw = default(Int32);
            Int32 bmph = default(Int32);
            bmpw = oBmp.Width;
            bmph = oBmp.Height;

            oGrap.DrawImage(water, new System.Drawing.Rectangle(oBmp.Width - water.Width, oBmp.Height - water.Height, water.Width, water.Height), 0, 0, water.Width, water.Height, System.Drawing.GraphicsUnit.Pixel);
            oGrap.Dispose();
            return oBmp;
        }
    }
}