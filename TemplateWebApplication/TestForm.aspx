<%@ Page EnableViewState="false" Language="C#" Title="TestForm" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="TestForm.aspx.cs" Inherits="TemplateWebApplication.TestForm" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to ASP.NET!
    </h2>
    <asp:HiddenField ID="hdnID" runat="server" />
    <asp:TextBox runat="server" ID="txtValidator"></asp:TextBox>
    <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_OnRowCommand">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" CausesValidation="false" CommandName="SendMail"
                        Text="SendMail" CommandArgument='<%# ((GridViewRow)Container).RowIndex %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button runat="server" ID="btnReload" Text="Reload page" OnClick="Page_Load"/>
</asp:Content>
