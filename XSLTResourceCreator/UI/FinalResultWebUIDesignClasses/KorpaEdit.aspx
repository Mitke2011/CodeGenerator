
    <%@ Page MasterPageFile="~/Site.Master" Title="Konfiguracija" Language="C#"
    AutoEventWireup="true" CodeBehind="KorpaEdit.aspx.cs"  Inherits="WebUI.KorpaEdit" %>
  
    <asp:Content ID="HeaderPlaceholder" ContentPlaceHolderID="HeadContent" runat="server">
    </asp:Content >
  
    <asp:Content ID="BodyPlaceholder" ContentPlaceHolderID="MainContent" runat="server">
    <table>
      <asp:HiddenField ID="hdnID" runat="server" />
    
      <tr>
      <td>
      <asp:Label runat="server" Text="SifraKupca" />
      </td>
      <td>
      
          <asp:TextBox runat="server" ID="cboSifraKupca"/>
        
          <asp:DropDownList runat="server" ID="cboSifraKupca"></asp:DropDownList>
        
      </td>
      </tr>
        <tr>
        
        </tr>
    
      <tr>
      <td>
      <asp:Label runat="server" Text="Datum" />
      </td>
      <td>
      
          <asp:TextBox runat="server" ID="dtpDatum"/>
        
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
  