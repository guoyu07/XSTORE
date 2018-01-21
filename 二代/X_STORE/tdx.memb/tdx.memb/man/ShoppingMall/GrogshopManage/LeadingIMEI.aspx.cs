using Creatrue.kernel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.DBUtility;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;

namespace tdx.memb.man.ShoppingMall.GrogshopManage
{
    public partial class LeadingIMEI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string path = "";
            try
            {
                if (this.FileUpload1.HasFile)
                {
                    string fileExtension = Path.GetExtension(this.FileUpload1.FileName).ToLower();
                    if (fileExtension == ".xls" || fileExtension == ".xlsx")
                    {
                        path = Server.MapPath("~/Upload/");

                        this.FileUpload1.SaveAs(path + this.FileUpload1.FileName);

                        var flag = GetExcel(path + this.FileUpload1.FileName, fileExtension);
                        if (flag)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "111", "alert('导入成功')", true);
                            File.Delete(path + this.FileUpload1.FileName);
                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "111", "alert('导入失败')", true);
                            File.Delete(path + this.FileUpload1.FileName);
                        }


                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "11", "alert('请选择.xls或.xlsx文件')", true);
                        return;
                    }
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "1111", "alert('请选择文件')", true);
                }
            }
            catch (Exception)
            {
                File.Delete(path + this.FileUpload1.FileName);
                throw;
            }
        }
        protected bool GetExcel(string path, string fileExtension)
        {
            using (FileStream fs = File.OpenRead(path))
            {

                IWorkbook wk = null;
                if (fileExtension == ".xlsx") // 2007版本
                    wk = new XSSFWorkbook(fs);
                else if (fileExtension == ".xls") // 2003版本
                    wk = new HSSFWorkbook(fs);

                ISheet sheet = wk.GetSheetAt(0);
                List<DTcms.Model.WP_BarCode> list = new List<DTcms.Model.WP_BarCode>();
                var begin_exsql = " Begin Tran ";
                var exsql = "  declare @count int ";
                var end_sql = @" If @@ERROR>0 
                                Rollback Tran  
                            Else
                                Commit Tran
                            Go";
                for (int j = 1; j <= sheet.LastRowNum; j++)  //LastRowNum 是当前表的总行数
                {
                    IRow row = sheet.GetRow(j);
                    if (row != null)
                    {
                        string appid = ConfigurationManager.AppSettings["APPID"].ObjToStr();//wx4b52212c5d5983ad
                        string root = ConfigurationManager.AppSettings["HomeUrl"].ObjToStr();//http://x.x-store.com.cn
                        string iccid = row.GetCell(0).ObjToStr();
                        string number = row.GetCell(1).ObjToStr();
                        string imei = row.GetCell(2).ObjToStr();
                        string serial = row.GetCell(3).ObjToStr();
                        string code = row.GetCell(4).ObjToStr();
                        
                        var url = string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}/shop/pages/enter.aspx?boxmac={2}&response_type=code&scope=snsapi_base&state=STATE#wechat_redirect", appid, root, imei);
                        //var url = string.Format("http://x.x-store.com.cn/shop/pages/enter.aspx?boxmac={0}", imei);
                        var bar_src = CreateCode_Simple(url, imei);
                        exsql += string.Format(@"
                                    select @count = Count(*) from WP_BarCode where BarCode = '{0}'
                                    if @count = 0
                                    begin
                                    INSERT INTO WP_BarCode([BarCode],[ICCID],[Serial],[Number],[Code],[CreateTime],[HasBind],[Url]) VALUES('{0}','{1}','{2}','{3}','{4}',getdate(),'{5}','{6}')
                                    end
                                    else
                                    begin
                                    update WP_BarCode set [ICCID] = '{1}',Serial = '{2}',Number = '{3}',Code = '{4}',Url='{6}' where BarCode = '{0}'
                                    end ",imei, iccid, serial, number, code, 0, bar_src);
                        // CreateCode_Simple(url, imei);
                    }
                }
                var b = DbHelperSQL.ExecuteSql(begin_exsql + exsql + end_sql);
                if (b > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }  
            }
        }

        //生成二维码方法一
        private string CreateCode_Simple(string nr,string name)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeScale = 4;
            qrCodeEncoder.QRCodeVersion = 0;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            //System.Drawing.Image image = qrCodeEncoder.Encode("4408810820 深圳－广州 小江");
            System.Drawing.Image image = qrCodeEncoder.Encode(nr);
            string filename = name + ".jpg";
            string root = Server.MapPath(@"~\Upload\BarCode");
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            string filepath = root + "\\" + filename;
            string barCodeUrl = ConfigurationManager.AppSettings["HomeUrl"].ObjToStr() + "/Upload/BarCode/" + filename;
            System.IO.FileStream fs = new System.IO.FileStream(filepath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
            image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);

            fs.Close();
            image.Dispose();
            return barCodeUrl;
            //二维码解码
            //var codeDecoder = CodeDecoder(filepath);
        }
        /// <summary>
        /// 二维码解码
        /// </summary>
        /// <param name="filePath">图片路径</param>
        /// <returns></returns>
        public string CodeDecoder(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
                return null;
            Bitmap myBitmap = new Bitmap(System.Drawing.Image.FromFile(filePath));
            QRCodeDecoder decoder = new QRCodeDecoder();
            string decodedString = decoder.decode(new QRCodeBitmapImage(myBitmap));
            return decodedString;
        }

        protected void lbtdown_Click(object sender, EventArgs e)
        {
            string filePath = Server.MapPath("~/Excel/employee.xlsx");//路径 
            //以字符流的形式下载文件
            FileStream fs = new FileStream(filePath, FileMode.Open);
            byte[] bytes = new byte[(int)fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Close();
            Response.ContentType = "application/octet-stream";
            //通知浏览器下载文件而不是打开
            Response.AddHeader("Content-Disposition", "attachment;  filename=" + HttpUtility.UrlEncode("employee.xlsx", System.Text.Encoding.UTF8));
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
    }
}