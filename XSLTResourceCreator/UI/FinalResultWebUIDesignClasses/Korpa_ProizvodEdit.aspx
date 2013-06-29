
    <%@ Page MasterPageFile="~/Site.Master" Title="Konfiguracija" Language="C#"
    AutoEventWireup="true" CodeBehind="Korpa_ProizvodEdit.aspx.cs"  Inherits="WebUI.Korpa_ProizvodEdit" %>
  
    <asp:Content ID="HeaderPlaceholder" ContentPlaceHolderID="HeadContent" runat="server">
    </asp:Content >
  
    <asp:Content ID="BodyPlaceholder" ContentPlaceHolderID="MainContent" runat="server">
    <table>
      <asp:HiddenField ID="hdnID" runat="server" />
    
      <tr>
      <td>
      <asp:Label runat="server" Text="SifraProizvoda" />
      </td>
      <td>
      
          <asp:TextBox runat="server" ID="cboSifraProizvoda"/>
        
          <asp:DropDownList runat="server" ID="cboSifraProizvoda"></asp:DropDownList>
        
      </td>
      </tr>
        <tr>
        
        </tr>
    
      <tr>
      <td>
      <asp:Label runat="server" Text="SifraKorpe" />
      </td>
      <td>
      
          <asp:TextBox runat="server" ID="cboSifraKorpe"/>
        
          <asp:DropDownList runat="server" ID="cboSifraKorpe"></asp:DropDownList>
        
      </td>
      </tr>
        <tr>
        
        </tr>
    
      <tr>
      <td>
      <asp:Label runat="server" Text="Datum_Kupovine" />
      </td>
      <td>
      
          <asp:TextBox runat="server" ID="dtpDatum_Kupovine"/>
        
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
  