<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Panter.Modules.PageIcon.Views.View" %>
<%@ Register TagPrefix="dnnweb" Namespace="DotNetNuke.Web.UI.WebControls.Internal" Assembly="DotNetNuke.Web" %>
<%@ Register TagPrefix="dnn" TagName="URL" Src="~/controls/DnnUrlControl.ascx" %>

<div>
    <div class="dnnFormItem">
        <div class="dnnLabel">Page</div>
        <div class="dnnFileUploadScope">
            <dnnweb:DnnComboBox ID="cboTab" DataTextField="IndentedTabName" DataValueField="TabId" runat="server" Width="400px" OnSelectedIndexChanged="cboTab_SelectedIndexChanged" AutoPostBack="true" />
        </div>
    </div>
    <div class="dnnFormItem">
        <div class="dnnLabel">Icon File Large</div>
        <div class="dnnFileUploadScope">
            <dnn:url runat="server" id="IconUrlLarge" showimages="true" ShowUrls="False" showtabs="False" ShowLog="False" ShowTrack="False" ShowNone="False" />
        </div>
    </div>    
    <div class="dnnFormItem">
        <div class="dnnLabel">Icon File</div>
        <div class="dnnFileUploadScope">
            <dnn:url runat="server" id="IconUrl" showimages="true" ShowUrls="False" showtabs="False" ShowLog="False" ShowTrack="False" ShowNone="False" />
        </div>
    </div>
    <div class="dnnFormItem">
        <asp:LinkButton ID="btnSubmit" runat="server" OnClick="SaveButtonClick" CssClass="dnnPrimaryAction" Text="Guardar" />
    </div>
</div>