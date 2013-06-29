
    <%@ Page MasterPageFile="~/Site.Master" Title="Konfiguracija" Language="C#"
    AutoEventWireup="true" CodeBehind="ProizvodEdit.aspx.cs"  Inherits="WebUI.ProizvodEdit" %>
  
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
    
      <tr>
          <td><asp:Button runat="server" ID="btnSave" Text="Save" OnClick="SaveButtonEvent"/></td>
          <td><asp:Button runat="server" ID="btnDelete" Text="Delete" OnClick="DeleteButton"/></td>
      <td><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="ProizvodList.aspx">Go Back</asp:HyperLink></td>
      </tr>
    </table>
    </asp:Content>
  