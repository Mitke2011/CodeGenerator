<%@ Page MasterPageFile="~/Site.Master" Title="Konfiguracija" Language="C#" AutoEventWireup="true"
    CodeBehind="ProizvodEditDemo.aspx.cs" Inherits="TemplateWebApplication.ProizvodEditDemo" %>

<asp:Content ID="HeaderPlaceholder" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyPlaceholder" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        //        function is_int(args) {
        //            if ((parseFloat(args) == parseInt(args)) && !isNaN(args)) {
        //                return true;
        //            } else {
        //                return false;
        //            }
        //        }

        //        function is_int(args) {
        //            var intRegex = /^\d+$/;
        //            if (intRegex.test(document.getElementById("<%=txtKolicina.ClientID %>").value)) {
        //                return args.isVa= true;
        //            }
        //            else return false;
        //        }

        function is_int(source, argument) {
            var val1 = $.trim(arguments.Value.toLowerCase());
            var intRegex = /^\d+$/;
            argument.IsValid = intRegex.test(val1);
        }
    </script>
    <table>
        <asp:HiddenField ID="hdnID" runat="server" />
        <tr>
            <td>
                <asp:Label runat="server" Text="Naziv" />
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtNaziv" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" Text="Kolicina" />
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtKolicina" />
                <asp:CustomValidator ID="CustomValidatortxtKolicina" runat="server" ClientValidationFunction="is_int"
                    ControlToValidate="txtKolicina" EnableClientScript="True" Text="Input could not be parsed to integer number!!!"
                    Display="Dynamic">
          </asp:CustomValidator>
            </td>
            <td>
                <asp:Button runat="server" ID="bnt1" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button runat="server" ID="btnSave" Text="Save" />
            </td>
        </tr>
    </table>
</asp:Content>
