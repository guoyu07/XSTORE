using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tdx.memb.man.formcontrols
{
    /// <summary>
    /// controlItem 的摘要说明
    /// </summary>
    public class controlItem : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            switch (context.Request["type"].ToString())
            {
                case "4":
                    context.Response.Write(@" <table><tbody>
                        <tr>
            <td width='100'>选项列表<span >以换行符隔开</span></td>
            <td>
                                <textarea name='setting[options]' rows='2' cols='20' id='options' style='height:100px;width:400px;'>选项1</textarea>
                            </td>
        </tr>
        <tr>
            <td>默认值<span class='label label-info'>必须是选项列表里的值</span></td>
            <td>
                                <input type='text' name='setting[defaultvalue]' value='' class='input-medium'>
                            </td>
        </tr>
            </tbody>
</table>");
                    break;

                case "5":
                    context.Response.Write(@" <table><tbody>
                        <tr>
            <td width='100'>选项列表<span >以换行符隔开</span></td>
            <td>
                                <textarea name='setting[options]' rows='2' cols='20' id='options' style='height:100px;width:400px;'>选项1</textarea>
                            </td>
        </tr>
            </tbody>
</table>");
                    break;
                case "6":
                    context.Response.Write(@" <table><tbody>
                        <tr>
            <td width='100'>选项列表<span >以换行符隔开</span></td>
            <td>
                                <textarea name='setting[options]' rows='2' cols='20' id='options' style='height:100px;width:400px;'>选项1</textarea>
                            </td>
        </tr>
        <tr>
            <td>默认值<span class='label label-info'>必须是选项列表里的值</span></td>
            <td>
                                <input type='text' name='setting[defaultvalue]' value='' class='input-medium'>
                            </td>
        </tr>
            </tbody>
</table>");
                    break;
                case "7":
                    context.Response.Write(@" <table><tbody>
                        <tr>
            <td width='100'>描述文本</td>
            <td>
                                <textarea name='setting[options]' rows='2' cols='20' id='options' style='height:100px;width:400px;'>文本内容</textarea>
                            </td>
        </tr>
            </tbody>
</table>");
                    break;
                default:
                    context.Response.Write(@"<table>
    <tbody>
                        <tr><td colspan='2' style='text-align: center;'>无相关参数设置</td></tr>
            </tbody>
</table>");
                    break;
            }


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