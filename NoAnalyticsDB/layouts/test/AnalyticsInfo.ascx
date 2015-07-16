<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AnalyticsInfo.ascx.cs" Inherits="NoAnalyticsDB.layouts.test.AnalyticsInfo" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<h1>Profile information</h1>
<asp:Repeater runat="server" ItemType="Sitecore.Analytics.Tracking.Profile" SelectMethod="GetData">

    <ItemTemplate>
        
        <strong>    <%#: Item.ProfileName %>: </strong> <%#: Item.PatternLabel %> <br />
        
    </ItemTemplate>
</asp:Repeater>