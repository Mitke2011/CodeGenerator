
    <%@ Page MasterPageFile="~/Site.Master" Title="Konfiguracija" Language="C#"
    AutoEventWireup="true" CodeBehind="ProizvodEdit.aspx.cs"  Inherits="TemplateWebApplication.ProizvodEdit" %>
  
    <asp:Content ID="HeaderPlaceholder" ContentPlaceHolderID="HeadContent" runat="server">
    </asp:Content >
  
    <asp:Content ID="BodyPlaceholder" ContentPlaceHolderID="MainContent" runat="server">
    <table>
      <asp:HiddenField ID="hdnID" runat="server" />
    
      <tr>
      <td>
      <asp:Label runat="server" Text="Naziv" />
      </td>
      <td>
      
          <asp:TextBox runat="server" ID="txtNaziv"/>
        
      </td>
      </tr>
        <tr>
        
        </tr>
    
      <tr>
      <td>
      <asp:Label runat="server" Text="Kolicina" />
      </td>
      <td>
      
          <asp:TextBox runat="server" ID="txtKolicina"/>
          
        
      </td>
      </tr>
        <tr>
        
        </tr>
    
      <asp:Button runat="server" ID="btnSave" Text="Save" OnClick="SaveButtonEvent"/>
      <asp:Button runat="server" ID="btnDelete" Text="Delete" OnClick="DeleteButton"/>
  
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="ProizvodList.aspx">HyperLink</asp:HyperLink>
    </table>
    </asp:Content>
  