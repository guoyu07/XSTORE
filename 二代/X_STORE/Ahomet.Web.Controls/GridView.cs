using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
namespace Ahomet.Web.Controls
{
    [DefaultProperty("Text"), ToolboxData("<{0}:GridView runat=\"server\" CssClass=\"gv\"><RowStyle CssClass=\"gvRow\" /><HeaderStyle CssClass=\"gvHeader\" /><AlternatingRowStyle CssClass=\"gvAlternatingRow\" /></{0}:GridView>")]
    public class GridView : System.Web.UI.WebControls.GridView, INamingContainer
    {

        public GridView()
        {
            this.ViewState["Sort"] = " DESC";
            this.ViewState["SortExpression"] = null;
            this.GridLines = GridLines.Both;
            this.AllowSorting = true;
            base.Sorting += new GridViewSortEventHandler(this.GridView_Sorting);
            base.RowDataBound += new GridViewRowEventHandler(this.GridView_RowDataBound);
            this.ShowHeader = false;
        }
        protected override void RenderContents(HtmlTextWriter writer)
        {
            base.RenderContents(writer);
        }
        #region 排序
        private static readonly object EventSubmitKey = new object();
        // 实现事件属性结构 
        public event EventHandler SubSort
        {
            add { Events.AddHandler(EventSubmitKey, value); }
            remove { Events.RemoveHandler(EventSubmitKey, value); }
        }
        // 实现OnSubmit 
        protected virtual void OnSubSort(EventArgs e)
        {
            EventHandler SubmitHandler = (EventHandler)Events[EventSubmitKey];
            if (SubmitHandler != null) { SubmitHandler(this, e); }
        }
        public string NewSortDirection
        {
            set
            {
                this.ViewState["Sort"] = " " + value;
            }
        }
        public string NewSortExpression
        {
            set
            {
                this.ViewState["SortExpression"] = value;
            }
        }
        public string GetSort
        {
            get
            {
                object str = this.ViewState["GetSort"];
                string temp = string.Empty;
                if (str != null)
                {
                    temp = (string)str;
                }
                return temp;
            }
            set { this.ViewState["GetSort"] = value; }
        }
        private void GridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression;
            this.ViewState["SortExpression"] = sortExpression;
            if (this.ViewState["Sort"].ToString() == " ASC")
            {
                this.ViewState["Sort"] = " DESC";
            }
            else
            {
                this.ViewState["Sort"] = " ASC";
            }
            this.SortGridview(sortExpression, this.ViewState["Sort"].ToString());
        }
        private void SortGridview(string SortExpression, string SortDirection)
        {
            string str = SortExpression + SortDirection;
            this.ChangeHeaderText(SortExpression, SortDirection);
            this.ViewState["GetSort"] = " Order by " + str;
            OnSubSort(EventArgs.Empty);
        }
        private void ChangeHeaderText(string SortExpression, string SortDirection)
        {
            string strArrowDown = WebSource.GetControlsResourceUrl("GridView.Down.gif", this.Page);
            string strArrowUp = WebSource.GetControlsResourceUrl("GridView.Up.gif", this.Page);

            for (int i = 0; i < base.Columns.Count; i++)
            {
                if (base.Columns[i].GetType() == typeof(BoundField))
                {
                    ((BoundField)base.Columns[i]).HtmlEncode = false;
                    base.Columns[i].HeaderText = base.Columns[i].HeaderText.Replace(" <img src=\"" + strArrowDown + "\" border=\"0\" />", "");
                    base.Columns[i].HeaderText = base.Columns[i].HeaderText.Replace(" <img src=\"" + strArrowUp + "\" border=\"0\" />", "");
                    if (base.Columns[i].SortExpression == SortExpression)
                    {
                        if (SortDirection == " DESC")
                        {
                            DataControlField field1 = base.Columns[i];
                            field1.HeaderText = field1.HeaderText + " <img src=\"" + strArrowDown + "\" border=\"0\" />";
                        }
                        else
                        {
                            DataControlField field2 = base.Columns[i];
                            field2.HeaderText = field2.HeaderText + " <img src=\"" + strArrowUp + "\" border=\"0\" />";
                        }
                    }
                }
                if (base.Columns[i].GetType() == typeof(TemplateField))
                {
                    base.Columns[i].HeaderText = base.Columns[i].HeaderText.Replace(" <img src=\"" + strArrowDown + "\" border=\"0\" />", "");
                    base.Columns[i].HeaderText = base.Columns[i].HeaderText.Replace(" <img src=\"" + strArrowUp + "\" border=\"0\" />", "");
                    if (base.Columns[i].SortExpression == SortExpression)
                    {
                        if (SortDirection == " DESC")
                        {
                            DataControlField field1 = base.Columns[i];
                            field1.HeaderText = field1.HeaderText + " <img src=\"" + strArrowDown + "\" border=\"0\" />";
                        }
                        else
                        {
                            DataControlField field2 = base.Columns[i];
                            field2.HeaderText = field2.HeaderText + " <img src=\"" + strArrowUp + "\" border=\"0\" />";
                        }
                    }
                }
            }
        }
        #endregion
        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (this.IsGradient)
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#E9F8EA'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
                }
            }
        }
        public bool IsGradient
        {
            get
            {
                object str = this.ViewState["IsGradient"];
                bool result = false;
                if (str != null)
                {
                    result = (bool)str;
                }
                return result;
            }
            set { this.ViewState["IsGradient"] = value; }
        }
        protected override void OnPreRender(EventArgs e)
        {
            WebSource.AddControls("GridView.css", "GridView_css", this.Page);
            WebSource.AddControlsScriptResource("GridView.js", this.Page);

            base.OnPreRender(e);

            //调整位置
            StringBuilder sbl = new StringBuilder();
            sbl.Append("<script type=\"text/javascript\">");
            sbl.Append("addEvent(window, \"resize\",");
            sbl.Append("function() {");
            sbl.AppendFormat("gridview(\"{0}-grid-headbox\", \"{0}-grid-body\")", base.UniqueID);
            sbl.Append("});");
            sbl.AppendFormat("gridview(\"{0}-grid-headbox\", \"{0}-grid-body\")", base.UniqueID);
            sbl.Append("</script>");
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Ahomet_Web_UI_GridView_Js", sbl.ToString(), false);
        }
        #region 重写表格数据为空！
        public class StringBuilderli
        {
            private StringBuilder sb = null;
            public StringBuilderli()
            {
                sb = new StringBuilder();
            }
            public void Append(string input)
            {
                sb.Append(input + Environment.NewLine);
            }
            public void Append(string input, params object[] arg)
            {
                sb.AppendFormat(input + Environment.NewLine, arg);
            }
            public override string ToString()
            {
                return sb.ToString();
            }
            public void Insert(int start, string input)
            {
                sb.Insert(start, input);
            }
        }
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilderli sbl = null;
            bool IsRender = true;
            bool IsEmpty = false;
            if (!base.DesignMode)
                if (this.Rows.Count == 0)
                    IsEmpty = true;
                //this.RenderEmptyContent(writer);
                else
                    IsRender = true;
            else
                IsRender = true;
            if (IsRender)
            {
                sbl = new StringBuilderli();
                sbl.Append("<div class=\"gird\" style=\"width:{0};\">", this.ScrollWidth);
                sbl.Append("  <!--grid-view-->");
                sbl.Append("  <div class=\"grid-view\" style=\"width:{0};\">", this.ScrollWidth);
                sbl.Append("    <!--grid-head-->");
                sbl.Append("    <div class=\"grid-head\" style=\"width:{0};\" id=\"{1}-grid-headbox\">", this.ScrollWidth, base.UniqueID);
                sbl.Append("      <div class=\"grid-headbox\" >");
                sbl.Append("        <table cellspacing=\"0\" border=\"1\" style=\"width:100%;border-collapse:collapse;\" rules=\"rows\" class=\"gv\">");
                sbl.Append("          <tbody>");
                sbl.Append("            <tr class=\"gvHeader\">");

                for (int i = 0; i < base.Columns.Count; i++)
                {
                    if (base.Columns[i].Visible)
                    {
                        //bool IsColumns = false;
                        //if (base.Columns[i].GetType() == typeof(BoundField)) IsColumns = true;
                        //if (base.Columns[i].GetType() == typeof(TemplateField)) { IsColumns = true; }

                        string Html = base.Columns[i].HeaderText;
                        switch (base.Columns[i].HeaderText)
                        {
                            case "选择":
                                 Html = "<input type=\"checkbox\" onclick=\"checkAll(this);\">";
                                break;
                            default:
                                break;

                        }
                        if (base.Columns[i].SortExpression == null || base.Columns[i].SortExpression.Trim() == "")
                        {
                            sbl.Append("              <th scope=\"col\" style=\"width:{0};\">{1}</th>",
                             base.Columns[i].ItemStyle.Width.ToString(),
                             Html);
                        }
                        else
                        {
                            if (base.Rows.Count > 0)
                            {
                                sbl.Append("              <th scope=\"col\" style=\"width:{0};\"><a href=\"javascript:__doPostBack('{1}','Sort${2}')\">{3}</a></th>",
                                 base.Columns[i].ItemStyle.Width.ToString(),
                                 base.UniqueID,
                                 base.Columns[i].SortExpression,
                                 base.Columns[i].HeaderText);
                            }
                            else
                            {
                                sbl.Append("              <th scope=\"col\" style=\"width:{0};\">{1}</th>",
                                 base.Columns[i].ItemStyle.Width.ToString(),
                                 base.Columns[i].HeaderText);
                            }
                        }
                    }
                }
                sbl.Append("            </tr>");
                sbl.Append("          </tbody>");
                sbl.Append("        </table>");
                sbl.Append("      </div>");
                sbl.Append("    </div>");
                sbl.Append("    <!--grid-head-->");
                sbl.Append("    <!--grid-body-->");

                string ScrollShow = "";
                if (this.Scroll_X_Show && this.Scroll_Y_Show)
                    ScrollShow = ""; //显示 x,y 滚动
                else if (!this.Scroll_Y_Show && this.Scroll_X_Show)
                    ScrollShow = "overflow-x:auto;overflow-y:hidden;";//只显示 x 滚动
                else if (this.Scroll_Y_Show && !this.Scroll_X_Show)
                    ScrollShow = "overflow-x:hidden;overflow-y:auto;";//只显示 y 滚动

                sbl.Append("    <div  class=\"grid-body\" style=\"width:{1}; height:{2};" + ScrollShow + "\" id=\"{0}-grid-body\">", base.UniqueID, this.ScrollWidth, this.ScrollHeight);
                sbl.Append("      <div style=\"position:relative; padding-bottom:20px;\">");
                writer.Write(sbl.ToString());

                if (this.Rows.Count <= 0)
                {
                    this.RenderEmptyContent(writer);
                }
                else
                {
                    base.Render(writer);
                }
                sbl = new StringBuilderli();
                sbl.Append("      </div>");
                sbl.Append("    </div>");
                sbl.Append("    <!--grid-body-->");
                sbl.Append("  </div>");
                sbl.Append("  <!--grid-view-->");
                sbl.Append("</div>");
                writer.Write(sbl.ToString());
            }
        }
        public class RedContainer : Literal, INamingContainer
        {
            private object dataItem;

            public object DataItem
            {
                get { return this.dataItem; }
            }

            public RedContainer(object dataItem)
            {
                this.dataItem = dataItem;
            }
        }
        [DefaultValue("100%"), Bindable(true), Category("Scroll")]
        public string ScrollWidth
        {
            get
            {
                return this.ViewState["ScrollWidth"] == null ? "100%" : this.ViewState["ScrollWidth"].ToString();
            }
            set { this.ViewState["ScrollWidth"] = value; }
        }
        [DefaultValue(true), Bindable(true), Category("Scroll")]
        public bool Scroll_X_Show
        {
            get
            {
                return this.ViewState["Scroll_X_Show"] == null ? true : (bool)this.ViewState["Scroll_X_Show"];
            }
            set { this.ViewState["Scroll_X_Show"] = value; }
        }
        [DefaultValue("100%"), Bindable(true), Category("Scroll")]
        public string ScrollHeight
        {
            get
            {
                return this.ViewState["ScrollHeight"] == null ? "100%" : this.ViewState["ScrollHeight"].ToString();
            }
            set { this.ViewState["ScrollHeight"] = value; }
        }
        [DefaultValue(true), Bindable(true), Category("Scroll")]
        public bool Scroll_Y_Show
        {
            get
            {
                return this.ViewState["Scroll_Y_Show"] == null ? true : (bool)this.ViewState["Scroll_Y_Show"];
            }
            set { this.ViewState["Scroll_Y_Show"] = value; }
        }
        protected virtual void RenderEmptyContent(HtmlTextWriter writer)
        {
            if (!base.DesignMode)
            {
                StringBuilder table = new StringBuilder();
                table.Append(" <table width=\"" + base.Width.ToString() + "\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"  style=\"table-layout:fixed; border-collapse:collapse;border:1px #CCCCCC double;\" class=\"grid-empty\">");
                table.Append(" <tr style='padding:2px;'>");
                for (int i = 0; i < base.Columns.Count; i++)
                {
                    if (base.Columns[i].Visible)
                    {
                        table.Append(" <td width='" + base.Columns[i].ItemStyle.Width.ToString() + "' style='border-right:1px #ffffff solid'>&nbsp;</td>");
                    }
                }
                table.Append(" </tr>");
                int num = 0;
                for (int i = 0; i < base.Columns.Count; i++)
                {
                    if (base.Columns[i].Visible)
                    {
                        num++;
                    }
                }
                table.Append(" <tr style='padding:2px;'>");
                string strEmpty = WebSource.GetControlsResourceUrl("GridView.Empty.png", this.Page);
                table.Append(" <td colspan='" + num + "' style='text-indent:15px'><img src='" + strEmpty + "'/>" + this.EmptyDataText + "</td>");
                table.Append(" </tr>");
                table.Append(" <tr style='padding:2px;'>");
                for (int i = 0; i < base.Columns.Count; i++)
                {
                    if (base.Columns[i].Visible)
                    {
                        table.Append(" <td width='" + base.Columns[i].ItemStyle.Width.ToString() + "' style='border-right:1px #ffffff solid'>&nbsp;</td>");
                    }
                }
                table.Append(" </tr>");
                table.Append(" </table>");
                new LiteralControl(table.ToString()).RenderControl(writer);
            }
        }
        #endregion
    }
}
