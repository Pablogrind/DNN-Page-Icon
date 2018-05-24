/*
' Copyright (c) 2014 Panter
' http://www.panter.co
' All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/
using System;
using System.Collections.Generic;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;

using Panter.Modules.PageIcon.Models;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Tabs;
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.FileSystem;

namespace Panter.Modules.PageIcon.Views
{
    public partial class View : PortalModuleBase
    {
        private int _moduleId = -1;
        private ModuleInfo _module;
        private ModuleInfo Module
        {
            get { return _module ?? (_module = ModuleController.Instance.GetModule(_moduleId, TabId, false)); }
        }

        public PortalSettings PortalSettings
        {
            get
            {
                return PortalController.Instance.GetCurrentPortalSettings();
            }
        }

        public int PortalId
        {
            get
            {
                return ModuleContext.PortalId;
            }
        }

        public int TabId
        {
            get
            {
                return ModuleContext.TabId;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    IconUrlLarge.FileFilter = Globals.glbImageFileTypes;
                    IconUrl.FileFilter = Globals.glbImageFileTypes;

                    if ((Request.QueryString["ModuleId"] != null))
                    {
                        _moduleId = Int32.Parse(Request.QueryString["ModuleId"]);
                    }

                    cboTab.DataSource = TabController.GetPortalTabs(PortalId, -1, false, Null.NullString, true, false, true, false, true);
                    cboTab.DataBind();

                    //if tab is a  host tab, then add current tab
                    if (Globals.IsHostTab(PortalSettings.ActiveTab.TabID))
                    {
                        cboTab.InsertItem(0, PortalSettings.ActiveTab.LocalizedTabName, PortalSettings.ActiveTab.TabID.ToString());
                    }
                    if (Module != null)
                    {
                        if (cboTab.FindItemByValue(Module.TabID.ToString()) == null)
                        {
                            var objTab = TabController.Instance.GetTab(Module.TabID, Module.PortalID, false);
                            cboTab.AddItem(objTab.LocalizedTabName, objTab.TabID.ToString());
                        }
                    }
                }
            }
            catch (Exception exc) 
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }           
        }

        protected void cboTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabController tabController = new TabController();
            TabInfo controller = TabController.Instance.GetTab(int.Parse(cboTab.SelectedValue), PortalId);

            if (!string.IsNullOrEmpty(controller.IconFileLargeRaw))
            {
                var file = FileManager.Instance.GetFile(controller.PortalID, controller.IconFileLargeRaw);
                if (file != null)
                    IconUrlLarge.Url = "FileID=" + file.FileId.ToString();
                else
                    IconUrlLarge.Url = string.Empty;
            }
            else
            {
                IconUrlLarge.Url = string.Empty;
            }

            if (!string.IsNullOrEmpty(controller.IconFileRaw))
            {
                var file = FileManager.Instance.GetFile(controller.PortalID, controller.IconFileRaw);
                if (file != null)
                    IconUrl.Url = "FileID=" + file.FileId.ToString();
                else
                        IconUrl.Url = string.Empty;
                }
            else
            {
                IconUrl.Url = string.Empty;
            }
        }

        public void SaveButtonClick(object sender, EventArgs e)
        {
            TabController tabController = new TabController();
            TabInfo controller = TabController.Instance.GetTab(int.Parse(cboTab.SelectedValue), PortalId);
            if (controller != null)
            {
                controller.IconFileLarge = IconUrlLarge.Url;
                controller.IconFile = IconUrl.Url;
            }

            tabController.UpdateTab(controller);
        }
    }
}