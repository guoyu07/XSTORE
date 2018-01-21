using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;
using System.Text;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Web.UI.HtmlControls;
using System.Data;
[assembly: TagPrefix("FeliControls", "x-store")]
namespace Ahomet.Web.Controls
{
    public enum PagerInfo
    {
        All,
        Easy
    }
    [DefaultProperty("Text"), ToolboxData("<{0}:Pager runat=\"server\"></{0}:Pager>")]
    public class Pager : CompositeControl
    {
        private static readonly object EventSubmitKey = new object();
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        //实现事件属性结构 
        public event EventHandler SubPager
        {
            add { Events.AddHandler(EventSubmitKey, value); }
            remove { Events.RemoveHandler(EventSubmitKey, value); }
        }
        //实现OnSubmit 
        protected virtual void OnSubPager(EventArgs e)
        {
            EventHandler SubmitHandler = (EventHandler)Events[EventSubmitKey];
            if (SubmitHandler != null)
            {
                SubmitHandler(this, e);
            }
        }
        //当前页码
        [DefaultValue(""), Bindable(true), Category("Pager")]
        public int PageIndex
        {
            set { this.ViewState["PageIndex"] = value; }
            get
            {
                object obj = this.ViewState["PageIndex"];
                int num = 1;
                if (obj != null)
                {
                    num = (int)obj;
                    if (num > this.PageCount)
                    {
                        num = this.PageCount;
                    }
                }
                return num;
            }
        }
        //总分页
        [DefaultValue(""), Bindable(true), Category("Pager")]
        public int PageCount
        {
            set { this.ViewState["PageCount"] = value; }
            get
            {
                object obj = this.ViewState["PageCount"];
                int num = 1;
                if (obj != null)
                {
                    num = (int)obj;
                }
                return num;
            }
        }
        //分页大小
        [DefaultValue(""), Bindable(true), Category("Pager")]
        public int PageSize
        {
            set { this.ViewState["PageSize"] = value; }
            get
            {
                object obj = this.ViewState["PageSize"];
                int num = 1;
                if (obj != null)
                {
                    num = (int)obj;
                }
                return num;
            }
        }
        //记录总数
        [DefaultValue(""), Bindable(true), Category("Pager")]
        public int RecordCount
        {
            set { this.ViewState["RecordCount"] = value; }
            get
            {
                object obj = this.ViewState["RecordCount"];
                int num = 1;
                if (obj != null)
                {
                    num = (int)obj;
                }
                return num;
            }
        }
        //是否显示数字分页
        [DefaultValue(true), Bindable(true), Category("Pager")]
        public bool ShowNumberPage
        {
            set { this.ViewState["ShowNumberPage"] = value; }
            get
            {
                object obj = this.ViewState["ShowNumberPage"];
                bool flag = true;
                if (obj != null)
                {
                    flag = (bool)obj;
                }
                return flag;
            }
        }
        //是否显示首页与尾页
        [DefaultValue(true), Bindable(true), Category("Pager")]
        public bool ShowFirstLast
        {
            set { this.ViewState["ShowFirstLast"] = value; }
            get
            {
                object obj = this.ViewState["ShowFirstLast"];
                bool flag = true;
                if (obj != null)
                {
                    flag = (bool)obj;
                }
                return flag;
            }
        }
        //是否显示全部信息
        [DefaultValue(true), Bindable(true), Category("Pager")]
        public PagerInfo ShowPagerInfo
        {
            set { this.ViewState["ShowPagerInfo"] = value; }
            get
            {
                object obj = this.ViewState["ShowPagerInfo"];
                PagerInfo flag = PagerInfo.All;
                if (obj != null)
                {
                    flag = (PagerInfo)Enum.Parse(typeof(PagerInfo), obj.ToString());
                }
                return flag;
            }
        }
        //Text
        [DefaultValue(""), Bindable(true), Category("Pager")]
        public string PagesText
        {
            set { this.ViewState["PagesText"] = value; }
            get
            {
                object obj = this.ViewState["PagesText"];
                string temp = "";
                if (ShowPagerInfo == PagerInfo.All)
                {
                    temp = "首页|上一页|下一页|末页|页次：{0}/{1} 页 {2} 条记录/页  共{3} 条记录";
                }
                else
                {
                    temp = "首页|上一页|下一页|末页|页次：{0}/{1} 页";
                }
                if (obj != null)
                {
                    temp = (string)obj;
                }
                return temp;
            }
        }
        protected override void Render(HtmlTextWriter output)
        {
            CreateChildControls();
            base.Render(output);
        }
        protected override void CreateChildControls()
        {
            Controls.Clear();
            ClearChildViewState();
            this.BuildControlHierarchy();
        }
        private void BuildControlHierarchy()
        {
            HtmlGenericControl html = new HtmlGenericControl();
            PagerNet(html);
            Controls.Add(html);
        }
        private void PagerNet(HtmlGenericControl cell)
        {
            int totalCount = this.RecordCount;
            int pageSize = this.PageSize;
            int pageIndex = this.PageIndex;
            int centSize = 8;

            //计算页数
            if (totalCount < 1 || pageSize < 1)
            {
                return;
            }
            int pageCount = totalCount / pageSize;
            if (pageCount < 1)
            {
                return;
            }
            if (totalCount % pageSize > 0)
            {
                pageCount += 1;
            }
            if (pageCount <= 1)
            {
                return;
            }
            this.PageCount = pageCount;

            //首页
            LinkButton first = new LinkButton();
            first.ID = "First";
            first.Click += new EventHandler(first_Click);
            first.Text = PagesText.Split('|')[0];
            first.Visible = this.ShowFirstLast;
            cell.Controls.Add(first);
            //上一页
            LinkButton prev = new LinkButton();
            prev.ID = "Prev";
            prev.Click += new EventHandler(prev_Click);
            prev.Text = PagesText.Split('|')[1];
            cell.Controls.Add(prev);

            //页码
            if (this.ShowNumberPage)
            {
                int firstNum = pageIndex - (centSize / 2); //中间开始的页码
                if (pageIndex < centSize)
                    firstNum = 1; //firstNum = 2;
                int lastNum = pageIndex + centSize - ((centSize / 2) + 1); //中间结束的页码
                if (lastNum >= pageCount)
                    lastNum = pageCount; //pageCount - 1;

                if (pageIndex >= centSize)
                {
                    cell.Controls.Add(new LiteralControl("..."));
                }

                int NumSize = (lastNum - firstNum) + 1;
                if (NumSize > 0)
                {
                    LinkButton[] Pages = new LinkButton[NumSize];
                    int index = 0;
                    for (int i = firstNum; i <= lastNum; i++)
                    {
                        Pages[index] = new LinkButton();
                        Pages[index].CssClass = "in";
                        if (i == pageIndex) Pages[index].CssClass = "on";

                        Pages[index].Text = i.ToString();
                        Pages[index].ID = "P" + i.ToString();
                        Pages[index].Click += new EventHandler(LinkPageList_Click);
                        Pages[index].CommandArgument = i.ToString();
                        cell.Controls.Add(Pages[index]);
                        index++;
                    }
                }

                if (pageCount - pageIndex > centSize - ((centSize / 2)))
                {
                    cell.Controls.Add(new LiteralControl("..."));
                }
            }

            //下一页
            LinkButton next = new LinkButton();
            next.ID = "Next";
            next.Click += new EventHandler(next_Click);
            next.Text = PagesText.Split('|')[2];
            cell.Controls.Add(next);

            //末页
            LinkButton last = new LinkButton();
            last.ID = "Last";
            last.Click += new EventHandler(last_Click);
            last.Text = PagesText.Split('|')[3];
            last.Visible = this.ShowFirstLast;
            cell.Controls.Add(last);

            //状态
            first.Enabled = pageIndex != 1;
            prev.Enabled = pageIndex != 1;
            next.Enabled = pageIndex != pageCount;
            last.Enabled = pageIndex != pageCount;

            first.CssClass = pageIndex != 1 ? "in" : "off";
            prev.CssClass = pageIndex != 1 ? "in" : "off";
            next.CssClass = pageIndex != pageCount ? "in" : "off";
            last.CssClass = pageIndex != pageCount ? "in" : "off";


            cell.Controls.Add(new LiteralControl("&nbsp;"));
            cell.Controls.Add(new LiteralControl("&nbsp;"));

            //当前页和总页码   
            Literal li = new Literal();
            string str = "";
            switch (ShowPagerInfo)
            {
                case PagerInfo.All:
                    str = string.Format(PagesText.Split('|')[4], this.PageIndex.ToString(), this.PageCount.ToString(), this.PageSize.ToString(), this.RecordCount.ToString());
                    li.Text = str;
                    cell.Controls.Add(li);
                    break;
                case PagerInfo.Easy:
                    str = string.Format(PagesText.Split('|')[4], this.PageIndex.ToString(), this.PageCount.ToString(), this.PageSize.ToString(), this.RecordCount.ToString());
                    li.Text = str;
                    cell.Controls.Add(li);
                    break;
            }
            cell.Controls.Add(new LiteralControl("&nbsp;"));
        }
        private void first_Click(object sender, EventArgs e)
        {
            this.PageIndex = 1;
            OnSubPager(EventArgs.Empty);
        }
        private void prev_Click(object sender, EventArgs e)
        {
            this.PageIndex = this.PageIndex - 1 <= 0 ? 1 : this.PageIndex - 1;
            OnSubPager(EventArgs.Empty);
        }
        private void next_Click(object sender, EventArgs e)
        {
            this.PageIndex = this.PageIndex + 1;
            OnSubPager(EventArgs.Empty);
        }
        private void last_Click(object sender, EventArgs e)
        {
            this.PageIndex = this.PageCount;
            OnSubPager(EventArgs.Empty);
        }
        private void LinkPageList_Click(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(LinkButton))
            {
                LinkButton myLk = (LinkButton)sender;
                this.PageIndex = Convert.ToInt32(myLk.CommandArgument);
                OnSubPager(EventArgs.Empty);
            }
        }
        private void DropPageList_Click(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(DropDownList))
            {
                DropDownList myDp = (DropDownList)sender;
                this.PageIndex = Convert.ToInt32(myDp.Text.ToString().Trim());
                OnSubPager(EventArgs.Empty);
            }
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }
        protected override void RenderContents(HtmlTextWriter writer)
        {
            base.RenderContents(writer);
        }
    }
}
