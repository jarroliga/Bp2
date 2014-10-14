<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ErrorList.ascx.cs" Inherits="BP.Controls.ErrorList" %>
<asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate>
        <ul class="failureNotification">
    </HeaderTemplate>
    <ItemTemplate>
        <li><asp:Literal ID="lblErrorMessage" runat="server" Text='<%# Eval("Message") %>'></asp:Literal></li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>