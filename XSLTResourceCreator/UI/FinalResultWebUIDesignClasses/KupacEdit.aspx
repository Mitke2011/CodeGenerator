
    <%@ Page MasterPageFile="~/Site.Master" Title="Konfiguracija" Language="C#"
    AutoEventWireup="true" CodeBehind="KupacEdit.aspx.cs"  Inherits="WebUI.KupacEdit" %>
  
    <asp:Content ID="HeaderPlaceholder" ContentPlaceHolderID="HeadContent" runat="server">
    </asp:Content >
  
    <asp:Content ID="BodyPlaceholder" ContentPlaceHolderID="MainContent" runat="server">
    <table>
      <asp:HiddenField ID="hdnID" runat="server" />
    
      <tr>
      <td>
      <asp:Label runat="server" Text="Ime" />
      </td>
      <td>
      
          <asp:TextBox runat="server" ID="txtIme"/>
        
      </td>
      </tr>
        <tr>
        
        </tr>
    
      <tr>
      <td>
      <asp:Label runat="server" Text="Prezime" />
      </td>
      <td>
      
          <asp:TextBox runat="server" ID="txtPrezime"/>
        
      </td>
      </tr>
        <tr>
        
        </tr>
    
      <tr>
      <td>
      <asp:Label runat="server" Text="BrojTelefona" />
      </td>
      <td>
      
          <asp:TextBox runat="server" ID="txtBrojTelefona"/>
        
      </td>
      </tr>
        <tr>
        
        </tr>
    
      <tr>
      <td>
      <asp:Label runat="server" Text="Adresa" />
      </td>
      <td>
      
          <asp:TextBox runat="server" ID="txtAdresa"/>
        
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
  