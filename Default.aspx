<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tensho.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tensho Demo</title>
    <link type="text/css" href="DemoStyles.css?version=7" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <p class="clsPageTitle">Welcome to Tenshō</p>
        <p>Tenshō is a contact tracing service in the blockchain. It provides privacy by design to contact tracing app developers, and joins contact tracing apps in the blockchain to provide a global footprint. </a></p>
<%--        <a href='http://blockchain.carbonfx.com/Extract.aspx?guid=9362fc33-720d-438d-a461-8741626a9044'>9362fc33-720d-438d-a461-8741626a9044</a>--%>
            <div>
            <table cellpadding="10" cellspacing="0">
                <tr>
                    <td>
                        <table cellpadding="20" cellspacing="0" style="border-style: none; background-position: center center; width: 350px; height: 700px; background-image: url('Device.png'); background-repeat: no-repeat; background-attachment: inherit;">
                            <tr>
                                <td style="text-align: center; ">
                                    <asp:Button ID="ButtonRegisterA" runat="server" CssClass="clsButton" Text="Register" Width="100%" OnClick="ButtonRegisterA_Click" />
                                    <p><asp:Label ID="LabelGUIDA" runat="server"></asp:Label></p>
                                    <asp:Button ID="ButtonDiagnoseA" runat="server" CssClass="clsOrangeButton" Text="Now Diagnose" Width="100%" OnClick="ButtonDiagnoseA_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <asp:Button ID="ButtonMeet" runat="server" CssClass="clsButton" Text="Now Make Contact" OnClick="ButtonMeet_Click" />
                    </td>
                    <td>
                        <table cellpadding="20" cellspacing="0" style="border-style: none; background-position: center center; width: 350px; height: 700px; background-image: url('Device.png'); background-repeat: no-repeat; background-attachment: inherit;">
                            <tr>
                                <td style="text-align: center">
                                    <asp:Button ID="ButtonRegisterB" runat="server" CssClass="clsButton" Text="Register" Width="100%" OnClick="ButtonRegisterB_Click" />
                                    <p>
                                        <asp:Label ID="LabelGUIDB" runat="server"></asp:Label></p>
                                    <asp:Button ID="ButtonDiagnoseB" runat="server" CssClass="clsOrangeButton" Text="Now Diagnose" Width="100%" OnClick="ButtonDiagnoseB_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <p>
                <asp:Label ID="LabelInstructions" runat="server"></asp:Label>
            </p>
            <table>
                <tr>
                    <td>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Logo.png" /></td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
