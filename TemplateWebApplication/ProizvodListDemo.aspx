<%@ Page MasterPageFile="~/Site.Master" Title="Konfiguracija" Language="C#" AutoEventWireup="true"
    EnableViewState="false" CodeBehind="ProizvodListDemo.aspx.cs" Inherits="TemplateWebApplication.ProizvodListDemo" %>

<asp:Content ID="HeaderPlaceholder" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyPlaceholder" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_OnRowCommand" OnRowCreated="GridView1_OnRowCreated">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" CausesValidation="false" CommandName="Edit"
                        Text="Edit" CommandArgument='<%# ((GridViewRow)Container).RowIndex %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="Button2" runat="server" CausesValidation="false" CommandName="Add"
                        Text="Add New" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
