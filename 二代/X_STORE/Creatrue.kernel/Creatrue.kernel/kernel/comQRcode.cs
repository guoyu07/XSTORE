using ThoughtWorks.QRCode.Codec;

namespace Creatrue.kernel.kernel
{
    public class comQRcode
    {
        public static System.Drawing.Bitmap GetQRcode(string str)
        {
            QRCodeEncoder qrCodeEncoder__1 = new QRCodeEncoder();
            //设置编码模式  
            qrCodeEncoder__1.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            //设置编码测量度  
            qrCodeEncoder__1.QRCodeScale = 7;
            //设置编码版本  
            qrCodeEncoder__1.QRCodeVersion = 0;
            //设置编码错误纠正  
            qrCodeEncoder__1.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            //生成二维码图片  
            return qrCodeEncoder__1.Encode(str);
        }
        

    }
}
