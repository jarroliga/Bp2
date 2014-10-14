using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Permissions;

namespace Snip.BP.UI.WebControls
{
    //[DefaultProperty("Text")]
    //[ToolboxData("<{0}:ServerControl1 runat=server></{0}:ServerControl1>")]
    public class GroupingRepeater : System.Web.UI.WebControls.Repeater
    {

        private object previousItem = null;
        private int itemCount = 0;

        public GroupingRepeater()
        {
            this.ItemCreated += new RepeaterItemEventHandler(GroupingRepeater_ItemCreated);
        }

        protected override void AddParsedSubObject(object obj)
        {
            base.AddParsedSubObject(obj);
        }
        
        //private IComparer comparer = null;

        public IComparer Comparer { get; set; }

        //private ITemplate groupHeaderTemplate = null;

        [Browsable(false), 
        PersistenceMode(PersistenceMode.InnerProperty), 
        DefaultValue((string)null), 
        TemplateContainer(typeof(GroupHeader))]
        public ITemplate GroupHeaderTemplate { get; set; }

        [Browsable(false), 
        PersistenceMode(PersistenceMode.InnerProperty), 
        DefaultValue((string)null), 
        TemplateContainer(typeof(GroupFooter))]
        public ITemplate GroupFooterTemplate { get; set; }

        protected override void CreateChildControls()
        {
            this.previousItem = null;

            IEnumerable enumerable1 = this.GetData();
            ICollection collection1 = enumerable1 as ICollection;

            if (collection1 != null)
            {
                this.itemCount = collection1.Count;
            }

            base.CreateChildControls();
        }

        private void GroupingRepeater_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            if ((GroupHeaderTemplate == null) && (GroupFooterTemplate == null))
            {
                return;
            }
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.Item.DataItem != null)
                {
                    if (Comparer == null)
                    {
                        if (e.Item.DataItem is IComparable)
                        {
                            if ((((IComparable)e.Item.DataItem).CompareTo(this.previousItem) != 0) || (e.Item.ItemIndex == 0))
                            {
                                GroupHeader item = new GroupHeader();
                                GroupHeaderTemplate.InstantiateIn(item);
                                item.DataItem = e.Item.DataItem;

                                if ((previousItem != null) && (GroupFooterTemplate != null))
                                {
                                    GroupFooter footer = new GroupFooter();
                                    GroupFooterTemplate.InstantiateIn(footer);
                                    footer.DataItem = e.Item.DataItem;
                                    item.Controls.AddAt(0, footer);
                                }
                                e.Item.Controls.AddAt(0, item);
                            }
                        }
                    }
                    else
                    {
                        if (Comparer.Compare(previousItem, e.Item.DataItem) != 0)
                        {
                            GroupHeader item = new GroupHeader();
                            GroupHeaderTemplate.InstantiateIn(item);
                            item.DataItem = e.Item.DataItem;

                            if ((previousItem != null) && (GroupFooterTemplate != null))
                            {
                                GroupFooter footer = new GroupFooter();
                                GroupFooterTemplate.InstantiateIn(footer);
                                footer.DataItem = e.Item.DataItem;
                                item.Controls.AddAt(0, footer);
                            }
                            e.Item.Controls.AddAt(0, item);
                        }
                    }
                }
                if( e.Item.ItemIndex == (this.itemCount-1) && (GroupFooterTemplate != null))
                {
                    GroupFooter footer = new GroupFooter();
                    GroupFooterTemplate.InstantiateIn(footer);
                    footer.DataItem = e.Item.DataItem;
                    e.Item.Controls.Add(footer);
                }
                previousItem = e.Item.DataItem;
            }
        }

        [ToolboxItem(false),
            AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal),
            AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
        public class GroupHeader : Control, INamingContainer
        {
            public virtual object DataItem { get; set;}
        }

        [ToolboxItem(false),
            AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal),
            AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
        public class GroupFooter : Control, INamingContainer
        {
            public virtual object DataItem { get; set; }
        }

        //[Bindable(true)]
        //[Category("Appearance")]
        //[DefaultValue("")]
        //[Localizable(true)]
        //public string Text
        //{
        //    get
        //    {
        //        String s = (String)ViewState["Text"];
        //        return ((s == null) ? "[" + this.ID + "]" : s);
        //    }

        //    set
        //    {
        //        ViewState["Text"] = value;
        //    }
        //}
        //protected override void RenderContents(HtmlTextWriter output)
        //{
        //    output.Write(Text);
        //}


    }
}
