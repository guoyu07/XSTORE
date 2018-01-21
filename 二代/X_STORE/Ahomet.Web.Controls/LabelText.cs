using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using System.Web;
namespace Ahomet.Web.Controls
{
    [DefaultProperty("Text"), ToolboxData("<{0}:LabelText runat=\"server\">")]
    public class LabelText : Label, INamingContainer
    {
        public LabelText()
        {
            
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            // 实现Label控件的回发(Postback)功能
            ImplementPostback();
        }
        [Browsable(true),
        Description("使Label支持回发(Postback)的隐藏控件的后缀名"),
        Category("扩展"),
        DefaultValue("EnablePostback")]
        public virtual string HiddenFieldPostfix
        {
            get
            {
                string s = (string)ViewState["HiddenFieldPostfix"];
                return (s == null) ? "EnablePostback" : s;
            }
            set
            {
                ViewState["HiddenFieldPostfix"] = value;
            }
        }
        // 是否启用Label控件的回发(Postback)
        [Browsable(true),
        Description("是否启用Label控件的回发(Postback)"),
        Category("扩展"),
        DefaultValue(false)]
        public virtual bool EnablePostback
        {
            get
            {
                bool? b = (bool?)ViewState["EnablePostback"];
                return (b == null) ? false : (bool)b;
            }

            set
            {
                ViewState["EnablePostback"] = value;
            }
        }
        // 实现Label控件的回发(Postback)功能
        private void ImplementPostback()
        {
            if (this.EnablePostback)
            {
                // 使Label支持回发(Postback)的隐藏控件的ID
                string hiddenFieldId = string.Concat(this.ClientID, "_", HiddenFieldPostfix);

                // 注册隐藏控件
                Page.ClientScript.RegisterHiddenField(hiddenFieldId, "");

                // 注册客户端脚本
                WebSource.AddControlsScriptResource("LabelText.js", this.Page);

                // 表单提交前将Label控件的的值赋给隐藏控件
                this.Page.ClientScript.RegisterOnSubmitStatement(this.GetType(),
                this.UniqueID + "_Label_enablePostback",
                string.Format("Label_copyTextToHiddenField('{0}', '{1}')",
                this.ClientID,
                hiddenFieldId));
            }
        }
        // 获取或设置 控件的文本内容
        public override string Text
        {
            get
            {
                try
                {
                    if (this.EnablePostback && !string.IsNullOrEmpty(HttpContext.Current.Request[string.Concat(this.ClientID, "_", HiddenFieldPostfix)]))
                    {
                        // 隐藏控件的值
                        return HttpContext.Current.Request[string.Concat(this.ClientID, "_", HiddenFieldPostfix)];
                    }
                    else
                    {
                        return base.Text;
                    }
                }
                catch
                {
                    return base.Text;
                }
            }
            set
            {
                try
                {
                    if (this.EnablePostback && !string.IsNullOrEmpty(HttpContext.Current.Request[string.Concat(this.ClientID, "_", HiddenFieldPostfix)]))
                    {
                        // 隐藏控件的值
                        base.Text = HttpContext.Current.Request[string.Concat(this.ClientID, "_", HiddenFieldPostfix)];
                    }
                    else
                    {
                        base.Text = value;
                    }
                }
                catch
                {
                    base.Text = value;
                }
            }
        }
    }
}
